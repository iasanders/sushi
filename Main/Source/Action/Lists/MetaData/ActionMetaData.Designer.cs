namespace SUSHI
{
    partial class ActionMetadata
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
            this.rtbValidateMessage = new System.Windows.Forms.RichTextBox();
            this.lblAllSitesList = new System.Windows.Forms.Label();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateMetadata_1 = new System.Windows.Forms.Button();
            this.btnValidate_1 = new System.Windows.Forms.Button();
            this.btnPopulateDocLibs = new System.Windows.Forms.Button();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboColumnNames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCurrentValue = new System.Windows.Forms.ComboBox();
            this.btnMapData = new System.Windows.Forms.Button();
            this.cboMappingProfile = new System.Windows.Forms.ComboBox();
            this.lnkEditProfiles = new System.Windows.Forms.LinkLabel();
            this.lnkShowAllMetadata = new System.Windows.Forms.LinkLabel();
            this.cboDocLibs = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUpdateValuesForAColumn = new System.Windows.Forms.TabPage();
            this.lnkShowColumnInfo = new System.Windows.Forms.LinkLabel();
            this.tabApplyContentType = new System.Windows.Forms.TabPage();
            this.lnkCopyProfile = new System.Windows.Forms.LinkLabel();
            this.lnkDeleteSourceColumns = new System.Windows.Forms.LinkLabel();
            this.lnkAddContentTypeFromRoot = new System.Windows.Forms.LinkLabel();
            this.lnkAddNew = new System.Windows.Forms.LinkLabel();
            this.btnValidate_2 = new System.Windows.Forms.Button();
            this.lblProfile = new System.Windows.Forms.Label();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.imgBrowse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabUpdateValuesForAColumn.SuspendLayout();
            this.tabApplyContentType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbValidateMessage
            // 
            this.rtbValidateMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbValidateMessage.DetectUrls = false;
            this.rtbValidateMessage.Location = new System.Drawing.Point(296, 51);
            this.rtbValidateMessage.Name = "rtbValidateMessage";
            this.rtbValidateMessage.ReadOnly = true;
            this.rtbValidateMessage.Size = new System.Drawing.Size(380, 26);
            this.rtbValidateMessage.TabIndex = 24;
            this.rtbValidateMessage.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSitesList.Location = new System.Drawing.Point(3, 5);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(99, 13);
            this.lblAllSitesList.TabIndex = 22;
            this.lblAllSitesList.Text = "SharePoint Site:";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(5, 279);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(675, 330);
            this.rtbDisplay.TabIndex = 26;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Target Document Library:";
            // 
            // btnUpdateMetadata_1
            // 
            this.btnUpdateMetadata_1.Location = new System.Drawing.Point(215, 100);
            this.btnUpdateMetadata_1.Name = "btnUpdateMetadata_1";
            this.btnUpdateMetadata_1.Size = new System.Drawing.Size(203, 23);
            this.btnUpdateMetadata_1.TabIndex = 51;
            this.btnUpdateMetadata_1.Text = "Update values in column to new value";
            this.btnUpdateMetadata_1.UseVisualStyleBackColor = true;
            this.btnUpdateMetadata_1.Click += new System.EventHandler(this.btnUpdatemetadata_Click);
            // 
            // btnValidate_1
            // 
            this.btnValidate_1.Location = new System.Drawing.Point(136, 100);
            this.btnValidate_1.Name = "btnValidate_1";
            this.btnValidate_1.Size = new System.Drawing.Size(74, 23);
            this.btnValidate_1.TabIndex = 53;
            this.btnValidate_1.Text = "Validate";
            this.btnValidate_1.UseVisualStyleBackColor = true;
            this.btnValidate_1.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnPopulateDocLibs
            // 
            this.btnPopulateDocLibs.Location = new System.Drawing.Point(155, 51);
            this.btnPopulateDocLibs.Name = "btnPopulateDocLibs";
            this.btnPopulateDocLibs.Size = new System.Drawing.Size(101, 23);
            this.btnPopulateDocLibs.TabIndex = 56;
            this.btnPopulateDocLibs.Text = "Retrieve Lists";
            this.btnPopulateDocLibs.UseVisualStyleBackColor = true;
            this.btnPopulateDocLibs.Click += new System.EventHandler(this.btnPopulateDocLibs_Click);
            // 
            // txtNewValue
            // 
            this.txtNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewValue.Location = new System.Drawing.Point(138, 72);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(391, 20);
            this.txtNewValue.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Current Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "New Value:";
            // 
            // cboColumnNames
            // 
            this.cboColumnNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboColumnNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumnNames.FormattingEnabled = true;
            this.cboColumnNames.Location = new System.Drawing.Point(138, 18);
            this.cboColumnNames.MaxDropDownItems = 35;
            this.cboColumnNames.Name = "cboColumnNames";
            this.cboColumnNames.Size = new System.Drawing.Size(391, 21);
            this.cboColumnNames.Sorted = true;
            this.cboColumnNames.TabIndex = 61;
            this.cboColumnNames.SelectedIndexChanged += new System.EventHandler(this.cboColumnNames_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Metadata Column Name:";
            // 
            // cboCurrentValue
            // 
            this.cboCurrentValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrentValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentValue.FormattingEnabled = true;
            this.cboCurrentValue.Location = new System.Drawing.Point(138, 45);
            this.cboCurrentValue.MaxDropDownItems = 60;
            this.cboCurrentValue.Name = "cboCurrentValue";
            this.cboCurrentValue.Size = new System.Drawing.Size(391, 21);
            this.cboCurrentValue.Sorted = true;
            this.cboCurrentValue.TabIndex = 63;
            // 
            // btnMapData
            // 
            this.btnMapData.Location = new System.Drawing.Point(305, 106);
            this.btnMapData.Name = "btnMapData";
            this.btnMapData.Size = new System.Drawing.Size(161, 23);
            this.btnMapData.TabIndex = 65;
            this.btnMapData.Text = "Map Data";
            this.btnMapData.UseVisualStyleBackColor = true;
            this.btnMapData.Click += new System.EventHandler(this.btnMapData_Click);
            // 
            // cboMappingProfile
            // 
            this.cboMappingProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMappingProfile.FormattingEnabled = true;
            this.cboMappingProfile.Location = new System.Drawing.Point(24, 50);
            this.cboMappingProfile.Name = "cboMappingProfile";
            this.cboMappingProfile.Size = new System.Drawing.Size(204, 21);
            this.cboMappingProfile.TabIndex = 66;
            this.cboMappingProfile.SelectedIndexChanged += new System.EventHandler(this.cboMappingProfile_SelectedIndexChanged);
            // 
            // lnkEditProfiles
            // 
            this.lnkEditProfiles.AutoSize = true;
            this.lnkEditProfiles.Enabled = false;
            this.lnkEditProfiles.Location = new System.Drawing.Point(267, 53);
            this.lnkEditProfiles.Name = "lnkEditProfiles";
            this.lnkEditProfiles.Size = new System.Drawing.Size(24, 13);
            this.lnkEditProfiles.TabIndex = 67;
            this.lnkEditProfiles.TabStop = true;
            this.lnkEditProfiles.Text = "edit";
            this.lnkEditProfiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditProfiles_LinkClicked);
            // 
            // lnkShowAllMetadata
            // 
            this.lnkShowAllMetadata.AutoSize = true;
            this.lnkShowAllMetadata.Location = new System.Drawing.Point(476, 30);
            this.lnkShowAllMetadata.Name = "lnkShowAllMetadata";
            this.lnkShowAllMetadata.Size = new System.Drawing.Size(177, 13);
            this.lnkShowAllMetadata.TabIndex = 68;
            this.lnkShowAllMetadata.TabStop = true;
            this.lnkShowAllMetadata.Text = "Show all metadata for all documents";
            this.lnkShowAllMetadata.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowAllMetadata_LinkClicked);
            // 
            // cboDocLibs
            // 
            this.cboDocLibs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDocLibs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocLibs.FormattingEnabled = true;
            this.cboDocLibs.Location = new System.Drawing.Point(154, 78);
            this.cboDocLibs.MaxDropDownItems = 40;
            this.cboDocLibs.Name = "cboDocLibs";
            this.cboDocLibs.Size = new System.Drawing.Size(314, 21);
            this.cboDocLibs.Sorted = true;
            this.cboDocLibs.TabIndex = 69;
            this.cboDocLibs.SelectedIndexChanged += new System.EventHandler(this.cboDocLibs_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabUpdateValuesForAColumn);
            this.tabControl1.Controls.Add(this.tabApplyContentType);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(3, 111);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 161);
            this.tabControl1.TabIndex = 71;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabUpdateValuesForAColumn
            // 
            this.tabUpdateValuesForAColumn.Controls.Add(this.lnkShowColumnInfo);
            this.tabUpdateValuesForAColumn.Controls.Add(this.cboCurrentValue);
            this.tabUpdateValuesForAColumn.Controls.Add(this.txtNewValue);
            this.tabUpdateValuesForAColumn.Controls.Add(this.label2);
            this.tabUpdateValuesForAColumn.Controls.Add(this.label3);
            this.tabUpdateValuesForAColumn.Controls.Add(this.cboColumnNames);
            this.tabUpdateValuesForAColumn.Controls.Add(this.label4);
            this.tabUpdateValuesForAColumn.Controls.Add(this.btnUpdateMetadata_1);
            this.tabUpdateValuesForAColumn.Controls.Add(this.btnValidate_1);
            this.tabUpdateValuesForAColumn.Location = new System.Drawing.Point(4, 22);
            this.tabUpdateValuesForAColumn.Name = "tabUpdateValuesForAColumn";
            this.tabUpdateValuesForAColumn.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdateValuesForAColumn.Size = new System.Drawing.Size(669, 135);
            this.tabUpdateValuesForAColumn.TabIndex = 0;
            this.tabUpdateValuesForAColumn.Text = "Update values of a column";
            this.tabUpdateValuesForAColumn.UseVisualStyleBackColor = true;
            // 
            // lnkShowColumnInfo
            // 
            this.lnkShowColumnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkShowColumnInfo.AutoSize = true;
            this.lnkShowColumnInfo.Location = new System.Drawing.Point(535, 21);
            this.lnkShowColumnInfo.Name = "lnkShowColumnInfo";
            this.lnkShowColumnInfo.Size = new System.Drawing.Size(89, 13);
            this.lnkShowColumnInfo.TabIndex = 65;
            this.lnkShowColumnInfo.TabStop = true;
            this.lnkShowColumnInfo.Text = "show column info";
            this.lnkShowColumnInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowColumnInfo_LinkClicked);
            // 
            // tabApplyContentType
            // 
            this.tabApplyContentType.Controls.Add(this.lnkCopyProfile);
            this.tabApplyContentType.Controls.Add(this.lnkDeleteSourceColumns);
            this.tabApplyContentType.Controls.Add(this.lnkAddContentTypeFromRoot);
            this.tabApplyContentType.Controls.Add(this.lnkAddNew);
            this.tabApplyContentType.Controls.Add(this.btnValidate_2);
            this.tabApplyContentType.Controls.Add(this.lblProfile);
            this.tabApplyContentType.Controls.Add(this.cboMappingProfile);
            this.tabApplyContentType.Controls.Add(this.lnkEditProfiles);
            this.tabApplyContentType.Controls.Add(this.lnkShowAllMetadata);
            this.tabApplyContentType.Controls.Add(this.btnMapData);
            this.tabApplyContentType.Location = new System.Drawing.Point(4, 22);
            this.tabApplyContentType.Name = "tabApplyContentType";
            this.tabApplyContentType.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplyContentType.Size = new System.Drawing.Size(669, 135);
            this.tabApplyContentType.TabIndex = 1;
            this.tabApplyContentType.Text = "Map Data";
            this.tabApplyContentType.UseVisualStyleBackColor = true;
            // 
            // lnkCopyProfile
            // 
            this.lnkCopyProfile.AutoSize = true;
            this.lnkCopyProfile.Enabled = false;
            this.lnkCopyProfile.Location = new System.Drawing.Point(297, 53);
            this.lnkCopyProfile.Name = "lnkCopyProfile";
            this.lnkCopyProfile.Size = new System.Drawing.Size(30, 13);
            this.lnkCopyProfile.TabIndex = 76;
            this.lnkCopyProfile.TabStop = true;
            this.lnkCopyProfile.Text = "copy";
            this.lnkCopyProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCopyProfile_LinkClicked);
            // 
            // lnkDeleteSourceColumns
            // 
            this.lnkDeleteSourceColumns.AutoSize = true;
            this.lnkDeleteSourceColumns.Location = new System.Drawing.Point(476, 58);
            this.lnkDeleteSourceColumns.Name = "lnkDeleteSourceColumns";
            this.lnkDeleteSourceColumns.Size = new System.Drawing.Size(174, 13);
            this.lnkDeleteSourceColumns.TabIndex = 75;
            this.lnkDeleteSourceColumns.TabStop = true;
            this.lnkDeleteSourceColumns.Text = "Delete source columns from library..";
            this.lnkDeleteSourceColumns.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteSourceColumns_LinkClicked);
            // 
            // lnkAddContentTypeFromRoot
            // 
            this.lnkAddContentTypeFromRoot.AutoSize = true;
            this.lnkAddContentTypeFromRoot.Location = new System.Drawing.Point(476, 3);
            this.lnkAddContentTypeFromRoot.Name = "lnkAddContentTypeFromRoot";
            this.lnkAddContentTypeFromRoot.Size = new System.Drawing.Size(136, 13);
            this.lnkAddContentTypeFromRoot.TabIndex = 73;
            this.lnkAddContentTypeFromRoot.TabStop = true;
            this.lnkAddContentTypeFromRoot.Text = "Add content type to library..";
            this.lnkAddContentTypeFromRoot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddContentTypeFromRoot_LinkClicked);
            // 
            // lnkAddNew
            // 
            this.lnkAddNew.AutoSize = true;
            this.lnkAddNew.Location = new System.Drawing.Point(234, 53);
            this.lnkAddNew.Name = "lnkAddNew";
            this.lnkAddNew.Size = new System.Drawing.Size(27, 13);
            this.lnkAddNew.TabIndex = 71;
            this.lnkAddNew.TabStop = true;
            this.lnkAddNew.Text = "new";
            this.lnkAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddNew_LinkClicked);
            // 
            // btnValidate_2
            // 
            this.btnValidate_2.Location = new System.Drawing.Point(210, 106);
            this.btnValidate_2.Name = "btnValidate_2";
            this.btnValidate_2.Size = new System.Drawing.Size(89, 23);
            this.btnValidate_2.TabIndex = 70;
            this.btnValidate_2.Text = "Validate";
            this.btnValidate_2.UseVisualStyleBackColor = true;
            this.btnValidate_2.Click += new System.EventHandler(this.btnValidateCT_Click);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(6, 30);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(80, 13);
            this.lblProfile.TabIndex = 69;
            this.lblProfile.Text = "Mapping Profile";
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(3, 24);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(677, 20);
            this.txtTargetSite.TabIndex = 74;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSelectSite.Image = global::SUSHI.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(103, 1);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(106, 22);
            this.imgSelectSite.TabIndex = 76;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // imgBrowse
            // 
            this.imgBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBrowse.Image = global::SUSHI.Properties.Resources.browse1;
            this.imgBrowse.Location = new System.Drawing.Point(469, 78);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(88, 22);
            this.imgBrowse.TabIndex = 91;
            this.imgBrowse.TabStop = false;
            this.imgBrowse.Click += new System.EventHandler(this.imgBrowse_Click_1);
            // 
            // ActionMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cboDocLibs);
            this.Controls.Add(this.btnPopulateDocLibs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.rtbValidateMessage);
            this.Controls.Add(this.lblAllSitesList);
            this.Name = "ActionMetadata";
            this.Load += new System.EventHandler(this.ActionMetadata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabUpdateValuesForAColumn.ResumeLayout(false);
            this.tabUpdateValuesForAColumn.PerformLayout();
            this.tabApplyContentType.ResumeLayout(false);
            this.tabApplyContentType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbValidateMessage;
        private System.Windows.Forms.Label lblAllSitesList;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateMetadata_1;
        private System.Windows.Forms.Button btnValidate_1;
        private System.Windows.Forms.Button btnPopulateDocLibs;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboColumnNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCurrentValue;
        private System.Windows.Forms.Button btnMapData;
        private System.Windows.Forms.LinkLabel lnkShowAllMetadata;
        private System.Windows.Forms.ComboBox cboDocLibs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUpdateValuesForAColumn;
        private System.Windows.Forms.TabPage tabApplyContentType;
        private System.Windows.Forms.Label lblProfile;
        internal System.Windows.Forms.ComboBox cboMappingProfile;
        private System.Windows.Forms.LinkLabel lnkAddNew;
        private System.Windows.Forms.Button btnValidate_2;
        private System.Windows.Forms.LinkLabel lnkAddContentTypeFromRoot;
        private System.Windows.Forms.LinkLabel lnkShowColumnInfo;
        private System.Windows.Forms.LinkLabel lnkDeleteSourceColumns;
        internal System.Windows.Forms.LinkLabel lnkEditProfiles;
        internal System.Windows.Forms.LinkLabel lnkCopyProfile;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.PictureBox imgBrowse;


    }
}
