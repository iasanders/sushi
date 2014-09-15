namespace SUSHI
{
    partial class ActionThemes
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
            this.lblAllSitesList = new System.Windows.Forms.Label();
            this.btnGetThemes = new System.Windows.Forms.Button();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbSiteValidateMessage = new System.Windows.Forms.RichTextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnLookupThemes = new System.Windows.Forms.Button();
            this.cboThemes = new System.Windows.Forms.ComboBox();
            this.optApplyToParentSite = new System.Windows.Forms.RadioButton();
            this.optApplyToChildren = new System.Windows.Forms.RadioButton();
            this.lnkShowCurrentTheme = new System.Windows.Forms.LinkLabel();
            this.gbTools = new System.Windows.Forms.GroupBox();
            this.lnkOpenSpThemes = new System.Windows.Forms.LinkLabel();
            this.optApplyToAllChildrenRecursively = new System.Windows.Forms.RadioButton();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.imgBrowse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.gbTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(0, 28);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(404, 20);
            this.txtTargetSite.TabIndex = 76;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Location = new System.Drawing.Point(2, 8);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(83, 13);
            this.lblAllSitesList.TabIndex = 75;
            this.lblAllSitesList.Text = "SharePoint Site:";
            // 
            // btnGetThemes
            // 
            this.btnGetThemes.Location = new System.Drawing.Point(222, 221);
            this.btnGetThemes.Name = "btnGetThemes";
            this.btnGetThemes.Size = new System.Drawing.Size(129, 23);
            this.btnGetThemes.TabIndex = 78;
            this.btnGetThemes.Text = "Apply Theme";
            this.btnGetThemes.UseVisualStyleBackColor = true;
            this.btnGetThemes.Click += new System.EventHandler(this.btnGetThemes_Click);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(3, 260);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(675, 353);
            this.rtbDisplay.TabIndex = 79;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Theme To Apply:";
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(5, 51);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(673, 21);
            this.rtbSiteValidateMessage.TabIndex = 82;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(73, 221);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(129, 23);
            this.btnValidate.TabIndex = 83;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnLookupThemes
            // 
            this.btnLookupThemes.Location = new System.Drawing.Point(113, 76);
            this.btnLookupThemes.Name = "btnLookupThemes";
            this.btnLookupThemes.Size = new System.Drawing.Size(187, 23);
            this.btnLookupThemes.TabIndex = 84;
            this.btnLookupThemes.Text = "Get Themes";
            this.btnLookupThemes.UseVisualStyleBackColor = true;
            this.btnLookupThemes.Click += new System.EventHandler(this.btnLookupThemes_Click);
            // 
            // cboThemes
            // 
            this.cboThemes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThemes.FormattingEnabled = true;
            this.cboThemes.Location = new System.Drawing.Point(113, 105);
            this.cboThemes.MaxDropDownItems = 30;
            this.cboThemes.Name = "cboThemes";
            this.cboThemes.Size = new System.Drawing.Size(187, 21);
            this.cboThemes.Sorted = true;
            this.cboThemes.TabIndex = 85;
            this.cboThemes.SelectedIndexChanged += new System.EventHandler(this.cboThemes_SelectedIndexChanged);
            // 
            // optApplyToParentSite
            // 
            this.optApplyToParentSite.AutoSize = true;
            this.optApplyToParentSite.Checked = true;
            this.optApplyToParentSite.Location = new System.Drawing.Point(113, 140);
            this.optApplyToParentSite.Name = "optApplyToParentSite";
            this.optApplyToParentSite.Size = new System.Drawing.Size(114, 17);
            this.optApplyToParentSite.TabIndex = 86;
            this.optApplyToParentSite.TabStop = true;
            this.optApplyToParentSite.Text = "Apply theme to site";
            this.optApplyToParentSite.UseVisualStyleBackColor = true;
            // 
            // optApplyToChildren
            // 
            this.optApplyToChildren.AutoSize = true;
            this.optApplyToChildren.Location = new System.Drawing.Point(113, 163);
            this.optApplyToChildren.Name = "optApplyToChildren";
            this.optApplyToChildren.Size = new System.Drawing.Size(235, 17);
            this.optApplyToChildren.TabIndex = 87;
            this.optApplyToChildren.Text = "Apply theme to site and direct children of site";
            this.optApplyToChildren.UseVisualStyleBackColor = true;
            // 
            // lnkShowCurrentTheme
            // 
            this.lnkShowCurrentTheme.AutoSize = true;
            this.lnkShowCurrentTheme.Location = new System.Drawing.Point(13, 27);
            this.lnkShowCurrentTheme.Name = "lnkShowCurrentTheme";
            this.lnkShowCurrentTheme.Size = new System.Drawing.Size(107, 13);
            this.lnkShowCurrentTheme.TabIndex = 89;
            this.lnkShowCurrentTheme.TabStop = true;
            this.lnkShowCurrentTheme.Text = "Show Current Theme";
            this.lnkShowCurrentTheme.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowCurrentTheme_LinkClicked);
            // 
            // gbTools
            // 
            this.gbTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTools.Controls.Add(this.lnkOpenSpThemes);
            this.gbTools.Controls.Add(this.lnkShowCurrentTheme);
            this.gbTools.Location = new System.Drawing.Point(501, 130);
            this.gbTools.Name = "gbTools";
            this.gbTools.Size = new System.Drawing.Size(177, 100);
            this.gbTools.TabIndex = 90;
            this.gbTools.TabStop = false;
            this.gbTools.Text = "Tools";
            // 
            // lnkOpenSpThemes
            // 
            this.lnkOpenSpThemes.AutoSize = true;
            this.lnkOpenSpThemes.Location = new System.Drawing.Point(13, 56);
            this.lnkOpenSpThemes.Name = "lnkOpenSpThemes";
            this.lnkOpenSpThemes.Size = new System.Drawing.Size(106, 13);
            this.lnkOpenSpThemes.TabIndex = 90;
            this.lnkOpenSpThemes.TabStop = true;
            this.lnkOpenSpThemes.Text = "Open SPThemes.xml";
            this.lnkOpenSpThemes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenSpThemes_LinkClicked);
            // 
            // optApplyToAllChildrenRecursively
            // 
            this.optApplyToAllChildrenRecursively.AutoSize = true;
            this.optApplyToAllChildrenRecursively.Location = new System.Drawing.Point(113, 186);
            this.optApplyToAllChildrenRecursively.Name = "optApplyToAllChildrenRecursively";
            this.optApplyToAllChildrenRecursively.Size = new System.Drawing.Size(271, 17);
            this.optApplyToAllChildrenRecursively.TabIndex = 91;
            this.optApplyToAllChildrenRecursively.Text = "Apply theme to site and all children of site (recursive)";
            this.optApplyToAllChildrenRecursively.UseVisualStyleBackColor = true;
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Image = global::SUSHI.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(87, 4);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(106, 23);
            this.imgSelectSite.TabIndex = 92;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // imgBrowse
            // 
            this.imgBrowse.Image = global::SUSHI.Properties.Resources.browse;
            this.imgBrowse.Location = new System.Drawing.Point(413, 28);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(89, 22);
            this.imgBrowse.TabIndex = 93;
            this.imgBrowse.TabStop = false;
            this.imgBrowse.Click += new System.EventHandler(this.imgBrowse_Click);
            // 
            // ActionThemes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.optApplyToAllChildrenRecursively);
            this.Controls.Add(this.gbTools);
            this.Controls.Add(this.optApplyToChildren);
            this.Controls.Add(this.optApplyToParentSite);
            this.Controls.Add(this.cboThemes);
            this.Controls.Add(this.btnLookupThemes);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.btnGetThemes);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.lblAllSitesList);
            this.Name = "ActionThemes";
            this.Load += new System.EventHandler(this.ActionThemes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.gbTools.ResumeLayout(false);
            this.gbTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.Label lblAllSitesList;
        private System.Windows.Forms.Button btnGetThemes;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbSiteValidateMessage;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnLookupThemes;
        private System.Windows.Forms.ComboBox cboThemes;
        private System.Windows.Forms.RadioButton optApplyToParentSite;
        private System.Windows.Forms.RadioButton optApplyToChildren;
        private System.Windows.Forms.LinkLabel lnkShowCurrentTheme;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.RadioButton optApplyToAllChildrenRecursively;
        private System.Windows.Forms.LinkLabel lnkOpenSpThemes;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.PictureBox imgBrowse;
    }
}
