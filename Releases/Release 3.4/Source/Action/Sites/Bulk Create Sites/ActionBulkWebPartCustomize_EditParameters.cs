using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SushiNS
{
    public partial class ActionBulkWebPartCustomize_EditParameters : Form
    {
        public ActionBulkWebPartCustomize_EditParameters()
        {
            InitializeComponent();
        }

        public static void ShowForm()
        {
            ActionBulkWebPartCustomize_EditParameters frm = new ActionBulkWebPartCustomize_EditParameters();
            frm.ShowDialog();
        }

        private void ActionBulkWebPartCustomize_EditParameters_Load(object sender, EventArgs e)
        {
            if (BulkWebpartParameters.BulkWebPartParametersList != null)
            {
                foreach (BulkWebpartParameters bwp in BulkWebpartParameters.BulkWebPartParametersList)
                    dg.Rows.Add(new object[] { bwp.SiteUrlName, bwp.StockSymbol, bwp.ExternalUrl,bwp.Directors });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BulkWebpartParameters.BulkWebPartParametersList = new List<BulkWebpartParameters>();

            foreach (DataGridViewRow row in dg.Rows)
            {
                if (!row.IsNewRow)
                {
                    BulkWebpartParameters bwp = new BulkWebpartParameters(Util.ToStr(row.Cells[0].Value), Util.ToStr(row.Cells[1].Value), Util.ToStr(row.Cells[2].Value), Util.ToStr(row.Cells[3].Value));
                    if (bwp.SiteUrlName == "")
                    {
                        MessageBox.Show(this, "Site URL Name is blank.", "SUSHI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg.FirstDisplayedCell = row.Cells[0];
                        dg.ClearSelection();
                        row.Cells[0].Selected = true;

                        return;
                    }
                    BulkWebpartParameters.BulkWebPartParametersList.Add(bwp);
                }
            }

            BulkWebpartParameters.BulkWebPartParametersList.Sort(); //needed to check for duplicates.
            ActionBulkWebPartCustomization.DefInstance.lblSiteCount.Text = "sites list count: " + BulkWebpartParameters.BulkWebPartParametersList.Count;
            this.Close();
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void dgNewSites_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dg.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
        }

        private void lnkPaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string[] lines = Clipboard.GetText().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            dg.Rows.Clear();

            foreach (string line in lines)
            {
                if (line.Trim() != "")
                {
                    dg.Rows.Add(line.Split('\t')); 
                }
            }
        }
    }

    public class BulkWebpartParameters :IComparable<BulkWebpartParameters>              
    {
        public static List<BulkWebpartParameters> BulkWebPartParametersList;

        public string SiteUrlName;
        public string StockSymbol;
        public string ExternalUrl;
        public string Directors;

        public BulkWebpartParameters(string siteUrlName, string stockSymbol,string externalUrl,string directors)
        {
            this.SiteUrlName = Util.StripCharactersSharepointDoesNotLike(siteUrlName.Trim());
            this.StockSymbol = stockSymbol;
            this.ExternalUrl = externalUrl;
            this.Directors = directors;
        }

        public override string ToString()
        {
            return "URL:" + this.SiteUrlName + " StockSymbol:" + this.StockSymbol + " ExternalUrl:" + this.ExternalUrl + " Directors:" + Directors;
        }

        #region IComparable<BulkWebpartParameters> Members
        public int CompareTo(BulkWebpartParameters other)
        {
            return string.Compare(this.SiteUrlName, other.SiteUrlName);
        }
        #endregion
    }
}