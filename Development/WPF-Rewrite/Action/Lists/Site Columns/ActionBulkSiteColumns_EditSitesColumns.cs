using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.SharePoint;

namespace SUSHI
{
    public partial class ActionContentTypes_EditSiteColumns : Form
    {
        public ActionContentTypes_EditSiteColumns()
        {
            InitializeComponent();
        }

        public static void ShowForm()
        {
            ActionContentTypes_EditSiteColumns frm = new ActionContentTypes_EditSiteColumns();
            frm.ShowDialog();
        }

        public static List<SiteColumnToCreate> SiteColumnsToCreate;

        private void ActionBulkSiteCreation_EditSitesList_Load(object sender, EventArgs e)
        {
            if (SiteColumnsToCreate != null)
                foreach (SiteColumnToCreate sc in SiteColumnsToCreate)
                {
                    string choices = sc.ChoicesToSemiColonList();
                    dgNewSiteColumns.Rows.Add(new object[] { sc.InternalName, sc.DisplayName, sc.FieldType.ToString(), sc.Group, choices, sc.DefaultValue, sc.Description });
                }
        }

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            SiteColumnsToCreate = new List<SiteColumnToCreate>();
            rtbDisplay.Clear();

            try
            {
                foreach (DataGridViewRow row in dgNewSiteColumns.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    //--
                    SPFieldType fieldType = parseFieldType(Util.ToStr(row.Cells["colFieldType"].Value));
                    StringCollection choices = SiteColumnToCreate.ChoicesFromSemicolonString(Util.ToStr(row.Cells["colChoices"].Value).Trim());

                    SiteColumnToCreate sc = new SiteColumnToCreate(Util.ToStr(row.Cells["colInternalName"].Value).Trim(),
                                                                   Util.ToStr(row.Cells["colDisplayName"].Value).Trim(),
                                                                   fieldType,
                                                                   Util.ToStr(row.Cells["colGroup"].Value).Trim(),
                                                                   choices,
                                                                   Util.ToStr(row.Cells["colDefaultValue"].Value).Trim(),
                                                                   Util.ToStr(row.Cells["colDescription"].Value).Trim());

                    //--Validate
                    validateSc(sc.InternalName == "", "Internal Name is blank", row.Index, "colInternalName");
                    validateSc(sc.DisplayName == "", "Display Name is blank", row.Index, "colDisplayName");
                    validateSc(sc.FieldType == SPFieldType.Invalid, "Field Type is not valid", row.Index, "colFieldType");
                    validateSc(sc.Group == "", "Group is blank", row.Index, "colGroup");
                    validateSc(sc.DefaultValue != "" && !sc.Choices.Contains(sc.DefaultValue), "Default Value is not contained in Choices", row.Index, "colDefaultValue");

                    //--Add
                    SiteColumnsToCreate.Add(sc);
                }

                ActionContentTypes.DefInstance.rtbDisplay.Clear();
                this.Close();
                ActionContentTypes.DefInstance.lblNewSiteColumnsCount.Text = "Count: " + SiteColumnsToCreate.Count.ToString();
                

            }
            catch (SUSHI.Eh.CancelException)
            {
                return;
            }
        }

        private void validateSc(bool isInvalid, string message, int rowIndex,string colName)
        {
            if (isInvalid)
            {
                AddToRtbLocal(message + " in row " + (rowIndex + 1 ).ToString() + "\r\n", StyleType.bodyRed);
                dgNewSiteColumns.FirstDisplayedCell = dgNewSiteColumns.Rows[rowIndex].Cells[0];
                dgNewSiteColumns.ClearSelection();
                dgNewSiteColumns.Rows[rowIndex].Cells[colName].Selected = true;

                throw new Eh.CancelException();
            }
        }

        private SPFieldType parseFieldType(string s)
        {
            SPFieldType fieldType = SPFieldType.Invalid;
            foreach (SPFieldType t in Enum.GetValues(typeof(SPFieldType)))
            {
                if (t.ToString() == s)
                    fieldType = t;
            }
            return fieldType;
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void dgNewSites_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dgNewSiteColumns.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
        }

        private void btnPasteFromClipboard_Click(object sender, EventArgs e)
        {
            string[] lines = Clipboard.GetText().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            dgNewSiteColumns.Rows.Clear();

            foreach (string line in lines)
            {
                if (line.Trim() != "")
                {
                    string[] vals = cleanLine(line);
                    dgNewSiteColumns.Rows.Add(vals);
                }
            }
        }

        private string[] cleanLine(string line)
        {
            string[] vals = line.Split('\t');
            if (vals.Length >=3 && vals[2] != null && vals[2] != "")
            {
                DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgNewSiteColumns.Columns[2];
                
                foreach (string itemOption in col.Items)
                {
                    if (itemOption.ToUpper() == vals[2].Trim().ToUpper())
                    {
                        vals[2] = itemOption;
                        return vals;
                    }
                }
                vals[2] = "Invalid";
            }
            return vals;
        }

        #region entities
        public class SiteColumnToCreate
        {
            public SiteColumnToCreate(string internalName, string displayName, SPFieldType fieldType, string group, StringCollection choices, string defaultValue, string description)
            {
                this.InternalName = internalName;
                this.DisplayName = displayName;
                this.FieldType = fieldType;
                this.Group = group;
                this.Choices = choices;
                this.DefaultValue = defaultValue;
                this.Description = description;
            }

            public string InternalName;
            public string DisplayName;
            public SPFieldType FieldType;
            public string Group;
            public StringCollection Choices;
            public string DefaultValue;
            public string Description;

            public string ChoicesToSemiColonList()
            {
                string choices = "";
                foreach (string s in this.Choices)
                    choices += ";" + s;
                choices = choices.StartsWith(";") ? choices.Remove(0, 1) : choices;
                return choices;
            }

            public string ChoicesToNewlineList()
            {
                string choices = "";
                foreach (string s in this.Choices)
                    choices += "\r\n" + s;
                choices = choices.StartsWith("\r\n") ? choices.Remove(0, 2) : choices;
                return choices;
            }

            public static StringCollection ChoicesFromSemicolonString(string commaList)
            {
                StringCollection scol = new StringCollection();
                foreach (string s in commaList.Split(new string[] { ";" }, StringSplitOptions.None))
                    scol.Add(s);
                return scol;
            }
        }
        #endregion

        #region action functions
        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        #endregion

        private void dgNewSites_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
            AddToRtbLocal("Gridview DataError at row " + (e.RowIndex + 1) + ", column " + (e.ColumnIndex + 1) +" message:" + e.Exception.Message + "\r\n", StyleType.bodyRed);
            
            SmartStepUtil.ScrollToBottom(rtbDisplay);
        }

    }

}