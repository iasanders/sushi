using System;
using System.Windows.Forms;

namespace SUSHI
{
    public partial class MainForm : Form
    {
        internal static MainForm DefInstance;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                displayVersionAndAccountId();

                addTreenodes();

                openLastOpenTreenode(tvNav.Nodes);

            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }

        private void addTreenodes()
        {
            TreeNode tnAdmin = addTreeviewNode("Administration", null, "admin.gif", "admin_h.png");
            addTreeviewNode(tnAdmin, "Security Reports", typeof(SUSHI.ActionSharepointSecurity), "security_report.png", "security_reports_h.png");
            addTreeviewNode(tnAdmin, "Profile Images Import", typeof(SUSHI.ActionProfileImages), "profile_image_import.png", "profile_image_import_h.png");
            addTreeviewNode(tnAdmin, "Backup", typeof(SUSHI.ActionBackup), "backup.png", "backup_h.png");
            addTreeviewNode(tnAdmin, "Restore", typeof(SUSHI.ActionRestore), "restore.png", "restore_h.png");
            addTreeviewNode(tnAdmin, "Email Test", typeof(SUSHI.ActionEmail), "email_test.png", "email_test_h.png");

            TreeNode tnLists = addTreeviewNode("Lists", null, "tvNavicon_reporting.gif", "tvNavicon_reporting.gif");
            addTreeviewNode(tnLists, "Copy A View", typeof(SUSHI.ActionCopyView), "copy_a_view.png", "copy_a_view_h.png");
            addTreeviewNode(tnLists, "Meta Data", typeof(SUSHI.ActionMetadata), "metadata.png", "metadata_h.png");
            addTreeviewNode(tnLists, "Bulk List Creation", typeof(SUSHI.ActionBulkListCreation), "bulk_list_creation.png", "bulk_list_creation_h.png");
            addTreeviewNode(tnLists, "Bulk Site Columns",typeof(SUSHI.ActionContentTypes), "bulk_site_creation.png", "bulk_site_creation_h.png");
            addTreeviewNode(tnLists, "Import Documents", typeof(SUSHI.ActionImportDocs), "import_doc.png", "import_doc_h.png");
            addTreeviewNode(tnLists, "Delete Old Documents", typeof(SUSHI.ActionDeleteOldDocs), "del.png", "del_h.png");

            TreeNode tnSites = addTreeviewNode("Sites", null, "bulk_site_creation.png", "bulk_site_creation_h.png");
            addTreeviewNode(tnSites, "Bulk Site Creation", typeof(SUSHI.ActionBulkSiteCreation), "bulk_site_creation.png", "bulk_site_creation_h.png");
            addTreeviewNode(tnSites, "Themes", typeof(SUSHI.ActionThemes), "themes.png", "themes_h.png");
            addTreeviewNode("Help & Settings", typeof(SUSHI.ActionSettings), "help_settings.png", "help_settings_h.png");
            
            #region keepcode
            //--addTreeviewNode(tnMore,"Bulk WebPart Customize", "SUSHI.ActionBulkWebPartCustomization", null,null);
            #endregion
        }

        #region Navigation Treeview methods
        private TreeNode addTreeviewNode(string nodeText, Type actionControlClass, string imageKey, string selectedImageKey)
        {
            return addTreeviewNode(null, nodeText, actionControlClass, imageKey, selectedImageKey);
        }

        private TreeNode addTreeviewNode(TreeNode parentTreeNode, string nodeText, Type actionControlClass, string imageKey, string selectedImageKey)
        {
            TreeNode tn = new TreeNode(nodeText);
            tn.Name = nodeText;
            tn.Tag = actionControlClass;
            if (imageKey == null)
                imageKey = "tvNavicon_overview.gif";
            tn.ImageKey = imageKey;
            if (selectedImageKey == null)
                selectedImageKey = "tvnavicon_operatorconsole_over.gif";
            tn.SelectedImageKey = selectedImageKey;
            if (parentTreeNode == null)
                tvNav.Nodes.Add(tn);
            else
            {
                parentTreeNode.Nodes.Add(tn);
                parentTreeNode.Expand(); 
            }
            return tn;
        }

