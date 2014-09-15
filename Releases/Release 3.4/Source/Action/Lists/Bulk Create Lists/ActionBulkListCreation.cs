using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.Navigation;
using System.Diagnostics;
//using System.Xml;

namespace SushiNS
{
    public partial class ActionBulkListCreation : SushiNS.ActionParent
    {
        public static ActionBulkListCreation DefInstance;

        public ActionBulkListCreation()
        {
            InitializeComponent();
        }

        private void ActionBulkSiteCreation_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Bulk List Creation";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtTargetSite.Text = GlobalVars.SETTINGS.bulkListCreate_siteUrl;
            ToolTip t = new ToolTip();
            t.SetToolTip(lnkOpenSiteManager, "Open Site Manager to view existing lists, delete existing lists, view settings, etc.");
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            string s = @"This feature allows you to bulk create SharePoint Lists.If you want to create many document libraries, or other lists, this feature of SUSHI will be quite helpful to you. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Bulk%20List%20Creation&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        #region populateListTemplates
        private void btnRetrieveTemplates_Click(object sender, EventArgs e)
        {
            populateListTemplates();
        }

        private void populateListTemplates()
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                rtbDisplay.Clear();

                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
                if (web == null)
                    return;
                txtTargetSite.Text = web.Url;

                SPListTemplateCollection templates;
                //if (chkOnlyCustomTemplates.Checked)
                templates = web.Site.GetCustomListTemplates(web);
                //else
                //    templates = 

                string rememberSelected = null;
                rememberSelected = cboListTemplates.SelectedItem == null ? null : cboListTemplates.SelectedItem.ToString();
                cboListTemplates.Items.Clear();
                foreach (SPListTemplate template in templates)
                    cboListTemplates.Items.Add(new TemplateHolderForList(template));

                if (rememberSelected == null)
                    cboListTemplates.SelectedIndex = cboListTemplates.FindStringExact(GlobalVars.SETTINGS.bulkListCreate_siteTemplate);
                else
                    cboListTemplates.SelectedIndex = cboListTemplates.FindStringExact(rememberSelected);

                if (templates.Count == 0)
                    AddToRtbLocal("No Custom List Templates found in site collection\r\n", StyleType.bodyBlack);
                else
                {
                    AddToRtbLocal(templates.Count + " custom List Templates found\r\n", StyleType.bodyBlack);
                    cboListTemplates.DroppedDown = true;
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            finally
            {
                MainForm.DefInstance.Cursor = Cursors.Default;
            }
        }

        private class TemplateHolderForList
        {
            public SPListTemplate Template;

            public TemplateHolderForList(SPListTemplate template)
            {
                this.Template = template;
            }

            public override string ToString()
            {
                return Template.Name;
            }
        }
        #endregion

        #region bulk Site creation
        private void btnValidate_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
            AddToRtbLocal("Validating Bulk Creation of Lists" + "\r\n", StyleType.titleSeagreen);
            bulkSiteCreation(true);
        }

