namespace SushiNS
{
    partial class ActionBulkListCreation 
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
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.rtbSiteValidateMessage = new System.Windows.Forms.RichTextBox();
            this.lblAllSitesList = new System.Windows.Forms.Label();
            this.cboListTemplates = new System.Windows.Forms.ComboBox();
            this.lblListTemplate = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnBulkListCreate = new System.Windows.Forms.Button();
            this.btnRetrieveTemplates = new System.Windows.Forms.Button();
            this.btnEditSitesToCreateList = new System.Windows.Forms.Button();
            this.lblSiteCount = new System.Windows.Forms.Label();
            this.lnkShowAllTemplates = new System.Windows.Forms.LinkLabel();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.chkOnlyCustomTemplates = new System.Windows.Forms.CheckBox();
            this.chkAddListToQuickLanuch = new System.Windows.Forms.CheckBox();
            this.groupboxToolkit = new System.Windows.Forms.GroupBox();
            this.lnkRenameListURL = new System.Windows.Forms.LinkLabel();
            this.lnkOpenSiteManager = new System.Windows.Forms.LinkLabel();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.imgBrowse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.groupboxToolkit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(3, 226);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 382);
            this.rtbDisplay.TabIndex = 22;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(3, 59);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(677, 18);
            this.rtbSiteValidateMessage.TabIndex = 33;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSitesList.Location = new System.Drawing.Point(3, 11);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(377, 13);
            this.lblAllSitesList.TabIndex = 50;
            this.lblAllSitesList.Text = "SharePoint Site: (child lists will be bulk created beneath this site)";
            // 
            // cboListTemplates
            // 
            this.cboListTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListTemplates.FormattingEnabled = true;
            this.cboListTemplates.Location = new System.Drawing.Point(90, 111);
            this.cboListTemplates.MaxDropDownItems = 30;
            this.cboListTemplates.Name = "cboListTemplates";
            this.cboListTemplates.Size = new System.Drawing.Size(286, 21);
            this.cboListTemplates.Sorted = true;
            this.cboListTemplates.TabIndex = 57;
            this.cboListTemplates.SelectedIndexChanged += new System.EventHandler(this.cboListTemplates_SelectedIndexChanged);
            // 
            // lblListTemplate
            // 
            this.lblListTemplate.AutoSize = true;
            this.lblListTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTemplate.Location = new System.Drawing.Point(3, 114);
            this.lblListTemplate.Name = "lblListTemplate";
            this.lblListTemplate.Size = new System.Drawing.Size(87, 13);
            this.lblListTemplate.TabIndex = 58;
            this.lblListTemplate.Text = "List Template:";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(86, 194);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(82, 23);
            this.btnValidate.TabIndex = 61;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnBulkListCreate
            // 
            this.btnBulkListCreate.Location = new System.Drawing.Point(179, 194);
            this.btnBulkListCreate.Name = "btnBulkListCreate";
            this.btnBulkListCreate.Size = new System.Drawing.Size(113, 23);
            this.btnBulkListCreate.TabIndex = 62;
            this.btnBulkListCreate.Text = "Bulk List Create";
            this.btnBulkListCreate.UseVisualStyleBackColor = true;
            this.btnBulkListCreate.Click += new System.EventHandler(this.btnBulkSiteCreate_Click);
            // 
            // btnRetrieveTemplates
            // 
            this.btnRetrieveTemplates.Location = new System.Drawing.Point(88, 80);
            this.btnRetrieveTemplates.Name = "btnRetrieveTemplates";
            this.btnRetrieveTemplates.Size = new System.Drawing.Size(136, 23);
            this.btnRetrieveTemplates.TabIndex = 63;
            this.btnRetrieveTemplates.Text = "Retrieve List Templates";
            this.btnRetrieveTemplates.UseVisualStyleBackColor = true;
            this.btnRetrieveTemplates.Click += new System.EventHandler(this.btnRetrieveTemplates_Click);
            // 
            // btnEditSitesToCreateList
            // 
            this.btnEditSitesToCreateList.Location = new System.Drawing.Point(88, 138);
            this.btnEditSitesToCreateList.Name = "btnEditSitesToCreateList";
            this.btnEditSitesToCreateList.Size = new System.Drawing.Size(136, 23);
            this.btnEditSitesToCreateList.TabIndex = 64;
            this.btnEditSitesToCreateList.Text = "Edit lists to create";
            this.btnEditSitesToCreateList.UseVisualStyleBackColor = true;
            this.btnEditSitesToCreateList.Click += new System.EventHandler(this.btnEditSitesToCreateList_Click);
            // 
            // lblSiteCount
            // 
            this.lblSiteCount.AutoSize = true;
            this.lblSiteCount.Location = new System.Drawing.Point(230, 143);
            this.lblSiteCount.Name = "lblSiteCount";
            this.lblSiteCount.Size = new System.Drawing.Size(146, 13);
            this.lblSiteCount.TabIndex = 66;
            this.lblSiteCount.Text = "count of new lists to create: 0";
            // 
            // lnkShowAllTemplates
            // 
            this.lnkShowAllTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkShowAllTemplates.AutoSize = true;
            this.lnkShowAllTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowAllTemplates.Location = new System.Drawing.Point(6, 20);
            this.lnkShowAllTemplates.Name = "lnkShowAllTemplates";
            this.lnkShowAllTemplates.Size = new System.Drawing.Size(119, 13);
            this.lnkShowAllTemplates.TabIndex = 69;
            this.lnkShowAllTemplates.TabStop = true;
            this.lnkShowAllTemplates.Text = "Show All List Templates";
            this.lnkShowAllTemplates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowAllTemplates_LinkClicked);
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(3, 32);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(677, 20);
            this.txtTargetSite.TabIndex = 73;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // chkOnlyCustomTemplates
            // 
            this.chkOnlyCustomTemplates.AutoSize = true;
            this.chkOnlyCustomTemplates.Location = new System.Drawing.Point(231, 84);
            this.chkOnlyCustomTemplates.Name = "chkOnlyCustomTemplates";
            this.chkOnlyCustomTemplates.Size = new System.Drawing.Size(158, 17);
            this.chkOnlyCustomTemplates.TabIndex = 75;
            this.chkOnlyCustomTemplates.Text = "only show custom templates";
            this.chkOnlyCustomTemplates.UseVisualStyleBackColor = true;
            this.chkOnlyCustomTemplates.Visible = false;
            // 
            // chkAddListToQuickLanuch
            // 
            this.chkAddListToQuickLanuch.AutoSize = true;
            this.chkAddListToQuickLanuch.Checked = true;
            this.chkAddListToQuickLanuch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddListToQuickLanuch.Location = new System.Drawing.Point(88, 171);
            this.chkAddListToQuickLanuch.Name = "chkAddListToQuickLanuch";
            this.chkAddListToQuickLanuch.Size = new System.Drawing.Size(143, 17);
            this.chkAddListToQuickLanuch.TabIndex = 76;
            this.chkAddListToQuickLanuch.Text = "Add List to QuickLaunch";
            this.chkAddListToQuickLanuch.UseVisualStyleBackColor = true;
            // 
            // groupboxToolkit
            // 
            this.groupboxToolkit.Controls.Add(this.lnkRenameListURL);
            this.groupboxToolkit.Controls.Add(this.lnkOpenSiteManager);
            this.groupboxToolkit.Controls.Add(this.lnkShowAllTemplates);
            this.groupboxToolkit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupboxToolkit.Location = new System.Drawing.Point(461, 83);
            this.groupboxToolkit.Name = "groupboxToolkit";
            this.groupboxToolkit.Size = new System.Drawing.Size(219, 89);
            this.groupboxToolkit.TabIndex = 87;
            this.groupboxToolkit.TabStop = false;
            this.groupboxToolkit.Text = "Tools";
            // 
            // lnkRenameListURL
            // 
            this.lnkRenameListURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkRenameListURL.AutoSize = true;
            this.lnkRenameListURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRenameListURL.Location = new System.Drawing.Point(6, 62);
            this.lnkRenameListURL.Name = "lnkRenameListURL";
            this.lnkRenameListURL.Size = new System.Drawing.Size(91, 13);
            this.lnkRenameListURL.TabIndex = 71;
            this.lnkRenameListURL.TabStop = true;
            this.lnkRenameListURL.Text = "Rename List URL";
            this.lnkRenameListURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRenameListURL_LinkClicked);
            // 
            // lnkOpenSiteManager
            // 
            this.lnkOpenSiteManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkOpenSiteManager.AutoSize = true;
            this.lnkOpenSiteManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpenSiteManager.Location = new System.Drawing.Point(6, 41);
            this.lnkOpenSiteManager.Name = "lnkOpenSiteManager";
            this.lnkOpenSiteManager.Size = new System.Drawing.Size(99, 13);
            this.lnkOpenSiteManager.TabIndex = 70;
            this.lnkOpenSiteManager.TabStop = true;
            this.lnkOpenSiteManager.Text = "Open Site Manager";
            this.lnkOpenSiteManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenSiteManager_LinkClicked);
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSelectSite.Image = global::SushiNS.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(425, 6);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(105, 24);
            this.imgSelectSite.TabIndex = 88;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // imgBrowse
            // 
            this.imgBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBrowse.Image = global::SushiNS.Properties.Resources.browse1;
            this.imgBrowse.Location = new System.Drawing.Point(541, 6);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(88, 24);
            this.imgBrowse.TabIndex = 89;
            this.imgBrowse.TabStop = false;
            this.imgBrowse.Click += new System.EventHandler(this.imgBrowse_Click);
            // 
            // ActionBulkListCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.groupboxToolkit);
            this.Controls.Add(this.chkAddListToQuickLanuch);
            this.Controls.Add(this.chkOnlyCustomTemplates);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.lblSiteCount);
            this.Controls.Add(this.btnEditSitesToCreateList);
            this.Controls.Add(this.btnRetrieveTemplates);
            this.Controls.Add(this.btnBulkListCreate);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblListTemplate);
            this.Controls.Add(this.cboListTemplates);
            this.Controls.Add(this.lblAllSitesList);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.rtbDisplay);
            this.Name = "ActionBulkListCreation";
            this.Load += new System.EventHandler(this.ActionBulkSiteCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.groupboxToolkit.ResumeLayout(false);
            this.groupboxToolkit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.RichTextBox rtbSiteValidateMessage;
        private System.Windows.Forms.Label lblAllSitesList;
        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboListTemplates;
        private System.Windows.Forms.Label lblListTemplate;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnBulkListCreate;
        private System.Windows.Forms.Button btnRetrieveTemplates;
        private System.Windows.Forms.Button btnEditSitesToCreateList;
        internal System.Windows.Forms.Label lblSiteCount;
        private System.Windows.Forms.LinkLabel lnkShowAllTemplates;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.CheckBox chkOnlyCustomTemplates;
        private System.Windows.Forms.CheckBox chkAddListToQuickLanuch;
        private System.Windows.Forms.GroupBox groupboxToolkit;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.PictureBox imgBrowse;
        private System.Windows.Forms.LinkLabel lnkOpenSiteManager;
        private System.Windows.Forms.LinkLabel lnkRenameListURL;

    }
}
