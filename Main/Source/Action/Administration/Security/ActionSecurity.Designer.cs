namespace SUSHI
{
    partial class ActionSharepointSecurity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.rtbValidateMessage = new System.Windows.Forms.RichTextBox();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.chkShowOnlyUnique = new System.Windows.Forms.CheckBox();
            this.chkShowLinkToManagePermissions = new System.Windows.Forms.CheckBox();
            this.optListGroupMemberShipForUser = new System.Windows.Forms.RadioButton();
            this.optFindAllPermissionsForUser = new System.Windows.Forms.RadioButton();
            this.optShowPermissionsInheritanceForSite = new System.Windows.Forms.RadioButton();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.btnRunSecurityReport = new System.Windows.Forms.Button();
            this.lnkCopyReport = new System.Windows.Forms.LinkLabel();
            this.grpChooseAReport = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.pnlUser.SuspendLayout();
            this.grpChooseAReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(108, 24);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(572, 20);
            this.txtTargetSite.TabIndex = 3;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtSiteUrl_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SharePoint Site:";
            // 
            // cboUsers
            // 
            this.cboUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(110, 5);
            this.cboUsers.MaxDropDownItems = 30;
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(140, 21);
            this.cboUsers.Sorted = true;
            this.cboUsers.TabIndex = 12;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(74, 8);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "User:";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDisplay.Location = new System.Drawing.Point(3, 136);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 476);
            this.rtbDisplay.TabIndex = 14;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // rtbValidateMessage
            // 
            this.rtbValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbValidateMessage.DetectUrls = false;
            this.rtbValidateMessage.Location = new System.Drawing.Point(220, 3);
            this.rtbValidateMessage.Name = "rtbValidateMessage";
            this.rtbValidateMessage.ReadOnly = true;
            this.rtbValidateMessage.Size = new System.Drawing.Size(411, 21);
            this.rtbValidateMessage.TabIndex = 20;
            this.rtbValidateMessage.Text = "";
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetUsers.Location = new System.Drawing.Point(3, 5);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(68, 21);
            this.btnGetUsers.TabIndex = 22;
            this.btnGetUsers.Text = "Get Users";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.btnGetUsers_Click);
            // 
            // chkShowOnlyUnique
            // 
            this.chkShowOnlyUnique.AutoSize = true;
            this.chkShowOnlyUnique.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowOnlyUnique.Location = new System.Drawing.Point(385, 95);
            this.chkShowOnlyUnique.Name = "chkShowOnlyUnique";
            this.chkShowOnlyUnique.Size = new System.Drawing.Size(235, 17);
            this.chkShowOnlyUnique.TabIndex = 74;
            this.chkShowOnlyUnique.Text = "Show Sites and Lists that Inherit Permissions";
            this.chkShowOnlyUnique.UseVisualStyleBackColor = true;
            // 
            // chkShowLinkToManagePermissions
            // 
            this.chkShowLinkToManagePermissions.AutoSize = true;
            this.chkShowLinkToManagePermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowLinkToManagePermissions.Location = new System.Drawing.Point(385, 116);
            this.chkShowLinkToManagePermissions.Name = "chkShowLinkToManagePermissions";
            this.chkShowLinkToManagePermissions.Size = new System.Drawing.Size(216, 17);
            this.chkShowLinkToManagePermissions.TabIndex = 76;
            this.chkShowLinkToManagePermissions.Text = "Show HyperLink to Manage Permissions";
            this.chkShowLinkToManagePermissions.UseVisualStyleBackColor = true;
            this.chkShowLinkToManagePermissions.Visible = false;
            this.chkShowLinkToManagePermissions.CheckedChanged += new System.EventHandler(this.chkShowLinkToManagePermissions_CheckedChanged);
            // 
            // optListGroupMemberShipForUser
            // 
            this.optListGroupMemberShipForUser.AutoSize = true;
            this.optListGroupMemberShipForUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optListGroupMemberShipForUser.Location = new System.Drawing.Point(268, 20);
            this.optListGroupMemberShipForUser.Name = "optListGroupMemberShipForUser";
            this.optListGroupMemberShipForUser.Size = new System.Drawing.Size(173, 17);
            this.optListGroupMemberShipForUser.TabIndex = 77;
            this.optListGroupMemberShipForUser.Text = "List Group Membership for User";
            this.optListGroupMemberShipForUser.UseVisualStyleBackColor = true;
            this.optListGroupMemberShipForUser.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optFindAllPermissionsForUser
            // 
            this.optFindAllPermissionsForUser.AutoSize = true;
            this.optFindAllPermissionsForUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optFindAllPermissionsForUser.Location = new System.Drawing.Point(446, 19);
            this.optFindAllPermissionsForUser.Name = "optFindAllPermissionsForUser";
            this.optFindAllPermissionsForUser.Size = new System.Drawing.Size(157, 17);
            this.optFindAllPermissionsForUser.TabIndex = 78;
            this.optFindAllPermissionsForUser.Text = "Find All Permissions for User";
            this.optFindAllPermissionsForUser.UseVisualStyleBackColor = true;
            this.optFindAllPermissionsForUser.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optShowPermissionsInheritanceForSite
            // 
            this.optShowPermissionsInheritanceForSite.AutoSize = true;
            this.optShowPermissionsInheritanceForSite.Checked = true;
            this.optShowPermissionsInheritanceForSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optShowPermissionsInheritanceForSite.Location = new System.Drawing.Point(12, 19);
            this.optShowPermissionsInheritanceForSite.Name = "optShowPermissionsInheritanceForSite";
            this.optShowPermissionsInheritanceForSite.Size = new System.Drawing.Size(254, 17);
            this.optShowPermissionsInheritanceForSite.TabIndex = 79;
            this.optShowPermissionsInheritanceForSite.TabStop = true;
            this.optShowPermissionsInheritanceForSite.Text = "Show Permissions Inheritance For Site Collection";
            this.optShowPermissionsInheritanceForSite.UseVisualStyleBackColor = true;
            this.optShowPermissionsInheritanceForSite.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.cboUsers);
            this.pnlUser.Controls.Add(this.lblUser);
            this.pnlUser.Controls.Add(this.btnGetUsers);
            this.pnlUser.Location = new System.Drawing.Point(4, 91);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(254, 30);
            this.pnlUser.TabIndex = 80;
            // 
            // btnRunSecurityReport
            // 
            this.btnRunSecurityReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSecurityReport.Location = new System.Drawing.Point(260, 96);
            this.btnRunSecurityReport.Name = "btnRunSecurityReport";
            this.btnRunSecurityReport.Size = new System.Drawing.Size(111, 37);
            this.btnRunSecurityReport.TabIndex = 81;
            this.btnRunSecurityReport.Text = "Run Security Report";
            this.btnRunSecurityReport.UseVisualStyleBackColor = true;
            this.btnRunSecurityReport.Click += new System.EventHandler(this.btnRunSecurityReport_Click);
            // 
            // lnkCopyReport
            // 
            this.lnkCopyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCopyReport.AutoSize = true;
            this.lnkCopyReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCopyReport.Location = new System.Drawing.Point(614, 118);
            this.lnkCopyReport.Name = "lnkCopyReport";
            this.lnkCopyReport.Size = new System.Drawing.Size(66, 13);
            this.lnkCopyReport.TabIndex = 82;
            this.lnkCopyReport.TabStop = true;
            this.lnkCopyReport.Text = "Copy Report";
            this.lnkCopyReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCopyReport_LinkClicked);
            // 
            // grpChooseAReport
            // 
            this.grpChooseAReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChooseAReport.Controls.Add(this.optListGroupMemberShipForUser);
            this.grpChooseAReport.Controls.Add(this.optFindAllPermissionsForUser);
            this.grpChooseAReport.Controls.Add(this.optShowPermissionsInheritanceForSite);
            this.grpChooseAReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChooseAReport.Location = new System.Drawing.Point(5, 46);
            this.grpChooseAReport.Name = "grpChooseAReport";
            this.grpChooseAReport.Size = new System.Drawing.Size(675, 46);
            this.grpChooseAReport.TabIndex = 83;
            this.grpChooseAReport.TabStop = false;
            this.grpChooseAReport.Text = "Choose A Security Report";
            // 
            // btnSelect
            // 
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Image = global::SUSHI.Properties.Resources.select_site1;
            this.btnSelect.Location = new System.Drawing.Point(109, 1);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(106, 23);
            this.btnSelect.TabIndex = 84;
            this.btnSelect.TabStop = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ActionSharepointSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.grpChooseAReport);
            this.Controls.Add(this.lnkCopyReport);
            this.Controls.Add(this.btnRunSecurityReport);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.chkShowLinkToManagePermissions);
            this.Controls.Add(this.chkShowOnlyUnique);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.rtbValidateMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTargetSite);
            this.Name = "ActionSharepointSecurity";
            this.Load += new System.EventHandler(this.ActionSharepointSecurity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.grpChooseAReport.ResumeLayout(false);
            this.grpChooseAReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.RichTextBox rtbValidateMessage;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.CheckBox chkShowOnlyUnique;
        private System.Windows.Forms.CheckBox chkShowLinkToManagePermissions;
        private System.Windows.Forms.RadioButton optListGroupMemberShipForUser;
        private System.Windows.Forms.RadioButton optFindAllPermissionsForUser;
        private System.Windows.Forms.RadioButton optShowPermissionsInheritanceForSite;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Button btnRunSecurityReport;
        private System.Windows.Forms.LinkLabel lnkCopyReport;
        private System.Windows.Forms.GroupBox grpChooseAReport;
        private System.Windows.Forms.PictureBox btnSelect;

    }
}
