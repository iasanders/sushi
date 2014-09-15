namespace SUSHI
{
    partial class ActionImportDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionImportDocs));
            this.lblSource = new System.Windows.Forms.Label();
            this.txtLocalSourceDir = new System.Windows.Forms.TextBox();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.lblDest = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.txtFileExtentionsToExclude = new System.Windows.Forms.TextBox();
            this.gbRules = new System.Windows.Forms.GroupBox();
            this.lblFileNamesToExclude = new System.Windows.Forms.Label();
            this.chkCreateRootFolderInSharepoint = new System.Windows.Forms.CheckBox();
            this.txtFileExtToExcludeAutomatically = new System.Windows.Forms.TextBox();
            this.lblExtToExclude = new System.Windows.Forms.Label();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.txtDispCounters = new System.Windows.Forms.TextBox();
            this.cboDocLib = new System.Windows.Forms.ComboBox();
            this.rtbValidateMessage = new System.Windows.Forms.RichTextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnRetrieveDocLibs = new System.Windows.Forms.Button();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.imgBrowse = new System.Windows.Forms.PictureBox();
            this.imgBrowseSource = new System.Windows.Forms.PictureBox();
            this.fbdSource = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.gbRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowseSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(6, 121);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(90, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source Folder:";
            // 
            // txtLocalSourceDir
            // 
            this.txtLocalSourceDir.Location = new System.Drawing.Point(6, 137);
            this.txtLocalSourceDir.Name = "txtLocalSourceDir";
            this.txtLocalSourceDir.Size = new System.Drawing.Size(354, 20);
            this.txtLocalSourceDir.TabIndex = 1;
            this.txtLocalSourceDir.TextChanged += new System.EventHandler(this.txtLocalSourceDir_TextChanged);
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Location = new System.Drawing.Point(6, 26);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(668, 20);
            this.txtTargetSite.TabIndex = 2;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtSiteURL_TextChanged);
            this.txtTargetSite.Validating += new System.ComponentModel.CancelEventHandler(this.txtTargetSpWeb_Validating);
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDest.Location = new System.Drawing.Point(6, 8);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(99, 13);
            this.lblDest.TabIndex = 3;
            this.lblDest.Text = "SharePoint Site:";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(101, 168);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(77, 21);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Document Library To Import Into";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(6, 337);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 273);
            this.rtbDisplay.TabIndex = 7;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // txtFileExtentionsToExclude
            // 
            this.txtFileExtentionsToExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileExtentionsToExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileExtentionsToExclude.Location = new System.Drawing.Point(9, 42);
            this.txtFileExtentionsToExclude.Name = "txtFileExtentionsToExclude";
            this.txtFileExtentionsToExclude.Size = new System.Drawing.Size(372, 20);
            this.txtFileExtentionsToExclude.TabIndex = 9;
            this.txtFileExtentionsToExclude.Leave += new System.EventHandler(this.txtFileExtentionsToExclude_Leave);
            // 
            // gbRules
            // 
            this.gbRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRules.Controls.Add(this.lblFileNamesToExclude);
            this.gbRules.Controls.Add(this.chkCreateRootFolderInSharepoint);
            this.gbRules.Controls.Add(this.txtFileExtToExcludeAutomatically);
            this.gbRules.Controls.Add(this.lblExtToExclude);
            this.gbRules.Controls.Add(this.txtFileExtentionsToExclude);
            this.gbRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRules.Location = new System.Drawing.Point(277, 163);
            this.gbRules.Name = "gbRules";
            this.gbRules.Size = new System.Drawing.Size(397, 146);
            this.gbRules.TabIndex = 10;
            this.gbRules.TabStop = false;
            this.gbRules.Text = "Settings";
            // 
            // lblFileNamesToExclude
            // 
            this.lblFileNamesToExclude.AutoSize = true;
            this.lblFileNamesToExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNamesToExclude.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblFileNamesToExclude.Location = new System.Drawing.Point(111, 92);
            this.lblFileNamesToExclude.Name = "lblFileNamesToExclude";
            this.lblFileNamesToExclude.Size = new System.Drawing.Size(278, 13);
            this.lblFileNamesToExclude.TabIndex = 16;
            this.lblFileNamesToExclude.Text = "file names to skip and not log: .permissions, .rules, .stages";
            // 
            // chkCreateRootFolderInSharepoint
            // 
            this.chkCreateRootFolderInSharepoint.AutoSize = true;
            this.chkCreateRootFolderInSharepoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCreateRootFolderInSharepoint.Location = new System.Drawing.Point(9, 118);
            this.chkCreateRootFolderInSharepoint.Name = "chkCreateRootFolderInSharepoint";
            this.chkCreateRootFolderInSharepoint.Size = new System.Drawing.Size(180, 17);
            this.chkCreateRootFolderInSharepoint.TabIndex = 15;
            this.chkCreateRootFolderInSharepoint.Text = "Create Root Folder in Sharepoint";
            this.chkCreateRootFolderInSharepoint.UseVisualStyleBackColor = true;
            // 
            // txtFileExtToExcludeAutomatically
            // 
            this.txtFileExtToExcludeAutomatically.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileExtToExcludeAutomatically.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileExtToExcludeAutomatically.Location = new System.Drawing.Point(9, 68);
            this.txtFileExtToExcludeAutomatically.Name = "txtFileExtToExcludeAutomatically";
            this.txtFileExtToExcludeAutomatically.ReadOnly = true;
            this.txtFileExtToExcludeAutomatically.Size = new System.Drawing.Size(372, 20);
            this.txtFileExtToExcludeAutomatically.TabIndex = 11;
            this.txtFileExtToExcludeAutomatically.Text = resources.GetString("txtFileExtToExcludeAutomatically.Text");
            // 
            // lblExtToExclude
            // 
            this.lblExtToExclude.AutoSize = true;
            this.lblExtToExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtToExclude.Location = new System.Drawing.Point(9, 23);
            this.lblExtToExclude.Name = "lblExtToExclude";
            this.lblExtToExclude.Size = new System.Drawing.Size(304, 13);
            this.lblExtToExclude.TabIndex = 10;
            this.lblExtToExclude.Text = "file extentions to exclude (separate with a semicolon, no period)";
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Enabled = false;
            this.lnkCancel.Location = new System.Drawing.Point(194, 172);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(77, 13);
            this.lnkCancel.TabIndex = 13;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel Upload";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // txtDispCounters
            // 
            this.txtDispCounters.BackColor = System.Drawing.SystemColors.Control;
            this.txtDispCounters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDispCounters.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDispCounters.Location = new System.Drawing.Point(6, 315);
            this.txtDispCounters.Name = "txtDispCounters";
            this.txtDispCounters.Size = new System.Drawing.Size(595, 13);
            this.txtDispCounters.TabIndex = 16;
            this.txtDispCounters.Text = "Total Files:0  Total Bytes:0  Errors:0  Blocked Filetypes:0  Renamed Files:0";
            // 
            // cboDocLib
            // 
            this.cboDocLib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocLib.FormattingEnabled = true;
            this.cboDocLib.Location = new System.Drawing.Point(6, 96);
            this.cboDocLib.MaxDropDownItems = 20;
            this.cboDocLib.Name = "cboDocLib";
            this.cboDocLib.Size = new System.Drawing.Size(354, 21);
            this.cboDocLib.TabIndex = 18;
            this.cboDocLib.SelectedIndexChanged += new System.EventHandler(this.cboDocLib_SelectedIndexChanged);
            // 
            // rtbValidateMessage
            // 
            this.rtbValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbValidateMessage.DetectUrls = false;
            this.rtbValidateMessage.Location = new System.Drawing.Point(180, 47);
            this.rtbValidateMessage.Name = "rtbValidateMessage";
            this.rtbValidateMessage.ReadOnly = true;
            this.rtbValidateMessage.Size = new System.Drawing.Size(393, 32);
            this.rtbValidateMessage.TabIndex = 19;
            this.rtbValidateMessage.Text = "";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(6, 168);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(77, 21);
            this.btnValidate.TabIndex = 79;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnRetrieveDocLibs
            // 
            this.btnRetrieveDocLibs.Location = new System.Drawing.Point(6, 50);
            this.btnRetrieveDocLibs.Name = "btnRetrieveDocLibs";
            this.btnRetrieveDocLibs.Size = new System.Drawing.Size(168, 23);
            this.btnRetrieveDocLibs.TabIndex = 80;
            this.btnRetrieveDocLibs.Text = "Retrieve Document Libraries";
            this.btnRetrieveDocLibs.UseVisualStyleBackColor = true;
            this.btnRetrieveDocLibs.Click += new System.EventHandler(this.btnRetrieveDocLibs_Click);
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSelectSite.Image = global::SUSHI.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(107, 3);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(105, 22);
            this.imgSelectSite.TabIndex = 82;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // imgBrowse
            // 
            this.imgBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBrowse.Image = global::SUSHI.Properties.Resources.browse;
            this.imgBrowse.Location = new System.Drawing.Point(366, 95);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(89, 22);
            this.imgBrowse.TabIndex = 83;
            this.imgBrowse.TabStop = false;
            this.imgBrowse.Click += new System.EventHandler(this.imgBrowse_Click);
            // 
            // imgBrowseSource
            // 
            this.imgBrowseSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBrowseSource.Image = global::SUSHI.Properties.Resources.browse;
            this.imgBrowseSource.Location = new System.Drawing.Point(366, 135);
            this.imgBrowseSource.Name = "imgBrowseSource";
            this.imgBrowseSource.Size = new System.Drawing.Size(89, 22);
            this.imgBrowseSource.TabIndex = 84;
            this.imgBrowseSource.TabStop = false;
            this.imgBrowseSource.Click += new System.EventHandler(this.imgBrowseSource_Click);
            // 
            // fbdSource
            // 
            this.fbdSource.Description = "Select the folder that contains the documents you want to upload.";
            // 
            // ActionImportDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgBrowseSource);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.btnRetrieveDocLibs);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.cboDocLib);
            this.Controls.Add(this.txtDispCounters);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.gbRules);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblDest);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.txtLocalSourceDir);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.rtbValidateMessage);
            this.Name = "ActionImportDocs";
            this.Load += new System.EventHandler(this.ActionImportDocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.gbRules.ResumeLayout(false);
            this.gbRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowseSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        internal System.Windows.Forms.TextBox txtLocalSourceDir;
        internal System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        internal System.Windows.Forms.TextBox txtFileExtentionsToExclude;
        private System.Windows.Forms.GroupBox gbRules;
        private System.Windows.Forms.Label lblExtToExclude;
        private System.Windows.Forms.LinkLabel lnkCancel;
        internal System.Windows.Forms.TextBox txtFileExtToExcludeAutomatically;
        private System.Windows.Forms.CheckBox chkCreateRootFolderInSharepoint;
        internal System.Windows.Forms.TextBox txtDispCounters;
        private System.Windows.Forms.ComboBox cboDocLib;
        private System.Windows.Forms.RichTextBox rtbValidateMessage;
        private System.Windows.Forms.Label lblFileNamesToExclude;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnRetrieveDocLibs;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.PictureBox imgBrowse;
        private System.Windows.Forms.PictureBox imgBrowseSource;
        private System.Windows.Forms.FolderBrowserDialog fbdSource;



    }
}
