namespace SushiNS
{
    partial class ActionProfileImages
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
            this.rtbSiteValidateMessage = new System.Windows.Forms.RichTextBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.cboPictureLibName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.txtLocalSourceDir = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lnkSaveLog = new System.Windows.Forms.LinkLabel();
            this.lnkClearLog = new System.Windows.Forms.LinkLabel();
            this.lnkOpen = new System.Windows.Forms.LinkLabel();
            this.lnkEdit = new System.Windows.Forms.LinkLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.btnRetrieveDocLibs = new System.Windows.Forms.Button();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.imgBrowse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(3, 30);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(673, 20);
            this.txtTargetSite.TabIndex = 3;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtSiteUrl_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SharePoint Site";
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(121, 56);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(555, 29);
            this.rtbSiteValidateMessage.TabIndex = 20;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(3, 237);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 376);
            this.rtbDisplay.TabIndex = 22;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(109, 201);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(167, 24);
            this.btnValidate.TabIndex = 23;
            this.btnValidate.Text = "Validate Image Names";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(283, 201);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(167, 24);
            this.btnUpload.TabIndex = 24;
            this.btnUpload.Text = "Upload Images to User Profiles";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // cboPictureLibName
            // 
            this.cboPictureLibName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPictureLibName.FormattingEnabled = true;
            this.cboPictureLibName.Location = new System.Drawing.Point(3, 104);
            this.cboPictureLibName.MaxDropDownItems = 20;
            this.cboPictureLibName.Name = "cboPictureLibName";
            this.cboPictureLibName.Size = new System.Drawing.Size(319, 21);
            this.cboPictureLibName.TabIndex = 26;
            this.cboPictureLibName.SelectedIndexChanged += new System.EventHandler(this.cboDocLib_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Picture Library to store User Pictures";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Domain Name:";
            // 
            // txtDomainName
            // 
            this.txtDomainName.Location = new System.Drawing.Point(3, 201);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(100, 20);
            this.txtDomainName.TabIndex = 28;
            // 
            // txtLocalSourceDir
            // 
            this.txtLocalSourceDir.Location = new System.Drawing.Point(3, 153);
            this.txtLocalSourceDir.Name = "txtLocalSourceDir";
            this.txtLocalSourceDir.Size = new System.Drawing.Size(668, 20);
            this.txtLocalSourceDir.TabIndex = 30;
            this.txtLocalSourceDir.TextChanged += new System.EventHandler(this.txtLocalSourceDir_TextChanged);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(3, 137);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(298, 13);
            this.lblSource.TabIndex = 29;
            this.lblSource.Text = "Source Folder containing Profile Pictures to Upload";
            // 
            // lnkSaveLog
            // 
            this.lnkSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSaveLog.AutoSize = true;
            this.lnkSaveLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSaveLog.Location = new System.Drawing.Point(577, 218);
            this.lnkSaveLog.Name = "lnkSaveLog";
            this.lnkSaveLog.Size = new System.Drawing.Size(47, 13);
            this.lnkSaveLog.TabIndex = 32;
            this.lnkSaveLog.TabStop = true;
            this.lnkSaveLog.Text = "save log";
            this.lnkSaveLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSaveLog_LinkClicked_1);
            // 
            // lnkClearLog
            // 
            this.lnkClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkClearLog.AutoSize = true;
            this.lnkClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClearLog.Location = new System.Drawing.Point(635, 218);
            this.lnkClearLog.Name = "lnkClearLog";
            this.lnkClearLog.Size = new System.Drawing.Size(46, 13);
            this.lnkClearLog.TabIndex = 31;
            this.lnkClearLog.TabStop = true;
            this.lnkClearLog.Text = "clear log";
            this.lnkClearLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearLog_LinkClicked);
            // 
            // lnkOpen
            // 
            this.lnkOpen.AutoSize = true;
            this.lnkOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpen.Location = new System.Drawing.Point(594, 137);
            this.lnkOpen.Name = "lnkOpen";
            this.lnkOpen.Size = new System.Drawing.Size(31, 13);
            this.lnkOpen.TabIndex = 34;
            this.lnkOpen.TabStop = true;
            this.lnkOpen.Text = "open";
            this.lnkOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpen_LinkClicked);
            // 
            // lnkEdit
            // 
            this.lnkEdit.AutoSize = true;
            this.lnkEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEdit.Location = new System.Drawing.Point(647, 137);
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Size = new System.Drawing.Size(24, 13);
            this.lnkEdit.TabIndex = 33;
            this.lnkEdit.TabStop = true;
            this.lnkEdit.Text = "edit";
            this.lnkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCancel.Location = new System.Drawing.Point(118, 205);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(0, 15);
            this.lnkCancel.TabIndex = 35;
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // btnRetrieveDocLibs
            // 
            this.btnRetrieveDocLibs.Location = new System.Drawing.Point(3, 56);
            this.btnRetrieveDocLibs.Name = "btnRetrieveDocLibs";
            this.btnRetrieveDocLibs.Size = new System.Drawing.Size(100, 23);
            this.btnRetrieveDocLibs.TabIndex = 81;
            this.btnRetrieveDocLibs.Text = "Retrieve Lists";
            this.btnRetrieveDocLibs.UseVisualStyleBackColor = true;
            this.btnRetrieveDocLibs.Click += new System.EventHandler(this.btnRetrieveDocLibs_Click);
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSelectSite.Image = global::SushiNS.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(134, 6);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(106, 22);
            this.imgSelectSite.TabIndex = 89;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // imgBrowse
            // 
            this.imgBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBrowse.Image = global::SushiNS.Properties.Resources.browse1;
            this.imgBrowse.Location = new System.Drawing.Point(327, 104);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(88, 22);
            this.imgBrowse.TabIndex = 90;
            this.imgBrowse.TabStop = false;
            this.imgBrowse.Click += new System.EventHandler(this.imgBrowse_Click);
            // 
            // ActionProfileImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.btnRetrieveDocLibs);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.lnkOpen);
            this.Controls.Add(this.lnkEdit);
            this.Controls.Add(this.lnkSaveLog);
            this.Controls.Add(this.lnkClearLog);
            this.Controls.Add(this.txtLocalSourceDir);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.txtDomainName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPictureLibName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTargetSite);
            this.Name = "ActionProfileImages";
            this.Load += new System.EventHandler(this.ActionProfileImages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbSiteValidateMessage;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ComboBox cboPictureLibName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDomainName;
        internal System.Windows.Forms.TextBox txtLocalSourceDir;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.LinkLabel lnkSaveLog;
        private System.Windows.Forms.LinkLabel lnkClearLog;
        private System.Windows.Forms.LinkLabel lnkOpen;
        private System.Windows.Forms.LinkLabel lnkEdit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.Button btnRetrieveDocLibs;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.PictureBox imgBrowse;

    }
}