        private void btnBulkSiteCreate_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
            AddToRtbLocal("Bulk Creating Lists" + "\r\n", StyleType.titleSeagreen);
            bulkSiteCreation(false);
        }

        private void bulkSiteCreation(bool onlyValidate)
        {
            //--Validate
            if (NewSiteOrList.ListOfNewLists == null || NewSiteOrList.ListOfNewLists.Count == 0)
            {
                AddToRtbLocal("The list of SharePoint Lists to create is empty.\r\n", StyleType.bodyRed);
                return;
            }
            if (cboListTemplates.SelectedItem == null)
            {
                AddToRtbLocal("Please select a List Template.\r\n", StyleType.bodyRed);
                return;
            }
            for (int i = 0; i < NewSiteOrList.ListOfNewLists.Count - 1; i++)
            {
                if (NewSiteOrList.ListOfNewLists[i].UrlName == NewSiteOrList.ListOfNewLists[i + 1].UrlName)
                {
                    AddToRtbLocal("The List URL " + NewSiteOrList.ListOfNewLists[i].UrlName + " is listed twice.\r\n", StyleType.bodyRed);
                    return;
                }
            }

            int counterCreated = 0;
            int counterListToCreate = 0;
            try
            {
                FrmCancelRunning.ToggleEnabled(true);
                SPWeb parentWeb = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
                if (parentWeb == null)
                    return;
                txtTargetSite.Text = parentWeb.Url;

                //--
                SPListTemplate targetTemplate = ((TemplateHolderForList)cboListTemplates.SelectedItem).Template;
                AddToRtbLocal("Creating new Lists beneath parent site ", StyleType.bodySeaGreen);
                AddToRtbLocal(parentWeb.Url + "\r\n", StyleType.bodyBlue);
                AddToRtbLocal("Using list template: ", StyleType.bodySeaGreen); AddToRtbLocal(targetTemplate.Name + "\r\n", StyleType.bodyBlue);
                AddToRtbLocal("\r\n", StyleType.bodyBlack);
                Application.DoEvents();

                //--
                List<NewSiteOrList> currentListUrlNamesAndTitles = new List<NewSiteOrList>();
                foreach (SPList list in parentWeb.Lists)
                    currentListUrlNamesAndTitles.Add(new NewSiteOrList(list.RootFolder.Name.ToUpper(), list.Title.ToUpper()));

                foreach (NewSiteOrList ns in NewSiteOrList.ListOfNewLists)
                {
                    if (GlobalVars.CancelRunning)
                        throw new Eh.CancelException();

                    counterListToCreate++;
                    AddToRtbLocal("#" + (counterListToCreate) + ") ", StyleType.bodyBlackBold);
                    if (listAlreadyExists(currentListUrlNamesAndTitles, ns))
                        AddToRtbLocal("List " + ns.UrlName + " already exists\r\n", StyleType.bodyBlue);
                    else
                    {
                        if (onlyValidate)
                        {
                            AddToRtbLocal("List to be created: ", StyleType.bodyBlack);
                            AddToRtbLocal(ns.ToString() + "\r\n", StyleType.bodyBlue);
                        }
                        else
                        {
                            AddToRtbLocal("Creating list:" + ns.ToString(), StyleType.bodyBlack);

                            Guid newListGuid = parentWeb.Lists.Add(ns.UrlName, "", targetTemplate);
                            counterCreated++;
                            SPList newList = parentWeb.Lists[newListGuid];
                            newList.Title = ns.Title;
                            newList.Update();

                            AddToRtbLocal(" success\r\n", StyleType.bodySeaGreen);

                            //--
                            if (chkAddListToQuickLanuch.Checked)
                            {
                                newList.OnQuickLaunch = true;
                                newList.Update();
                                AddToRtbLocal("  Quicklanuch node added for list\r\n", StyleType.bodyBlack);
                            }
                        }
                    }

                    SmartStepUtil.ScrollToBottom(rtbDisplay);
                    Application.DoEvents();
                }
            }
            catch (Eh.CancelException)
            {
                AddToRtbLocal("Cancelled by user\r\n", StyleType.bodyRed);
            }
            catch (Exception ex)
            {
                AddToRtbLocal("Error: " + ex.Message + "\r\n", StyleType.bodyRed);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false);
                AddToRtbLocal("\r\n\r\n", StyleType.bodyBlack);
                if (!onlyValidate)
                    AddToRtbLocal("DONE. Count of new lists created: " + counterCreated, StyleType.bodyDarkGray);
            }
        }

        private bool listAlreadyExists(List<NewSiteOrList> l, NewSiteOrList candidate)
        {
            foreach (NewSiteOrList nsl in l)
            {
                if (nsl.Title.ToUpper() == candidate.Title.ToUpper() || nsl.UrlName.ToUpper() == candidate.UrlName.ToUpper())
                    return true;
            }
            return false;
        }
        #endregion

        #region Misc
        private void btnEditSitesToCreateList_Click(object sender, EventArgs e)
        {
            ActionBulkSiteCreation_EditSitesList.ShowForm(false);
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        #endregion

        #region GlobalVar.SETTINGS
        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.bulkListCreate_siteUrl = txtTargetSite.Text;
        }

        private void cboListTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.bulkListCreate_siteTemplate = cboListTemplates.Text;
        }
        #endregion

        private void lnkShowAllTemplates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
            if (web == null)
                return;
            txtTargetSite.Text = web.Url;

            SPListTemplateCollection templates = web.Site.GetCustomListTemplates(web);

            rtbDisplay.Clear();
            AddToRtbLocal("Custom List Templates", StyleType.titleChocolate);
            AddToRtbLocal(" for site collection ", StyleType.bodyBlack);
            AddToRtbLocal(web.Site.RootWeb.Url + "\r\n", StyleType.bodyBlue);

            foreach (SPListTemplate template in templates)
                AddToRtbLocal("List Template Name:" + template.Name + ",  InteralName:" + template.InternalName + "\r\n", StyleType.bodyBlack);

            if (templates.Count == 0)
                AddToRtbLocal("(No Custom List Templates found)\r\n", StyleType.bodyBlack);
        }

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void imgBrowse_Click(object sender, EventArgs e)
        {
            SPWeb parentWeb = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
            if (parentWeb == null)
                return;

            Util.OpenURLinDefaultBrowser(parentWeb.Url, rtbDisplay);
        }

        private void lnkOpenSiteManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rtbDisplay.Clear();

            
            string u = txtTargetSite.Text + "/_layouts/sitemanager.aspx";
            Util.OpenURLinDefaultBrowser(u, rtbDisplay);
            SmartStepUtil.AddToRTB(rtbDisplay, "Navigating to " + u + "\r\n\r\n", StyleType.bodySeaGreen);

            string s = @"Site Manager is useful for giving you a view of all the Sites and Lists in your Site Collection. 

TIP: One useful feature is the ability to delete many lists at once. Within Site Manager, navigate to the Site containing the lists you wish to delete and check all the lists you wish to delete, then click Delete under the actions menu.";

            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyChocolate);


        }

        private void lnkRenameListURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rtbDisplay.Clear();
            string s = @"How to rename the URL name of a List:
                    Tip: To rename a list URL, use SharePoint designer. Within SharePoint Designer, navigate to the SharePoint Site containing the List, highlight the List URL you wish to rename and press F2 to rename.
                    Background: It is easy to change the title of a list or site, and it is easy to change the URL of a Site. But the SharePoint web interface does not provide a way to change the URL Name of a List. SharePoint Designer 2007 allows you to accomplish this task.";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyChocolate);

        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
                
        }
    }
}

