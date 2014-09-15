using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.IO;
using System.Reflection;

namespace SushiNS
{
    public partial class ActionBulkWebPartCustomization : SushiNS.ActionParent
    {
        public static ActionBulkWebPartCustomization DefInstance;

        public ActionBulkWebPartCustomization()
        {
            InitializeComponent();
        }

        private void ActionBulkSiteCreation_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Bulk Webpart Customization";
            txtTargetSite.Text = GlobalVars.SETTINGS.bulkWebPartCreate_siteUrl;

            //--
            populateWebpartCustomizationProfiles();
        }

        #region populateWebpartCustomizationProfiles
        /// <summary>
        /// The Logic for the WebPart Customization is contained in a separate DLL because it is customer-specifc. 
        /// So SUSHI looks for any DLL in the same directory and uses reflection to load it.
        /// </summary>
        private void populateWebpartCustomizationProfiles()
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
            foreach (FileInfo fi in di.GetFiles("SushiClientLibrary_*.dll"))
            {
                try 
	            {
                    Assembly asm = Assembly.LoadFile(fi.FullName);

                    Type t = Assembly.LoadFile(fi.FullName).GetType("SushiClientLibrary_P1.ActionBulkWebPartCustomization_p1");
                    WebpartBulkClientLibParentProfile profile = (WebpartBulkClientLibParentProfile)Activator.CreateInstance(t);
                    //--set a reference to the rtbDisplay so text can be written to it.
                    profile.InitializeStuff(rtbDisplay);

                    cboProfiles.Items.Add(profile);
                }
	            catch (Exception ex)
	            {
		            AddToRtbLocal("Problem loading assembly from " + fi.FullName + " " + ex.Message, StyleType.bodyBlue);
	            }
                //--select default
                cboProfiles.SelectedIndex = cboProfiles.FindStringExact(GlobalVars.SETTINGS.bulkWebPartCustomization_defaultProfile);

            }
        }

        public abstract class WebpartBulkClientLibParentProfile
        {
            public abstract void DoWebpartCustomization(bool onlyValidate, TextBox txtTargetSite, RichTextBox rtbSiteValidateMessage);

            public RichTextBox RtbDisplay;
            public virtual void InitializeStuff(RichTextBox rtb)
            {
                this.RtbDisplay = rtb;
            }
        }
        #endregion

        #region SETTINGS update on Control Events
        private void cboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.bulkWebPartCustomization_defaultProfile = cboProfiles.SelectedItem.ToString();
        }
        
        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.bulkWebPartCreate_siteUrl = txtTargetSite.Text;
        }
        #endregion

        #region bulk webpart customize
        private void btnValidate_Click(object sender, EventArgs e)
        {
            DoWebpartBulkCustomization(true);
        }

        private void btnWebpartsToCreateList_Click(object sender, EventArgs e)
        {
            DoWebpartBulkCustomization(false);
        }

        private void DoWebpartBulkCustomization(bool onlyValidate)
        {
            rtbDisplay.Clear();
            AddToRtbLocal("Bulk WebPart Customization" + Util.V(onlyValidate) + "\r\n", StyleType.titleSeagreen);

            if (cboProfiles.SelectedItem == null)
            {
                AddToRtbLocal("Please select a profile\r\n", StyleType.bodyBlack);
                return;
            }

            WebpartBulkClientLibParentProfile profile = (WebpartBulkClientLibParentProfile)cboProfiles.SelectedItem;

            profile.DoWebpartCustomization(onlyValidate,txtTargetSite,rtbSiteValidateMessage);
        }
        #endregion

        #region Misc
        private void btnEditSitesToCreateList_Click(object sender, EventArgs e)
        {
            ActionBulkWebPartCustomize_EditParameters.ShowForm();
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        #endregion

        




    }
}

