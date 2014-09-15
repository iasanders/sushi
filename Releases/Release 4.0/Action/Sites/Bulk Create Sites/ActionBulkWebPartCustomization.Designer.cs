namespace SushiNS
{
    partial class ActionBulkWebPartCustomization
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
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnBulkWebPartCustomize = new System.Windows.Forms.Button();
            this.btnWebpartsToCreateList = new System.Windows.Forms.Button();
            this.lblSiteCount = new System.Windows.Forms.Label();
            this.lblProfile = new System.Windows.Forms.Label();
            this.cboProfiles = new System.Windows.Forms.ComboBox();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
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
            this.rtbDisplay.DetectUrls = false;
            this.rtbDisplay.Location = new System.Drawing.Point(3, 211);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(668, 418);
            this.rtbDisplay.TabIndex = 22;
            this.rtbDisplay.Text = "";
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(271, 50);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(409, 38);
            this.rtbSiteValidateMessage.TabIndex = 33;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Location = new System.Drawing.Point(5, 6);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(117, 13);
            this.lblAllSitesList.TabIndex = 50;
            this.lblAllSitesList.Text = "Parent SharePoint Site:";
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
            // btnBulkWebPartCustomize
            // 
            this.btnBulkWebPartCustomize.Location = new System.Drawing.Point(345, 182);
            this.btnBulkWebPartCustomize.Name = "btnBulkWebPartCustomize";
            this.btnBulkWebPartCustomize.Size = new System.Drawing.Size(154, 23);
            this.btnBulkWebPartCustomize.TabIndex = 62;
            this.btnBulkWebPartCustomize.Text = "Bulk WebPart Customization";
            this.btnBulkWebPartCustomize.UseVisualStyleBackColor = true;
            this.btnBulkWebPartCustomize.Click += new System.EventHandler(this.btnWebpartsToCreateList_Click);
            // 
            // btnWebpartsToCreateList
            // 
            this.btnWebpartsToCreateList.Location = new System.Drawing.Point(85, 94);
            this.btnWebpartsToCreateList.Name = "btnWebpartsToCreateList";
            this.btnWebpartsToCreateList.Size = new System.Drawing.Size(115, 23);
            this.btnWebpartsToCreateList.TabIndex = 64;
            this.btnWebpartsToCreateList.Text = "Edit Parameters";
            this.btnWebpartsToCreateList.UseVisualStyleBackColor = true;
            this.btnWebpartsToCreateList.Click += new System.EventHandler(this.btnEditSitesToCreateList_Click);
            // 
            // lblSiteCount
            // 
            this.lblSiteCount.AutoSize = true;
            this.lblSiteCount.Location = new System.Drawing.Point(206, 99);
            this.lblSiteCount.Name = "lblSiteCount";
            this.lblSiteCount.Size = new System.Drawing.Size(80, 13);
            this.lblSiteCount.TabIndex = 66;
            this.lblSiteCount.Text = "site list count: 0";
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(37, 51);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(36, 13);
            this.lblProfile.TabIndex = 67;
            this.lblProfile.Text = "Profile";
            // 
            // cboProfiles
            // 
            this.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfiles.FormattingEnabled = true;
            this.cboProfiles.Location = new System.Drawing.Point(79, 48);
            this.cboProfiles.Name = "cboProfiles";
            this.cboProfiles.Size = new System.Drawing.Size(301, 21);
            this.cboProfiles.TabIndex = 68;
            this.cboProfiles.SelectedIndexChanged += new System.EventHandler(this.cboProfiles_SelectedIndexChanged);
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(0, 24);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(677, 20);
            this.txtTargetSite.TabIndex = 75;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Image = global::SushiNS.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(124, 2);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(85, 22);
            this.imgSelectSite.TabIndex = 76;
            this.imgSelectSite.TabStop = false;
            // 
            // ActionBulkWebPartCustomization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.cboProfiles);
            this.Controls.Add(this.lblProfile);
            this.Controls.Add(this.lblSiteCount);
            this.Controls.Add(this.btnWebpartsToCreateList);
            this.Controls.Add(this.btnBulkWebPartCustomize);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblAllSitesList);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.rtbDisplay);
            this.Name = "ActionBulkWebPartCustomization";
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
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnBulkWebPartCustomize;
        private System.Windows.Forms.Button btnWebpartsToCreateList;
        internal System.Windows.Forms.Label lblSiteCount;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.ComboBox cboProfiles;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.PictureBox imgSelectSite;

    }
}
