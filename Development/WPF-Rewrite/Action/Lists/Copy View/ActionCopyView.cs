using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Specialized;
using System.Drawing;
using System.Diagnostics;

namespace SUSHI
{
    public partial class ActionCopyView : SUSHI.ActionParent
    {
        public static ActionCopyView DefInstance;
        public ActionCopyView()
        {
            InitializeComponent();
        }

        private void ActionBulkSiteCreation_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Copy View";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtTargetSite.Text = GlobalVars.SETTINGS.createViews_siteUrl;

            //--
            ActionCopyViewUtil.LoadFavoriteViews();
            PopulateFavoriteViews();
            foreach (FavoriteView fv in cboFavoriteViews.Items)
                if (GlobalVars.SETTINGS.createViews_defaultFavoriteView == fv.ToString())
                    cboFavoriteViews.SelectedItem = fv;

            showhelp();
        }
        private void showhelp()
        {
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            string s = @"The SUSHI 'Copy View' feature enables you to select an existing view and replicate it to another SharePoint list. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Copy%20View&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        public void PopulateFavoriteViews()
        {
            cboFavoriteViews.Items.Clear();
            foreach (FavoriteView fv in ActionCopyViewUtil.FavoriteViews)
                cboFavoriteViews.Items.Add(fv);
        }

        #region populate SharePoint Lists
        private void btnRetrieveLists_Click(object sender, EventArgs e)
        {
            populateSharePointLists();
        }

        private void populateSharePointLists()
        {
            using (SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage))
            {
                if (web == null)
                    return;
                txtTargetSite.Text = web.Url;

                //--
                Util.PopulateComboboWithSharePointLists(web, cboTargetList, true, chkLimitDocLibs.Checked);
            }
        }
        #endregion

