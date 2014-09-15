using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Diagnostics;

namespace SushiNS
{
    public partial class ActionBackup : SushiNS.ActionParent
    {

        #region class variables and load
        public static ActionBackup DefInstance;
        private bool _cancelNotice;
        private int _totalSites;

        public ActionBackup()
        {
            InitializeComponent();
        }

        private void ActionSharepointBackup_Load(object sender, EventArgs e)
        {
            //this.HelpKey = "Site backups";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtBackupPath.Text = GlobalVars.SETTINGS.backup_backupFilesPath;

            //--
            if (GlobalVars.SETTINGS.backup_includeSubsites)
                optBackupAllSubsites.Checked = true;
            else
                optBackupOnlyTopLevelSite.Checked = true;

            //--
            if (GlobalVars.SETTINGS.backup_siteURLcollection != null)
            {
                foreach (string item in GlobalVars.SETTINGS.backup_siteURLcollection)
                    lstSiteURLs.Items.Add(item);
            }

            //--
            optBackupOnlyTopLevelSite.CheckedChanged += optBackupOption_CheckedChanged;
            optBackupAllSubsites.CheckedChanged += optBackupOption_CheckedChanged;
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            showhelp();
        }

        void showhelp()
        {
            string s = @"The backup feature in Sushi allows you to create manual or scheduled automatic backups of SharePoint. The SUSHI backup feature is simply a wrapper around the STSADM.exe -o export -url <sharepoint url> command. SUSHI gives you a way to easily build the commandline command without having to open up the console window. SUSHI also allows you to schedule regular backups that will run automatically. 
            Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Site%20backups&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        void lnkAllSites_Click(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region set property events
        private void optBackupOption_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.backup_includeSubsites = optBackupAllSubsites.Checked;
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        #endregion

        #region Start Backup
        private void btnValidate_Click(object sender, EventArgs e)
        {
            StartBackup(true);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            StartBackup(false);
        }

        internal void StartBackup(bool onlyValidate)
        {
            rtbDisplay.Clear();
            toggleCancel(false, true, false);

            //--
            StartBackupDelegate del = new StartBackupDelegate(StartBackup2);
            del.BeginInvoke(onlyValidate, null, null);
        }

        private delegate void StartBackupDelegate(bool onlyValidate);
        private void StartBackup2(bool onlyValidate)
        {

            try
            {
                if (!System.IO.Directory.Exists(txtBackupPath.Text))
                {
                    SmartStepUtil.AddToRTB(rtbDisplay, "Backup folder '" + txtBackupPath.Text + "' does not exist.", Color.Red, 10, false);
                    return;
                }

                if (onlyValidate)
                    SmartStepUtil.AddToRTB(rtbDisplay, "validating only\r\n\r\n", Color.SeaGreen, 11, true);

                int urlCount = 0;
                foreach (string item in lstSiteURLs.Items)
                {
                    urlCount++;
                    StartBackup3(onlyValidate, item, urlCount);
                }

                //--
                if (!onlyValidate)
                    SmartStepUtil.AddToRTB(rtbDisplay, "backup complete\r\n\r\n", Color.SeaGreen, 11, true);

            }
            catch (Eh.CancelException)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Backup Cancelled by user\r\n", Color.Red, 12, true);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            finally
            {
                toggleCancel(false, false, true);
            }
        }

        private void StartBackup3(bool onlyValidate, string siteURLtoBackup, int urlCount)
        {
            SPSite sps = new SPSite(siteURLtoBackup); //note, unable to call Util.RetrieveWeb(), because it throws asynchronous errors or COM errors
            SPWeb web = sps.OpenWeb();

            _totalSites = 0;
            //if (chkcompress.Checked == true)
                BackupRecursively(web, onlyValidate, true, true);
            //else
            //    BackupRecursively(web, onlyValidate, true, false);


            //--
            if (this.optBackupAllSubsites.Checked)
            {
                string s = (_totalSites > 1) ? "s" : "";
                if (onlyValidate)
                    SmartStepUtil.AddToRTB(rtbDisplay, "\r\n" + _totalSites + " site" + s + " to be backed up for top site #" + urlCount + "\r\n", Color.Gray, 8, true);
                else
                    SmartStepUtil.AddToRTB(rtbDisplay, "\r\nBatch Complete. " + _totalSites + " site" + s + " backed up for top site #" + urlCount + "\r\n", Color.Gray, 8, true);
            }
            SmartStepUtil.ScrollToBottom(rtbDisplay);
        }

        private void BackupRecursively(SPWeb web, bool onlyValidate, bool isTopLevelSite, bool isCompressed)
        {
            //--loop through all subsites, call StartBackup3 recursively
            if (optBackupAllSubsites.Checked)
            {

                foreach (SPWeb subweb in web.Webs)
                    if (isCompressed)
                        BackupRecursively(subweb, onlyValidate, false, true);
                    else
                        BackupRecursively(subweb, onlyValidate, false, false);

                if (isTopLevelSite)
                    return;
            }

            if (_cancelNotice)
                throw new Eh.CancelException();

            _totalSites++;

            string backupFileName = txtBackupPath.Text + "\\" + AutoBackup.fetchCleanBackupFileName(web.Url) + ".SUSHIbackup";
            //SmartStepUtil.AddToRTB(rtbDisplay, "Site to backup: ");
            //SmartStepUtil.AddToRTB(rtbDisplay, web.Url + "\r\n", Color.Blue, 0, true);
            //SmartStepUtil.AddToRTB(rtbDisplay, "Backup file name: " + backupFileName + "\r\n\r\n");

            string args = string.Empty;
            if (isCompressed)
                args = AutoBackup.fetchStsadmCmdArgsForBackup(web.Url, backupFileName, true);
            else
                args = AutoBackup.fetchStsadmCmdArgsForBackup(web.Url, backupFileName, false);

            if (onlyValidate)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "stsadm.exe " + args + "\r\n\r\n", Color.Gray, 8, false);
            }
            else
            {
                //--do backup of site
                SmartStepUtil.AddToRTB(rtbDisplay, "starting backup..\r\n", Color.SeaGreen, 11, true);
                SmartStepUtil.AddToRTB(rtbDisplay, "stsadm.exe " + args + "\r\n", Color.Gray, 8, false);
                ProcessStartInfo si = new ProcessStartInfo();
                si.Arguments = args;
                si.FileName = GlobalVars.StsadmExePath;
                Process ret = Process.Start(si);
                ret.WaitForExit();
            }
        }
        #endregion

