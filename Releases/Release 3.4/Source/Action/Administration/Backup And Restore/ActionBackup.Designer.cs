namespace SushiNS
{
    partial class ActionBackup
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
            this.btnValidateBackup = new System.Windows.Forms.Button();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.btnStartBackup = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.lnkOpen = new System.Windows.Forms.LinkLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblBackupFilesPath = new System.Windows.Forms.Label();
            this.optBackupAllSubsites = new System.Windows.Forms.RadioButton();
            this.optBackupOnlyTopLevelSite = new System.Windows.Forms.RadioButton();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.lstSiteURLs = new System.Windows.Forms.ListBox();
            this.lnkAddURL = new System.Windows.Forms.LinkLabel();
            this.lnkRemoveURL = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.lnkSelectASite1 = new System.Windows.Forms.PictureBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.ucCreateSchedule1 = new SushiNS.ucCreateSchedule();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkSelectASite1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbValidateMessage
            // 
            this.rtbValidateMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbValidateMessage.DetectUrls = false;
            this.rtbValidateMessage.Location = new System.Drawing.Point(91, 57);
            this.rtbValidateMessage.Name = "rtbValidateMessage";
            this.rtbValidateMessage.ReadOnly = true;
            this.rtbValidateMessage.Size = new System.Drawing.Size(457, 15);
            this.rtbValidateMessage.TabIndex = 24;
            this.rtbValidateMessage.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSitesList.Location = new System.Drawing.Point(3, 14);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(99, 13);
            this.lblAllSitesList.TabIndex = 22;
            this.lblAllSitesList.Text = "SharePoint Site:";
            // 
            // btnValidateBackup
            // 
            this.btnValidateBackup.Location = new System.Drawing.Point(7, 253);
            this.btnValidateBackup.Name = "btnValidateBackup";
            this.btnValidateBackup.Size = new System.Drawing.Size(123, 23);
            this.btnValidateBackup.TabIndex = 25;
            this.btnValidateBackup.Text = "Validate Backup";
            this.btnValidateBackup.UseVisualStyleBackColor = true;
            this.btnValidateBackup.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(5, 282);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(675, 188);
            this.rtbDisplay.TabIndex = 26;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.Location = new System.Drawing.Point(140, 253);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(123, 23);
            this.btnStartBackup.TabIndex = 27;
            this.btnStartBackup.Text = "Start Backup";
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupPath.Location = new System.Drawing.Point(3, 186);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(646, 20);
            this.txtBackupPath.TabIndex = 28;
            // 
            // lnkOpen
            // 
            this.lnkOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkOpen.AutoSize = true;
            this.lnkOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpen.Location = new System.Drawing.Point(604, 170);
            this.lnkOpen.Name = "lnkOpen";
            this.lnkOpen.Size = new System.Drawing.Size(41, 13);
            this.lnkOpen.TabIndex = 36;
            this.lnkOpen.TabStop = true;
            this.lnkOpen.Text = "browse";
            this.lnkOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpen_LinkClicked);
            // 
            // lblBackupFilesPath
            // 
            this.lblBackupFilesPath.AutoSize = true;
            this.lblBackupFilesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupFilesPath.Location = new System.Drawing.Point(0, 169);
            this.lblBackupFilesPath.Name = "lblBackupFilesPath";
            this.lblBackupFilesPath.Size = new System.Drawing.Size(187, 13);
            this.lblBackupFilesPath.TabIndex = 37;
            this.lblBackupFilesPath.Text = "Store Backups in this Directory:";
            // 
            // optBackupAllSubsites
            // 
            this.optBackupAllSubsites.AutoSize = true;
            this.optBackupAllSubsites.Location = new System.Drawing.Point(170, 221);
            this.optBackupAllSubsites.Name = "optBackupAllSubsites";
            this.optBackupAllSubsites.Size = new System.Drawing.Size(115, 17);
            this.optBackupAllSubsites.TabIndex = 40;
            this.optBackupAllSubsites.TabStop = true;
            this.optBackupAllSubsites.Text = "backup all subsites";
            this.optBackupAllSubsites.UseVisualStyleBackColor = true;
            // 
            // optBackupOnlyTopLevelSite
            // 
            this.optBackupOnlyTopLevelSite.AutoSize = true;
            this.optBackupOnlyTopLevelSite.Location = new System.Drawing.Point(9, 221);
            this.optBackupOnlyTopLevelSite.Name = "optBackupOnlyTopLevelSite";
            this.optBackupOnlyTopLevelSite.Size = new System.Drawing.Size(145, 17);
            this.optBackupOnlyTopLevelSite.TabIndex = 41;
            this.optBackupOnlyTopLevelSite.TabStop = true;
            this.optBackupOnlyTopLevelSite.Text = "backup only top-level site";
            this.optBackupOnlyTopLevelSite.UseVisualStyleBackColor = true;
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Enabled = false;
            this.lnkCancel.Location = new System.Drawing.Point(274, 260);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(80, 13);
            this.lnkCancel.TabIndex = 42;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel Backup";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // lstSiteURLs
            // 
            this.lstSiteURLs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSiteURLs.FormattingEnabled = true;
            this.lstSiteURLs.Location = new System.Drawing.Point(5, 79);
            this.lstSiteURLs.Name = "lstSiteURLs";
            this.lstSiteURLs.ScrollAlwaysVisible = true;
            this.lstSiteURLs.Size = new System.Drawing.Size(675, 69);
            this.lstSiteURLs.Sorted = true;
            this.lstSiteURLs.TabIndex = 45;
            // 
            // lnkAddURL
            // 
            this.lnkAddURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAddURL.AutoSize = true;
            this.lnkAddURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddURL.Location = new System.Drawing.Point(572, 63);
            this.lnkAddURL.Name = "lnkAddURL";
            this.lnkAddURL.Size = new System.Drawing.Size(39, 13);
            this.lnkAddURL.TabIndex = 46;
            this.lnkAddURL.TabStop = true;
            this.lnkAddURL.Text = "add url";
            this.lnkAddURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddURL_LinkClicked);
            // 
            // lnkRemoveURL
            // 
            this.lnkRemoveURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkRemoveURL.AutoSize = true;
            this.lnkRemoveURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRemoveURL.Location = new System.Drawing.Point(620, 63);
            this.lnkRemoveURL.Name = "lnkRemoveURL";
            this.lnkRemoveURL.Size = new System.Drawing.Size(56, 13);
            this.lnkRemoveURL.TabIndex = 47;
            this.lnkRemoveURL.TabStop = true;
            this.lnkRemoveURL.Text = "remove url";
            this.lnkRemoveURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemoveURL_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Sites to Backup";
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(3, 31);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(673, 20);
            this.txtTargetSite.TabIndex = 74;
            // 
            // lnkSelectASite1
            // 
            this.lnkSelectASite1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkSelectASite1.Image = global::SushiNS.Properties.Resources.select_site1;
            this.lnkSelectASite1.Location = new System.Drawing.Point(107, 7);
            this.lnkSelectASite1.Name = "lnkSelectASite1";
            this.lnkSelectASite1.Size = new System.Drawing.Size(105, 22);
            this.lnkSelectASite1.TabIndex = 76;
            this.lnkSelectASite1.TabStop = false;
            this.lnkSelectASite1.Click += new System.EventHandler(this.lnkSelectASite1_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder.Location = new System.Drawing.Point(652, 184);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(28, 23);
            this.btnSelectFolder.TabIndex = 78;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // ucCreateSchedule1
            // 
            this.ucCreateSchedule1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCreateSchedule1.AutoStartType = SushiNS.AutoStartUtil.AutoStartMode.Catapult_SharePoint_Autobackup;
            this.ucCreateSchedule1.Location = new System.Drawing.Point(5, 476);
            this.ucCreateSchedule1.Name = "ucCreateSchedule1";
            this.ucCreateSchedule1.RtbDisplay = this.rtbDisplay;
            this.ucCreateSchedule1.Size = new System.Drawing.Size(673, 116);
            this.ucCreateSchedule1.TabIndex = 43;
            // 
            // ActionBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lnkSelectASite1);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkRemoveURL);
            this.Controls.Add(this.lnkAddURL);
            this.Controls.Add(this.lstSiteURLs);
            this.Controls.Add(this.ucCreateSchedule1);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.optBackupOnlyTopLevelSite);
            this.Controls.Add(this.optBackupAllSubsites);
            this.Controls.Add(this.lblBackupFilesPath);
            this.Controls.Add(this.lnkOpen);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.btnStartBackup);
            this.Controls.Add(this.btnValidateBackup);
            this.Controls.Add(this.rtbValidateMessage);
            this.Controls.Add(this.lblAllSitesList);
            this.Name = "ActionBackup";
            this.Load += new System.EventHandler(this.ActionSharepointBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkSelectASite1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbValidateMessage;
        private System.Windows.Forms.Label lblAllSitesList;
        private System.Windows.Forms.Button btnValidateBackup;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Button btnStartBackup;
        private System.Windows.Forms.LinkLabel lnkOpen;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblBackupFilesPath;
        private System.Windows.Forms.RadioButton optBackupAllSubsites;
        private System.Windows.Forms.RadioButton optBackupOnlyTopLevelSite;
        private System.Windows.Forms.LinkLabel lnkCancel;
        internal System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.ListBox lstSiteURLs;
        private System.Windows.Forms.LinkLabel lnkAddURL;
        private System.Windows.Forms.LinkLabel lnkRemoveURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.PictureBox lnkSelectASite1;
        private System.Windows.Forms.Button btnSelectFolder;
        private ucCreateSchedule ucCreateSchedule1;


    }
}
