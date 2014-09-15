using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace SUSHI
{
    public static class SushiHelp
    {
        /// <summary>
        /// Generate a LinkLabel to the right of a control which will open the corresponding Wiki help page for that control.
        /// </summary>
        public static void createHelpLinkLabel(Control control, string helpKey)
        {
            try
            { 
                LinkLabel lnk = new LinkLabel();
                lnk.Text = "?";
                lnk.Location = new System.Drawing.Point(control.Left + control.Width + 1, control.Top);
                lnk.Tag = helpKey;
                lnk.Width = 16;
                lnk.Height = 16;
                lnk.Font = new System.Drawing.Font("Courier New", 10);
                control.Parent.Controls.Add(lnk);
                lnk.BringToFront();

                lnk.LinkClicked += new LinkLabelLinkClickedEventHandler(lnk_LinkClicked);  
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }
         
        private static void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lnk = (LinkLabel)sender;
            if (lnk.Tag == null)
            {
                Util.ShowMessageBox("Unable to retrieve helpKey from control " + lnk.Name + " because it blank");
                return;
            }
            ShowHelpLink((string)lnk.Tag);
        }

        /// <summary>
        /// Open Browser and show help wiki hosted at www.codeplex.com
        /// </summary>
        public static void ShowHelpLink(string helpKey)
        {
            //--example URL:          http://www.codeplex.com/sushi/Wiki/View.aspx?title=SettingsAndHelp
            string url;
            if (helpKey == "HOME")
                url = "http://www.codeplex.com/sushi";
            else
            {
                helpKey = helpKey.Replace(" ", "%20");
                url = "http://www.codeplex.com/sushi/Wiki/View.aspx?title=" + helpKey;
            }
            Process.Start(url);
        }

    }
}
