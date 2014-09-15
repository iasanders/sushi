namespace SUSHI
{
    partial class ActionContentTypes
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
            this.btnCreateSiteColumns = new System.Windows.Forms.Button();
            this.txtTargetSite = new System.Windows.Forms.TextBox();
            this.btnEditSiteColumnsToCreateList = new System.Windows.Forms.Button();
            this.lblNewSiteColumnsCount = new System.Windows.Forms.Label();
            this.groupboxToolkit = new System.Windows.Forms.GroupBox();
            this.lnkEditSiteColumns = new System.Windows.Forms.LinkLabel();
            this.imgSelectSite = new System.Windows.Forms.PictureBox();
            this.imgBrowse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.groupboxToolkit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(3, 141);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 459);
            this.rtbDisplay.TabIndex = 22;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // rtbSiteValidateMessage
            // 
            this.rtbSiteValidateMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSiteValidateMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSiteValidateMessage.DetectUrls = false;
            this.rtbSiteValidateMessage.Location = new System.Drawing.Point(195, 54);
            this.rtbSiteValidateMessage.Name = "rtbSiteValidateMessage";
            this.rtbSiteValidateMessage.ReadOnly = true;
            this.rtbSiteValidateMessage.Size = new System.Drawing.Size(485, 26);
            this.rtbSiteValidateMessage.TabIndex = 33;
            this.rtbSiteValidateMessage.Text = "";
            // 
            // lblAllSitesList
            // 
            this.lblAllSitesList.AutoSize = true;
            this.lblAllSitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSitesList.Location = new System.Drawing.Point(5, 31);
            this.lblAllSitesList.Name = "lblAllSitesList";
            this.lblAllSitesList.Size = new System.Drawing.Size(99, 13);
            this.lblAllSitesList.TabIndex = 50;
            this.lblAllSitesList.Text = "SharePoint Site:";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(103, 87);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(68, 23);
            this.btnValidate.TabIndex = 61;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnCreateSiteColumns
            // 
            this.btnCreateSiteColumns.Location = new System.Drawing.Point(181, 87);
            this.btnCreateSiteColumns.Name = "btnCreateSiteColumns";
            this.btnCreateSiteColumns.Size = new System.Drawing.Size(122, 23);
            this.btnCreateSiteColumns.TabIndex = 62;
            this.btnCreateSiteColumns.Text = "Create Site Columns";
            this.btnCreateSiteColumns.UseVisualStyleBackColor = true;
            this.btnCreateSiteColumns.Click += new System.EventHandler(this.btnCreateSiteColumns_Click);
            // 
            // txtTargetSite
            // 
            this.txtTargetSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetSite.Location = new System.Drawing.Point(106, 29);
            this.txtTargetSite.Name = "txtTargetSite";
            this.txtTargetSite.Size = new System.Drawing.Size(303, 20);
            this.txtTargetSite.TabIndex = 72;
            this.txtTargetSite.TextChanged += new System.EventHandler(this.txtTargetSite_TextChanged);
            // 
            // btnEditSiteColumnsToCreateList
            // 
            this.btnEditSiteColumnsToCreateList.Location = new System.Drawing.Point(104, 56);
            this.btnEditSiteColumnsToCreateList.Name = "btnEditSiteColumnsToCreateList";
            this.btnEditSiteColumnsToCreateList.Size = new System.Drawing.Size(180, 23);
            this.btnEditSiteColumnsToCreateList.TabIndex = 73;
            this.btnEditSiteColumnsToCreateList.Text = "Edit list of site columns to create";
            this.btnEditSiteColumnsToCreateList.UseVisualStyleBackColor = true;
            this.btnEditSiteColumnsToCreateList.Click += new System.EventHandler(this.btnEditSiteColumnsToCreateList_Click);
            // 
            // lblNewSiteColumnsCount
            // 
            this.lblNewSiteColumnsCount.AutoSize = true;
            this.lblNewSiteColumnsCount.Location = new System.Drawing.Point(290, 59);
            this.lblNewSiteColumnsCount.Name = "lblNewSiteColumnsCount";
            this.lblNewSiteColumnsCount.Size = new System.Drawing.Size(46, 13);
            this.lblNewSiteColumnsCount.TabIndex = 74;
            this.lblNewSiteColumnsCount.Text = "count: 0";
            // 
            // groupboxToolkit
            // 
            this.groupboxToolkit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxToolkit.Controls.Add(this.lnkEditSiteColumns);
            this.groupboxToolkit.Location = new System.Drawing.Point(309, 82);
            this.groupboxToolkit.Name = "groupboxToolkit";
            this.groupboxToolkit.Size = new System.Drawing.Size(159, 53);
            this.groupboxToolkit.TabIndex = 87;
            this.groupboxToolkit.TabStop = false;
            this.groupboxToolkit.Text = "Tools";
            // 
            // lnkEditSiteColumns
            // 
            this.lnkEditSiteColumns.AutoSize = true;
            this.lnkEditSiteColumns.Location = new System.Drawing.Point(7, 24);
            this.lnkEditSiteColumns.Name = "lnkEditSiteColumns";
            this.lnkEditSiteColumns.Size = new System.Drawing.Size(142, 13);
            this.lnkEditSiteColumns.TabIndex = 83;
            this.lnkEditSiteColumns.TabStop = true;
            this.lnkEditSiteColumns.Text = "Edit Site Columns In Browser";
            this.lnkEditSiteColumns.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditSiteColumns_LinkClicked);
            // 
            // imgSelectSite
            // 
            this.imgSelectSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSelectSite.Image = global::SUSHI.Properties.Resources.select_site1;
            this.imgSelectSite.Location = new System.Drawing.Point(107, 3);
            this.imgSelectSite.Name = "imgSelectSite";
            this.imgSelectSite.Size = new System.Drawing.Size(107, 22);
            this.imgSelectSite.TabIndex = 88;
            this.imgSelectSite.TabStop = false;
            this.imgSelectSite.Click += new System.EventHandler(this.imgSelectSite_Click);
            // 
            // imgBrowse
            // 
            this.imgBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBrowse.Image = global::SUSHI.Properties.Resources.browse;
            this.imgBrowse.Location = new System.Drawing.Point(223, 3);
            this.imgBrowse.Name = "imgBrowse";
            this.imgBrowse.Size = new System.Drawing.Size(90, 22);
            this.imgBrowse.TabIndex = 89;
            this.imgBrowse.TabStop = false;
            // 
            // ActionContentTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.imgBrowse);
            this.Controls.Add(this.imgSelectSite);
            this.Controls.Add(this.groupboxToolkit);
            this.Controls.Add(this.lblNewSiteColumnsCount);
            this.Controls.Add(this.btnEditSiteColumnsToCreateList);
            this.Controls.Add(this.txtTargetSite);
            this.Controls.Add(this.btnCreateSiteColumns);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblAllSitesList);
            this.Controls.Add(this.rtbSiteValidateMessage);
            this.Controls.Add(this.rtbDisplay);
            this.Name = "ActionContentTypes";
            this.Size = new System.Drawing.Size(683, 615);
            this.Load += new System.EventHandler(this.ActionContentTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.groupboxToolkit.ResumeLayout(false);
            this.groupboxToolkit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSelectSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBrowse)).EndInit();
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
        private System.Windows.Forms.Button btnCreateSiteColumns;
        private System.Windows.Forms.TextBox txtTargetSite;
        private System.Windows.Forms.Button btnEditSiteColumnsToCreateList;
        internal System.Windows.Forms.Label lblNewSiteColumnsCount;
        private System.Windows.Forms.GroupBox groupboxToolkit;
        private System.Windows.Forms.LinkLabel lnkEditSiteColumns;
        private System.Windows.Forms.PictureBox imgSelectSite;
        private System.Windows.Forms.PictureBox imgBrowse;

    }
}
