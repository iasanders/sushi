using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Xml;

namespace SushiNS
{
    public partial class ActionErrorsFileNotFound : SushiNS.ActionParent
    {
        public static ActionErrorsFileNotFound DefInstance;

        public ActionErrorsFileNotFound()
        {
            InitializeComponent();
        }

        private void ActionErrorsFileNotFound_Load(object sender, EventArgs e)
        {
            txtTargetSite.Text = GlobalVars.SETTINGS.errors_errorsNotFound_targetSite;

            txtNewErrorPage.Text = GlobalVars.SETTINGS.errors_errorsNotFound_defaultLocalErrorFile;
        }

        
        #region Go errors
        private void btnValidate_Click(object sender, EventArgs e)
        {
            SwitchErrorsFile(true);
        }

        private void btnSwitchErrorFile(object sender, EventArgs e)
        {
            SwitchErrorsFile(false);
        }

        private void SwitchErrorsFile(bool onlyValidate)
        {
            try
            {
                rtbDisplay.Clear();

                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
                string pageNotFound = web.Site.WebApplication.FileNotFoundPage;
                if (string.IsNullOrEmpty(pageNotFound))
                {
                    AddToRtbLocal(" Current Error page: (there is currently no Error Page)", StyleType.bodyBlue);
                    return;
                }
                else
                {
                    AddToRtbLocal(" Current Error page: " + pageNotFound + "\r\n", StyleType.bodyBlue);

                    string fileErr = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\Microsoft Shared\web server extensions\12\TEMPLATE\LAYOUTS\1033\" + pageNotFound;
                    System.IO.FileInfo fi = new System.IO.FileInfo(fileErr);
                    if (fi.Exists)
                    {
                        AddToRtbLocal(" Full Path: " + fi.FullName + "\r\n", StyleType.bodyBlue);
                    }
                    else
                        AddToRtbLocal(" Full Path: Can't find full path at: " + fi.FullName + "\r\n", StyleType.bodyBlue);
                }
                AddToRtbLocal("\r\n\r\n", StyleType.bodyBlack);

                if (web != null)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(txtNewErrorPage.Text);
                    if (!fi.Exists)
                    {
                        AddToRtbLocal("New File not found '" + fi.FullName + "'", StyleType.bodyBlue);
                        return;
                    }
                    AddToRtbLocal("Copying new error page '" + fi.FullName + "' to Layouts directory. " + Util.V(onlyValidate) + "\r\n", StyleType.bodyBlue);
                    string fileErr = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\Microsoft Shared\web server extensions\12\TEMPLATE\LAYOUTS\1033\" + fi.Name;
                    if (!onlyValidate)
                    {
                        fi.CopyTo(fileErr, true);

                        AddToRtbLocal("Setting WebApplication.FileNotFoundPage property\r\n", StyleType.bodyBlue);
                        Microsoft.SharePoint.Administration.SPWebApplication webApp = web.Site.WebApplication;
                        webApp.FileNotFoundPage = fi.Name;
                        webApp.Update();
                        AddToRtbLocal("\r\nsuccess\r\n", StyleType.bodyBlackBold);
                    }
                }
            }
            catch (Exception ex)
            {
                AddToRtbLocal(ex.Message, StyleType.bodyRed);
            }
        }
        #endregion

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        #region Save Settings control events
        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.errors_errorsNotFound_targetSite = txtTargetSite.Text;
        }
        #endregion

        private void txtNewErrorPage_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.errors_errorsNotFound_defaultLocalErrorFile = txtNewErrorPage.Text;
        }

        private void lnkSelectASite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        









    }
}
