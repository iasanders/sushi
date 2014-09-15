namespace SUSHI
{
    partial class ActionRestore
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblBackupFolder = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.lblChooseBackup = new System.Windows.Forms.Label();
            this.lstBackupToRestore = new System.Windows.Forms.ListBox();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            this.btnStartRestore = new System.Windows.Forms.Button();
            this.txtRestoreDestinationURL = new System.Windows.Forms.TextBox();
            this.lblRestoreDestinationURL = new System.Windows.Forms.Label();
            this.lblFeedbackNoBackupFilesFound = new System.Windows.Forms.Label();
            this.chkIncludeUserSecurity = new System.Windows.Forms.CheckBox();
            this.btnValidateRestore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(5, 299);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(675, 281);
            this.rtbDisplay.TabIndex = 26;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // lblBackupFolder
            // 
            this.lblBackupFolder.AutoSize = true;
            this.lblBackupFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupFolder.Location = new System.Drawing.Point(5, 9);
            this.lblBackupFolder.Name = "lblBackupFolder";
            this.lblBackupFolder.Size = new System.Drawing.Size(209, 13);
            this.lblBackupFolder.TabIndex = 27;
            this.lblBackupFolder.Text = "Directory where backups are stored";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(5, 26);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(668, 20);
            this.txtBackupPath.TabIndex = 28;
            // 
            // lblChooseBackup
            // 
            this.lblChooseBackup.AutoSize = true;
            this.lblChooseBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseBackup.Location = new System.Drawing.Point(5, 58);
            this.lblChooseBackup.Name = "lblChooseBackup";
            this.lblChooseBackup.Size = new System.Drawing.Size(164, 13);
            this.lblChooseBackup.TabIndex = 29;
            this.lblChooseBackup.Text = "Choose a backup to restore";
            // 
            // lstBackupToRestore
            // 
            this.lstBackupToRestore.FormattingEnabled = true;
            this.lstBackupToRestore.Location = new System.Drawing.Point(5, 74);
            this.lstBackupToRestore.Name = "lstBackupToRestore";
            this.lstBackupToRestore.Size = new System.Drawing.Size(331, 134);
            this.lstBackupToRestore.TabIndex = 30;
            this.lstBackupToRestore.SelectedIndexChanged += new System.EventHandler(this.lstBackupToRestore_SelectedIndexChanged);
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.Location = new System.Drawing.Point(339, 74);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(39, 13);
            this.lnkRefresh.TabIndex = 31;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "refresh";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
            // 
            // btnStartRestore
            // 
            this.btnStartRestore.Location = new System.Drawing.Point(109, 260);
            this.btnStartRestore.Name = "btnStartRestore";
            this.btnStartRestore.Size = new System.Drawing.Size(95, 23);
            this.btnStartRestore.TabIndex = 32;
            this.btnStartRestore.Text = "Start Restore";
            this.btnStartRestore.UseVisualStyleBackColor = true;
            this.btnStartRestore.Click += new System.EventHandler(this.btnStartRestore_Click);
            // 
            // txtRestoreDestinationURL
            // 
            this.txtRestoreDestinationURL.Location = new System.Drawing.Point(5, 234);
            this.txtRestoreDestinationURL.Name = "txtRestoreDestinationURL";
            this.txtRestoreDestinationURL.Size = new System.Drawing.Size(668, 20);
            this.txtRestoreDestinationURL.TabIndex = 34;
            // 
            // lblRestoreDestinationURL
            // 
            this.lblRestoreDestinationURL.AutoSize = true;
            this.lblRestoreDestinationURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestoreDestinationURL.Location = new System.Drawing.Point(5, 217);
            this.lblRestoreDestinationURL.Name = "lblRestoreDestinationURL";
            this.lblRestoreDestinationURL.Size = new System.Drawing.Size(148, 13);
            this.lblRestoreDestinationURL.TabIndex = 33;
            this.lblRestoreDestinationURL.Text = "Restore Destination URL";
            // 
            // lblFeedbackNoBackupFilesFound
            // 
            this.lblFeedbackNoBackupFilesFound.AutoSize = true;
            this.lblFeedbackNoBackupFilesFound.ForeColor = System.Drawing.Color.Red;
            this.lblFeedbackNoBackupFilesFound.Location = new System.Drawing.Point(350, 132);
            this.lblFeedbackNoBackupFilesFound.Name = "lblFeedbackNoBackupFilesFound";
            this.lblFeedbackNoBackupFilesFound.Size = new System.Drawing.Size(0, 13);
            this.lblFeedbackNoBackupFilesFound.TabIndex = 35;
            // 
            // chkIncludeUserSecurity
            // 
            this.chkIncludeUserSecurity.AutoSize = true;
            this.chkIncludeUserSecurity.Location = new System.Drawing.Point(339, 191);
            this.chkIncludeUserSecurity.Name = "chkIncludeUserSecurity";
            this.chkIncludeUserSecurity.Size = new System.Drawing.Size(127, 17);
            this.chkIncludeUserSecurity.TabIndex = 36;
            this.chkIncludeUserSecurity.Text = "Include User Security";
            this.chkIncludeUserSecurity.UseVisualStyleBackColor = true;
            this.chkIncludeUserSecurity.CheckedChanged += new System.EventHandler(this.chkIncludeUserSecurity_CheckedChanged);
            // 
            // btnValidateRestore
            // 
            this.btnValidateRestore.Location = new System.Drawing.Point(5, 260);
            this.btnValidateRestore.Name = "btnValidateRestore";
            this.btnValidateRestore.Size = new System.Drawing.Size(95, 23);
            this.btnValidateRestore.TabIndex = 37;
            this.btnValidateRestore.Text = "Validate Restore";
            this.btnValidateRestore.UseVisualStyleBackColor = true;
            this.btnValidateRestore.Click += new System.EventHandler(this.btnValidateRestore_Click);
            // 
            // ActionRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnValidateRestore);
            this.Controls.Add(this.chkIncludeUserSecurity);
            this.Controls.Add(this.lblFeedbackNoBackupFilesFound);
            this.Controls.Add(this.txtRestoreDestinationURL);
            this.Controls.Add(this.lblRestoreDestinationURL);
            this.Controls.Add(this.btnStartRestore);
            this.Controls.Add(this.lnkRefresh);
            this.Controls.Add(this.lstBackupToRestore);
            this.Controls.Add(this.lblChooseBackup);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.lblBackupFolder);
            this.Controls.Add(this.rtbDisplay);
            this.Name = "ActionRestore";
            this.Load += new System.EventHandler(this.ActionRestore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblBackupFolder;
        private System.Windows.Forms.Label lblChooseBackup;
        private System.Windows.Forms.ListBox lstBackupToRestore;
        private System.Windows.Forms.LinkLabel lnkRefresh;
        private System.Windows.Forms.Button btnStartRestore;
        private System.Windows.Forms.TextBox txtRestoreDestinationURL;
        private System.Windows.Forms.Label lblRestoreDestinationURL;
        internal System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label lblFeedbackNoBackupFilesFound;
        private System.Windows.Forms.CheckBox chkIncludeUserSecurity;
        private System.Windows.Forms.Button btnValidateRestore;


    }
}
