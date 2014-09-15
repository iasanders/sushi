using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Diagnostics;
using System.IO;

namespace SushiNS
{
    public partial class ActionRestore : SushiNS.ActionParent
    {
        public static ActionRestore DefInstance;
        
        public ActionRestore()
        {
            InitializeComponent();
        }

        private void ActionRestore_Load(object sender, EventArgs e)
        {
            //this.HelpKey = "Restore";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtBackupPath.Text = GlobalVars.SETTINGS.backup_backupFilesPath;
            chkIncludeUserSecurity.Checked = GlobalVars.SETTINGS.restore_includeUserSecurity;
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            showhelp();

        }
        void showhelp()
        {
            string s = @"This feature simply restores a site from a backup. Note that this feature is a wrapper around STSADM. So it simply makes it easier to use STSADM to restore a site from backup.Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Restore&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        #region Save Property values
        private void chkIncludeUserSecurity_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.restore_includeUserSecurity = chkIncludeUserSecurity.Checked;
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            
        }
        #endregion

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lstBackupToRestore.Items.Clear();

            if (!Directory.Exists(txtBackupPath.Text))
                return;

            DirectoryInfo di = new DirectoryInfo(txtBackupPath.Text);
            int count = 0;
            foreach (FileInfo fi in di.GetFiles("*.SUSHIbackup"))
            {
                lstBackupToRestore.Items.Add(fi.Name);
                count++;
            }
            if (count == 0)
                lblFeedbackNoBackupFilesFound.Text = @"No files found in backup folder with extention of "".SUSHIbackup""";
            else
                lblFeedbackNoBackupFilesFound.Text = "";

        }

        private void lstBackupToRestore_SelectedIndexChanged(object sender, EventArgs e)
        {
            string defaultRestorePath = lstBackupToRestore.SelectedItem.ToString();

            //--note: that # and } are illegal characters in sharepoint and valid windows filename characters 
            //--so we are using them as placeholders for the / and : symbols 
            if (defaultRestorePath.StartsWith("https#"))
                defaultRestorePath.Replace("https#", "https://");
            else
                defaultRestorePath = "http://" + defaultRestorePath;
            defaultRestorePath = defaultRestorePath.Replace("#", "/").Replace("}", ":");
            defaultRestorePath = defaultRestorePath.Remove(defaultRestorePath.Length - 12, 12); //remove ".SUSHIbackup" at end.
            txtRestoreDestinationURL.Text = defaultRestorePath;
        }

        #region Start Restore
        private void btnValidateRestore_Click(object sender, EventArgs e)
        {
            startRestore(true);
        }

        private void btnStartRestore_Click(object sender, EventArgs e)
        {
            startRestore(false);
        }

        private void startRestore(bool onlyValidate)
        {
            rtbDisplay.Clear();
            if (lstBackupToRestore.SelectedIndex == -1 )
                return;

            //--
            StartRestoreDelegate del = new StartRestoreDelegate(StartRestore2);
            del.BeginInvoke(onlyValidate, lstBackupToRestore.SelectedItem.ToString(), null, null);
        }

        private delegate void StartRestoreDelegate(bool onlyValidate, string backupToRestore);
        private void StartRestore2(bool onlyValidate, string backupToRestore)
        {
            try
            {
                //TODO: have user type in the word "RESTORE" if destination URL already exists.

                string destUrl = txtRestoreDestinationURL.Text;
                FileInfo fiBackup = new FileInfo(txtBackupPath.Text + "\\" + backupToRestore);
                string includeUserSecurity = chkIncludeUserSecurity.Checked ? "-includeusersecurity" : "";
                SmartStepUtil.AddToRTB(rtbDisplay, "backup to restore:   ");
                SmartStepUtil.AddToRTB(rtbDisplay, fiBackup.Name + "\r\n", Color.Black, 0, true);
                SmartStepUtil.AddToRTB(rtbDisplay, "destination URL:      ");
                SmartStepUtil.AddToRTB(rtbDisplay, destUrl + "\r\n" , Color.Black, 0, true);

                //--validate destination site URL
                SPSite site;
                try
                {
                    site = new SPSite(txtRestoreDestinationURL.Text);
                }
                catch (Exception ex)
                {
                    SmartStepUtil.AddToRTB(rtbDisplay, ex.Message, Color.Red, 0, false);
                    return;
                }
                
                SPWeb web = site.OpenWeb();
                SmartStepUtil.AddToRTB(rtbDisplay, "destination SPS Site: " + web.Url );
                if ((new Uri(txtRestoreDestinationURL.Text)).ToString() == (new Uri(web.Url)).ToString())
                    SmartStepUtil.AddToRTB(rtbDisplay, " same, content will be overwritten ", Color.Firebrick, 0, false);
                else
                    SmartStepUtil.AddToRTB(rtbDisplay, " not same, a new site will be created ", Color.Firebrick, 0, false);
                SmartStepUtil.AddToRTB(rtbDisplay, "\r\n");

                string args = string.Format(@"-o import -url ""{0}"" -filename ""{1}"" {2} ", destUrl, fiBackup.FullName, includeUserSecurity);;
                SmartStepUtil.AddToRTB(rtbDisplay, "stsadm.exe " + args,Color.Gray,8,false);
                if (onlyValidate)
                    SmartStepUtil.AddToRTB(rtbDisplay, "validating only\r\n", Color.YellowGreen, 0, true);
                else
                {
                    SmartStepUtil.AddToRTB(rtbDisplay, "restore started\r\n", Color.SeaGreen, 0, true);
                    ProcessStartInfo si = new ProcessStartInfo();
                    si.Arguments = args;
                    si.FileName = GlobalVars.StsadmExePath; 
                    Process ret = Process.Start(si);
                    ret.WaitForExit();
                    SmartStepUtil.AddToRTB(rtbDisplay, "restore complete\r\n\r\n", Color.SeaGreen, 0, true);
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }
        #endregion





    }
}