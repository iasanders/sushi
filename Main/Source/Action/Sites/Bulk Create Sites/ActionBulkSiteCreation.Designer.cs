namespace SUSHI
{
    partial class ActionBulkSiteCreation
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
            this.cboSiteTemplates = new System.Windows.Forms.ComboBox();
            this.lblSiteTemplate = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnBulkSiteCreate = new System.Windows.Forms.Button();
            this.btnRetrieveTemplates = new System.Windows.Forms.Button();
            this.btnEditSitesToCreateList = new System.Windows.Forms.Button();
            this.lnkDeleteSubsites = new System.Windows.Forms.LinkLabel();
            this.lblSiteCount = new System.Windows.Forms.Label();
            this.lnkShowAllTemplates = new System.Windows.Forms.LinkLabel();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.chkOnlyCustomTemplates = new System.Windows.Forms.CheckBox();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(3, 211);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 402);
            this.rtbDisplay.TabIndex = 22;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(3, 51);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(677, 18);
            this.rtbSiteValidateMessage.TabIndex = 33;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Location = new System.Drawing.Point(5, 7);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(312, 13);
            this.lblAllSitesList.TabIndex = 50;
            this.lblAllSitesList.Text = "SharePoint Site: (child sites will be bulk created beneath this site)";
            // 
            // cboSiteTemplates
            // 
            this.cboSiteTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSiteTemplates.FormattingEnabled = true;
            this.cboSiteTemplates.Location = new System.Drawing.Point(85, 101);
            this.cboSiteTemplates.MaxDropDownItems = 30;
            this.cboSiteTemplates.Name = "cboSiteTemplates";
            this.cboSiteTemplates.Size = new System.Drawing.Size(286, 21);
            this.cboSiteTemplates.Sorted = true;
            this.cboSiteTemplates.TabIndex = 57;
            this.cboSiteTemplates.SelectedIndexChanged += new System.EventHandler(this.cboSiteTemplates_SelectedIndexChanged);
            // 
            // lblSiteTemplate
            // 
            this.lblSiteTemplate.AutoSize = true;
            this.lblSiteTemplate.Location = new System.Drawing.Point(3, 104);
            this.lblSiteTemplate.Name = "lblSiteTemplate";
            this.lblSiteTemplate.Size = new System.Drawing.Size(72, 13);
            this.lblSiteTemplate.TabIndex = 58;
            this.lblSiteTemplate.Text = "Site Template";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(196, 182);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(122, 23);
            this.btnValidate.TabIndex = 61;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnBulkSiteCreate
            // 
            this.btnBulkSiteCreate.Location = new System.Drawing.Point(345, 182);
            this.btnBulkSiteCreate.Name = "btnBulkSiteCreate";
            this.btnBulkSiteCreate.Size = new System.Drawing.Size(154, 23);
            this.btnBulkSiteCreate.TabIndex = 62;
            this.btnBulkSiteCreate.Text = "Bulk Site Create";
            this.btnBulkSiteCreate.UseVisualStyleBackColor = true;
            this.btnBulkSiteCreate.Click += new System.EventHandler(this.btnBulkSiteCreate_Click);
            // 
            // btnRetrieveTemplates
            // 
            this.btnRetrieveTemplates.Location = new System.Drawing.Point(85, 73);
            this.btnRetrieveTemplates.Name = "btnRetrieveTemplates";
            this.btnRetrieveTemplates.Size = new System.Drawing.Size(136, 23);
            this.btnRetrieveTemplates.TabIndex = 63;
            this.btnRetrieveTemplates.Text = "Retrieve Site Templates";
            this.btnRetrieveTemplates.UseVisualStyleBackColor = true;
            this.btnRetrieveTemplates.Click += new System.EventHandler(this.btnRetrieveTemplates_Click);
            // 
            // btnEditSitesToCreateList
            // 
            this.btnEditSitesToCreateList.Location = new System.Drawing.Point(85, 128);
            this.btnEditSitesToCreateList.Name = "btnEditSitesToCreateList";
            this.btnEditSitesToCreateList.Size = new System.Drawing.Size(136, 23);
            this.btnEditSitesToCreateList.TabIndex = 64;
            this.btnEditSitesToCreateList.Text = "Edit sites to create list";
            this.btnEditSitesToCreateList.UseVisualStyleBackColor = true;
            this.btnEditSitesToCreateList.Click += new System.EventHandler(this.btnEditSitesToCreateList_Click);
            // 
            // lnkDeleteSubsites
            // 
            this.lnkDeleteSubsites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDeleteSubsites.AutoSize = true;
            this.lnkDeleteSubsites.Location = new System.Drawing.Point(591, 187);
            this.lnkDeleteSubsites.Name = "lnkDeleteSubsites";
            this.lnkDeleteSubsites.Size = new System.Drawing.Size(89, 13);
            this.lnkDeleteSubsites.TabIndex = 65;
            this.lnkDeleteSubsites.TabStop = true;
            this.lnkDeleteSubsites.Text = "delete subsites ...";
            this.lnkDeleteSubsites.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteSubsites_LinkClicked);
            // 
            // lblSiteCount
            // 
            this.lblSiteCount.AutoSize = true;
            this.lblSiteCount.Location = new System.Drawing.Point(229, 133);
            this.lblSiteCount.Name = "lblSiteCount";
            this.lblSiteCount.Size = new System.Drawing.Size(150, 13);
            this.lblSiteCount.TabIndex = 66;
            this.lblSiteCount.Text = "count of new sites to create: 0";
            // 
            // lnkShowAllTemplates
            // 
            this.lnkShowAllTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkShowAllTemplates.AutoSize = true;
            this.lnkShowAllTemplates.Location = new System.Drawing.Point(568, 161);
            this.lnkShowAllTemplates.Name = "lnkShowAllTemplates";
            this.lnkShowAllTemplates.Size = new System.Drawing.Size(112, 13);
            this.lnkShowAllTemplates.TabIndex = 69;
            this.lnkShowAllTemplates.TabStop = true;
            this.lnkShowAllTemplates.Text = "show all site templates";
            this.lnkShowAllTemplates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowAllTemplates_LinkClicked);
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(3, 28);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(677, 20);
            this.txtTargetSite.TabIndex = 73;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // chkOnlyCustomTemplates
            // 
            this.chkOnlyCustomTemplates.AutoSize = true;
            this.chkOnlyCustomTemplates.Location = new System.Drawing.Point(232, 77);
            this.chkOnlyCustomTemplates.Name = "chkOnlyCustomTemplates";
            this.chkOnlyCustomTemplates.Size = new System.Drawing.Size(158, 17);
            this.chkOnlyCustomTemplates.TabIndex = 75;
            this.chkOnlyCustomTemplates.Text = "only show custom templates";
            this.chkOnlyCustomTemplates.UseVisualStyleBackColor = true;
            this.chkOnlyCustomTemplates.CheckedChanged += new System.EventHandler(this.chkOnlyCustomTemplates_CheckedChanged);
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Image = global::SUSHI.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(353, 3);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(106, 22);
            this.imgSelectSite.TabIndex = 76;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // ActionBulkSiteCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.chkOnlyCustomTemplates);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.lnkShowAllTemplates);
            this.Controls.Add(this.lblSiteCount);
            this.Controls.Add(this.lnkDeleteSubsites);
            this.Controls.Add(this.btnEditSitesToCreateList);
            this.Controls.Add(this.btnRetrieveTemplates);
            this.Controls.Add(this.btnBulkSiteCreate);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblSiteTemplate);
            this.Controls.Add(this.cboSiteTemplates);
            this.Controls.Add(this.lblAllSitesList);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.rtbDisplay);
            this.Name = "ActionBulkSiteCreation";
            this.Load += new System.EventHandler(this.ActionBulkSiteCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.RichTextBox rtbSiteValidateMessage;
        private System.Windows.Forms.Label lblAllSitesList;
        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboSiteTemplates;
        private System.Windows.Forms.Label lblSiteTemplate;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnBulkSiteCreate;
        private System.Windows.Forms.Button btnRetrieveTemplates;
        private System.Windows.Forms.Button btnEditSitesToCreateList;
        private System.Windows.Forms.LinkLabel lnkDeleteSubsites;
        internal System.Windows.Forms.Label lblSiteCount;
        private System.Windows.Forms.LinkLabel lnkShowAllTemplates;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.CheckBox chkOnlyCustomTemplates;
        private System.Windows.Forms.PictureBox imgSelectSite;

    }
}
