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
    public partial class ActionCopyView_AddFavorite : Form
    {
        public ActionCopyView_AddFavorite()
        {
            InitializeComponent();
        }

        internal static void ShowForm()
        {
            ActionCopyView_AddFavorite frm = new ActionCopyView_AddFavorite();
            frm.Location = new Point(MainForm.DefInstance.Left + 10, MainForm.DefInstance.Top + 10);
            frm.ShowDialog();
        }

        private void ActionCreateView_AddFavorite_Load(object sender, EventArgs e)
        {
            txtTargetSite.Text = GlobalVars.SETTINGS.createViews_siteUrl_forAddFavoriteView;
            Toggle(false);
        }

        #region btnAddViewToFavorites
        private void btnAddViewToFavorites_Click(object sender, EventArgs e)
        {
            SPView view = (SPView)cboViews.SelectedItem;

            FavoriteView fv = new FavoriteView(view.Url,view.ParentList.ParentWeb.ServerRelativeUrl);
            ActionCopyViewUtil.FavoriteViews.Add(fv);
            ActionCopyViewUtil.SaveFavoriteViews();
            ActionCopyView.DefInstance.PopulateFavoriteViews();
            ActionCopyView.DefInstance.cboFavoriteViews.SelectedIndex = ActionCopyView.DefInstance.cboFavoriteViews.FindStringExact(fv.ToString());
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnRetrieveLists_Click(object sender, EventArgs e)
        {
            SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
            if (web == null)
                return;
            txtTargetSite.Text = web.Url;

            Util.PopulateComboboWithSharePointLists(web, cboLists, true, false);

            Toggle(false);
        }

        private void cboLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLists.SelectedItem == null)
                return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SPList list = (SPList)cboLists.SelectedItem;
                cboViews.Items.Clear();

                foreach (SPView view in list.Views)
                {
                    if (! view.Hidden && view.Title != "Explorer View")
                        cboViews.Items.Add(view);
                }
                cboViews.DroppedDown = true;

                Toggle(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Toggle(bool enabled)
        {
            btnAddViewToFavorites.Enabled = enabled;
            cboViews.Enabled = enabled;

            if (!enabled)
            {
                cboViews.Items.Clear();
            }
        }

        private void cboViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayViewInfo();
        }

        private void displayViewInfo()
        {
            if (cboViews.SelectedItem == null)
                return;

            rtbDisplay.Clear();

            SPView view = (SPView)cboViews.SelectedItem;
            
            AddToRtbLocal("Information About View\r\n" , StyleType.titleSeagreen);
            AddToRtbLocal("View URL: " + view.Url + "\r\n", StyleType.bodyBlack);
            AddToRtbLocal("View Title: " + view.Title + "\r\n", StyleType.bodyBlack);
            AddToRtbLocal("View Fields: " + view.ViewFields.Count + "\r\n", StyleType.bodyBlack);
            AddToRtbLocal("Is Default View: " + view.DefaultView.ToString() + "\r\n", StyleType.bodyBlack);
            foreach (string s in view.ViewFields)
                AddToRtbLocal(s + "\r\n", StyleType.bodyBlack);
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.createViews_siteUrl_forAddFavoriteView = txtTargetSite.Text;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

    }
}