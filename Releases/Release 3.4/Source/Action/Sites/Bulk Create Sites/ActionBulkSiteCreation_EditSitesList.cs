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
    public partial class ActionBulkSiteCreation_EditSitesList : Form
    {
        public ActionBulkSiteCreation_EditSitesList()
        {
            InitializeComponent();
        }

        private bool _forSitesNotLists;

        public static void ShowForm(bool forSitesNotLists)
        {
            ActionBulkSiteCreation_EditSitesList frm = new ActionBulkSiteCreation_EditSitesList();
            frm._forSitesNotLists = forSitesNotLists;
            frm.ShowDialog();
        }

        private List<NewSiteOrList> CurrentList
        {
            get 
            {
                if (_forSitesNotLists)
                    return NewSiteOrList.ListOfNewSites;
                else
                    return NewSiteOrList.ListOfNewLists;
            }
            set
            {
                if (_forSitesNotLists)
                    NewSiteOrList.ListOfNewSites = value;
                else
                    NewSiteOrList.ListOfNewLists = value;
            }
        }

        private void ActionBulkSiteCreation_EditSitesList_Load(object sender, EventArgs e)
        {
            if (_forSitesNotLists)
            {
                this.Text = "Edit list of SharePoint Sites to be Created";
                this.dgNewSites.Columns["colURLname"].HeaderText = "Site URL Name";
                this.dgNewSites.Columns["colTitle"].HeaderText = "Site Title";
            }
            else
            {
                this.Text = "Edit list of SharePoint Lists to be Created";
                this.dgNewSites.Columns["colURLname"].HeaderText = "List URL Name";
                this.dgNewSites.Columns["colTitle"].HeaderText = "List Title";
            }

            if (CurrentList != null)
                foreach (NewSiteOrList ns in CurrentList)
                    dgNewSites.Rows.Add(new object[] { ns.UrlName, ns.Title });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            CurrentList = new List<NewSiteOrList>();

            foreach (DataGridViewRow row in dgNewSites.Rows)
            {
                if (!row.IsNewRow)
                {
                    NewSiteOrList ns = new NewSiteOrList(Util.ToStr(row.Cells[0].Value), Util.ToStr(row.Cells[1].Value));
                    if (ns.UrlName == "")
                    {
                        MessageBox.Show(this, "Site URL Name is blank.", "SUSHI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgNewSites.FirstDisplayedCell = row.Cells[0];
                        dgNewSites.ClearSelection();
                        row.Cells[0].Selected = true;

                        return;
                    }
                    CurrentList.Add(ns);
                }
            }
            CurrentList.Sort(); //note: needed to check for duplicates
            if (_forSitesNotLists)
                ActionBulkSiteCreation.DefInstance.lblSiteCount.Text = "count of sites to create: " + CurrentList.Count;
            else
                ActionBulkListCreation.DefInstance.lblSiteCount.Text = "count of lists to create: " + CurrentList.Count;
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
                DataObject d = dgNewSites.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = Clipboard.GetText().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            dgNewSites.Rows.Clear();

            foreach (string line in lines)
                if (line.Trim() != "")
                    dgNewSites.Rows.Add(line.Split('\t'));
        }
    }

    public class NewSiteOrList :IComparable<NewSiteOrList>         
    {
        public static List<NewSiteOrList> ListOfNewSites;
        public static List<NewSiteOrList> ListOfNewLists;

        public string UrlName;
        public string Title;

        public NewSiteOrList(string urlName, string title)
        {
            this.UrlName = Util.StripCharactersSharepointDoesNotLike(urlName.Trim());
            if (title.Trim() == "")
                title = this.UrlName;
            this.Title = title.Trim(); 
        }

        public override string ToString()
        {
            return "URL:" + this.UrlName + "  TITLE: " + this.Title;
        }

        #region IComparable<NewSite> Members
        public int CompareTo(NewSiteOrList other)
        {
            return string.Compare(this.UrlName, other.UrlName);
        }
        #endregion
    }
}