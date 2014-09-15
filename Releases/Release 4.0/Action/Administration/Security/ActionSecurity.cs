using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SharePoint;
using SushiNS.SecurityNs;
using System.DirectoryServices;

namespace SushiNS
{
    public partial class ActionSharepointSecurity : SushiNS.ActionParent
    {
        #region initial stuff
        public static ActionSharepointSecurity DefInstance;

        public ActionSharepointSecurity()
        {
            InitializeComponent();
        }

        private void ActionSharepointSecurity_Load(object sender, EventArgs e)
        {
            this.HelpKey = "Security Reports";
            if (this.DisableIfSharePointNotInstalledLocally())
                return;

            txtTargetSite.Text = GlobalVars.SETTINGS.security_siteURL;
            chkShowLinkToManagePermissions.Checked = GlobalVars.SETTINGS.errors_errorsNotFound_checkedShowHyperlink;

            switch (GlobalVars.SETTINGS.security_optWhichReport)
            {
                case "optShowPermissionsInheritanceForSite":
                    optShowPermissionsInheritanceForSite.Checked = true;
                    break;
                case "optListGroupMemberShipForUser":
                    optListGroupMemberShipForUser.Checked = true;
                    break;
                case "optFindAllPermissionsForUser":
                    optFindAllPermissionsForUser.Checked = true;
                    break;
            }
            opt_CheckedChanged(null, null);
        }
        #endregion

        #region populateAllUsersCombo()
        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            populateAllUsersCombo();
        }

