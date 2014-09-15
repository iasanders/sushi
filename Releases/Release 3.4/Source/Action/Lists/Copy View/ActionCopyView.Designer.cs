namespace SushiNS
{
    partial class ActionCopyView
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
            this.cboTargetList = new System.Windows.Forms.ComboBox();
            this.lblSiteTemplate = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnCreateView = new System.Windows.Forms.Button();
            this.btnRetrieveLists = new System.Windows.Forms.Button();
            this.cboFavoriteViews = new System.Windows.Forms.ComboBox();
            this.lblViewProfiles = new System.Windows.Forms.Label();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.lnkRemove = new System.Windows.Forms.LinkLabel();
            this.chkLimitDocLibs = new System.Windows.Forms.CheckBox();
            this.lblArrow = new System.Windows.Forms.Label();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.chkRequireListHaveAllFields = new System.Windows.Forms.CheckBox();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.imgBrowse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(3, 180);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 428);
            this.rtbDisplay.TabIndex = 22;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(5, 55);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(380, 32);
            this.rtbSiteValidateMessage.TabIndex = 33;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSitesList.Location = new System.Drawing.Point(5, 9);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(99, 13);
            this.lblAllSitesList.TabIndex = 50;
            this.lblAllSitesList.Text = "SharePoint Site:";
            // 
            // cboTargetList
            // 
            this.cboTargetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTargetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetList.FormattingEnabled = true;
            this.cboTargetList.Location = new System.Drawing.Point(359, 106);
            this.cboTargetList.Name = "cboTargetList";
            this.cboTargetList.Size = new System.Drawing.Size(289, 21);
            this.cboTargetList.Sorted = true;
            this.cboTargetList.TabIndex = 57;
            // 
            // lblSiteTemplate
            // 
            this.lblSiteTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSiteTemplate.AutoSize = true;
            this.lblSiteTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiteTemplate.Location = new System.Drawing.Point(357, 90);
            this.lblSiteTemplate.Name = "lblSiteTemplate";
            this.lblSiteTemplate.Size = new System.Drawing.Size(306, 13);
            this.lblSiteTemplate.TabIndex = 58;
            this.lblSiteTemplate.Text = "Target List (A favorite view will be copied to this list)";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(123, 136);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(84, 23);
            this.btnValidate.TabIndex = 61;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnCreateView
            // 
            this.btnCreateView.Location = new System.Drawing.Point(216, 136);
            this.btnCreateView.Name = "btnCreateView";
            this.btnCreateView.Size = new System.Drawing.Size(84, 23);
            this.btnCreateView.TabIndex = 62;
            this.btnCreateView.Text = "Copy View";
            this.btnCreateView.UseVisualStyleBackColor = true;
            this.btnCreateView.Click += new System.EventHandler(this.btnBulkSiteCreate_Click);
            // 
            // btnRetrieveLists
            // 
            this.btnRetrieveLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieveLists.Location = new System.Drawing.Point(391, 55);
            this.btnRetrieveLists.Name = "btnRetrieveLists";
            this.btnRetrieveLists.Size = new System.Drawing.Size(108, 23);
            this.btnRetrieveLists.TabIndex = 63;
            this.btnRetrieveLists.Text = "Retrieve Lists";
            this.btnRetrieveLists.UseVisualStyleBackColor = true;
            this.btnRetrieveLists.Click += new System.EventHandler(this.btnRetrieveLists_Click);
            // 
            // cboFavoriteViews
            // 
            this.cboFavoriteViews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFavoriteViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFavoriteViews.FormattingEnabled = true;
            this.cboFavoriteViews.Location = new System.Drawing.Point(13, 106);
            this.cboFavoriteViews.Name = "cboFavoriteViews";
            this.cboFavoriteViews.Size = new System.Drawing.Size(292, 21);
            this.cboFavoriteViews.Sorted = true;
            this.cboFavoriteViews.TabIndex = 64;
            this.cboFavoriteViews.SelectedIndexChanged += new System.EventHandler(this.cboFavoriteViews_SelectedIndexChanged);
            // 
            // lblViewProfiles
            // 
            this.lblViewProfiles.AutoSize = true;
            this.lblViewProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewProfiles.Location = new System.Drawing.Point(10, 90);
            this.lblViewProfiles.Name = "lblViewProfiles";
            this.lblViewProfiles.Size = new System.Drawing.Size(94, 13);
            this.lblViewProfiles.TabIndex = 65;
            this.lblViewProfiles.Text = "Favorite Views:";
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Location = new System.Drawing.Point(119, 90);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(26, 13);
            this.lnkAdd.TabIndex = 66;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Add";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // lnkRemove
            // 
            this.lnkRemove.AutoSize = true;
            this.lnkRemove.Location = new System.Drawing.Point(151, 90);
            this.lnkRemove.Name = "lnkRemove";
            this.lnkRemove.Size = new System.Drawing.Size(47, 13);
            this.lnkRemove.TabIndex = 67;
            this.lnkRemove.TabStop = true;
            this.lnkRemove.Text = "Remove";
            this.lnkRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemove_LinkClicked);
            // 
            // chkLimitDocLibs
            // 
            this.chkLimitDocLibs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLimitDocLibs.AutoSize = true;
            this.chkLimitDocLibs.Checked = true;
            this.chkLimitDocLibs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLimitDocLibs.Location = new System.Drawing.Point(506, 59);
            this.chkLimitDocLibs.Name = "chkLimitDocLibs";
            this.chkLimitDocLibs.Size = new System.Drawing.Size(161, 17);
            this.chkLimitDocLibs.TabIndex = 68;
            this.chkLimitDocLibs.Text = "only show document libraries";
            this.chkLimitDocLibs.UseVisualStyleBackColor = true;
            // 
            // lblArrow
            // 
            this.lblArrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArrow.AutoSize = true;
            this.lblArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow.Location = new System.Drawing.Point(320, 109);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(21, 13);
            this.lblArrow.TabIndex = 69;
            this.lblArrow.Text = "=>";
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(3, 28);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(677, 20);
            this.txtTargetSite.TabIndex = 72;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // chkRequireListHaveAllFields
            // 
            this.chkRequireListHaveAllFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRequireListHaveAllFields.AutoSize = true;
            this.chkRequireListHaveAllFields.Checked = true;
            this.chkRequireListHaveAllFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRequireListHaveAllFields.Location = new System.Drawing.Point(363, 136);
            this.chkRequireListHaveAllFields.Name = "chkRequireListHaveAllFields";
            this.chkRequireListHaveAllFields.Size = new System.Drawing.Size(190, 17);
            this.chkRequireListHaveAllFields.TabIndex = 73;
            this.chkRequireListHaveAllFields.Text = "require that list has all fields in view";
            this.chkRequireListHaveAllFields.UseVisualStyleBackColor = true;
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSelectSite.Image = global::SushiNS.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(105, 4);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(105, 22);
            this.imgSelectSite.TabIndex = 74;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // imgBrowse
            // 
            this.imgBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBrowse.Image = global::SushiNS.Properties.Resources.browse;
            this.imgBrowse.Location = new System.Drawing.Point(561, 136);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(89, 22);
            this.imgBrowse.TabIndex = 75;
            this.imgBrowse.TabStop = false;
            this.imgBrowse.Click += new System.EventHandler(this.imgBrowse_Click);
            // 
            // ActionCopyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.chkRequireListHaveAllFields);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.lblArrow);
            this.Controls.Add(this.chkLimitDocLibs);
            this.Controls.Add(this.lnkRemove);
            this.Controls.Add(this.lnkAdd);
            this.Controls.Add(this.lblViewProfiles);
            this.Controls.Add(this.cboFavoriteViews);
            this.Controls.Add(this.btnRetrieveLists);
            this.Controls.Add(this.btnCreateView);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblSiteTemplate);
            this.Controls.Add(this.cboTargetList);
            this.Controls.Add(this.lblAllSitesList);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.rtbDisplay);
            this.Name = "ActionCopyView";
            this.Load += new System.EventHandler(this.ActionBulkSiteCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
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
        private System.Windows.Forms.ComboBox cboTargetList;
        private System.Windows.Forms.Label lblSiteTemplate;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnCreateView;
        private System.Windows.Forms.Button btnRetrieveLists;
        private System.Windows.Forms.Label lblViewProfiles;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.LinkLabel lnkRemove;
        private System.Windows.Forms.CheckBox chkLimitDocLibs;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.TextBox txtTargetSite;
        internal System.Windows.Forms.ComboBox cboFavoriteViews;
        private System.Windows.Forms.CheckBox chkRequireListHaveAllFields;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.PictureBox imgBrowse;

    }
}
