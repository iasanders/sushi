namespace SushiNS
{
    partial class ActionBulkSiteCreation_EditSitesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionBulkSiteCreation_EditSitesList));
            this.dgNewSites = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.colURLname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgNewSites)).BeginInit();
            this.SuspendLayout();
            // 
            // dgNewSites
            // 
            this.dgNewSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNewSites.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgNewSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNewSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colURLname,
            this.colTitle});
            this.dgNewSites.Location = new System.Drawing.Point(1, 0);
            this.dgNewSites.Name = "dgNewSites";
            this.dgNewSites.Size = new System.Drawing.Size(896, 490);
            this.dgNewSites.TabIndex = 0;
            this.dgNewSites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgNewSites_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(385, 501);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkCancel
            // 
            this.lnkCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Location = new System.Drawing.Point(617, 512);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(40, 13);
            this.lnkCancel.TabIndex = 4;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(1, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "Paste From Clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTip
            // 
            this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(134, 512);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(213, 13);
            this.lblTip.TabIndex = 6;
            this.lblTip.Text = "Tip: Edit your list in Excel then paste above.";
            // 
            // colURLname
            // 
            this.colURLname.HeaderText = "Relative URL Name";
            this.colURLname.Name = "colURLname";
            this.colURLname.Width = 200;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title                                   ";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 200;
            // 
            // ActionBulkSiteCreation_EditSitesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 542);
            this.ControlBox = false;
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgNewSites);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionBulkSiteCreation_EditSitesList";
            this.Text = "Edit List of ___ to Create";
            this.Load += new System.EventHandler(this.ActionBulkSiteCreation_EditSitesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgNewSites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNewSites;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colURLname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
    }
}