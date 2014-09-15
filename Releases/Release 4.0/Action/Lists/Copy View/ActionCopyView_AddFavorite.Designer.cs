namespace SushiNS
{
    partial class ActionCopyView_AddFavorite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionCopyView_AddFavorite));
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.lblAllSitesList = new System.Windows.Forms.Label();
            this.rtbSiteValidateMessage = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLists = new System.Windows.Forms.ComboBox();
            this.cboViews = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddViewToFavorites = new System.Windows.Forms.Button();
            this.btnRetrieveLists = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.DetectUrls = false;
            this.rtbDisplay.Location = new System.Drawing.Point(2, 218);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(662, 376);
            this.rtbDisplay.TabIndex = 23;
            this.rtbDisplay.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSitesList.Location = new System.Drawing.Point(2, 7);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(99, 13);
            this.lblAllSitesList.TabIndex = 53;
            this.lblAllSitesList.Text = "SharePoint Site:";
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(281, 55);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(380, 37);
            this.rtbSiteValidateMessage.TabIndex = 56;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "SharePoint List:";
            // 
            // cboLists
            // 
            this.cboLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLists.FormattingEnabled = true;
            this.cboLists.Location = new System.Drawing.Point(2, 98);
            this.cboLists.MaxDropDownItems = 30;
            this.cboLists.Name = "cboLists";
            this.cboLists.Size = new System.Drawing.Size(232, 21);
            this.cboLists.TabIndex = 58;
            this.cboLists.SelectedIndexChanged += new System.EventHandler(this.cboLists_SelectedIndexChanged);
            // 
            // cboViews
            // 
            this.cboViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViews.Enabled = false;
            this.cboViews.FormattingEnabled = true;
            this.cboViews.Location = new System.Drawing.Point(2, 147);
            this.cboViews.MaxDropDownItems = 30;
            this.cboViews.Name = "cboViews";
            this.cboViews.Size = new System.Drawing.Size(232, 21);
            this.cboViews.TabIndex = 60;
            this.cboViews.SelectedIndexChanged += new System.EventHandler(this.cboViews_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "SharePoint View:";
            // 
            // btnAddViewToFavorites
            // 
            this.btnAddViewToFavorites.Enabled = false;
            this.btnAddViewToFavorites.Location = new System.Drawing.Point(2, 185);
            this.btnAddViewToFavorites.Name = "btnAddViewToFavorites";
            this.btnAddViewToFavorites.Size = new System.Drawing.Size(171, 23);
            this.btnAddViewToFavorites.TabIndex = 61;
            this.btnAddViewToFavorites.Text = "Add View To Favorites";
            this.btnAddViewToFavorites.UseVisualStyleBackColor = true;
            this.btnAddViewToFavorites.Click += new System.EventHandler(this.btnAddViewToFavorites_Click);
            // 
            // btnRetrieveLists
            // 
            this.btnRetrieveLists.Location = new System.Drawing.Point(2, 53);
            this.btnRetrieveLists.Name = "btnRetrieveLists";
            this.btnRetrieveLists.Size = new System.Drawing.Size(97, 22);
            this.btnRetrieveLists.TabIndex = 62;
            this.btnRetrieveLists.Text = "Retrieve Lists";
            this.btnRetrieveLists.UseVisualStyleBackColor = true;
            this.btnRetrieveLists.Click += new System.EventHandler(this.btnRetrieveLists_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(179, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 63;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(2, 27);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(662, 20);
            this.txtTargetSite.TabIndex = 78;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::SushiNS.Properties.Resources.select_site1;
            this.pictureBox1.Location = new System.Drawing.Point(104, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 23);
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ActionCopyView_AddFavorite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 598);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRetrieveLists);
            this.Controls.Add(this.btnAddViewToFavorites);
            this.Controls.Add(this.cboViews);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLists);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.lblAllSitesList);
            this.Controls.Add(this.rtbDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ActionCopyView_AddFavorite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add A Favorite View";
            this.Load += new System.EventHandler(this.ActionCreateView_AddFavorite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Label lblAllSitesList;
        private System.Windows.Forms.RichTextBox rtbSiteValidateMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLists;
        private System.Windows.Forms.ComboBox cboViews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddViewToFavorites;
        private System.Windows.Forms.Button btnRetrieveLists;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}