        #region open or edit backup folder
        private void lnkOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.openFolderInWindowsExplorer(txtBackupPath.Text);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtBackupPath.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = folderBrowserDialog1.SelectedPath;
                GlobalVars.SETTINGS.backup_backupFilesPath = folderBrowserDialog1.SelectedPath;
                if (ActionRestore.DefInstance != null)
                    ActionRestore.DefInstance.txtBackupPath.Text = GlobalVars.SETTINGS.backup_backupFilesPath;
            }
        }
        #endregion

        #region toggleCancel
        private delegate void del1(bool v1, bool v2, bool v3);
        private void toggleCancel(bool cancel, bool CancelLinkbuttonEnableState, bool UploadButtonEnableState)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                MainForm.DefInstance.Invoke(new del1(toggleCancel), new object[] { cancel, CancelLinkbuttonEnableState, UploadButtonEnableState });
                return;
            }
            _cancelNotice = cancel;
            lnkCancel.Text = cancel ? "Cancel Pending.." : "Cancel Backup";
            lnkCancel.Enabled = CancelLinkbuttonEnableState;

            btnStartBackup.Enabled = UploadButtonEnableState;
            btnValidateBackup.Enabled = UploadButtonEnableState;

            MainForm.DefInstance.tvNav.Enabled = UploadButtonEnableState;
            ucCreateSchedule1.Enabled = UploadButtonEnableState;
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toggleCancel(true, false, false);
            SmartStepUtil.AddToRTB(rtbDisplay, "cancel pending...\r\n", Color.Orange, 0, false);
        }
        #endregion

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        private void lnkAddURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!lstSiteURLs.Items.Contains(txtTargetSite.Text))
            {
                //--validate
                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbValidateMessage);
                if (web == null)
                    return;

                lstSiteURLs.Items.Add(txtTargetSite.Text);
                if (GlobalVars.SETTINGS.backup_siteURLcollection == null)
                    GlobalVars.SETTINGS.backup_siteURLcollection = new System.Collections.Specialized.StringCollection();
                GlobalVars.SETTINGS.backup_siteURLcollection.Add(txtTargetSite.Text);
            }
        }

        private void lnkRemoveURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lstSiteURLs.SelectedIndex > -1)
            {
                GlobalVars.SETTINGS.backup_siteURLcollection.Remove(lstSiteURLs.SelectedItem.ToString());
                lstSiteURLs.Items.RemoveAt(lstSiteURLs.SelectedIndex);

            }

        }

        private void lnkSelectASite1_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        #region keepcode
        //public delegate void WaitCursorDelegate();
        //public static void CallMethodWithWaitCursor(WaitCursorDelegate wd)
        //{
        //    try
        //    {
        //        MainForm.DefInstance.Cursor = Cursors.WaitCursor;
        //        wd.Invoke();
        //    }
        //    finally
        //    {
        //        MainForm.DefInstance.Cursor = Cursors.Default;
        //    }
        //}


        //#endregion


        //#region delete all backups
        //private void lnkDeleteAllBackups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (!System.IO.Directory.Exists(txtBackupPath.Text))
        //    {
        //        Util.ShowMessageBox("Backup folder '" + txtBackupPath.Text + "' does not exist.");
        //        return;
        //    }

        //    rtbDisplay.Clear();

        //    int count = 0;
        //    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(txtBackupPath.Text);
        //    foreach (FileInfo fi in di.GetFiles("*.SUSHIbackup"))
        //    {
        //        fi.Delete();
        //        count++;
        //        SmartStepUtil.AddToRTB(rtbDisplay, "deleted ");
        //        SmartStepUtil.AddToRTB(rtbDisplay, fi.Name, Color.Black, 0, true);
        //        if (File.Exists(fi.FullName + ".export.log"))
        //        {
        //            File.Delete(fi.FullName + ".export.log");
        //            SmartStepUtil.AddToRTB(rtbDisplay, ",and deleted export log");
        //        }
        //        if (File.Exists(fi.FullName + ".import.log"))
        //        {
        //            File.Delete(fi.FullName + ".import.log");
        //            SmartStepUtil.AddToRTB(rtbDisplay, ",and deleted import log");
        //        }                

        //        SmartStepUtil.AddToRTB(rtbDisplay, "\r\n");
        //    }
        //    SmartStepUtil.AddToRTB(rtbDisplay, count.ToString(), Color.Firebrick, 10, true);
        //    SmartStepUtil.AddToRTB(rtbDisplay, " backup files deleted from backup folder " + txtBackupPath.Text, Color.Firebrick, 0, false);
        //}
        //#endregion
        #endregion

    }
}