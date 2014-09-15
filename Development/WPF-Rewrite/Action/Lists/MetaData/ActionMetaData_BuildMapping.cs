using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;

namespace SUSHI
{
    public partial class frmBuildMapping : Form
    {
        public frmBuildMapping()
        {
            InitializeComponent();
        }

        SPDocumentLibrary m_targetDocLib;
        int m_editingMPindex = -1;
        MappingProfile m_mpWorking;

        public static void ShowBuildMappingForm(SPDocumentLibrary docLib, MappingProfile mp)
        {
            if (docLib == null)
                return;
            frmBuildMapping f = new frmBuildMapping();

            //--populate cboTargetContentType
            List<string> inelligableContentTypes = new List<string>();
            //inelligableContentTypes.Add("Document");
            inelligableContentTypes.Add("Folder");
            foreach (SPContentType ct in docLib.ContentTypes)
            {
                if (!inelligableContentTypes.Contains(ct.Name)) 
                    f.cboTargetContentType.Items.Add(ct.Name);
            }

            //--
            f.lblTargetDocLib.Text = "Target Document Library: " + docLib.Title;
            f.m_targetDocLib = docLib;
            if (mp == null) //--create a new Mapping Profile
            {
                f.m_mpWorking = new MappingProfile("new profile","");
                f.m_mpWorking.MappingItems = new List<MappingItem>();
                f.txtProfileName.Text = "(New Mapping Profile)";
                f.Text = "New Mapping Profile";
                f.lnkDeleteProfile.Enabled = false;
                if (f.cboTargetContentType.Items.Count == 1)
                    f.cboTargetContentType.SelectedIndex = 0;
            }
            else //--edit existing Mapping Profile
            {
                f.m_editingMPindex = ActionMetaDataUtil.MappingProfiles.IndexOf(mp);
                MappingProfile ret = (MappingProfile)Util.DeepCopy(mp);
                if (ret == null)
                    return;
                f.m_mpWorking = ret;
                f.txtProfileName.Text = mp.ProfileName;
                f.cboTargetContentType.SelectedIndex = f.cboTargetContentType.FindStringExact(mp.TargetContentTypeName);
                f.Text = "Edit Mapping Profile";
                if (f.m_mpWorking.MappingItems == null)
                    f.m_mpWorking.MappingItems = new List<MappingItem>();
            }

            f.displayMappingProfileInRtb(null, null);
            f.Location = new Point(MainForm.DefInstance.Left +10 , MainForm.DefInstance.Top + 10);

            //--
            f.ShowDialog();
        }

        private bool m_alreadyInitialized;
        private void cboTargetContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_alreadyInitialized)
            {
                if (cboTargetContentType.SelectedItem.ToString() == m_mpWorking.TargetContentTypeName)
                    return;
            }
            m_alreadyInitialized = true;

            m_mpWorking.TargetContentTypeName = cboTargetContentType.SelectedItem.ToString();

            lstSource.Items.Clear();
            lstDest.Items.Clear();
            ListBox lst;
            foreach (SPContentType ct in m_targetDocLib.ContentTypes)
            {
                if (ct.Name == "Folder") //--exclude Folder content type
                    continue;
                if (ct.Name == cboTargetContentType.Text)
                    lst = lstDest;
                else
                    lst = lstSource;

                foreach (SPField field in ct.Fields)
                {
                    lst.Items.Add(new FieldAndContentType(field, ct));
                }
            }
            //SPField = m_targetDocLib.ContentTypes["Document"].Fields["Title"];
            //lstDest.Items.Add(new FieldAndContentType(field, ct)); //FutureDev

