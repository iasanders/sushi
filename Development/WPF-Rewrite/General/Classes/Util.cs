using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace SUSHI
{
    public static class Util
    {
        private static List<string> documentLibraryNamesToExclude;
        public static List<string> DocumentLibraryNamesToExclude
        {
            get
            {
                if (documentLibraryNamesToExclude == null)
                {
                    documentLibraryNamesToExclude = new List<string>();
                    DocumentLibraryNamesToExclude.AddRange(new string[] { "Master Page Gallery", "List Template Gallery", "Site Template Gallery", "Web Part Gallery" });
                }
                return documentLibraryNamesToExclude;
            }
        }

        public static void ShowMessageBox(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "SharePoint SUSHI", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// note: not threadsafe
        /// </summary>
        public static SPWeb RetrieveWeb(string siteUrl, RichTextBox rtbValidateMessage)
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                rtbValidateMessage.Clear();
                if (siteUrl.Trim() == "")
                {
                    SmartStepUtil.AddToRTB(rtbValidateMessage, "site URL is blank", Color.Red, 8, false, SmartStepUtil.enumIcon.red_x);
                    return null;
                }

                SPSite site;
                try
                {
                    site = new SPSite(siteUrl);
                }
                catch (Exception ex)
                {
                    SmartStepUtil.AddToRTB(rtbValidateMessage, "site not found: " + ex.Message + " ", Color.Red, 8, false, SmartStepUtil.enumIcon.red_x);
                    return null;
                }

                SPWeb web = site.OpenWeb();
                SmartStepUtil.AddToRTB(rtbValidateMessage, "site found: " + web.Url + " ", Color.Green, 8, false, SmartStepUtil.enumIcon.green_check);
                return web;
            }
            finally
            {MainForm.DefInstance.Cursor = Cursors.Default;}
        }

        public static string StripCharactersSharepointDoesNotLike(string dirtyName)
        {
            //-- illegal characters: \ / : * ? " < > | # { } % ~ &
            //-- illegal to have two periods in a row.
            string cleanName = dirtyName.Replace(@"%20", " ");
            cleanName = Regex.Replace(cleanName, @"[\\/:*?""<>|#{}%~&]", "");
            cleanName = cleanName.Replace("..", ".");
            return cleanName;
        }

        public static void SaveLogFile(RichTextBox rtb, string logFileName)
        {
            FileInfo fi = new FileInfo(GlobalVars.LogFilesDir + @"\" + logFileName);

            System.IO.File.AppendAllText(fi.FullName, rtb.Rtf);

            int x = MainForm.DefInstance.tvNav.Width + rtb.Width - 450;
            int y = MainForm.DefInstance.pictureBoxTop.Height + rtb.Location.Y - 15;
            ToolTip tt = new ToolTip();
            tt.AutoPopDelay = 30000;
            tt.InitialDelay = 1;
            tt.ReshowDelay = 1;
            tt.Show("Log saved as " + fi.FullName, MainForm.DefInstance, x, y, 5000);
        }

        public static void openFolderInWindowsExplorer(string dest)
        {
            if (Directory.Exists(dest))
                System.Diagnostics.Process.Start(@"C:\WINDOWS\explorer.exe", dest + @" ,/e");
            else
                Util.ShowMessageBox("Directory '"+ dest + "' does not exist");
        }

        public static void OpenURLinDefaultBrowser(string url,RichTextBox rtbIfError)
        {
            try
            {
                SmartStepUtil.ClearRtbSafely(rtbIfError);
                if (string.IsNullOrEmpty(url))
                {
                    SmartStepUtil.AddToRTB(rtbIfError, "Unable to browse because URL is blank.", StyleType.bodyOrange);
                    return;
                }
                Process.Start(url);
            }
            catch (Exception ex)
            {
                SmartStepUtil.AddToRTB(rtbIfError, "Unable to browse to " + url + ", error:" + ex.Message, StyleType.bodyRed);
            }
        }

        internal static Byte[] getFileBytes(string fileName)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = File.OpenRead(fileName);
                Byte[] Contents = new byte[Convert.ToInt32(fileStream.Length)];
                fileStream.Read(Contents, 0, Convert.ToInt32(fileStream.Length));
                return Contents;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        private delegate void del1(RichTextBox rtb);
        public static void ClearRtbSafely(RichTextBox rtb)
        {
            if (rtb.InvokeRequired)
            {
                rtb.BeginInvoke(new del1(ClearRtbSafely), new object[] { rtb });
                return;
            }

            rtb.Clear();
        }

        public enum ToggleCancelState
        {
            begin,
            end,
            pressCancel
        }
        private delegate void delTog(ToggleCancelState tcs,LinkLabel lnkCancel);
        internal static void ToggleCancelLink(ToggleCancelState tcs,LinkLabel lnkCancel)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                MainForm.DefInstance.Invoke(new delTog(ToggleCancelLink), new object[] { tcs, lnkCancel });
                return;
            }

            switch (tcs)
            {
                case ToggleCancelState.begin:
                    lnkCancel.Text = "Cancel Upload";
                    lnkCancel.Enabled = true;        
                    break;
                case ToggleCancelState.end:
                    lnkCancel.Text = "";
                    lnkCancel.Enabled = false;
                    break;
                case ToggleCancelState.pressCancel:
                    lnkCancel.Text = "Cancel Pending..";
                    lnkCancel.Enabled = false;
                    break;
            }
        }

        public static string ToStr(object s)
        {
            if (s == null)
                return string.Empty;
            else if (s == DBNull.Value)
                return string.Empty;
            else
                return s.ToString();
        }

        public static object DeepCopy(object obj)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(ms, obj);

                object retval;
                ms.Seek(0, SeekOrigin.Begin);
                retval = bf.Deserialize(ms);
                ms.Close();
                return retval;
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
                return null;
            }
        } 

        public static string V(bool onlyValidate)
        {
            return onlyValidate ? " (validating only)" : "";
        }

        public static XmlAttribute MakeAttribute(XmlDocument xDoc, string name, string value)
        {
            XmlAttribute att = xDoc.CreateAttribute(name);
            att.Value = value;
            return att;
        }

        public static void PopulateComboboWithSharePointLists(SPWeb web, ComboBox cbo, bool pleaseDropdown, bool onlyDocLibs)
        {
            cbo.Items.Clear();
            foreach (SPList list in web.Lists)
            {
                if ((list.GetType().Name == "SPDocumentLibrary" || !onlyDocLibs) && !DocumentLibraryNamesToExclude.Contains(list.Title))
                   cbo.Items.Add(list);
            }
            if (pleaseDropdown)
                cbo.DroppedDown = true;
        }
    }
}
