using System;
using System.Windows.Forms;
using System.Net.Mail;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Diagnostics;

namespace SushiNS
{
    public partial class ActionEmail : SushiNS.ActionParent
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

                MailMessage message = new MailMessage();
                message.From = new MailAddress(txtFromEmail.Text);
                message.To.Add(txtFromEmail.Text);
                message.Subject = _subject;
                message.Body = populateBody();

                SmtpClient client = new SmtpClient(smtp);
                client.Send(message);
                AddToRtbLocal("\r\nDONE. Successfully sent test email to SMTP server.\r\n", StyleType.bodySeaGreen);
            }
            catch (Exception ex)
            {
                AddToRtbLocal("Error while trying to sending mail: " , StyleType.bodyBlack);
                AddToRtbLocal(ex.Message + "\r\n\r\n", StyleType.bodyRed);
            }
        }

        private string populateBody()
        {
            string s = "This is a test email.\r\n";
            s += "sent via SMTP sever:" + txtSMTP.Text;

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
                SPWebApplication webAppAdmin = getCentralAdminWebApplication();
               
                if (webAppAdmin.OutboundMailServiceInstance == null)
                {
                    AddToRtbLocal("Current SMTP Server has not been set. (Outbound Email is not set up.)\r\n", StyleType.bodyBlueBold);
                }
                else
                {
                    string smtpCurrent = webAppAdmin.OutboundMailServiceInstance.Parent.Name;

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

        private SPWebApplication getCentralAdminWebApplication()
        {
            SPFarm farm = SPFarm.Local;
            foreach (SPService service in farm.Services)
            {
                if (service is SPWebService && service.Name == "WSS_Administration")
                {
                    SPWebService ws = (SPWebService)service;
                    foreach (SPWebApplication webApp in ws.WebApplications)
                        return webApp;
                }
            }
            return null;
        }

        private void lnkBrowseToOutboundEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SPWebApplication webApp = getCentralAdminWebApplication();
                string centralAdminUrl = webApp.Sites[0].RootWeb.Url;
                string url = centralAdminUrl + "/_admin/globalemailconfig.aspx";

                Util.OpenURLinDefaultBrowser(url, rtbDisplay);
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