        private void tvNav_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //--This is for "container" nodes so that when user pressess up arrow, the container node is skipped.
                if (e.Node.Tag == null && e.Node.Nodes.Count > 0)
                {
                    if (!_lastKeywasUpArrow || e.Node.PrevNode == null)
                        tvNav.SelectedNode = e.Node.Nodes[0];
                    else
                        tvNav.SelectedNode = e.Node.PrevNode.LastNode;
                    return;
                }

                //--using reflection here for performance reasons, this allows the application to delay-load the Action user control.
                if (e.Node.Tag.GetType().FullName == "System.RuntimeType")
                    SetTreeNodeTagToActionParentInstance(e.Node);

                ActionParent ucp = (ActionParent)e.Node.Tag;
                splitContainer1.Panel2.Controls.Clear();
                ucp.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(ucp);
                ucp.ActionFormActivate();

                if (ucp.PictureboxImage != null)
                    this.pictureBoxTop.Image = ucp.PictureboxImage;

                rtbTitle.Text = "     " + e.Node.Text;
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }

        internal static void SetTreeNodeTagToActionParentInstance(TreeNode tn)
        {
            Type actionType = (Type)tn.Tag;
            ActionParent ap = Activator.CreateInstance(actionType) as ActionParent;

            System.Reflection.FieldInfo defInstanceField = actionType.GetField("DefInstance");
            defInstanceField.SetValue(ap, ap); //singlton design pattern: only one instance ever exists of each of the user controls and it is stored in DefInstance 

            tn.Tag = ap;
        }

        private bool openLastOpenTreenode(TreeNodeCollection nodes)
        {
            foreach (TreeNode tn in nodes)
            {
                if (tn.Name == GlobalVars.SETTINGS.general_lastOpenTreenode)
                {
                    tvNav.SelectedNode = tn;
                    return true;
                }

                if (openLastOpenTreenode(tn.Nodes))
                    return true;
            }
            return false;
        }
        #endregion

        private void displayVersionAndAccountId()
        {
            System.Reflection.AssemblyName n = System.Reflection.Assembly.GetExecutingAssembly().GetName();

            GlobalVars.MyAppVersion = n.Version.ToString(4);
            txtInfo.Text = "Username:\r\n    " + System.Environment.UserDomainName + "\\" + System.Environment.UserName +
                                        "\r\nVersion:\r\n    " + GlobalVars.MyAppVersion;
        }

        #region MainForm_FormClosing
        /// <summary>
        /// Save Settings on FormClosing
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!SharePointUtil.IsSharePointInstalledLocally)
                    return;

                GlobalVars.SETTINGS.general_lastOpenTreenode = tvNav.SelectedNode.Name;
                ActionSettings.SaveSettingsPlease();

            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex); 
            } 
        }
        #endregion

        #region picHelpIcon
        private void pbHelp_MouseDown(object sender, MouseEventArgs e)
        {
            pbHelp.Image = SUSHI.Properties.Resources.help_d;
        }
        private void pbHelp_MouseEnter(object sender, EventArgs e)
        {
            pbHelp.Cursor = Cursors.Hand;   
        }
        private void pbHelp_MouseLeave(object sender, EventArgs e)
        {
            pbHelp.Cursor = Cursors.Default;
            pbHelp.Image = SUSHI.Properties.Resources.help;
        }
        private void pbHelp_MouseHover(object sender, EventArgs e)
        {
            pbHelp.Image = SUSHI.Properties.Resources.help_h;
        }
        private void pbHelp_Click(object sender, EventArgs e)
        {
            if (tvNav.SelectedNode.Tag == null || !(tvNav.SelectedNode.Tag is ActionParent))
                return;
            ActionParent ap = (ActionParent)tvNav.SelectedNode.Tag;
            SushiHelp.ShowHelpLink(ap.HelpKey);
        }
        #endregion

        #region lastkeyWasUpArrow
        private bool _lastKeywasUpArrow = false;
        private void tvNav_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                _lastKeywasUpArrow = true;
            else
                _lastKeywasUpArrow = false;
        }

        private void tvNav_MouseClick(object sender, MouseEventArgs e)
        {
            _lastKeywasUpArrow = false;
        }
        #endregion

        

    }
}
