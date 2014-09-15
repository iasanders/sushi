using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.SharePoint.WebPartPages;
using System.Xml;

namespace SUSHI
{
    public partial class ActionBulkSiteCreation : SUSHI.ActionParent
    {
        public static ActionBulkSiteCreation DefInstance;

        public ActionBulkSiteCreation()
        {
            InitializeComponent();
        }

        private void ActionBulkSiteCreation_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Bulk site creation";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtTargetSite.Text = GlobalVars.SETTINGS.bulkSiteCreate_siteUrl;
            chkOnlyCustomTemplates.Checked = GlobalVars.SETTINGS.bulkSiteCreate_onlyCustomTemplates;
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            string s = @"This feature enables the bulk creation of subsites based on a site template. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Bulk%20Site%20Creation&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        #region populateSiteTemplates
        private void btnRetrieveTemplates_Click(object sender, EventArgs e)
        {
            populateSiteTemplates();
        }

        private void populateSiteTemplates()
        {
            try
            {
                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
                if (web == null)
                    return;
                txtTargetSite.Text = web.Url;

                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                SPWebTemplateCollection templates;
                if (chkOnlyCustomTemplates.Checked)
                    templates = web.Site.GetCustomWebTemplates(1033);
                else
                    templates = web.Site.GetWebTemplates(1033);

                string rememberSelected = null;
                if (cboSiteTemplates.SelectedItem != null)
                    rememberSelected = cboSiteTemplates.SelectedItem.ToString();
                cboSiteTemplates.Items.Clear();
                foreach (SPWebTemplate template in templates)
                    cboSiteTemplates.Items.Add(new TemplateHolder(template));

                if (rememberSelected == null)
                    cboSiteTemplates.SelectedIndex = cboSiteTemplates.FindStringExact(GlobalVars.SETTINGS.bulkSiteCreate_siteTemplate);
                else
                    cboSiteTemplates.SelectedIndex = cboSiteTemplates.FindStringExact(rememberSelected);

                cboSiteTemplates.DroppedDown = true;
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

        private class TemplateHolder
        {
            public SPWebTemplate Template;

            public TemplateHolder(SPWebTemplate template)
            {
                this.Template = template;
            }

            public override string ToString()
            {
                return Template.Title;
               // return "name:" + Template.Name + ", title:" + Template.Title;
            }
        }
        #endregion

        #region bulk Site creation
        private void btnValidate_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
            AddToRtbLocal("Validating Bulk Creation of Sites" + "\r\n", StyleType.titleSeagreen);
            bulkSiteCreation(true);
        }

        private void btnBulkSiteCreate_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
            AddToRtbLocal("Bulk Creating Sites" + "\r\n", StyleType.titleSeagreen);
            bulkSiteCreation(false);
        }

