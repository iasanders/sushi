using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SharePoint;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.Office.Server;
using System.Diagnostics;

namespace SUSHI
{
    public partial class ActionProfileImages : SUSHI.ActionParent
    {
        #region class variables
        public static ActionProfileImages DefInstance;
        private bool _cancelNotice;

        #endregion

        public ActionProfileImages()
        {
            InitializeComponent();
        }

        private void ActionProfileImages_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Profile Images";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtTargetSite.Text = GlobalVars.SETTINGS.profilePics_targetSharepointSite;
            txtLocalSourceDir.Text = GlobalVars.SETTINGS.profilePics_sourceDir;

            txtDomainName.Text = System.Environment.UserDomainName;

            displayNotes();
        }

        private void displayNotes()
        {
            AddToRtbLocal("Notes:", StyleType.bodyChocolate);
            string s = @"This feature allows you to bulk upload images for your user profiles and update the user profile to point to the image. This image will display on the user's MySite page and in the user profile. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Profile%20Images&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        #region Property Set on Control Events
        private void txtSiteUrl_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.profilePics_targetSharepointSite = txtTargetSite.Text;
        }

        private void txtLocalSourceDir_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.profilePics_sourceDir = txtLocalSourceDir.Text;
        }

        private void cboDocLib_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.profilePics_targetPictureLibary = cboPictureLibName.Text;
        }
        #endregion

        private SPUser GetSiteUser(SPWeb web, string userName)
        {
            foreach (SPUser user in web.AllUsers)
                if (user.LoginName.ToUpper() == userName.ToUpper())
                    return user;
            return null;
        }

        private void lnkClearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rtbDisplay.Clear();
        }

        private void lnkSaveLog_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string datePart = DateTime.Now.ToString("yyyy.MM.dd.hhmmss");
            string logFilename = @"SUSHI_ProfilePicsLog_" + datePart + ".doc";
            Util.SaveLogFile(rtbDisplay, logFilename);
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtLocalSourceDir.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLocalSourceDir.Text = folderBrowserDialog1.SelectedPath;
                GlobalVars.SETTINGS.profilePics_sourceDir = folderBrowserDialog1.SelectedPath;
            }
        }

        private void lnkOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.openFolderInWindowsExplorer(txtLocalSourceDir.Text);
        }

        #region UploadProfileImages
        private void btnValidate_Click(object sender, EventArgs e)
        {
            validateAndUploadProfileImages1(true);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            validateAndUploadProfileImages1(false);
        }

        private void validateAndUploadProfileImages1(bool onlyValidate)
        {
            rtbDisplay.Clear();

            //--validate web URL
            SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
            if (web == null) return;

            if (!Directory.Exists(txtLocalSourceDir.Text))
            {
                AddToRtbLocal("Source Folder " + txtLocalSourceDir.Text + " does not exist\r\n", StyleType.bodyRed);
                return;
            }

            //--
            _cancelNotice = false;
            Util.ToggleCancelLink(Util.ToggleCancelState.begin, lnkCancel);

            //-- call asynchronously
            del1 d1 = new del1(validateAndUploadProfileImages2);
            d1.BeginInvoke(onlyValidate, cboPictureLibName.Text, null, null);
        }

        private delegate void del1(bool alsoUpload, string pictureLibName);
        private void validateAndUploadProfileImages2(bool onlyValidate, string pictureLibName)
        {
            try
            {
                if (onlyValidate)
                {
                    AddToRtbLocal("Validating that pictures in source directory ", StyleType.bodyChocolateBold);
                    AddToRtbLocal(txtLocalSourceDir.Text, StyleType.bodyBlueBold);
                    AddToRtbLocal(" have a corresponding user profile\r\n", StyleType.bodyChocolateBold);
                }
                else
                {
                    AddToRtbLocal("Uploading pictures from source directory ", StyleType.bodyChocolateBold);
                    AddToRtbLocal(txtLocalSourceDir.Text, StyleType.bodyBlueBold);
                    AddToRtbLocal(" to ", StyleType.bodyChocolateBold);
                    AddToRtbLocal(pictureLibName, StyleType.bodyBlueBold);
                    AddToRtbLocal(" and assigning URL to user profile\r\n", StyleType.bodyChocolateBold);
                }

                if (!Directory.Exists(txtLocalSourceDir.Text))
                {
                    Util.ShowMessageBox("Not a valid source folder: '" + txtLocalSourceDir.Text + "'");
                    return;
                }

                DirectoryInfo diSourceDir = new DirectoryInfo(txtLocalSourceDir.Text);
                using (SPSite siteCol = new SPSite(txtTargetSite.Text)) //note, unable to call Util.RetrieveWeb(), because it throws asynchronous errors or COM errors
                {
                    SPWeb web = siteCol.OpenWeb();
                    SPServiceContext context = SPServiceContext.GetContext(web.Site);
                    UserProfileManager profileManager = new UserProfileManager(context);

                    SPList pictureLib = null;
                    if (!onlyValidate)
                    {
                        try
                        {
                            pictureLib = web.Lists[pictureLibName];
                        }
                        catch (Exception)
                        {
                            AddToRtbLocal("Unable to retrieve Picture Library\r\n", StyleType.bodyRed);
                            return;
                        }
                    }

                    string domain = txtDomainName.Text.ToUpper();
                    foreach (FileInfo fiImg in diSourceDir.GetFiles())
                    {
                        if (_cancelNotice)
                            throw new Eh.CancelException();

                        //--validate that picture has valid extension
                        if (".gif.jpg.jpeg.png".IndexOf(fiImg.Extension.ToLower()) == -1)
                        {
                            AddToRtbLocal(fiImg.Name + "   needs extention of .gif .jpg .jpeg .png ", StyleType.bodyRed, SmartStepUtil.enumIcon.red_x);
                            AddToRtbLocal("\r\n", StyleType.bodyBlack);
                            continue;
                        }

                        //--validate that user exists
                        string UserLoginString = domain + @"\" + fiImg.Name.Remove(fiImg.Name.Length - fiImg.Extension.Length, fiImg.Extension.Length);

                        if (profileManager.UserExists(UserLoginString))
                        {
                            //--upload image to document library
                            AddToRtbLocal(fiImg.Name + " => " + UserLoginString + " ", StyleType.bodyBlackBold, SmartStepUtil.enumIcon.green_check);
                            if (!onlyValidate)
                            {
                                pictureLib.RootFolder.Files.Add(fiImg.Name, Util.getFileBytes(fiImg.FullName), true);
                                AddToRtbLocal("  Image Uploaded", StyleType.bodySeaGreen);
                            }
                            AddToRtbLocal("\r\n", StyleType.bodyBlack);

                            //--set user profile picture property
                            if (!onlyValidate)
                            {
                                UserProfile u = profileManager.GetUserProfile(UserLoginString);
                                string picUrl = web.Url.TrimEnd('/') + "/" + pictureLib.RootFolder.Name + "/" + fiImg.Name;

                                u[PropertyConstants.PictureUrl].Value = picUrl;
                                u.Commit();

                                AddToRtbLocal("  Profile picture URL set to: " + picUrl + "\r\n", StyleType.bodyDarkGray);
                            }
                        }
                        else
                        {
                            if (GetSiteUser(web, UserLoginString) == null) // this tests whether the user is authenticated. It is possible to authenticate, but not have a Profile in the SSP.
                                AddToRtbLocal(fiImg.Name + " => " + UserLoginString + "   not a valid site user ", StyleType.bodyOrange, SmartStepUtil.enumIcon.red_x);
                            else
                                AddToRtbLocal(fiImg.Name + " => " + UserLoginString + "   valid site user, but no SSP profile ", StyleType.bodyOrange, SmartStepUtil.enumIcon.red_x);
                            AddToRtbLocal("\r\n", StyleType.bodyBlack);
                        }
                    }
                }
                AddToRtbLocal("\r\nDONE\r\n", StyleType.titleSeagreen);
                SmartStepUtil.ScrollToBottom(rtbDisplay);
            }
            catch (Eh.CancelException)
            {
                AddToRtbLocal("Upload Cancelled by user\r\n", StyleType.bodyRed);
            }
            catch (Exception ex)
            {
                AddToRtbLocal("error: " + ex.Message + "r\n", StyleType.bodyRed);
            }
            finally
            {
                Util.ToggleCancelLink(Util.ToggleCancelState.end, lnkCancel);
                _cancelNotice = false;
            }
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _cancelNotice = true;
            Util.ToggleCancelLink(Util.ToggleCancelState.pressCancel, lnkCancel);
        }
        #endregion

        #region control events


        private void btnRetrieveDocLibs_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                cboPictureLibName.Items.Clear();

                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
                if (web == null) return;
                foreach (SPList list in web.Lists)
                {
                    if (list.BaseType.ToString() == "DocumentLibrary" && !Util.DocumentLibraryNamesToExclude.Contains(list.ToString()))
                    {
                        cboPictureLibName.Items.Add(list.RootFolder.Name);
                        if (list.RootFolder.Name == GlobalVars.SETTINGS.profilePics_targetPictureLibary)
                            cboPictureLibName.SelectedIndex = cboPictureLibName.FindString(list.RootFolder.Name);
                    }
                }
                if (cboPictureLibName.SelectedIndex == -1)
                    cboPictureLibName.DroppedDown = true;
            }
            finally
            {
                MainForm.DefInstance.Cursor = Cursors.Default;
            }
        }


        #endregion


        #region AddToRtbLocal
        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style, SmartStepUtil.enumIcon.no_icon);
        }

        private void AddToRtbLocal(string strText, StyleType style, SmartStepUtil.enumIcon icon)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style, icon);
        }
        #endregion

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void imgBrowse_Click(object sender, EventArgs e)
        {
            if (cboPictureLibName.SelectedItem == null)
                return;

            string url = txtTargetSite.Text + "/" + cboPictureLibName.SelectedItem.ToString();
            Util.OpenURLinDefaultBrowser(url, rtbDisplay);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }



    }
}

