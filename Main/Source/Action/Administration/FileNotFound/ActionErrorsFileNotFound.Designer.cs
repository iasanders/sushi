namespace SUSHI
{
    partial class ActionErrorsFileNotFound
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
            this.txtNewErrorPage = new System.Windows.Forms.TextBox();
            this.rtbSiteValidateMessage = new System.Windows.Forms.RichTextBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.lblAllSitesList = new System.Windows.Forms.Label();
            this.btnChangeErrorPage = new System.Windows.Forms.Button();
            this.lbl4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lnkSelectASite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkSelectASite)).BeginInit();
            this.SuspendLayout();
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(7, 111);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(77, 23);
            this.btnValidate.TabIndex = 83;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // txtNewErrorPage
            // 
            this.txtNewErrorPage.Location = new System.Drawing.Point(7, 82);
            this.txtNewErrorPage.Name = "txtNewErrorPage";
            this.txtNewErrorPage.Size = new System.Drawing.Size(399, 20);
            this.txtNewErrorPage.TabIndex = 84;
            this.txtNewErrorPage.TextChanged += new System.EventHandler(this.txtNewErrorPage_TextChanged);
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(6, 53);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(399, 21);
            this.rtbSiteValidateMessage.TabIndex = 89;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(7, 140);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(669, 473);
            this.rtbDisplay.TabIndex = 88;
            this.rtbDisplay.Text = "";
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(106, 30);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(570, 20);
            this.txtTargetSite.TabIndex = 86;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSitesList.Location = new System.Drawing.Point(7, 33);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(99, 13);
            this.lblAllSitesList.TabIndex = 85;
            this.lblAllSitesList.Text = "SharePoint Site:";
            // 
            // btnChangeErrorPage
            // 
            this.btnChangeErrorPage.Location = new System.Drawing.Point(99, 111);
            this.btnChangeErrorPage.Name = "btnChangeErrorPage";
            this.btnChangeErrorPage.Size = new System.Drawing.Size(131, 23);
            this.btnChangeErrorPage.TabIndex = 91;
            this.btnChangeErrorPage.Text = "Change Error Page";
            this.btnChangeErrorPage.UseVisualStyleBackColor = true;
            this.btnChangeErrorPage.Click += new System.EventHandler(this.btnSwitchErrorFile);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(7, 65);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(298, 13);
            this.lbl4.TabIndex = 92;
            this.lbl4.Text = "New Error Page to display for 404 Page Not Found:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lnkSelectASite
            // 
            this.lnkSelectASite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkSelectASite.Image = global::SUSHI.Properties.Resources.select_site1;
            this.lnkSelectASite.Location = new System.Drawing.Point(105, 5);
            this.lnkSelectASite.Name = "lnkSelectASite";
            this.lnkSelectASite.Size = new System.Drawing.Size(107, 22);
            this.lnkSelectASite.TabIndex = 94;
            this.lnkSelectASite.TabStop = false;
            this.lnkSelectASite.Click += new System.EventHandler(this.lnkSelectASite_Click);
            // 
            // ActionErrorsFileNotFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lnkSelectASite);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.btnChangeErrorPage);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.lblAllSitesList);
            this.Controls.Add(this.txtNewErrorPage);
            this.Controls.Add(this.btnValidate);
            this.Name = "ActionErrorsFileNotFound";
            this.Load += new System.EventHandler(this.ActionErrorsFileNotFound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkSelectASite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.TextBox txtNewErrorPage;
        internal System.Windows.Forms.RichTextBox rtbSiteValidateMessage;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        internal System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.Label lblAllSitesList;
        private System.Windows.Forms.Button btnChangeErrorPage;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox lnkSelectASite;

    }
}