        private void bulkSiteCreation(bool onlyValidate)
        {
            //--Validate
            if (NewSiteOrList.ListOfNewSites == null || NewSiteOrList.ListOfNewSites.Count == 0)
            {
                AddToRtbLocal("The sites to create list is empty.\r\n", StyleType.bodyRed);
                return;
            }
            if (cboSiteTemplates.SelectedItem == null)
            {
                AddToRtbLocal("Please select a Site Template.\r\n", StyleType.bodyRed);
                return;
            }
            for (int i = 0; i < NewSiteOrList.ListOfNewSites.Count - 1; i++)
            {
                if (NewSiteOrList.ListOfNewSites[i].UrlName == NewSiteOrList.ListOfNewSites[i + 1].UrlName)
                {
                    AddToRtbLocal("The Site URL " + NewSiteOrList.ListOfNewSites[i].UrlName + " is listed twice.\r\n", StyleType.bodyRed);
                    return;
                }
            }

            int counter = 0;
            int counterListToCreate = 0;
            try
            {
                FrmCancelRunning.ToggleEnabled(true);
                SPWeb parentWeb = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
                if (parentWeb == null)
                    return;
                txtTargetSite.Text = parentWeb.Url;

                //--
                SPWebTemplate targetTemplate = ((TemplateHolder)cboSiteTemplates.SelectedItem).Template;
                AddToRtbLocal("Creating new SubSites beneath parent site " + parentWeb.Url + "\r\n", StyleType.bodySeaGreen);
                AddToRtbLocal("Using template: ", StyleType.bodySeaGreen); AddToRtbLocal(targetTemplate.Title + "\r\n", StyleType.bodyBlue);
                AddToRtbLocal("\r\n", StyleType.bodyBlack);
                Application.DoEvents();

                //--
                List<string> currentSiteUrlNames = new List<string>();
                currentSiteUrlNames.AddRange(parentWeb.Webs.Names);
                foreach (NewSiteOrList ns in NewSiteOrList.ListOfNewSites)
                {
                    if (GlobalVars.CancelRunning)
                        throw new Eh.CancelException();
                    
                    counterListToCreate++;
                    AddToRtbLocal("#" + counterListToCreate + ") ", StyleType.bodyBlackBold);
                    SPWeb childWeb = null;
                    if (currentSiteUrlNames.Contains(ns.UrlName))
                    {
                        AddToRtbLocal("Subsite " + ns.UrlName + " already exists\r\n", StyleType.bodyBlue);
                        childWeb = parentWeb.Webs[ns.UrlName];
                    }
                    else
                    {
                        if (onlyValidate)
                        {
                            AddToRtbLocal("Subsite to be created: ", StyleType.bodyBlack);
                            AddToRtbLocal(ns.ToString() + "\r\n", StyleType.bodyBlue);
                        }
                        else
                        {
                            AddToRtbLocal("Creating subsite:" + ns.ToString(), StyleType.bodyBlack);
                            childWeb = parentWeb.Webs.Add(ns.UrlName, ns.Title, "", 1033, targetTemplate, false, false);
                            counter++;
                            AddToRtbLocal(" success\r\n", StyleType.bodySeaGreen);

                            //--
                            AddToRtbLocal("Applying same global navigation as parent\r\n", StyleType.bodyBlack);
                            childWeb.Navigation.UseShared = true;
                        }
                    }

                    SmartStepUtil.ScrollToBottom(rtbDisplay);
                    Application.DoEvents();
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
                string s = onlyValidate ? "to be " : "";
                AddToRtbLocal("DONE. Count of sites in new sites list: " + NewSiteOrList.ListOfNewSites.Count + ", sites " + s + "created: " + counter, StyleType.bodyDarkGray);
            }
        }
        #endregion

        #region delete subsites
        private void lnkDeleteSubsites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rtbDisplay.Clear();

                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
                if (web == null)
                    return;
                txtTargetSite.Text = web.Url;
                AddToRtbLocal("To delete subsites " + web.Url + ", copy the text below into a commandline batch file.\r\n", StyleType.bodyBlack);
                AddToRtbLocal("\r\n\r\n", StyleType.bodyBlue);
                
                if (web.Webs.Count == 0)
                    AddToRtbLocal("No subsites.\r\n", StyleType.bodyBlue);

                foreach (SPWeb webChild in web.Webs)
                    AddToRtbLocal("stsadm -o deleteweb -url \"" + webChild.Url + "\"\r\n", StyleType.bodyBlue);
            }
            catch (Exception ex)
            {
                AddToRtbLocal("error: " + ex.Message, StyleType.bodyRed);
            }
            //TODO: add instructions.
        }
        #endregion

        #region Misc
        private void btnEditSitesToCreateList_Click(object sender, EventArgs e)
        {
            ActionBulkSiteCreation_EditSitesList.ShowForm(true);
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        #endregion

        #region GlobalVar.SETTINGS
        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.bulkSiteCreate_siteUrl = txtTargetSite.Text;
        }

        private void cboSiteTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.bulkSiteCreate_siteTemplate = cboSiteTemplates.Text;
        }

        private void chkOnlyCustomTemplates_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.bulkSiteCreate_onlyCustomTemplates = chkOnlyCustomTemplates.Checked;
        }
        #endregion

        #region lnkShowAllTemplates_LinkClicked
        private void lnkShowAllTemplates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
            if (web == null)
                return;
            txtTargetSite.Text = web.Url;

            SPWebTemplateCollection templates = web.Site.GetWebTemplates(1033);

            rtbDisplay.Clear();
            SmartStepUtil.AddToRTB(rtbDisplay, "Site Template Information\r\n", Color.Blue, 10, true);
            foreach (SPWebTemplate template in templates)
                SmartStepUtil.AddToRTB(rtbDisplay, "name:" + template.Name + ", title:" + template.Title + "\r\n");
        }
        #endregion

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}

