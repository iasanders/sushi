using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net.Mail;

namespace SushiNS
{
    public partial class ActionSettings : SushiNS.ActionParent
    {

        public static ActionSettings DefInstance;
        public ActionSettings()
        {
            InitializeComponent();
        }

        private void ActionSettings_Load(object sender, EventArgs e)
        {
            this.HelpKey = "SettingsAndHelp";
            //SushiHelp.createHelpLinkLabel(btnSaveSettings, "SettingsAndHelp");
            if (!SharePointUtil.IsSharePointInstalledLocally)
            {
                Util.ShowMessageBox("Note that SharePoint is not installed locally. SUSHI uses the SharePoint API, which means it must be run from a Windows Server that has SharePoint bits installed.");
            }
        }

        private void lnkOpenSettingsFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Catapult";
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettingsPlease();
            lblConfirm.Text = "Settings Saved " + DateTime.Now.ToShortTimeString();
        }

        internal static void SaveSettingsPlease()
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                SushiSettingsUtil.SaveSushiSettings();
            }
            finally { MainForm.DefInstance.Cursor = Cursors.Default; }

        }

        private void lnkOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.openFolderInWindowsExplorer(GlobalVars.LogFilesDir);
        }

        private void lnkOpenHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SushiHelp.ShowHelpLink("HOME");
        }

        //private void lnkSendTestEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    ActionSettings_SendEmailForm f = new ActionSettings_SendEmailForm();
        //    f.ShowDialog();

        //}

        private void lnkDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RichTextBox rtb = new RichTextBox(); //note: just so routine doesn't throw error, need to create a real rtb
            Util.OpenURLinDefaultBrowser("http://www.codeplex.com/sushi/Wiki/View.aspx?title=donate", rtb);
            //http://www.codeplex.com/sushi/Wiki/View.aspx?title=donate&referringTitle=About%20SUSHI
            //https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=joseph%40fluckiger%2eorg&item_name=SharePoint%20SUSHI&item_number=456&no_shipping=0&no_note=1&tax=0&currency_code=USD&lc=US&bn=PP%2dDonationsBF&charset=UTF%2d8
        }

    }
}

