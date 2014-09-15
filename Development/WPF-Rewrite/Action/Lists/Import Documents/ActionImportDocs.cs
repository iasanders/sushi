using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SharePoint;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SUSHI
{
    public partial class ActionImportDocs : SUSHI.ActionParent
    {
        public static ActionImportDocs DefInstance;
        bool _cancelNotice;
        int _dispGrandTotalFiles;
        int _dispErroredFiles;
        int _dispIllegalChars;
        int _dispIllegalFileExtentions;
        long _dispGrandTotalFilesize;

        public ActionImportDocs()
        {
            InitializeComponent();
        }

        private void ActionImportDocs_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Upload";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtTargetSite.Text = GlobalVars.SETTINGS.upload_targetSharepointSite;
            txtLocalSourceDir.Text = GlobalVars.SETTINGS.upload_localSourceDir;
            txtFileExtentionsToExclude.Text = GlobalVars.SETTINGS.upload_fileExtentionsToExclude;
            if (!string.IsNullOrEmpty(GlobalVars.SETTINGS.upload_createRootFolder) && (GlobalVars.SETTINGS.upload_createRootFolder == "yes"))
                chkCreateRootFolderInSharepoint.Checked = true;
            chkCreateRootFolderInSharepoint.CheckedChanged += new EventHandler(chkCreateRootFolderInSharepoint_CheckedChanged);
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            string s = @"This feature allows you to import entire directory trees into a Sharepoint Document Library. It will loop through all documents from the source folder and all subfolders of the source folder and recreate that file structure within the target sharepoint document library. It also removes any illegal characters, forexample % and # which are valid windows file names, but not valid sharepoint document filenames. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Upload&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        private void btnRetrieveDocLibs_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbValidateMessage);
                if (web == null) return;
                txtTargetSite.Text = web.Url;

                Util.PopulateComboboWithSharePointLists(web, this.cboDocLib, true, true);
            }
            finally
            {
                MainForm.DefInstance.Cursor = Cursors.Default;
            }
        }

        #region UploadFolderTree
        private void btnValidate_Click(object sender, EventArgs e)
        {
            importFiles(true);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            importFiles(false);
        }

        private void importFiles(bool onlyValidate)
        {
            rtbDisplay.Clear();

            AddToRtbLocal("Importing Files from File System into a SharePoint Document Library " + Util.V(onlyValidate) + "\r\n", StyleType.bodyChocolateBold);


            toggleCancel(false, true, false);
            _dispGrandTotalFiles = 0; _dispGrandTotalFilesize = 0; _dispErroredFiles = 0; _dispIllegalChars = 0; _dispIllegalFileExtentions = 0;
            _cboDocLibText = cboDocLib.Text;

            if (!ValidateFolders() || onlyValidate)
            {
                toggleCancel(false, false, true);
                return;
            }

            MethodInvoker mi = new MethodInvoker(uploadAFolderPrep);
            mi.BeginInvoke(null, null);
        }

        private bool ValidateFolders()
        {
            if (cboDocLib.SelectedItem == null)
                return false;

            SPList list = (SPList)cboDocLib.SelectedItem;
            //--web
            AddToRtbLocal("Destination Document Library: ", StyleType.bodyBlack);
            AddToRtbLocal(list.Title, StyleType.bodyBlue);
            AddToRtbLocal(" in site ", StyleType.bodyBlack);
            AddToRtbLocal(list.ParentWeb.Url + "\r\n", StyleType.bodyBlue);

            //--source folder
            AddToRtbLocal("Source File Folder:", StyleType.bodyBlack);
            AddToRtbLocal(txtLocalSourceDir.Text, StyleType.bodyBlue);

            validOrInvalid(Directory.Exists(txtLocalSourceDir.Text));

            //--all three conditions must be true to return true
            return Directory.Exists(txtLocalSourceDir.Text);
        }

        string _cboDocLibText; //this variable is to prevent cross-thread errors
        private void uploadAFolderPrep()
        {
            try
            {
                SPSite sps = new SPSite(txtTargetSite.Text); //note, unable to call Util.RetrieveWeb(), because it throws COM errors..
                SPWeb web = sps.OpenWeb();

                //--kickoff
                DirectoryInfo localSourceDirRoot = new DirectoryInfo(txtLocalSourceDir.Text);
                SPFolder docLibFolder = web.GetFolder(_cboDocLibText);


                SmartStepUtil.AddToRTB(rtbDisplay, "Upload Started\r\n", Color.Black, 12, true);
                if (!chkCreateRootFolderInSharepoint.Checked) SmartStepUtil.AddToRTB(rtbDisplay, "uploading files in root folder\r\n");
                UploadAFolder(docLibFolder, localSourceDirRoot, chkCreateRootFolderInSharepoint.Checked);
                SmartStepUtil.AddToRTB(rtbDisplay, txtDispCounters.Text + "\r\n", Color.Brown, 8, false);
                SmartStepUtil.AddToRTB(rtbDisplay, "Upload Completed\r\n\r\n\r\n", Color.Green, 12, true);
            }
            catch (Eh.CancelException)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Upload Cancelled by user\r\n", Color.Red, 12, true);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            toggleCancel(false, false, true);
            SmartStepUtil.ScrollToBottom(rtbDisplay);
        }

        /// <summary>
        /// loop through each file in localFOlder and upload it, then call self with each subfolder.
        /// </summary>
        private void UploadAFolder(SPFolder spFolder, DirectoryInfo localFolder, bool createFolder)
        {
            if (_cancelNotice)
                throw new Eh.CancelException();

            //--
            SPFolder newSpSubFolder;
            if (createFolder)
            {
                string cleanFolderName = CleanFileOrFolderName(localFolder.Name);
                newSpSubFolder = spFolder.SubFolders.Add(cleanFolderName);
                SmartStepUtil.AddToRTB(rtbDisplay, "created folder: " + newSpSubFolder.ServerRelativeUrl + "\r\n");
            }
            else
                newSpSubFolder = spFolder;

            int localCounter = 0;
            long localTotalLength = 0;
            foreach (FileInfo fi in localFolder.GetFiles())
            {
                if (_cancelNotice)
                    throw new Eh.CancelException();
                if (!skipFile(fi))
                {
                    string cleanName = CleanFileOrFolderName(fi.Name);
                    try
                    {
                        newSpSubFolder.Files.Add(cleanName, Util.getFileBytes(fi.FullName), true);
                    }
                    catch (Exception ex)
                    {
                        _dispErroredFiles += 1;
                        SmartStepUtil.AddToRTB(rtbDisplay, "Error while uploading file '" + fi.FullName + "' " + ex.Message, Color.Red, 8, false);
                    }

                    localCounter++;
                    _dispGrandTotalFiles++;
                    localTotalLength += fi.Length;
                    _dispGrandTotalFilesize += fi.Length;
                }
            }
            SmartStepUtil.AddToRTB(rtbDisplay, "    [" + localCounter + " files " + localTotalLength.ToString("#,##0") + " bytes]\r\n", Color.DarkGray, 8, false);
            ShowCounters();
            foreach (DirectoryInfo localSubDir in localFolder.GetDirectories())
            {
                if (localSubDir.Name.ToUpper() == "FORMS")
                    SmartStepUtil.AddToRTB(rtbDisplay, "    skipping illegal Folder named 'Forms' , full path= " + localSubDir.FullName + " please rename it and try to upload again.\r\n", Color.Magenta, 8, false);
                else
                    UploadAFolder(newSpSubFolder, localSubDir, true);
            }
        }
        #endregion

        #region ActionImportUtils
        private string CleanFileOrFolderName(string dirtyFileName)
        {
            string cleanName = Util.StripCharactersSharepointDoesNotLike(dirtyFileName);
            if (cleanName != dirtyFileName)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "    RENAMED FILE: '" + dirtyFileName + "' renamed to '" + cleanName + "'\r\n", Color.Purple, 8, false);
                _dispIllegalChars++;
            }
            return cleanName;
        }

        private bool skipFile(FileInfo fi)
        {
            List<string> extsToSkip = new List<string>();
            extsToSkip.AddRange(txtFileExtentionsToExclude.Text.Split(new char[] { ';' }));
            extsToSkip.AddRange(txtFileExtToExcludeAutomatically.Text.Split(new char[] { ';' }));

            //--custom code for MISD:
            if (fi.Name == ".permissions" || fi.Name == ".rules" || fi.Name == ".stages")
                return true;

            foreach (string item in extsToSkip)
            {
                if ("." + item.ToUpper() == fi.Extension.ToUpper())
                {
                    SmartStepUtil.AddToRTB(rtbDisplay, "    SKIPPED FILE: '" + fi.Name + "', illegal file type: '." + item + "'\r\n", Color.Orange, 8, false);
                    _dispIllegalFileExtentions++;
                    return true;
                }
            }
            return false;
        }

        private delegate void delegate1();
        private void ShowCounters()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delegate1(ShowCounters));
                return;
            }
            //Total Files:0  Total Bytes:0  Errors:0  Blocked Extention:0  Renamed Files:0
            txtDispCounters.Text = string.Format("Total Files:{0}  Total Bytes:{1}  Errors:{2}  Blocked Filetypes:{3}  Renamed Files:{4}",
                _dispGrandTotalFiles, _dispGrandTotalFilesize.ToString("#,##0"), _dispErroredFiles, _dispIllegalFileExtentions, _dispIllegalChars);
        }
        #endregion

        #region control events
        private void txtFileExtentionsToExclude_Leave(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.upload_fileExtentionsToExclude = txtFileExtentionsToExclude.Text;
        }



        private void validOrInvalid(bool isValid)
        {
            if (isValid)
                SmartStepUtil.AddToRTB(rtbDisplay, " valid ", Color.Green, 10, false, SmartStepUtil.enumIcon.green_check);
            else
                SmartStepUtil.AddToRTB(rtbDisplay, " invalid ", Color.Red, 10, false, SmartStepUtil.enumIcon.red_x);

            SmartStepUtil.AddToRTB(rtbDisplay, "\r\n");
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toggleCancel(true, false, false);
        }

        private delegate void del1(bool v1, bool v2, bool v3);
        private void toggleCancel(bool cancel, bool lnkCancelEnabledState, bool btnUploadEnableState)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                MainForm.DefInstance.Invoke(new del1(toggleCancel), new object[] { cancel, lnkCancelEnabledState, btnUploadEnableState });
                return;
            }
            _cancelNotice = cancel;
            lnkCancel.Text = cancel ? "Cancel Pending.." : "Cancel Upload";
            lnkCancel.Enabled = lnkCancelEnabledState;
            btnUpload.Enabled = btnUploadEnableState;
        }

        void chkCreateRootFolderInSharepoint_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.upload_createRootFolder = chkCreateRootFolderInSharepoint.Checked ? "yes" : "no";
        }

        private void txtSiteURL_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.upload_targetSharepointSite = ActionImportDocs.DefInstance.txtTargetSite.Text;
        }

        private void txtTargetSpWeb_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //--
                btnUpload.Enabled = false;
                cboDocLib.Items.Clear();

                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbValidateMessage);
                if (web == null) return;

                //--
                foreach (SPList list in web.Lists)
                {
                    if (list.BaseType.ToString() == "DocumentLibrary" && !Util.DocumentLibraryNamesToExclude.Contains(list.ToString()))
                    {
                        cboDocLib.Items.Add(list.RootFolder.Name);
                        if (list.RootFolder.Name == GlobalVars.SETTINGS.upload_targetDocLib)
                            cboDocLib.SelectedIndex = cboDocLib.FindString(list.RootFolder.Name);
                    }
                }
                btnUpload.Enabled = true;
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }

        private void cboDocLib_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.upload_targetDocLib = cboDocLib.Text;
        }

        private void txtLocalSourceDir_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.upload_localSourceDir = txtLocalSourceDir.Text;
        }
        #endregion control events


         
        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        private void imgBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                SPList list = (SPList)cboDocLib.SelectedItem;
                if (list == null)
                    return;
                string url = list.ParentWeb.Url + "/" + list.RootFolder.Url;
                Util.OpenURLinDefaultBrowser(url, rtbDisplay);
            }
            catch (Exception ex)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, ex);
            }
        }

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void imgBrowseSource_Click(object sender, EventArgs e)
        {
            this.fbdSource.ShowDialog();
            this.txtLocalSourceDir.Text = fbdSource.SelectedPath;
        }


        //Import Files into SharePoint, good link:
        //http://simplyaprogrammer.com/2008/05/importing-files-into-sharepoint.html

        #region Keep code
        //--
        //txtTargetSpWeb_Validating(null, null);

        //--
        //SushiHelp.createHelpLinkLabel(chkCreateRootFolderInSharepoint, "Upload"); //note, needs to point to: "Create_Root_Folder"
        //SushiHelp.createHelpLinkLabel(lblExtToExclude, "Upload"); //note, point to File_Extentions_to_Exclude
        //SushiHelp.createHelpLinkLabel(lblHelp, "Upload");


        //private void lnkSaveLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        string datePart = DateTime.Now.ToString("yyyy-MM-dd_hhmmss");
        //        string logFilename = @"SUSHI_ImportLog_" + datePart + "_" + cboDocLib.Text + ".doc";

        //        Util.SaveLogFile(rtbDisplay, logFilename);

        //    }
        //    catch (Exception ex)
        //    {
        //        Eh.GlobalErrorHandler(ex);
        //    }
        //}

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        SPSite sps = new SPSite(txtTargetSpWeb.Text);
        //        _web = sps.OpenWeb();

        //        string s = new string('s', 129);
        //        //string s = new string('s', 22);
        //        FileInfo fi = new FileInfo(@"C:\zTempDocsC\" + s);

        //        using (FileStream fs = new FileStream(fi.FullName, FileMode.Create))
        //        {
        //            fs.WriteByte(new byte());
        //        }

        //        SPFolder docLibFolder = _web.GetFolder(txtDocLib.Text);
        //        docLibFolder.Files.Add(fi.Name, getFileBytes(fi.FullName));
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        #endregion

    }
}

