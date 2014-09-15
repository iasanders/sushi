namespace SushiNS
{
    partial class ActionBulkWebPartCustomize_EditParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionBulkWebPartCustomize_EditParameters));
            this.dg = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkPaste = new System.Windows.Forms.LinkLabel();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.colURLname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExternalURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirectors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dg.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colURLname,
            this.colStockSymbol,
            this.colExternalURL,
            this.colDirectors});
            this.dg.Location = new System.Drawing.Point(1, 0);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(963, 490);
            this.dg.TabIndex = 0;
            this.dg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgNewSites_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(391, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkPaste
            // 
            this.lnkPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkPaste.AutoSize = true;
            this.lnkPaste.Location = new System.Drawing.Point(36, 512);
            this.lnkPaste.Name = "lnkPaste";
            this.lnkPaste.Size = new System.Drawing.Size(104, 13);
            this.lnkPaste.TabIndex = 3;
            this.lnkPaste.TabStop = true;
            this.lnkPaste.Text = "Paste from Clipboard";
            this.lnkPaste.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPaste_LinkClicked);
            // 
            // lnkCancel
            // 
            this.lnkCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Location = new System.Drawing.Point(301, 512);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(40, 13);
            this.lnkCancel.TabIndex = 4;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // colURLname
            // 
            this.colURLname.HeaderText = "Site URL Name";
            this.colURLname.Name = "colURLname";
            this.colURLname.Width = 200;
            // 
            // colStockSymbol
            // 
            this.colStockSymbol.HeaderText = "Stock Symbol";
            this.colStockSymbol.Name = "colStockSymbol";
            // 
            // colExternalURL
            // 
            this.colExternalURL.HeaderText = "External Client Website URL";
            this.colExternalURL.Name = "colExternalURL";
            this.colExternalURL.Width = 300;
            // 
            // colDirectors
            // 
            this.colDirectors.HeaderText = "Directors";
            this.colDirectors.Name = "colDirectors";
            this.colDirectors.Width = 300;
            // 
            // ActionBulkWebPartCustomize_EditParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 542);
            this.ControlBox = false;
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.lnkPaste);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionBulkWebPartCustomize_EditParameters";
            this.Text = "Enter the Parameters needed to perform Bulk Webpart customization";
            this.Load += new System.EventHandler(this.ActionBulkWebPartCustomize_EditParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lnkPaste;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colURLname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExternalURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectors;
    }
}