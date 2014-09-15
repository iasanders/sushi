using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Specialized;

namespace SUSHI
{
    public partial class ActionContentTypes : SUSHI.ActionParent
    {
        public static ActionContentTypes DefInstance;

        public ActionContentTypes()
        {
            InitializeComponent();
        }


        private void ActionContentTypes_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Bulk Site Columns Create";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            this.txtTargetSite.Text = GlobalVars.SETTINGS.contentTypes_siteUrl;

            addreportNotes();
            //lnkBrowseSite1.InitMeStuff(txtTargetSite, rtbDisplay);
            
        }

        private void addreportNotes()
        {
            AddToRtbLocal("Notes: \r\n", StyleType.bodyChocolate);
            AddToRtbLocal(@"This SUSHI feature allows you to easily and quickly create site columns. The advantage of using SUSHI is that you can create your site columns in Excel and then paste into SUSHI and have SUSHI bulk create the site columns for you." + "\r\n\r\n", StyleType.bodyBlack);
            AddToRtbLocal(@"This also comes in handy when creating the same site columns accross multiple site collections. Additional Help: http://www.codeplex.com/sushi/Wiki/View.aspx?title=Site%20Columns&referringTitle=Home", StyleType.bodyBlack);
        }

        private void btnEditSiteColumnsToCreateList_Click(object sender, EventArgs e)
        {
            ActionContentTypes_EditSiteColumns.ShowForm();
        }

        #region Validate and Create Site Columns
        private void btnValidate_Click(object sender, EventArgs e)
        {
            createSiteColumns(true);
        }

        private void btnCreateSiteColumns_Click(object sender, EventArgs e)
        {
            createSiteColumns(false);
        }

        private void createSiteColumns(bool onlyValidate)
        {
            rtbDisplay.Clear();

            //--validate
            if (ActionContentTypes_EditSiteColumns.SiteColumnsToCreate == null || ActionContentTypes_EditSiteColumns.SiteColumnsToCreate.Count == 0)
            {
                AddToRtbLocal("Please edit the list of site columns to create.\r\n", StyleType.bodyRed);
                return;
            }

            //--
            SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbSiteValidateMessage);
            if (web == null)
                return;
            txtTargetSite.Text = web.Url;

            //--
            AddToRtbLocal("Adding Site Columns to Site ", StyleType.titleChocolate);
            AddToRtbLocal(web.Title , StyleType.titleBlue);
            AddToRtbLocal(Util.V(onlyValidate) + "\r\n\r\n", StyleType.titleChocolate);


            //--loop through list of SiteColumnsToCreate, and create.
            foreach (ActionContentTypes_EditSiteColumns.SiteColumnToCreate sc in ActionContentTypes_EditSiteColumns.SiteColumnsToCreate)
            {
                AddToRtbLocal("Adding Site Column " , StyleType.bodyBlackBold);
                AddToRtbLocal(sc.InternalName + " ", StyleType.bodyBlueBold);
                AddToRtbLocal(Util.V(onlyValidate), StyleType.bodyChocolate);

                bool invalid = false;
                if (SharePointUtil.SiteContainsFieldByInternalName(web, sc.InternalName))
                {
                    AddToRtbLocal("\r\n   Site already contains Site Column with Internal Name of ", StyleType.bodyOrange);
                    AddToRtbLocal(sc.InternalName, StyleType.bodyBlue);
                    invalid = true;
                }
                if (! invalid)
                    if (SharePointUtil.SiteContainsFieldByDisplayName(web, sc.InternalName))
                    {
                        AddToRtbLocal("\r\n  Site already contains Site Column with Title of ", StyleType.bodyOrange);
                        AddToRtbLocal(sc.DisplayName, StyleType.bodyBlue);
                        invalid = true;
                    }
                if (!invalid)
                {
                    AddToRtbLocal(
                        "\r\n  Internal Name:" + sc.InternalName + 
                        "\r\n  Title:" + sc.DisplayName + 
                        "\r\n  Field Type:" + sc.FieldType.ToString() + 
                        "\r\n  Group:" + sc.Group ,StyleType.bodyBlack);
                    if (sc.FieldType == SPFieldType.Choice)
                    {
                        AddToRtbLocal("\r\n  Choices (semicolon delimited):", StyleType.bodyBlack);
                        AddToRtbLocal(sc.ChoicesToSemiColonList(), StyleType.bodyDarkGray);
                    }
                    AddToRtbLocal(
                        "\r\n  Default Value:" + sc.DefaultValue +
                        "\r\n  Description:" + sc.Description, StyleType.bodyBlack);

                    if (!onlyValidate)
                    {
                        string newFieldName;
                        if (sc.FieldType == SPFieldType.Text)
                            newFieldName = web.Fields.Add(sc.InternalName, SPFieldType.Text, false);
                        else if (sc.FieldType == SPFieldType.Choice)
                            newFieldName = web.Fields.Add(sc.InternalName, SPFieldType.Choice, false, false, sc.Choices);
                        else
                        {
                            AddToRtbLocal("unrecognized FieldType\r\n", StyleType.bodyRed);
                            continue;
                        }

                        SPField newField = web.Fields[newFieldName];

                        newField.Title = sc.DisplayName;
                        newField.Group = sc.Group;
                        newField.DefaultValue = sc.DefaultValue;
                        newField.Description = sc.Description;
                        newField.Update();

                        AddToRtbLocal(" success", StyleType.bodySeaGreen);
                    }
                }
                AddToRtbLocal("\r\n", StyleType.bodyBlack);
            }

                      

             

        }
        #endregion

        #region basic Action methods
      

        private void txtTargetSite_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.contentTypes_siteUrl = this.txtTargetSite.Text;
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        #endregion

        private void lnkEditSiteColumns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = txtTargetSite.Text;
            if (!url.EndsWith("/"))
                url += "/";
            url += "_layouts/mngfield.aspx";

            Util.OpenURLinDefaultBrowser(url, rtbDisplay);
        }

        private void imgSelectSite_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}