        #region SETTINGS update on Control Events
        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.createViews_siteUrl = txtTargetSite.Text;
        }

        private void cboFavoriteViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFavoriteViews.SelectedItem == null)
                return;
            GlobalVars.SETTINGS.createViews_defaultFavoriteView = cboFavoriteViews.SelectedItem.ToString();
        }
        #endregion

        #region Create View
        private void btnValidate_Click(object sender, EventArgs e)
        {
            createView(true);
        }

        private void btnBulkSiteCreate_Click(object sender, EventArgs e)
        {
            createView(false);
        }

        private void createView(bool onlyValidate)
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                rtbDisplay.Clear();

                //--make sure that a favorite view has been selected and a target list
                if (cboFavoriteViews.SelectedItem == null)
                {
                    AddToRtbLocal("Please select a Favorite View\r\n", StyleType.bodyRed);
                    return;
                }
                if (cboTargetList.SelectedItem == null)
                {
                    AddToRtbLocal("Please select a Target List\r\n", StyleType.bodyRed);
                    return;
                }
                AddToRtbLocal("Copying A View" + Util.V(onlyValidate) + "\r\n", StyleType.titleSeagreen);

                //--initialize
                SPList targetList = (SPList)cboTargetList.SelectedItem;
                FavoriteView fv = (FavoriteView)cboFavoriteViews.SelectedItem;
                SPWeb sourceWeb = targetList.ParentWeb.Site.OpenWeb(fv.ParentWebURL);
                SPView sourceView;
                try
                {
                    sourceView = sourceWeb.GetViewFromUrl(fv.ViewURL);
                }
                catch (Exception ex)
                {
                    AddToRtbLocal("Cannot find source view: \"" + fv.ViewURL + "\" " + ex.Message, StyleType.bodyRed);
                    return;
                }

                //--communicate with user
                AddToRtbLocal("View will be copied from ", StyleType.bodyChocolate); AddToRtbLocal(fv.ParentWebURL + "/" + fv.ViewURL + "\r\n", StyleType.bodyBlue);
                AddToRtbLocal("    to this SharePoint List: ", StyleType.bodyChocolate); AddToRtbLocal(targetList.RootFolder.ServerRelativeUrl, StyleType.bodyBlue);
                AddToRtbLocal(Util.V(onlyValidate) + "\r\n", StyleType.bodyChocolate);

                //--display details about view
                AddToRtbLocal("Source View Details\r\n", StyleType.bodyChocolateBold);
                string ags = Util.ToStr(sourceView.Aggregations);
                ags = (ags == "") ? "(none)" : ags;
                AddToRtbLocal("    Totals: " + ags + "\r\n", StyleType.bodyChocolate);

                string inFolders = sourceView.Scope.ToString();
                inFolders = inFolders.Replace("Default", "yes");
                inFolders = inFolders.Replace("Recursive", "no");
                AddToRtbLocal("    Show Items in Folders: " + inFolders + "\r\n", StyleType.bodyChocolate);

                AddToRtbLocal("    Item Limit: " + sourceView.RowLimit, StyleType.bodyChocolate);
                AddToRtbLocal((sourceView.Paged ? " (paging turned on)" : " (paging turned off)") + "\r\n", StyleType.bodyChocolate);

                //--check if view already exists, if it does delete it
                bool viewAlreadyExistsInTargetList = false;
                foreach (SPView view in targetList.Views)
                {
                    if (view.Title == sourceView.Title)
                    {
                        viewAlreadyExistsInTargetList = true;
                        if (!onlyValidate)
                            targetList.Views.Delete(view.ID);
                        break;
                    }
                }

                if (viewAlreadyExistsInTargetList)
                {
                    AddToRtbLocal("Note: ", StyleType.bodyChocolateBold);
                    AddToRtbLocal("View already exists in target library, deleting and recreating" + Util.V(onlyValidate) + "\r\n", StyleType.bodyChocolate);
                }

                //--verify that target library has all the fields needed in View.
                List<SourceViewField> sourceViewFields = new List<SourceViewField>();
                foreach (string viewFieldName in sourceView.ViewFields)
                    sourceViewFields.Add(new SourceViewField(viewFieldName));
                if (!VerifyAllViewFieldsFoundInTargetList(targetList, sourceViewFields))
                {
                    //if (!onlyValidate)
                    //{
                    //    DialogResult ret = MessageBox.Show(this, "Not all view fields exist in target list, would you like to create the view anyway?", "SUSHI - Copy a View", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    //    if (ret == DialogResult.No)
                    //        return;
                    //}
                    AddToRtbLocal("Note: ", StyleType.bodyChocolateBold);
                    AddToRtbLocal("Not all fields exist in target List, only fields from the source view that exist in the target list will be included in the new view.\r\n", StyleType.bodyChocolate);
                }


                //--copy view into target list
                if (!onlyValidate)
                {
                    SPView newView = targetList.Views.Add(sourceView.Title, ToStringCol(sourceViewFields), sourceView.Query, sourceView.RowLimit, sourceView.Paged, true);
                    newView.Aggregations = sourceView.Aggregations;
                    newView.AggregationsStatus = sourceView.AggregationsStatus;
                    newView.Scope = sourceView.Scope;
                    newView.Update();
                    AddToRtbLocal("View created successfully.\r\n", StyleType.titleSeagreen);
                    SmartStepUtil.ScrollToBottom(rtbDisplay);
                }
            }
            catch (Eh.CancelException)
            {
                AddToRtbLocal("cancelled by user\r\n", StyleType.bodyRed);
            }
            catch (Exception ex)
            {
                AddToRtbLocal("error: " + ex.Message + "\r\n", StyleType.bodyRed);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false);
                MainForm.DefInstance.Cursor = Cursors.Default;
            }
        }

        private class SourceViewField
        {
            public SourceViewField(string viewFieldName)
            {
                this.ViewFieldName = viewFieldName;
            }
            public string ViewFieldName;
            public bool Found;
        }

        private bool VerifyAllViewFieldsFoundInTargetList(SPList targetList, List<SourceViewField> sourceViewFields)
        {
            foreach (SourceViewField svf in sourceViewFields)
            {
                svf.Found = false;
                foreach (SPField field in targetList.Fields)
                {
                    if (field.InternalName == svf.ViewFieldName)
                    {
                        svf.Found = true;
                        break;
                    }
                    //-- sometimes SharePoint adds a "0" to the end of the field and this is the field we are looking for
                    else if (field.InternalName == svf.ViewFieldName + "0")
                    {
                        svf.ViewFieldName = svf.ViewFieldName + "0";
                        AddToRtbLocal("Appending zero to field name: \"" + svf.ViewFieldName + "\"\r\n", StyleType.bodyChocolateBold);
                        svf.Found = true;
                        break;
                    }
                }
            }

            bool allFound = true;
            AddToRtbLocal("Checking that all Fields of source view found in target SharePoint List.\r\n", StyleType.bodyChocolateBold);
            foreach (SourceViewField ff in sourceViewFields)
            {
                if (!ff.Found)
                {
                    allFound = false;
                    AddToRtbLocal("\"" + ff.ViewFieldName + "\" not found\r\n", StyleType.bodyRed);
                }
                else
                    AddToRtbLocal("\"" + ff.ViewFieldName + "\" found\r\n", StyleType.bodyBlack);
            }
            return allFound;
        }

        private StringCollection ToStringCol(List<SourceViewField> fl)
        {
            StringCollection sCol = new StringCollection();
            foreach (SourceViewField ff in fl)
            {
                if (ff.Found)
                    sCol.Add(ff.ViewFieldName);
            }
            return sCol;
        }
        #endregion

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        #region Add or Remove Favorite View
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ActionCopyView_AddFavorite.ShowForm();
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboFavoriteViews.SelectedItem == null)
                return;
            FavoriteView fv = (FavoriteView)cboFavoriteViews.SelectedItem;
            ActionCopyViewUtil.FavoriteViews.Remove(fv);
            ActionCopyViewUtil.SaveFavoriteViews();

            ActionCopyView.DefInstance.PopulateFavoriteViews();
        }
        #endregion

        

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void imgBrowse_Click(object sender, EventArgs e)
        {
            if (cboTargetList.SelectedItem == null)
                return;
            SPList list = (SPList)cboTargetList.SelectedItem;
            string url = list.ParentWeb.Url + "/" + list.DefaultView.Url;
            Util.OpenURLinDefaultBrowser(url, rtbDisplay);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

      

       

    }
}

