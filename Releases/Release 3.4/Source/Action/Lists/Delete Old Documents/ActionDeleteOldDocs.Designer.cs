namespace SushiNS
{
    partial class ActionDeleteOldDocs
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
            this.btnValidate = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.lblSharepointsite = new System.Windows.Forms.Label();
            this.cklbDocLibs = new System.Windows.Forms.CheckedListBox();
            this.dtpArchiveDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescMonthsOld = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnArchiveAndDeleteOldFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArchiveSubfolder = new System.Windows.Forms.Label();
            this.lnkBrowse = new System.Windows.Forms.LinkLabel();
            this.txtArchiveDest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDoListFiles = new System.Windows.Forms.CheckBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRetrieveDocLibs = new System.Windows.Forms.Button();
            this.lnkCheckAll = new System.Windows.Forms.LinkLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            this.SuspendLayout();
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.Location = new System.Drawing.Point(69, 343);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(106, 21);
            this.btnValidate.TabIndex = 0;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(419, 82);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 33);
            this.textBox2.TabIndex = 5;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Documents will be archived from the checked document libraries";
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Location = new System.Drawing.Point(128, 25);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(505, 20);
            this.txtTargetSite.TabIndex = 13;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtSharepointsite_TextChanged);
            // 
            // lblSharepointsite
            // 
            this.lblSharepointsite.AutoSize = true;
            this.lblSharepointsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSharepointsite.Location = new System.Drawing.Point(24, 28);
            this.lblSharepointsite.Name = "lblSharepointsite";
            this.lblSharepointsite.Size = new System.Drawing.Size(98, 13);
            this.lblSharepointsite.TabIndex = 14;
            this.lblSharepointsite.Text = "Sharepoint Site:";
            this.lblSharepointsite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cklbDocLibs
            // 
            this.cklbDocLibs.CheckOnClick = true;
            this.cklbDocLibs.FormattingEnabled = true;
            this.cklbDocLibs.Location = new System.Drawing.Point(128, 51);
            this.cklbDocLibs.Name = "cklbDocLibs";
            this.cklbDocLibs.Size = new System.Drawing.Size(286, 139);
            this.cklbDocLibs.TabIndex = 15;
            // 
            // dtpArchiveDate
            // 
            this.dtpArchiveDate.Checked = false;
            this.dtpArchiveDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpArchiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpArchiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArchiveDate.Location = new System.Drawing.Point(128, 196);
            this.dtpArchiveDate.Name = "dtpArchiveDate";
            this.dtpArchiveDate.Size = new System.Drawing.Size(129, 20);
            this.dtpArchiveDate.TabIndex = 26;
            this.dtpArchiveDate.ValueChanged += new System.EventHandler(this.dtpArchiveDate_ValueChanged);
            // 
            // txtDescMonthsOld
            // 
            this.txtDescMonthsOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescMonthsOld.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescMonthsOld.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescMonthsOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescMonthsOld.Location = new System.Drawing.Point(263, 202);
            this.txtDescMonthsOld.Multiline = true;
            this.txtDescMonthsOld.Name = "txtDescMonthsOld";
            this.txtDescMonthsOld.Size = new System.Drawing.Size(417, 33);
            this.txtDescMonthsOld.TabIndex = 25;
            this.txtDescMonthsOld.TabStop = false;
            this.txtDescMonthsOld.Text = "Documents...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Sub Folder:";
            // 
            // btnArchiveAndDeleteOldFiles
            // 
            this.btnArchiveAndDeleteOldFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchiveAndDeleteOldFiles.Location = new System.Drawing.Point(190, 342);
            this.btnArchiveAndDeleteOldFiles.Name = "btnArchiveAndDeleteOldFiles";
            this.btnArchiveAndDeleteOldFiles.Size = new System.Drawing.Size(245, 21);
            this.btnArchiveAndDeleteOldFiles.TabIndex = 32;
            this.btnArchiveAndDeleteOldFiles.Text = "Archive Old Files and Delete from SharePoint";
            this.btnArchiveAndDeleteOldFiles.UseVisualStyleBackColor = true;
            this.btnArchiveAndDeleteOldFiles.Click += new System.EventHandler(this.btnArchiveAndDeleteOldFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Archive Root Folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArchiveSubfolder
            // 
            this.lblArchiveSubfolder.AutoSize = true;
            this.lblArchiveSubfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchiveSubfolder.Location = new System.Drawing.Point(128, 278);
            this.lblArchiveSubfolder.Name = "lblArchiveSubfolder";
            this.lblArchiveSubfolder.Size = new System.Drawing.Size(93, 13);
            this.lblArchiveSubfolder.TabIndex = 33;
            this.lblArchiveSubfolder.Text = "\\sub_folder_name";
            // 
            // lnkBrowse
            // 
            this.lnkBrowse.AutoSize = true;
            this.lnkBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBrowse.Location = new System.Drawing.Point(588, 241);
            this.lnkBrowse.Name = "lnkBrowse";
            this.lnkBrowse.Size = new System.Drawing.Size(41, 13);
            this.lnkBrowse.TabIndex = 34;
            this.lnkBrowse.TabStop = true;
            this.lnkBrowse.Text = "browse";
            this.lnkBrowse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrowse_LinkClicked);
            // 
            // txtArchiveDest
            // 
            this.txtArchiveDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchiveDest.Location = new System.Drawing.Point(128, 237);
            this.txtArchiveDest.Name = "txtArchiveDest";
            this.txtArchiveDest.Size = new System.Drawing.Size(420, 20);
            this.txtArchiveDest.TabIndex = 30;
            this.txtArchiveDest.TextChanged += new System.EventHandler(this.txtArchiveDest_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Document Libraries:";
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSelectSite.Image = global::SushiNS.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(128, 3);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(105, 22);
            this.imgSelectSite.TabIndex = 76;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Archive Date:";
            // 
            // chkDoListFiles
            // 
            this.chkDoListFiles.AutoSize = true;
            this.chkDoListFiles.Location = new System.Drawing.Point(591, 346);
            this.chkDoListFiles.Name = "chkDoListFiles";
            this.chkDoListFiles.Size = new System.Drawing.Size(85, 17);
            this.chkDoListFiles.TabIndex = 27;
            this.chkDoListFiles.Text = "list filenames";
            this.chkDoListFiles.UseVisualStyleBackColor = true;
            this.chkDoListFiles.CheckedChanged += new System.EventHandler(this.chkDoListFiles_CheckedChanged);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(554, 235);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(28, 23);
            this.btnSelectFolder.TabIndex = 79;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnRetrieveDocLibs
            // 
            this.btnRetrieveDocLibs.Location = new System.Drawing.Point(420, 51);
            this.btnRetrieveDocLibs.Name = "btnRetrieveDocLibs";
            this.btnRetrieveDocLibs.Size = new System.Drawing.Size(162, 23);
            this.btnRetrieveDocLibs.TabIndex = 80;
            this.btnRetrieveDocLibs.Text = "Retrieve Document Libraries";
            this.btnRetrieveDocLibs.UseVisualStyleBackColor = true;
            this.btnRetrieveDocLibs.Click += new System.EventHandler(this.btnRetrieveDocLibs_Click);
            // 
            // lnkCheckAll
            // 
            this.lnkCheckAll.AutoSize = true;
            this.lnkCheckAll.Location = new System.Drawing.Point(420, 118);
            this.lnkCheckAll.Name = "lnkCheckAll";
            this.lnkCheckAll.Size = new System.Drawing.Size(52, 13);
            this.lnkCheckAll.TabIndex = 81;
            this.lnkCheckAll.TabStop = true;
            this.lnkCheckAll.Text = "Check All";
            this.lnkCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCheckAll_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(456, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 21);
            this.btnCancel.TabIndex = 82;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(4, 395);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(675, 188);
            this.rtbDisplay.TabIndex = 83;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // ActionDeleteOldDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lnkCheckAll);
            this.Controls.Add(this.btnRetrieveDocLibs);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.chkDoListFiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpArchiveDate);
            this.Controls.Add(this.btnArchiveAndDeleteOldFiles);
            this.Controls.Add(this.txtDescMonthsOld);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblArchiveSubfolder);
            this.Controls.Add(this.lnkBrowse);
            this.Controls.Add(this.txtArchiveDest);
            this.Controls.Add(this.cklbDocLibs);
            this.Controls.Add(this.lblSharepointsite);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnValidate);
            this.Name = "ActionDeleteOldDocs";
            this.Size = new System.Drawing.Size(683, 600);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.Label lblSharepointsite;
        private System.Windows.Forms.CheckedListBox cklbDocLibs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpArchiveDate;
        private System.Windows.Forms.TextBox txtDescMonthsOld;
        private System.Windows.Forms.Button btnArchiveAndDeleteOldFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArchiveSubfolder;
        private System.Windows.Forms.LinkLabel lnkBrowse;
        private System.Windows.Forms.TextBox txtArchiveDest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDoListFiles;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnRetrieveDocLibs;
        private System.Windows.Forms.LinkLabel lnkCheckAll;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
    }
}

