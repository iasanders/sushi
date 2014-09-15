using System;
using System.Windows.Forms;
using System.Net.Mail;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Diagnostics;
using SUSHI.Core.Administrative;

namespace SUSHI
{
    public partial class ActionEmail : SUSHI.ActionParent
    {
        public static ActionEmail DefInstance;

        public ActionEmail()
        {
            InitializeComponent();
        }

        string _subject = "Test Email from SharePoint SUSHI";

        private void ActionEmail_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Email Test";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            //--remember these values
            txtFromEmail.Text = GlobalVars.SETTINGS.settings_testEmailFrom;
            txtSMTP.Text = GlobalVars.SETTINGS.settings_testEmailSMTP;
            this.txtSMTP.TextChanged += new System.EventHandler(this.txtSMTP_TextChanged);
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            string s = @"Use the Email Test SUSHI tab to test if outbound email is set up correctly. In SharePoint Central Administration you can specify an ""Outbound SMTP server"" which is used to generate emails for alerts, and notifications. In order for outbound email to successfully send, the SMTP server needs to allow anonymous relaying from the IP addresses of the web front end servers in your SharePoint Farm. If email is set up correctly, SUSHI will display ""Successfully sent test email to SMTP server."" which means that the SMTP server recieved the email request and did not throw an error and you should shortly recieve an email. If email is set up incorrectly, you will see an error message and SUSHI will display in red the error message thrown. Unfortunately, SUSHI can't always tell you exactly why the SMTP server failed to send because it isn't possible to detect how your SMTP server is set up, but at least you know immediately that it failed, and you will know that it is a SMTP routing issue and not a SharePoint timer issue, or some other SharePoint problem.When you press the ""Send Test Email"" button, SUSHI simply instantiates a MailMessage object and uses the System.Net.Mail.SmtpClient class to attempt to send an email. The subject of the email will be """ + _subject + @""". Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Email%20Test&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }

        /// <summary>
        /// Sends a test email.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                rtbDisplay.Clear();

                string smtp = txtSMTP.Text.Trim();
                AddToRtbLocal("Sending test message to ", StyleType.bodyChocolate);
                AddToRtbLocal(txtFromEmail.Text, StyleType.bodyBlue);
                AddToRtbLocal(" via SMTP server ", StyleType.bodyChocolate);
                AddToRtbLocal(smtp + "\r\n", StyleType.bodyBlue);

                SPEmail.SendEmail(smtp, txtFromEmail.Text, txtFromEmail.Text, _subject, populateBody(smtp));
                AddToRtbLocal("\r\nDONE. Successfully sent test email to SMTP server.\r\n", StyleType.bodySeaGreen);
            }
            catch (Exception ex)
            {
                AddToRtbLocal("Error while trying to sending mail: " , StyleType.bodyBlack);
                AddToRtbLocal(ex.Message + "\r\n\r\n", StyleType.bodyRed);
            }
        }

        private string populateBody(string smtp)
        {
            string s = "This is a test email.\r\n";
            s += "sent via SMTP sever:" + smtp;

            return s;
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        #region Save Settings
        private void txtSMTP_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.settings_testEmailSMTP = txtSMTP.Text;
        }

        private void txtFromEmail_TextChanged(object sender, EventArgs e)
        {
            txtToEmail.Text = txtFromEmail.Text;
            GlobalVars.SETTINGS.settings_testEmailFrom = txtFromEmail.Text;
        }
        #endregion


        private void lnkDisplayCurrentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.DefInstance.Cursor = Cursors.WaitCursor;
            rtbDisplay.Clear();
            Application.DoEvents();
            AddToRtbLocal("Looking up current outbound email settings\r\n", StyleType.bodyChocolate);
            try
            {
                string smtpCurrent = SPEmail.GetCurrentSMTPSettings();
                if (string.IsNullOrEmpty(smtpCurrent))
                {
                    AddToRtbLocal("Current SMTP Server has not been set. (Outbound Email is not set up.)\r\n", StyleType.bodyBlueBold);
                }
                else
                {
                    AddToRtbLocal("Current SMTP Server for outbound email: ", StyleType.bodyBlack);
                    AddToRtbLocal(smtpCurrent + "\r\n", StyleType.bodyBlue);
                }


            }
            catch (Exception ex)
            {
                AddToRtbLocal("Error: " + ex.Message, StyleType.bodyRed);
            }
            finally
            {
                MainForm.DefInstance.Cursor = Cursors.Default;
            }
        }

        private void lnkBrowseToOutboundEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string emailConfigurationURL = SPEmail.GetMailConfiugrationURL();
                Util.OpenURLinDefaultBrowser(emailConfigurationURL, rtbDisplay);
            }
            catch (Exception ex)
            {
                AddToRtbLocal(ex.Message, StyleType.bodyRed);
            }
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        } 
    }
}

