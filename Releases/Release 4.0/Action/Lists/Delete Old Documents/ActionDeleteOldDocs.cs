using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace SushiNS
{
    public partial class ActionDeleteOldDocs : ActionParent
    {
        public static ActionDeleteOldDocs DefInstance;
        bool _cancel;

        public ActionDeleteOldDocs()
        {
            InitializeComponent();
        }

        #region Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Archive Old Documents";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            try
            {
                //--remember settings
                txtTargetSite.Text = GlobalVars.SETTINGS.delete_Sharepointsite;
                //loadDocumentLibrariesForSite();

                if (!string.IsNullOrEmpty(GlobalVars.SETTINGS.delete_doListFilenames) && GlobalVars.SETTINGS.delete_doListFilenames == "yes")
                    chkDoListFiles.Checked = true;

                DateTime dte;
                if (DateTime.TryParse(GlobalVars.SETTINGS.delete_archiveDate, out dte))
                    dtpArchiveDate.Value = dte;
                else
                    dtpArchiveDate.Value = new DateTime(DateTime.Now.Year, 1, 1);

                txtArchiveDest.Text = GlobalVars.SETTINGS.delete_archiveDestFolder;
                AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
                showhelp();
            }
            catch (Exception ex)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, ex);
            }
        }
        void showhelp()
        {
            string s = @"The Delete Old Documents feature in sushi allows you to copy documents older than a sepcified date to an archive folder and then delete from SharePoint.Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Delete%20Old%20Documents&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }
        #endregion

        #region Retrieve Document Libraries For Site
        private void btnRetrieveDocLibs_Click(object sender, EventArgs e)
        {
            loadDocumentLibrariesForSite();
        }

        private void loadDocumentLibrariesForSite()
        {
            try
            {
                //--
                cklbDocLibs.Items.Clear();
                this.Cursor = Cursors.WaitCursor;
                rtbDisplay.Clear();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbDisplay);
                        if (web == null) return;

                        foreach (SPList list in web.Lists)
                        {
                            if (list.BaseType.ToString() == "DocumentLibrary" && !Util.DocumentLibraryNamesToExclude.Contains(list.ToString()))
                            {
                                string libName = list.ToString();
                                cklbDocLibs.Items.Add(libName);
                            }
                        }
                    });
            }
            catch (Exception ex)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Remember Settings Control Events
        private void txtSharepointsite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.delete_Sharepointsite = txtTargetSite.Text;

            lblArchiveSubfolder.Text = SiteUrlToArchiveFolderName(txtTargetSite.Text);
        }

        private void txtArchiveDest_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.delete_archiveDestFolder = txtArchiveDest.Text;
        }

        private void chkDoListFiles_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.delete_doListFilenames = chkDoListFiles.Checked ? "yes" : "no";
        }

        private void dtpArchiveDate_ValueChanged(object sender, EventArgs e)
        {
            txtDescMonthsOld.Text = "Documents will be deleted with a modified date prior to " + getArchiveDateDisplayString() ;//dtpArchiveDate.Value.ToShortDateString() + " 11:59:59 pm ";
            GlobalVars.SETTINGS.delete_archiveDate = dtpArchiveDate.Value.ToShortDateString();
        }
        #endregion

        #region Delete Old Files
        private void btnValidate_Click(object sender, EventArgs e)
        {
            deleteOldFilesAsync(true);
        }

        private void btnArchiveAndDeleteOldFiles_Click(object sender, EventArgs e)
        {
            deleteOldFilesAsync(false);
        }

        delegate void deleteOldFilesDelegate(bool validateOnly, string webUrl);
        void deleteOldFilesAsync(bool validateOnly)
        {
            rtbDisplay.Clear();

            //--Validate
            if (cklbDocLibs.CheckedItems.Count == 0)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Please select a Document Library to Delete From", StyleType.bodyRed);
                return;
            }

            if (!Directory.Exists(txtArchiveDest.Text))
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Archive Folder '" + txtArchiveDest.Text + "' is not valid.", StyleType.bodyRed);
                return;
            }

            //--
            _cancel = false;
            toggle(false);

            deleteOldFilesDelegate d = new deleteOldFilesDelegate(deleteOldFiles);
            d.BeginInvoke(validateOnly, txtTargetSite.Text, null, null);
        }

        private void deleteOldFiles(bool validateOnly, string webUrl)
        {
            try
            {
                //--
                SPSite site;
                try
                {
                    site = new SPSite(webUrl);
                }
                catch (Exception ex)
                {
                    SmartStepUtil.AddToRTB(rtbDisplay, "site not found: " + ex.Message + " \r\n", Color.Red, 8, false, SmartStepUtil.enumIcon.red_x);
                    return;
                }

                SPWeb web = site.OpenWeb();
                SmartStepUtil.AddToRTB(rtbDisplay, "site found: " + web.Url + " \r\n", Color.Green, 8, false, SmartStepUtil.enumIcon.green_check);

                //--
                if (validateOnly)
                    SmartStepUtil.AddToRTB(rtbDisplay, Util.V(validateOnly) + "\r\n", StyleType.titleSeagreen);
                SmartStepUtil.AddToRTB(rtbDisplay, "Archive Folder: ", StyleType.bodySeaGreen);
                SmartStepUtil.AddToRTB(rtbDisplay, txtArchiveDest.Text + "\r\n", StyleType.bodySeaGreenBold);
                SmartStepUtil.AddToRTB(rtbDisplay, "Archive Date: ", StyleType.bodySeaGreen);
                SmartStepUtil.AddToRTB(rtbDisplay, getArchiveDateDisplayString() + "\r\n", StyleType.bodySeaGreenBold);

                int countGrandTotalOlderThanArchiveDate = 0;
                foreach (object docLibName in cklbDocLibs.CheckedItems)
                {
                    //--loop through each document and if it is old, add to collection
                    SmartStepUtil.AddToRTB(rtbDisplay, "\nDeleteing old documents from library: ", StyleType.bodySeaGreen);
                    SmartStepUtil.AddToRTB(rtbDisplay, docLibName.ToString() + " " + Util.V(validateOnly) + "\r\n", StyleType.bodySeaGreenBold);
                    int countOlderThanArchiveDate = 0;
                    int countNewerThanArchiveDate = 0;

                    List<SPListItem> listitems = new List<SPListItem>();
                    foreach (SPListItem spListItem in web.Lists[docLibName.ToString()].Items)
                        listitems.Add(spListItem);

                    foreach (SPListItem spListItem in listitems)
                    {
                        if (_cancel)
                            throw new Eh.CancelException();

                        SPFile spFile = spListItem.File;
                        if (spFile.TimeLastModified < getArchiveDate().ToUniversalTime())
                        {
                            if (!validateOnly)
                            {
                                moveFileToArchiveFolder(spListItem);
                                spListItem.Delete();
                            }

                            if (chkDoListFiles.Checked)
                                SmartStepUtil.AddToRTB(rtbDisplay, spFile.Name + " " + spFile.TimeLastModified.ToLocalTime().ToString("yyyy-MM-dd HH:mm") + "\r\n", StyleType.bodyBlack);
                            countOlderThanArchiveDate++;
                            countGrandTotalOlderThanArchiveDate++;
                        }
                        else
                            countNewerThanArchiveDate++;
                    }

                    SmartStepUtil.AddToRTB(rtbDisplay, "Files " + (validateOnly ? "to " : "") + "archive" + (validateOnly ? "" : "d") + ": " + countOlderThanArchiveDate + "\r\n", StyleType.bodyChocolate);
                    SmartStepUtil.AddToRTB(rtbDisplay, "Files not " + (validateOnly ? "to " : "") + "archive" + (validateOnly ? "" : "d") + ": " + countNewerThanArchiveDate + "\r\n", StyleType.bodyChocolate);
                }
                SmartStepUtil.AddToRTB(rtbDisplay, "\r\nTotal archive files: " + countGrandTotalOlderThanArchiveDate + "\r\n", StyleType.bodyChocolateBold);
            }
            catch (Eh.CancelException)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Cancelled by User\r\n", StyleType.bodyRed);
            }
            catch (Exception ex)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, ex);
            }
            finally
            {
                toggle(true);
            }
        }

        private void moveFileToArchiveFolder(SPListItem listitem)
        {
            DirectoryInfo diTarget = new DirectoryInfo(
                txtArchiveDest.Text + @"\" + SiteUrlToArchiveFolderName(txtTargetSite.Text) + @"\" + listitem.ParentList.RootFolder.Name);
            if (!diTarget.Exists)
                diTarget.Create();

            string destArchiveFile = diTarget.FullName + @"\" + listitem.File.Name;
            if (File.Exists(destArchiveFile))
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "overwriting file '" + listitem.File.Name + "' in archive folder.\r\n", StyleType.bodyDarkGray);
            }
            using (FileStream fstream = new FileStream(destArchiveFile, FileMode.Create))
            {
                byte[] b = listitem.File.OpenBinary();
                fstream.Write(b, 0, b.Length);
            }
        }

        #region Cancel, Toggle Enable
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
            btnCancel.Enabled = false;
        }

        private delegate void toggleDelegate(bool enabled);
        void toggle(bool enabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new toggleDelegate(toggle), enabled);
                return;
            }
            MainForm.DefInstance.tvNav.Enabled = enabled;
            foreach (Control c in this.Controls)
            {
                if (c.Name != "btnCancel" && c.Name != "rtbDisplay")
                    c.Enabled = enabled;
            }
            btnCancel.Enabled = !enabled;
        }
        #endregion

        private DateTime getArchiveDate()
        {
            return dtpArchiveDate.Value.Date.AddDays(1).AddSeconds(-1);
        }

        private string getArchiveDateDisplayString()
        {
            return getArchiveDate().ToString("yyyy-MM-dd HH:mm") + " (" + System.TimeZone.CurrentTimeZone.DaylightName + ")";
        }


        private static string SiteUrlToArchiveFolderName(string s)
        {
            s = s.Replace("http://", "");
            s = s.Replace(@"\", "_");
            s = s.Replace(@"/", "_");
            s = s.Replace(@":", "_");
            return @"\" + s; 
        }
        #endregion

        #region lnkBrowse
        private void lnkBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DirectoryInfo diArchiveRoot = new DirectoryInfo(txtArchiveDest.Text);
            Util.openFolderInWindowsExplorer(diArchiveRoot.FullName + lblArchiveSubfolder.Text);
        }

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtArchiveDest.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtArchiveDest.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        #endregion

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        
        private void lnkCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i <= cklbDocLibs.Items.Count - 1; i++)
                cklbDocLibs.SetItemChecked(i, true);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        
        #region keepcode temp
        //private void btnArchiveOldFiles_Click(object sender, EventArgs e)
        //{
        //    deleteOldFiles(false);
        //    try
        //    {

        //        //    string lastDocLib = "";
        //        //    int counter = 0;

        //        //    //--loop through each item in _oldFiles, copy to local archive
        //        //    foreach (OldSharepointFile osf in oldFiles)
        //        //    {
        //        //        //--
        //        //        if (lastDocLib != osf.DocumentLibName)
        //        //            SmartStepUtil.AddToRTB(rtbDisplay, osf.DocumentLibName + "\r\n", Color.Blue, 10, true);
        //        //        lastDocLib = osf.DocumentLibName;

        //        //        //--loop through each document in _oldList and move to archive folder, then delete
        //        //        DirectoryInfo diTarget = new DirectoryInfo(
        //        //            txtArchiveDest.Text + @"\" + SiteUrlToArchiveFolderName(txtTargetSite.Text) + @"\" + osf.DocumentLibName);
        //        //        diTarget.Create();

        //        //        SPListItem spItem = web.Lists[osf.DocumentLibName].GetItemByUniqueId(osf.UniqueId);

        //        //        using (FileStream fstream = new FileStream(diTarget.FullName + @"\" + osf.FileName, FileMode.Create))
        //        //        {
        //        //            byte[] b = spItem.File.OpenBinary();
        //        //            fstream.Write(b, 0, b.Length);
        //        //        }
        //        //        counter++;
        //        //    }
        //        //    SmartStepUtil.AddToRTB(rtbDisplay, "[Copied " + counter + " old files from SharePoint to local archive folder]\r\n", Color.Black, 10, false);

        //        //    //--loop through each item in _oldFiles, delete from sharepoint
        //        //    counter = 0;
        //        //    if (System.Windows.Forms.MessageBox.Show(ActionDeleteOldDocs.DefInstance, "All old Files finished copying to local Archive.\r\nGo ahead and delete them from SharePoint?", "Delete OK?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        //    {
        //        //        foreach (OldSharepointFile osf in _oldFiles)
        //        //        {
        //        //            //--delete item
        //        //            SPListItem spItem = web.Lists[osf.DocumentLibName].GetItemByUniqueId(osf.UniqueId);
        //        //            spItem.Delete();
        //        //            counter++;
        //        //        }
        //        //    }
        //        //    SmartStepUtil.AddToRTB(rtbDisplay, "[Deleted " + counter + "  old files from SharePoint]\r\n", Color.Black, 10, false);
        //        //});
        //    }
        //    catch (Exception ex)
        //    {
        //        SmartStepUtil.AddToRTB(rtbDisplay, ex);
        //    }
        //}
        #endregion


    }
}