            //--
            lblDestColumn.Text = "Destination Columns of Content Type " + m_mpWorking.TargetContentTypeName;
            displayMappingProfileInRtb(null,null);
        }

        private void btnAddMap_Click(object sender, EventArgs e)
        {
            if (lstSource.SelectedItem == null || lstDest.SelectedItem == null)
                return;

            FieldAndContentType fcS = (FieldAndContentType)lstSource.SelectedItem;
            FieldAndContentType fcD = (FieldAndContentType)lstDest.SelectedItem;

            //lstSource.Items.Remove(fcS);
            //lstDest.Items.Remove(fcD);

            MappingItem mi = new MappingItem(fcS.Field.InternalName, fcD.Field.InternalName);
            m_mpWorking.MappingItems.Add(mi);
            m_mpWorking.MappingItems.Sort();
            displayMappingProfileInRtb(mi.ToString(), "added");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //--validate
            if (cboTargetContentType.SelectedItem == null)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Target Content Type is blank.", Color.Red, 10, true);
                return;
            }

            //--
            if (m_editingMPindex == -1) //--Mapping Profile is new
                ActionMetaDataUtil.MappingProfiles.Add(m_mpWorking);
            else
                ActionMetaDataUtil.MappingProfiles[m_editingMPindex] = m_mpWorking;

            //--refresh cboMappingProfile
            ActionMetadata.DefInstance.populateCboMappingProfiles();
            //ActionMetadata.DefInstance.cboMappingProfile.SelectedItem = m_mpWorking;
            ActionMetadata.DefInstance.cboMappingProfile.SelectedIndex = ActionMetadata.DefInstance.cboMappingProfile.FindStringExact(m_mpWorking.ProfileName);
            //ActionMetadata.DefInstance.cboMappingProfile.Refresh();
            //--
            ActionMetaDataUtil.SaveMappingProfileToXml();
            //

            //--
            ActionMetadata.DefInstance.rtbDisplay.Clear();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void displayMappingProfileInRtb(string item,string action)
        {
            rtbDisplay.Clear();
            AddToRTBLocal("Mapping Profile Name: " + m_mpWorking.ProfileName + "\r\n", StyleType.titleBlue);
            foreach (MappingItem mi in m_mpWorking.MappingItems)
                AddToRTBLocal(mi.ToString() + "\r\n", StyleType.bodyBlack);
            if (m_mpWorking.MappingItems.Count == 0)
                AddToRtbLocal("(No column mappings defined.)\r\n");

            if (item != null)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "\r\n" + item, Color.SeaGreen, 8, true);
                AddToRTBLocal(" was " + action + "\r\n", StyleType.bodySeaGreen);
            }
        }

        private void AddToRtbLocal(string strText)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText);
        }

        private void txtProfileName_TextChanged(object sender, EventArgs e)
        {
            m_mpWorking.ProfileName = txtProfileName.Text;
        }

        private void lnkDeleteProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult ret = MessageBox.Show(this,"Are you sure you want to delete Mapping Profile " + m_mpWorking.ProfileName + "?","", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
            {
                ActionMetaDataUtil.MappingProfiles.RemoveAt(m_editingMPindex);
                ActionMetaDataUtil.SaveMappingProfileToXml();
                ActionMetadata.DefInstance.populateCboMappingProfiles();
                ActionMetadata.DefInstance.lnkEditProfiles.Enabled = false;
                ActionMetadata.DefInstance.lnkCopyProfile.Enabled = false;
                this.Close();
            }
        }

        #region Clear A Mapping Column
        private void lnkClearSingleColumnMapping_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cboClearAMapping.Items.Clear();
            foreach (MappingItem mi in m_mpWorking.MappingItems)
                cboClearAMapping.Items.Add(mi);
            cboClearAMapping.Visible = true;
            cboClearAMapping.Focus();
            cboClearAMapping.DroppedDown = true;
        }

        private void cboClearAMapping_Leave(object sender, EventArgs e)
        {
            cboClearAMapping.Visible = false;
        }

        private void cboClearAMapping_SelectedIndexChanged(object sender, EventArgs e)
        {
            MappingItem miDeleted = (MappingItem)cboClearAMapping.SelectedItem;
            m_mpWorking.MappingItems.Remove(miDeleted);
            cboClearAMapping.Visible = false;
            displayMappingProfileInRtb(miDeleted.ToString(),"deleted");
        }
        #endregion

        private void AddToRTBLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }


    }
}