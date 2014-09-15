using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Diagnostics;
using System.Collections;
using System.Xml;

namespace SUSHI
{
    public partial class ActionMetadata : SUSHI.ActionParent
    {
        public static ActionMetadata DefInstance;

        public ActionMetadata()
        {
            InitializeComponent();
        }

        private void ActionMetadata_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Meta Data";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;


            //--
            txtTargetSite.Text = GlobalVars.SETTINGS.metadata_siteURL;
            tabControl1.SelectedIndex = GlobalVars.SETTINGS.metadata_selectedTab;

            //--
            ActionMetaDataUtil.LoadMappingProfilesFromXml();
            populateCboMappingProfiles();
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            string s = @"This feature of SUSHI helps with several metadata mass-update and grooming tasks. In a Search Engine world, metadata is key and keeping metadata accurate is key to findability, which is why this feature of SUSHI can be quite helpful. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Meta%20Data&referringTitle=Home";
            SmartStepUtil.AddToRTB(rtbDisplay, s, StyleType.bodyBlack);
        }
        
        public void populateCboMappingProfiles()
        {
            cboMappingProfile.Items.Clear();
            foreach (MappingProfile mp in ActionMetaDataUtil.MappingProfiles)
                cboMappingProfile.Items.Add(mp);
        }

        #region common controls
        private void btnPopulateDocLibs_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbValidateMessage);
                if (web == null)
                    return;
                txtTargetSite.Text = web.Url;

                Util.PopulateComboboWithSharePointLists(web, cboDocLibs, true, false);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            finally
            {
                MainForm.DefInstance.Cursor = Cursors.Default;
            }

        }

        private void cboDocLibs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDocLibs.SelectedItem == null)
                return;

            tabControl1.Enabled = true;

            m_cboDocLibHasChangedSinceColumnListWasUpdated = true;
            populatemetadataColumnNames(true);
        }

        bool m_cboDocLibHasChangedSinceColumnListWasUpdated;
        private void populatemetadataColumnNames(bool dropdown)
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;

                if (tabControl1.SelectedTab.Name == "tabUpdateValuesForAColumn" && m_cboDocLibHasChangedSinceColumnListWasUpdated)
                {
                    cboColumnNames.Items.Clear();
                    SPList list = (SPList)cboDocLibs.SelectedItem;
                    foreach (SPContentType ct in list.ContentTypes)
                    {
                        foreach (SPField field in ct.Fields)
                            cboColumnNames.Items.Add(new FieldAndContentType(field, ct));
                    }
                    if (dropdown)
                        cboColumnNames.DroppedDown = true;
                    m_cboDocLibHasChangedSinceColumnListWasUpdated = false;
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            finally
            {
                MainForm.DefInstance.Cursor = Cursors.Default;
            }
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }

        //TODO: use FrmCancelRunning method instead.
        //private delegate void delTE(bool r);
        //internal void toggleEnabled(bool running)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new delTE(toggleEnabled), running);
        //        return;
        //    }
        //    if (running == true)
        //    {
        //        GlobalVars.CancelRunning = false;
        //        FrmCancelRunning.ShowCancelRunningFormOn2ndThread();
        //    }
        //    else
        //        FrmCancelRunning.CloseCancelRunningFormSafely();

        //    MainForm.DefInstance.Enabled = !running;
        //}
        #endregion

        #region Update Values of A Column_1
        private void cboColumnNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCurrentValue.Items.Clear();
            SortedDictionary<string, int> uniqueValues = createUniqueListOfColumnValues();
            foreach (KeyValuePair<string, int> de in uniqueValues)
                cboCurrentValue.Items.Add(de.Key);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            updateSingleColumn(true);
        }

        private void btnUpdatemetadata_Click(object sender, EventArgs e)
        {
            updateSingleColumn(false);
        }

        private void updateSingleColumn(bool onlyValidate)
        {
            int counterUpdated = 0;
            int counterTotalItemsInList = 0;
            try
            {
                FrmCancelRunning.ToggleEnabled(true);//toggleEnabled(true);

                SmartStepUtil.ClearRtbSafely(rtbDisplay);
                //--validate
                if (cboCurrentValue.SelectedItem == null)
                {
                    AddToRtbLocal("Please select a Current Value", StyleType.bodyBlack);
                    return;
                }
                if (cboColumnNames.SelectedItem == null)
                {
                    AddToRtbLocal("Please select a Column", StyleType.bodyBlack);
                    return;
                }

                FieldAndContentType fnwc = (FieldAndContentType)cboColumnNames.SelectedItem;
                //--messagebox to validate if the user really wants to update value to blank. (prevent accident).
                if (txtNewValue.Text.Trim() == "" && !onlyValidate)
                {
                    if (MessageBox.Show(this, "You have selected to update to a blank, Are you sure?", "SUSHI", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }

                //--
                string s = onlyValidate ? "Displaying" : "Updating";
                SmartStepUtil.AddToRTB(rtbDisplay, s + " values for column ", Color.Green, 14, true);
                SmartStepUtil.AddToRTB(rtbDisplay, fnwc.Field.Title, Color.Chocolate, 14, true);
                SmartStepUtil.AddToRTB(rtbDisplay, " where value = ", Color.Green, 14, true);
                SmartStepUtil.AddToRTB(rtbDisplay, "\"" + cboCurrentValue.Text + "\"\r\n", Color.Chocolate, 14, true);

                SPList list = (SPList)cboDocLibs.SelectedItem;
                counterTotalItemsInList = list.Items.Count;
                foreach (SPListItem listitem in (list.Items))
                {
                    if (GlobalVars.CancelRunning)
                        throw new Eh.CancelException();
                    SmartStepUtil.ScrollToBottom(rtbDisplay);
                    Application.DoEvents();


                    if (Util.ToStr(listitem[fnwc.Field.Id]) == cboCurrentValue.Text)
                    {
                        //object o = listitem[fnwc.Field.Id];
                        //

                        SmartStepUtil.AddToRTB(rtbDisplay, listitem.File.Name, Color.Blue, 8, false);

                        AddToRtbLocal(" column ", StyleType.bodyBlack);
                        SmartStepUtil.AddToRTB(rtbDisplay, fnwc.Field.Title, Color.DarkCyan, 8, false);

                        if (onlyValidate)
                        {
                            AddToRtbLocal(" = ", StyleType.bodyBlack);
                            SmartStepUtil.AddToRTB(rtbDisplay, "\"" + cboCurrentValue.Text + "\"\r\n", Color.DarkGreen, 8, false);
                        }
                        else
                        {
                            listitem[fnwc.Field.Id] = txtNewValue.Text;
                            listitem.Update();
                            //idea: ability to replace part of a field, rather than the whole thing.
                            //mySPLI[mySPField.Title]=mySPLI[mySPField.Title].ToString().Replace(oldValue.Text,newValue.Text);mySPLI.Update(); 
                            if (listitem[fnwc.Field.Id].ToString() == txtNewValue.Text)
                            {
                                AddToRtbLocal(" updated to ", StyleType.bodyBlack);
                                SmartStepUtil.AddToRTB(rtbDisplay, "\"" + txtNewValue.Text + "\"\r\n", Color.DarkBlue, 8, false);
                                counterUpdated++;
                            }
                            else
                                SmartStepUtil.AddToRTB(rtbDisplay, " NOT successfully updated\r\n", Color.Red, 8, false);
                        }
                    }
                }

                //--
                if (!onlyValidate)
                {
                    cboColumnNames_SelectedIndexChanged(null, null);
                    SmartStepUtil.AddToRTB(rtbDisplay, "update completed successfully\r\n", Color.Black, 8, true);
                }
            }
            catch (Eh.CancelException)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Canceled by user\r\n", Color.Black, 10, true);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false); //toggleEnabled(false);
            }
            SmartStepUtil.AddToRTB(rtbDisplay, "STATS: total items in list:" + counterTotalItemsInList + ", items updated:" + counterUpdated + "\r\n", Color.DarkGray, 8, false);
            SmartStepUtil.ScrollToBottom(rtbDisplay);
        }
        #endregion

        #region Show Column Info
        private void lnkShowColumnInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboColumnNames.SelectedItem == null)
                return;
            FieldAndContentType fct = (FieldAndContentType)cboColumnNames.SelectedItem;

            rtbDisplay.Clear();
            SmartStepUtil.AddToRTB(rtbDisplay, "Information about the Column ", Color.Blue, 13, true);
            SmartStepUtil.AddToRTB(rtbDisplay, fct.Field.Title + "\r\n", Color.MediumBlue, 13, true);
            //--
            SortedDictionary<string, int> uniqueValues = createUniqueListOfColumnValues();
            SmartStepUtil.AddToRTB(rtbDisplay, "List of unique values:\r\n", Color.Black, 8, true);
            foreach (KeyValuePair<string, int> de in uniqueValues)
                SmartStepUtil.AddToRTB(rtbDisplay, "   " + de.Key + " (" + de.Value + ")\r\n");

            //--
            List<string> fieldPropertyNames = new List<string>();
            System.Collections.Hashtable fieldPropertyValues = new System.Collections.Hashtable();
            AddToRtbLocal("\r\n\r\n", StyleType.bodyBlack);
            SmartStepUtil.AddToRTB(rtbDisplay, "Technical Info: (All properties of the column)\r\n ", Color.Black, 8, true);
            foreach (System.Reflection.PropertyInfo propInfo in fct.Field.GetType().GetProperties())
            {
                object val = propInfo.GetValue(fct.Field, null);
                fieldPropertyNames.Add(propInfo.Name);
                fieldPropertyValues.Add(propInfo.Name, val);
            }

            //--
            fieldPropertyNames.Sort();
            foreach (string item in fieldPropertyNames)
            {
                AddToRtbLocal(item + ": ", StyleType.bodyBlack);
                SmartStepUtil.AddToRTB(rtbDisplay, fieldPropertyValues[item] + "\r\n", Color.Blue, 8, false);
            }
        }

        private SortedDictionary<string, int> createUniqueListOfColumnValues()
        {
            SortedDictionary<string, int> uniqueValues = new SortedDictionary<string, int>();

            //--validate
            if (cboColumnNames.SelectedItem == null)
                return uniqueValues;

            //--
            FieldAndContentType fnwc = (FieldAndContentType)cboColumnNames.SelectedItem;
            foreach (SPListItem listitem in ((SPList)cboDocLibs.SelectedItem).Items)
            {
                string val = Util.ToStr(listitem[fnwc.Field.Id]);
                if (!uniqueValues.ContainsKey(val))
                    uniqueValues.Add(val, 1);
                else
                    uniqueValues[val] = uniqueValues[val] + 1;
            }

            return uniqueValues;
        }
        #endregion

        #region control events for SushiSettings
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.metadata_selectedTab = tabControl1.SelectedIndex;

            populatemetadataColumnNames(false);
        }

        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.metadata_siteURL = txtTargetSite.Text;
        }
        #endregion

        #region Mapping Profile
        private void lnkShowAllMetadata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                FrmCancelRunning.ToggleEnabled(true); //toggleEnabled(true);
                SPList list = (SPList)cboDocLibs.SelectedItem;
                //--
                rtbDisplay.Clear();
                foreach (SPListItem listitem in list.Items)
                {
                    SmartStepUtil.AddToRTB(rtbDisplay, "Properties for  " + listitem.File.Name + "\r\n", Color.Green, 10, true);
                    List<string> props = new List<string>();
                    foreach (string item in listitem.File.Properties.Keys)
                        props.Add(item);
                    props.Sort();
                    foreach (string item in props)
                    {
                        SmartStepUtil.AddToRTB(rtbDisplay, item + ": ");
                        SmartStepUtil.AddToRTB(rtbDisplay, listitem.File.Properties[item].ToString() + "[" + listitem.File.Properties[item].GetType().Name + "]\r\n", Color.Blue, 8, false);
                    }
                    AddToRtbLocal("\r\n", StyleType.bodyBlack);

                    if (GlobalVars.CancelRunning)
                        throw new Eh.CancelException();
                }
            }
            catch (Eh.CancelException)
            {
                AddToRtbLocal("cancelled by user", StyleType.bodyBlackBold);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false); //toggleEnabled(false);
            }
            SmartStepUtil.ScrollToBottom(rtbDisplay);
        }

        private void lnkEditProfiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                MainForm.DefInstance.Cursor = Cursors.WaitCursor;
                SPDocumentLibrary docLib = (SPList)cboDocLibs.SelectedItem as SPDocumentLibrary;

                MappingProfile mp = (MappingProfile)cboMappingProfile.SelectedItem;
                frmBuildMapping.ShowBuildMappingForm(docLib, mp);
            }
            finally
            {
                MainForm.DefInstance.Cursor = Cursors.Default;
            }
        }

        private void lnkAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SPDocumentLibrary docLib = (SPList)cboDocLibs.SelectedItem as SPDocumentLibrary;
            frmBuildMapping.ShowBuildMappingForm(docLib, null);
        }

        private void lnkCopyProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MappingProfile mp = (MappingProfile)cboMappingProfile.SelectedItem;
            MappingProfile mpCopy = (MappingProfile)Util.DeepCopy(mp);
            if (mpCopy == null)
                return;
            ActionMetaDataUtil.MappingProfiles.Add(mpCopy);
            mpCopy.ProfileName = "Copy of " + mpCopy.ProfileName;
            cboMappingProfile.Items.Add(mpCopy);
            cboMappingProfile.SelectedItem = mpCopy;
            ActionMetaDataUtil.SaveMappingProfileToXml();
        }

        private void cboMappingProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            lnkEditProfiles.Enabled = true;
            lnkCopyProfile.Enabled = true;
        }
        #endregion

        #region Map Data
        private void btnValidateCT_Click(object sender, EventArgs e)
        {
            MapData(true);
        }

        private void btnMapData_Click(object sender, EventArgs e)
        {
            MapData(false);
        }

        private void MapData(bool onlyValidate)
        {
            int counter = 0;
            int countErrors = 0;
            try
            {
                //--validate
                if (cboMappingProfile.SelectedItem == null)
                    return;

                //--
                FrmCancelRunning.ToggleEnabled(true); //toggleEnabled(true);

                //--
                rtbDisplay.Clear();
                if (onlyValidate)
                    AddToRtbLocal("Validating Mapping for target Document Library\r\n", StyleType.titleSeagreen);
                else
                    AddToRtbLocal("Mapping metadata for target Document Library\r\n", StyleType.titleSeagreen);

                //--
                SPList list = (SPList)cboDocLibs.SelectedItem;
                MappingProfile mp = (MappingProfile)cboMappingProfile.SelectedItem;

                //--Find column ref and validate mapping profile for document library
                if (!findColoumRefFromInternalName(mp, list))
                    return;

                //--
                foreach (SPListItem listitem in list.Items)
                {
                    AddToRtbLocal(listitem.File.Name + "\r\n", StyleType.bodyBlackBold);
                    counter++;
                    foreach (MappingItem mi in mp.MappingItems)
                    {
                        if (onlyValidate)
                            AddToRtbLocal("   " + mi.DestColumn + " will be updated to \"" + Util.ToStr(listitem[mi.sourceID] + "\"\r\n"), StyleType.bodyBlack);
                        else
                        {
                            AddToRtbLocal("   " + mi.DestColumn + " updated to \"" + Util.ToStr(listitem[mi.sourceID] + "\"\r\n"), StyleType.bodyBlack);
                            //--for Lookup fields, need to validate format before updating
                            if (mi.DestColumn != "LookupMulti" || validateFormatOfLookup(listitem[mi.sourceID]))
                            {
                                listitem[mi.destID] = listitem[mi.sourceID];
                            }
                            //setLookupValueForPRTMproduct(listitem, mi);
                        }
                    }
                    try
                    {
                        if (!onlyValidate)
                            listitem.Update();
                    }
                    catch (Exception ex)
                    {
                        countErrors++;
                        AddToRtbLocal("Error while updating: " + ex.Message + ", continuing to next item..\r\n", StyleType.bodyRed);
                    }

                    //--
                    if (GlobalVars.CancelRunning)
                        throw new Eh.CancelException();
                    SmartStepUtil.ScrollToBottom(rtbDisplay);
                    Application.DoEvents();
                }
            }
            catch (Eh.CancelException)
            {
                SmartStepUtil.AddToRTB(rtbDisplay, "Canceled by user\r\n", Color.Black, 10, true);
            }
            catch (Exception ex)
            {
                AddToRtbLocal("error: " + ex.Message + "\r\nMessageType:" + ex.GetType().ToString() + "\r\n", StyleType.bodyRed);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false); //toggleEnabled(false);
            }
            string u = onlyValidate ? "validated" : "updated";
            AddToRtbLocal("\r\nNumber of documents " + u + ":" + counter + ", errors:" + countErrors + "\r\n", StyleType.bodyDarkGray);
            SmartStepUtil.ScrollToBottom(rtbDisplay);
        }

        #region keepcode
        //        List<string> prtmProdutLookup;
        //        private void setLookupValueForPRTMproduct(SPListItem listitem, MappingItem mi)
        //        {
        //            if (prtmProdutLookup == null)
        //            {
        //                SPList prtmProdutsList = listitem.ListItems.List.ParentWeb.Site.RootWeb.Lists["PRTMCT_product"];
        //                prtmProdutLookup = new List<string>();
        //                foreach(SPListItem listitem in prtmProdutsList)
        //                    prtmProdutLookup.Add(listitem["Title"].ToString();

        ////                prtmProdutLookup.AddRange(new string[] { "BTI: Business Technology Operations Strategy & Management",
        ////"BTI: Business Technology Portfolio Management","BTI: Business Technology Strategy","BTI: Business Technology Transformation Management","CEI: Customer Experience Strategy","CEI: Customer Service Operation","CEI: Customer Insight Management","CEI: Marketing & Media Management","CEI: Pricing","CEI: Sales & Channel Effectiveness","CEI: Sales & Channel Strategy","CEI: Strategic Account Management","OS: Business Process Management","OS: Business Strategy","OS: Capital Model",
        ////"OS: Change Management","OS: Enterprise Technology Systems","OS: Footprint","OS: Growth and Expansion Strategy","OS: Information Architecture","OS: Management Systems","OS: Merger & Acquisition","OS: Operational Economics","OS: Operational Performance Goals","OS: Formulation","OS: Regulatory Strategy","OS: Sales and Marketing Effectiveness","OS: Shared Services","OS: Solution Strategy","OS: Strategic Planning Process","OS: Strategic Vision and Mission (CSV Based)","OS: Talent, Culture and Leadership","OS: Value Network","OS: Value Streams","PI: Environmental & Regulatory Compliance","PI: Extended Enterprise and Open Innovation","PI: Innovation Strategy","PI: PLM Transformation","PI: Product Management","PI: Product Strategy & Portfolio Management","PI: Productivity & Strategic Resource Management","PI: Productivity Management","PI: Project Excellence and Product Development Operations","PI: Resource Management",
        ////"PI: Technology & IP Management","SCI: Environmental & Regulatory Compliance","SCI: Lean Operations","SCI: Managing Scale & Complexity","SCI: Outsourcing & Restructuring","SCI: Service Supply Chain",
        ////"SCI: Strategic Procurement","SCI: Supply Chain Benchmarking","SCI: Supply Chain Collaboration","SCI: Supply Chain Logistics and Distribution","SCI: Supply Chain Organizational Design","SCI: Supply Chain Planning and Demand (S&OP)",
        ////"SCI: Supply Chain Strategy","SCI: Supply Chain Systems Implementation" });
        //            }

        //            string toFind = listitem[mi.sourceID];
        //            int i = toFind.IndexOf(":");
        //            if (i > -1)
        //            {
        //                toFind = toFind.Substring(i,toFind.Length - i);
        //            }

        //            int index = prtmProdutLookup.IndexOf(toFind);

        //            string newValue = (index + 1).ToString() + "#;" + prtmProdutLookup[index];
        //            if (index > -1)
        //                listitem[mi.destID] = newValue;
        //            else
        //                listitem[mi.destID] = "";

        //        }
        #endregion

        private bool validateFormatOfLookup(object sourceVal)
        {
            string invalidReason = "unknown";
            try
            {
                if (sourceVal == null)
                    invalidReason = "is null";
                else if (sourceVal.GetType().ToString() == "Microsoft.SharePoint.SPFieldLookupValueCollection")
                    invalidReason = "is valid";
                else if (sourceVal.GetType().ToString() == "System.String")
                {
                    //--for type of string, make sure that every other value is an integer, otherwise, not invalid
                    string[] parts = ((string)sourceVal).Split(new string[] { ";#" }, StringSplitOptions.None);
                    invalidReason = "is valid";
                    for (int i = 0; i <= parts.Length - 1; i = i + 2)
                    {
                        int val;
                        if (!int.TryParse(parts[i], out val))
                        {
                            invalidReason = "string is not in format of 1;#value;#2;value";
                            break;
                        }
                    }
                }
                else
                    invalidReason = "invalid data type";
            }
            catch (Exception ex)
            {
                AddToRtbLocal("error while validating lookup column: " + ex.Message + "\r\n", StyleType.bodyRed);
                invalidReason = "error";
            }

            if (invalidReason == "is valid")
                return true;
            else
            {
                AddToRtbLocal("lookup source column format was not valid for a lookup column so not updating, reason: " + invalidReason + "\r\n", StyleType.bodyRed);
                return false;
            }
        }

        private void lnkAddContentTypeFromRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SPDocumentLibrary doclib = (SPDocumentLibrary)cboDocLibs.SelectedItem;
            FrmAddContnetTypeToDocLib.ShowForm(doclib);

            m_cboDocLibHasChangedSinceColumnListWasUpdated = true;
            populatemetadataColumnNames(false);
        }

        private void lnkDeleteSourceColumns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rtbDisplay.Clear();
            //TODO: redo to just display a form with checkboxes to delete columns, listing all content types besides target content type and folder content type.

            if (cboMappingProfile.SelectedItem == null)
                return;

            SPList list = (SPList)cboDocLibs.SelectedItem;
            MappingProfile mp = (MappingProfile)cboMappingProfile.SelectedItem;

            //--
            AddToRtbLocal("Deleting source columns from document library\r\n", StyleType.titleSeagreen);

            if (!findColoumRefFromInternalName(mp, list))
                return;

            DialogResult ret = MessageBox.Show(this, "Are you sure you want to delete these " + mp.MappingItems.Count + " columns?", "SUSHI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                foreach (MappingItem mi in mp.MappingItems)
                {
                    SPField field = list.Fields[mi.sourceID];
                    if (field.CanBeDeleted == false)
                        SmartStepUtil.AddToRTB(rtbDisplay, "can't delete source column " + mi.SourceColumn + ", because it is an undeletable column\r\n");
                    else
                    {
                        SmartStepUtil.AddToRTB(rtbDisplay, "deleting source column " + mi.SourceColumn);
                        field.Delete();
                        SmartStepUtil.AddToRTB(rtbDisplay, " done. \r\n", StyleType.bodyBlackBold);
                    }
                }
            }
        }

        private bool findColoumRefFromInternalName(MappingProfile mp, SPList list)
        {
            int countFound = 0;
            foreach (MappingItem mi in mp.MappingItems)
            {
                mi.sourceID = new Guid();
                mi.destID = new Guid();
                foreach (SPField field in list.Fields)
                {
                    if (field.InternalName == mi.SourceColumn)
                    {
                        mi.sourceID = field.Id;
                        mi.sourceTypeAsString = field.TypeAsString;
                        break;
                    }
                }
                foreach (SPField field in list.Fields)
                {
                    if (field.InternalName == mi.DestColumn)
                    {
                        mi.destID = field.Id;
                        mi.destTypeAsString = field.TypeAsString;
                        break;
                    }
                }

                if (mi.sourceID == new Guid())
                    AddToRtbLocal("source column " + mi.SourceColumn + " not found\r\n", StyleType.bodyRed);
                else
                {
                    AddToRtbLocal("source column " + mi.SourceColumn + " found\r\n", StyleType.bodySeaGreen);
                    countFound++;
                }
                if (mi.destID == new Guid())
                    AddToRtbLocal("  ->destination column " + mi.DestColumn + " not found\r\n", StyleType.bodyRed);
                else
                {
                    AddToRtbLocal("  ->destination column " + mi.DestColumn + " found\r\n", StyleType.bodySeaGreen);
                    countFound++;
                }
            }
            if (countFound != mp.MappingItems.Count * 2)
                return false;

            return true;
        }
        #endregion

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void imgBrowse_Click_1(object sender, EventArgs e)
        {
            SPList list = (SPList)cboDocLibs.SelectedItem;

            string url = list.ParentWeb.Url + "/" + list.RootFolder.Url;
            Util.OpenURLinDefaultBrowser(url, rtbDisplay);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