        List<string> _usersToExclude = new List<string>(new string[] { @"SHAREPOINT\SYSTEM", @"NT AUTHORITY\LOCAL SERVICE" });
        private void populateAllUsersCombo()
        {
            cboUsers.Items.Clear();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbValidateMessage))
                {
                    if (web == null) return;

                    foreach (SPUser user in web.AllUsers)
                    {
                        if (!_usersToExclude.Contains(user.LoginName.ToUpper()))
                            cboUsers.Items.Add(user);
                    }
                }
            });
            cboUsers.DroppedDown = true;
        }
        #endregion

        #region btnRunSecurityReport and opt_CheckedChanged
        private void btnRunSecurityReport_Click(object sender, EventArgs e)
        {
            if (optShowPermissionsInheritanceForSite.Checked)
                runPermissionInheritanceForSiteCollection();
            else if (optListGroupMemberShipForUser.Checked)
                runDisplayAllGroupsUserIsIn();
            else if (optFindAllPermissionsForUser.Checked)
                runFindAllPermissionsForUser();
        }

        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                RadioButton r = (RadioButton)sender;
                if (!r.Checked)
                    return;
                //--remember selected report
                GlobalVars.SETTINGS.security_optWhichReport = r.Name;
            }

            //--hide appropriate controls for report
            if (optShowPermissionsInheritanceForSite.Checked)
                pnlUser.Visible = false;
            else
                pnlUser.Visible = true;

            if (optFindAllPermissionsForUser.Checked)
            {
                chkShowLinkToManagePermissions.Visible = true;
                chkShowOnlyUnique.Visible = true;
            }
            else
            {
                chkShowLinkToManagePermissions.Visible = false;
                chkShowOnlyUnique.Visible = false;
            }

            //--Report Notes
            string reportNotes = null;
            if (optShowPermissionsInheritanceForSite.Checked)
                reportNotes = "This report shows all the SharePoint Sites and Lists that do not inherit permissions from their parent. Sites are displayed in blue, Lists are displayed in green. The server relative URL is used, so for example \"/\" is the root site. If a site is displayed in Gray it is simply a place holder, that site inherits permissions, but at least one of its child Lists does not. This report does not include hidden lists.";
            else if (optListGroupMemberShipForUser.Checked)
                reportNotes = "This report shows the SharePoint groups that a user is a member of. It also indicates if a user is a site collection admin. It also displays the Active Directory groups that a user is in. It also shows if a web application policy has been set to grant rights to the user. (Web application policies can be viewed through central admin.) Note that to be able to see Active Directory groups, your login must have at least view rights in Active Directory. SUSHI uses a Directory Services LDAP query to determine AD membership.";
            else if (optFindAllPermissionsForUser.Checked)
                reportNotes = "This report shows the permissions a user has for all Sites and Lists beneath the selected site. Sites are displayed in blue, and Lists in green. The user name or the SharePoint group is displayed in black, with the permissions in square brackets. Active Directory groups are displayed in navy blue. This report does not include hidden lists. By default the report will display only sites and lists that do not inherit permissions from their parent.";

            rtbDisplay.Clear();
            AddToRtbLocal("Notes: " + "\r\n", StyleType.bodyChocolate);
            AddToRtbLocal(reportNotes + "\r\n", StyleType.bodyBlack);

        }
        #endregion

        #region checkThatCurrentUserHasCorrectPriviledges
        private void checkThatCurrentUserHasCorrectPriviledges(SPWeb web)
        {
            try
            {
                string u = Environment.UserDomainName + "\\" + Environment.UserName; //TODO: what if user is on workgroup?

                SPUser currentUser = null;
                foreach (SPUser user in web.AllUsers)
                    if (user.LoginName.ToUpper() == u.ToUpper())
                        currentUser = user;
                if (currentUser == null)
                {
                    AddToRtbLocal("note: unable to check if current user " + u + " is a site collection admin.\r\n", StyleType.bodyOrange);
                    return;
                }
                if (!currentUser.IsSiteAdmin)
                {
                    AddToRtbLocal("note: it is recommended that the current user be a site collection admin in order to have the correct permissions to run the SUSHI security report. The current user " + currentUser.LoginName + " is not.", StyleType.bodyBlack, SmartStepUtil.enumIcon.red_x);
                    AddToRtbLocal("\r\n", StyleType.bodyBlack);
                }
            }
            catch (Exception ex)
            {
                AddToRtbLocal("note: unable to check if current user is site collection admin: " + ex.Message + "\r\n", StyleType.bodyOrange);
            }
        }
        #endregion

        #region runFindAllPermissionsForUser()
        private void runFindAllPermissionsForUser()
        {
            try
            {
                rtbDisplay.Clear();
                FrmCancelRunning.ToggleEnabled(true);

                if (cboUsers.SelectedItem == null)
                {
                    AddToRtbLocal("please select a user\r\n", StyleType.bodyRed);
                    return;
                }
                using (SPWeb web = Util.RetrieveWeb(this.txtTargetSite.Text, this.rtbValidateMessage))
                {
                    //--
                    SPUser user = (SPUser)cboUsers.SelectedItem;
                    AddToRtbLocal("Permissions for user ", StyleType.titleChocolate);
                    AddToRtbLocal(user.LoginName, StyleType.titleBlue);
                    AddToRtbLocal(" site ", StyleType.bodyChocolateBold);
                    AddToRtbLocal(web.Url + "\r\n", StyleType.bodyBlueBold);

                    checkThatCurrentUserHasCorrectPriviledges(web);
                    //--build list of user's SharePoint and Active Directory Groups
                    List<string> userSharepointGroups = new List<string>();
                    foreach (SPGroup group in user.Groups)
                        userSharepointGroups.Add(group.Name.ToUpper());

                    AddToRtbLocal("Looking up Active Directory groups for user...    ", StyleType.bodyDarkGray);
                    List<string> userADgroups = findADgroupsForUser(false, user, Environment.UserDomainName);
                    AddToRtbLocal(userADgroups.Count.ToString(), StyleType.bodyBlack);
                    AddToRtbLocal(" Active Directory groups found.\r\n", StyleType.bodyDarkGray);

                    AddToRtbLocal("\r\n", StyleType.bodyBlack);
                    AddToRtbLocal("________________________________________________________________________\r\n", StyleType.bodyBlack);
                    findRoleAssignments(web, user, 1, userSharepointGroups, userADgroups);
                    AddToRtbLocal("________________________________________________________________________\r\n", StyleType.bodyBlack);

                    SmartStepUtil.AddToRTB(rtbDisplay, "\r\nDONE", Color.Black, 8, true);
                }
            }
            catch (Exception ex)
            {
                AddToRtbLocal("error: " + ex.Message, StyleType.bodyRed);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false);
            }
        }

        private void findRoleAssignments(SPWeb web1, SPUser user, int depth, List<string> userSharepointGroups, List<string> userADgroups)
        {
            SushiSecurable secSite = findRoleAssignmentsForMember(web1, user, userSharepointGroups, userADgroups);
            secSite.Name = web1.ServerRelativeUrl;
            secSite.HyperLinkSiteSecurity = web1.Url + "/_layouts/user.aspx";

            foreach (SPList spList in web1.Lists)
            {
                SushiSecurable secList = findRoleAssignmentsForMember(spList, user, userSharepointGroups, userADgroups);
                if (secList.AtLeastOnePermission)
                {
                    if (spList.Hidden)
                        continue;
                    secList.Name = spList.Title;
                    secList.ListType = spList.GetType().Name;
                    secSite.AtLeastOnePermission = true;
                    secSite.SecurableLists.Add(secList);
                    secList.HyperLinkSiteSecurity = spList.ParentWeb.Url + "/_layouts/user.aspx?List=" + spList.ID.ToString() + "";
                }
            }

            //--
            displayIt(secSite);
            SmartStepUtil.ScrollToBottom(rtbDisplay);
            Application.DoEvents();

            //--recursively loop through all subwebs of top level site.
            foreach (SPWeb web2 in web1.Webs)
            {
                findRoleAssignments(web2, user, depth++, userSharepointGroups, userADgroups);
                web2.Dispose();
            }
        }

        private SushiSecurable findRoleAssignmentsForMember(ISecurableObject webOrList, SPUser user, List<string> userSharepointGroups, List<string> userADgroups)
        {
            SushiSecurable secSiteOrList = new SushiSecurable();

            if (!webOrList.HasUniqueRoleAssignments && !chkShowOnlyUnique.Checked)
                return secSiteOrList;

            foreach (SPRoleAssignment ra in webOrList.RoleAssignments)
            {
                string raName = ra.Member.Name.ToUpper();
                if (raName == user.Name.ToUpper() || userSharepointGroups.Contains(raName) || userADgroups.Contains(raName))
                {
                    UorG uOrG = new UorG(ra.Member.Name, userADgroups.Contains(raName));
                    if (ra.Member.Name.ToUpper() == user.Name.ToUpper())
                        uOrG.Name = user.LoginName;
                    secSiteOrList.UorGs.Add(uOrG);
                    foreach (SPRoleDefinition rd in ra.RoleDefinitionBindings)
                        uOrG.RoleNames.Add(rd.Name);
                    secSiteOrList.AtLeastOnePermission = true;
                }
            }
            if (user.IsSiteAdmin)
            {
                UorG uOrG = new UorG("Site Collection Admins", false);
                secSiteOrList.UorGs.Add(uOrG);
                uOrG.RoleNames.Add("Full Control");
                secSiteOrList.AtLeastOnePermission = true;
            }
            return secSiteOrList;

        }

        private void displayIt(SushiSecurable secSite)
        {
            if (!secSite.AtLeastOnePermission)
                return;

            AddToRtbLocal("\r\n" + secSite.Name, StyleType.bodyBlueBold);
            string s = chkShowLinkToManagePermissions.Checked ? secSite.HyperLinkSiteSecurity + "\r\n" : "\r\n";
            SmartStepUtil.AddToRTB(rtbDisplay, " " + s, Color.DarkGray, 4, false);
            displayRoles(secSite, "   ");
            foreach (SushiSecurable secList in secSite.SecurableLists)
            {
                AddToRtbLocal("   " + secList.Name, StyleType.bodySeaGreen);
                SmartStepUtil.AddToRTB(rtbDisplay, " (" + secList.ListType + ")", Color.SeaGreen, 8, false);
                string s2 = chkShowLinkToManagePermissions.Checked ? secList.HyperLinkSiteSecurity + "\r\n" : "\r\n";
                SmartStepUtil.AddToRTB(rtbDisplay, " " + s2, Color.DarkGray, 5, false);
                displayRoles(secList, "      ");
            }
            SmartStepUtil.ScrollToBottom(rtbDisplay);
        }

        private void displayRoles(SushiSecurable sec, string indentSpaces)
        {
            foreach (UorG uorG in sec.UorGs)
            {
                AddToRtbLocal(indentSpaces + uorG.Name, uorG.IsADgroup ? StyleType.bodyMidnightBlue : StyleType.bodyBlack);
                foreach (string role in uorG.RoleNames)
                    AddToRtbLocal(" [" + role + "]", StyleType.bodyBlack);

                AddToRtbLocal("\r\n", StyleType.bodyBlack);
            }
        }
        #endregion

        #region runDisplayAllGroupsUserIsIn()
        private void runDisplayAllGroupsUserIsIn()
        {
            rtbDisplay.Clear();

            if (cboUsers.SelectedItem == null)
            {
                AddToRtbLocal("Please select a user\r\n", StyleType.bodyRed);
                return;
            }

            SPWeb web = Util.RetrieveWeb(txtTargetSite.Text, rtbValidateMessage);
            if (web == null) return;
            SPUser user = (SPUser)cboUsers.SelectedItem;

            AddToRtbLocal("Group Membership for User ", StyleType.titleChocolate);
            AddToRtbLocal(user.LoginName + "\r\n", StyleType.titleBlue);
            AddToRtbLocal("For the site collection ", StyleType.bodyChocolateBold);
            AddToRtbLocal(web.Site.Url + "\r\n\r\n", StyleType.bodyBlueBold);

            //--site collection administrator
            if (user.IsSiteAdmin)
            {
                AddToRtbLocal("Site Collection Administrators:\r\n", StyleType.bodyBlackBold);
                AddToRtbLocal("  user " + user.LoginName + " is a site collection admin\r\n", StyleType.bodyBlack);
            }

            //--SharePoint Groups
            AddToRtbLocal("SharePoint Groups:\r\n", StyleType.bodyBlackBold);
            int countSharePointGroups = 0;
            foreach (SPGroup group in user.Groups)
            {
                AddToRtbLocal("  " + group.Name + "\r\n", StyleType.bodyBlack);
                countSharePointGroups++;
            }
            if (countSharePointGroups == 0)
                AddToRtbLocal("  (no SharePoint groups)\r\n", StyleType.bodyBlack);

            //--AD Groups
            AddToRtbLocal("Active Directory Groups:\r\n", StyleType.bodyBlackBold);
            List<string> adGroups = findADgroupsForUser(true, user, Environment.UserDomainName);
            if (adGroups.Count == 0)
                AddToRtbLocal("  (no Active Directory Groups)\r\n", StyleType.bodyBlack);
            else
                foreach (string adGroup in adGroups)
                    AddToRtbLocal("  " + adGroup + "\r\n", StyleType.bodyMidnightBlue);

            //--web application policies.
            AddToRtbLocal("Web Application Policies:\r\n", StyleType.bodyBlackBold);
            foreach (Microsoft.SharePoint.Administration.SPPolicy policy in web.Site.WebApplication.Policies)
            {
                if (policy.UserName.ToUpper() == user.LoginName.ToUpper() || adGroups.Contains(policy.UserName.ToUpper()))
                {
                    AddToRtbLocal("Web Application Policy:\r\n", StyleType.bodyBlackBold);
                    AddToRtbLocal("  policies applying to ", StyleType.bodyBlack);
                    if (adGroups.Contains(policy.UserName.ToUpper()))
                        AddToRtbLocal(policy.UserName, StyleType.bodyBlack);
                    else
                        AddToRtbLocal(policy.UserName, StyleType.bodyBlack);
                    foreach (Microsoft.SharePoint.Administration.SPPolicyRole role in policy.PolicyRoleBindings)
                        AddToRtbLocal(" [" + role.Name + "]", StyleType.bodyBlack);
                    AddToRtbLocal("\r\n", StyleType.bodyBlack);
                }
            }
            SmartStepUtil.AddToRTB(rtbDisplay, "\r\n\r\nDONE", Color.Black, 8, true);
        }

        private List<string> findADgroupsForUser(bool displayMessages, SPUser user, string defaultDomainName)
        {
            List<string> adGroups = new List<string>();
            try
            {
                //--
                string adUsername = user.LoginName.ToUpper();
                string domainName = defaultDomainName.ToUpper();
                if (user.LoginName.Contains("\\"))
                {
                    adUsername  = user.LoginName.Remove(0, user.LoginName.IndexOf("\\") + 1).ToUpper(); // strip out the domain name frmo the LoginName, for example: DEV\joe => joe.
                    domainName = user.LoginName.Substring(0, user.LoginName.IndexOf("\\")).ToUpper();
                }

                //--initiate DirectorySearcher 
                DirectoryEntry entry = new DirectoryEntry("LDAP://dc=" + domainName);
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.SearchScope = SearchScope.Subtree;
                searcher.Filter = "(&(objectClass=user)(sAMAccountName=" + adUsername + "))";
                searcher.PropertiesToLoad.AddRange(new string[] { "member" });

                //--Find all AD Groups
                SearchResultCollection results = searcher.FindAll();
                if (results.Count == 0)
                    AddToRtbLocal("User " + user.LoginName + " not found in Active Directory.\r\n", StyleType.bodyPurple);
                else
                {
                    foreach (SearchResult res in results)
                    {
                        for (int i = 0; i < res.GetDirectoryEntry().Properties["memberOf"].Count; i++)
                        {
                            string fullCN = res.GetDirectoryEntry().Properties["memberOf"][i].ToString();
                            string[] fullCNArray = fullCN.Split(',');
                            string group = fullCNArray[0].Replace("CN=", "").ToUpper();
                            adGroups.Add(domainName + "\\" + group);
                        }
                    }
                }

                //SearchResult resultUser = searcher.FindOne();
                //if (resultUser == null)
                //{
                //    AddToRtbLocal("User " + user.LoginName + " not found in Active Directory.\r\n", StyleType.bodyPurple);
                //    return adGroups;
                //}
                //DirectoryEntry deUser = resultUser.GetDirectoryEntry();

                //object obGroups = deUser.Invoke("Groups");
                //foreach (object ob in (System.Collections.IEnumerable)obGroups)
                //{
                //    DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                //    string n = obGpEntry.Name;
                //    n = n.StartsWith("CN=") ? n.Remove(0, 3) : n;
                //    adGroups.Add(domainName.ToUpper() + "\\" + n.ToUpper());
                //}
            }
            catch (Exception ex)
            {
                AddToRtbLocal("Unable to find active directory groups for user: " + ex.Message + "\r\n", StyleType.bodyPurple);
            }
            return adGroups;
        }
        #endregion

        #region runPermissionInheritanceForSiteCollection()
        private void runPermissionInheritanceForSiteCollection()
        {
            try
            {
                rtbDisplay.Clear();
                FrmCancelRunning.ToggleEnabled(true);
                using (SPWeb web = Util.RetrieveWeb(this.txtTargetSite.Text, this.rtbValidateMessage))
                {
                    AddToRtbLocal("Permissions Inheritance Report for Site ", StyleType.titleChocolate);
                    AddToRtbLocal(web.Url + "\r\n\r\n", StyleType.bodyBlueBold);

                    displayPermissionsInheritance(web);

                    SmartStepUtil.AddToRTB(rtbDisplay, "\r\nDONE", Color.Black, 8, true);
                    //AddToRtbLocal("\r\n\r\n\r\nReport Notes: This report shows all the SharePoint Sites and Lists that do not inherit permissions from their parent. Sites are displayed in blue, Lists are displayed in green. The server relative URL is used, so for example \"/\" is the root site. If a site is displayed in Gray it is simply a place holder, that site inherits permissions, but at least one of its child Lists does not. This report does not include hidden lists.", StyleType.bodyDarkGray);
                }
            }
            catch (Exception ex)
            {
                AddToRtbLocal(ex.Message, StyleType.bodyRed);
            }
            finally
            {
                FrmCancelRunning.ToggleEnabled(false);
            }
        }

        private void displayPermissionsInheritance(SPWeb web)
        {
            bool siteInheritsButDisplayAsPlaceholder = true;
            if (web.HasUniqueRoleAssignments)
            {
                AddToRtbLocal(web.ServerRelativeUrl + "\r\n", StyleType.bodyBlueBold);
                siteInheritsButDisplayAsPlaceholder = false;
            }

            foreach (SPList spList in web.Lists)
            {
                if (spList.HasUniqueRoleAssignments && !spList.Hidden)
                {
                    if (siteInheritsButDisplayAsPlaceholder)
                    {
                        AddToRtbLocal(web.ServerRelativeUrl + "\r\n", StyleType.bodyDarkGray);
                        siteInheritsButDisplayAsPlaceholder = false;
                    }
                    AddToRtbLocal("   " + spList.Title + "\r\n", StyleType.bodySeaGreen);
                }
            }

            //--
            SmartStepUtil.ScrollToBottom(rtbDisplay);
            Application.DoEvents();

            //--recursively loop through all subwebs of top level site.
            foreach (SPWeb subWeb in web.Webs)
            {
                displayPermissionsInheritance(subWeb);
                subWeb.Dispose();
            }
        }
        #endregion

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            //FutureDev: create links that are just numbers (or hexadecimal Numbers)  that translate into URLs.
            Uri uri = new Uri(e.LinkText);
            if (e.LinkText.StartsWith("http"))
            {
                System.Diagnostics.Process.Start(uri.ToString());
            }
        }

        private void chkShowLinkToManagePermissions_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.errors_errorsNotFound_checkedShowHyperlink = chkShowLinkToManagePermissions.Checked;
        }

        #region Control events for SushiSettings
        private void txtSiteUrl_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.SETTINGS.security_siteURL = txtTargetSite.Text;
            cboUsers.Items.Clear();
        }
        #endregion

        #region misc
        private void lnkSelectSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);

        }
        private void AddToRtbLocal(string strText, StyleType style, SmartStepUtil.enumIcon icon)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style, icon);
        }
        #endregion

        private void lnkCopyReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(rtbDisplay.Rtf, TextDataFormat.Rtf);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            MTV.SelectSite.DefInstance.ShowFormGetWebURL(txtTargetSite);
        }
    }
}

