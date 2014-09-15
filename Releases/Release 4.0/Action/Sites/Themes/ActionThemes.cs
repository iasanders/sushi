using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Diagnostics;
using System.Xml;

namespace SushiNS
{
    public partial class ActionThemes : SushiNS.ActionParent
    {
        public static ActionThemes DefInstance;

        public ActionThemes()
        {
            InitializeComponent();
        }
        private void ActionThemes_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Themes";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtTargetSite.Text = GlobalVars.SETTINGS.theme_siteURL;

            foreach (Control c in this.Controls)
            {
                if (c is RadioButton && c.Name.StartsWith("optApply"))
                {
                    if (GlobalVars.SETTINGS.theme_ApplyToChildSitesOption == c.Name)
                        ((RadioButton)c).Checked = true;
                }
            }

            optApplyToParentSite.CheckedChanged += new EventHandler(optApply_CheckedChanged);
            optApplyToChildren.CheckedChanged += new EventHandler(optApply_CheckedChanged);
            optApplyToAllChildrenRecursively.CheckedChanged += new EventHandler(optApply_CheckedChanged);

            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            string s = @"This feature allows you to apply theme to SharePoint sites and its sub sites. Here are the Steps that describe how to apply theme to a single site and its children sites. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Themes&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);

        }

        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.theme_siteURL = txtTargetSite.Text;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            ApplyTheme(true);
        }

        private void btnGetThemes_Click(object sender, EventArgs e)
        {
            ApplyTheme(false);
        }

        private void ApplyTheme(bool onlyValidate)
        {
            rtbDisplay.Clear();
            if (cboThemes.SelectedItem == null)
            {
                AddToRtbLocal("Please select a theme.", StyleType.bodyRed);
                return;
            }
            FrmCancelRunning.ToggleEnabled(true);
            SPWeb startSite = null;
            try
            {
                startSite = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);

                if (startSite == null)
                    return;
                string which = optApplyToParentSite.Checked ? " to the selected site " : " to all children selected site ";
                AddToRtbLocal("Applying Theme ", StyleType.titleChocolate);
                AddToRtbLocal(cboThemes.SelectedItem.ToString(), StyleType.titleBlue);
                AddToRtbLocal(which, StyleType.titleChocolate);
                AddToRtbLocal(startSite.Title, StyleType.titleBlue);
                AddToRtbLocal(Util.V(onlyValidate) + "\r\n", StyleType.titleChocolate);

                //--build collection of sites to apply theme to.
                List<SPWeb> listOfSites = new List<SPWeb>(); ;
                if (optApplyToParentSite.Checked)
                    listOfSites.Add(startSite);
                else if (optApplyToChildren.Checked)
                {
                    listOfSites.Add(startSite);
                    foreach (SPWeb webChild in startSite.Webs)
                        listOfSites.Add(webChild);
                }
                else if (optApplyToAllChildrenRecursively.Checked)
                {
                    listOfSites.Add(startSite);
                    getAllChildrenRecursively(listOfSites, startSite);
                }

                //--loop through each web in list, apply theme.
                foreach (SPWeb webChild in listOfSites)
                {
                    if (GlobalVars.CancelRunning)
                        throw new Eh.CancelException();
                    Application.DoEvents();

                    AddToRtbLocal("Appling Theme to site ", StyleType.bodyBlack);
                    string url = webChild.ServerRelativeUrl + " (" + webChild.Title + ")";
                    AddToRtbLocal(url, StyleType.bodyBlue);
                    if (!onlyValidate)
                    {
                        webChild.ApplyTheme(cboThemes.SelectedItem.ToString());
                        webChild.Update();
                    }

                    if (onlyValidate)
                        AddToRtbLocal(Util.V(onlyValidate) + "\r\n", StyleType.bodyBlack);
                    else
                        AddToRtbLocal("  success\r\n", StyleType.bodySeaGreen);

                    //--
                    webChild.Dispose();
                }
                if (listOfSites.Count == 0)
                    AddToRtbLocal("No sites to apply theme to.\r\n", StyleType.bodyRed);
            }
            catch (Eh.CancelException)
            {
                AddToRtbLocal("cancelled by user", StyleType.bodyRed);
            }
            catch (Exception ex)
            {
                AddToRtbLocal(ex.Message, StyleType.bodyRed);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false);
                if (startSite != null)
                    startSite.Dispose();
            }
        }

        private void getAllChildrenRecursively(List<SPWeb> listOfSites, SPWeb parentSite)
        {
            foreach (SPWeb child in parentSite.Webs)
                listOfSites.Add(child);

            foreach (SPWeb child in parentSite.Webs)
                getAllChildrenRecursively(listOfSites, child);
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        private void btnLookupThemes_Click(object sender, EventArgs e)
        {
            try
            {
                cboThemes.Items.Clear();
                rtbDisplay.Clear();

                string filePath = getSpThemesPath();
                if (filePath == null)
                    return;

                string content;
                using (System.IO.TextReader tr = new System.IO.StreamReader(filePath))
                {
                    content = tr.ReadToEnd();
                }
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(content);
                int count = 0;
                foreach (XmlNode xNode in xDoc.DocumentElement.ChildNodes)
                {
                    string themeID = xNode["TemplateID"].InnerXml;
                    cboThemes.Items.Add(themeID);
                    AddToRtbLocal(themeID + "\r\n", StyleType.bodyBlack);
                    count++;
                }
                AddToRtbLocal("Found " + count + " themes\r\n", StyleType.bodyBlue);
                cboThemes.SelectedIndex = cboThemes.FindStringExact(GlobalVars.SETTINGS.theme_defaultTheme);
                cboThemes.DroppedDown = true;
            }
            catch (Exception ex)
            {
                AddToRtbLocal(ex.Message, StyleType.bodyRed);
            }
        }

        private string getSpThemesPath()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\Microsoft Shared\web server extensions\12\TEMPLATE\LAYOUTS\1033\SPTHEMES.XML";
            if (!System.IO.File.Exists(filePath))
            {
                AddToRtbLocal("Unable to find SPTHEMES.XML at " + filePath, StyleType.bodyRed);
                return null;
            }

            AddToRtbLocal("Retrieving Themes from SPTHEMS.XML at ", StyleType.bodyBlack);
            AddToRtbLocal(filePath + "\r\n", StyleType.bodyChocolate);
            return filePath;
        }

        #region Save Settings control events
        private void cboThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.theme_defaultTheme = cboThemes.SelectedItem.ToString();
        }

        void optApply_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (!rb.Checked) return;

            GlobalVars.SETTINGS.theme_ApplyToChildSitesOption = rb.Name;
        }
        #endregion



        #region Tools
        private void lnkShowCurrentTheme_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rtbDisplay.Clear();

                using (SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage))
                {
                    if (web == null)
                        return;

                    //--
                    AddToRtbLocal("Current Theme for Site ", StyleType.titleChocolate);
                    AddToRtbLocal(web.Url + "\r\n", StyleType.bodyBlue);

                    AddToRtbLocal("Theme: ", StyleType.bodyBlack);
                    string t = web.Theme == "" ? "(No theme currenly applied)" : web.Theme;
                    AddToRtbLocal(t + "\r\n", StyleType.bodyBlue);

                    AddToRtbLocal("Theme CSS: ", StyleType.bodyBlack);
                    string c = web.ThemeCssUrl == "" ? "(No Custom CSS currently applied)" : web.ThemeCssUrl;
                    AddToRtbLocal(c + "\r\n", StyleType.bodyBlue);
                }
            }
            catch (Exception ex)
            {
                AddToRtbLocal(ex.Message, StyleType.bodyRed);
            }
        }

        private void lnkOpenSpThemes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rtbDisplay.Clear();
                string filePath = getSpThemesPath();
                if (filePath == null) return;
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                AddToRtbLocal(ex.Message, StyleType.bodyRed);
            }
        }
        #endregion

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void imgBrowse_Click(object sender, EventArgs e)
        {
            Util.OpenURLinDefaultBrowser(txtTargetSite.Text, rtbDisplay);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
