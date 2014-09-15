namespace SushiNS
{
    partial class ActionContentTypes_EditSiteColumns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionContentTypes_EditSiteColumns));
            this.dgNewSiteColumns = new System.Windows.Forms.DataGridView();
            this.colInternalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.btnPasteFromClipboard = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgNewSiteColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // dgNewSiteColumns
            // 
            this.dgNewSiteColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNewSiteColumns.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgNewSiteColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNewSiteColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInternalName,
            this.colDisplayName,
            this.colFieldType,
            this.colGroup,
            this.colChoices,
            this.colDefaultValue,
            this.colDescription});
            this.dgNewSiteColumns.Location = new System.Drawing.Point(1, 0);
            this.dgNewSiteColumns.Name = "dgNewSiteColumns";
            this.dgNewSiteColumns.Size = new System.Drawing.Size(1145, 451);
            this.dgNewSiteColumns.TabIndex = 0;
            this.dgNewSiteColumns.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgNewSites_DataError);
            this.dgNewSiteColumns.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgNewSites_KeyDown);
            // 
            // colInternalName
            // 
            this.colInternalName.HeaderText = "Internal Name";
            this.colInternalName.Name = "colInternalName";
            this.colInternalName.Width = 170;
            // 
            // colDisplayName
            // 
            this.colDisplayName.HeaderText = "Display Name";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.Width = 170;
            // 
            // colFieldType
            // 
            this.colFieldType.HeaderText = "Field Type";
            this.colFieldType.Items.AddRange(new object[] {
            "Text",
            "Choice",
            "Invalid"});
            this.colFieldType.MinimumWidth = 9;
            this.colFieldType.Name = "colFieldType";
            // 
            // colGroup
            // 
            this.colGroup.HeaderText = "Group";
            this.colGroup.Name = "colGroup";
            // 
            // colChoices
            // 
            this.colChoices.HeaderText = "Choices (semicolon delimited)";
            this.colChoices.Name = "colChoices";
            this.colChoices.ToolTipText = "If the Data Type is \"choice\", enter the choices, separated by commas";
            this.colChoices.Width = 200;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.HeaderText = "Default Value";
            this.colDefaultValue.Name = "colDefaultValue";
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(387, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkCancel
            // 
            this.lnkCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCancel.Location = new System.Drawing.Point(465, 502);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(51, 17);
            this.lnkCancel.TabIndex = 4;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // btnPasteFromClipboard
            // 
            this.btnPasteFromClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPasteFromClipboard.Location = new System.Drawing.Point(1, 456);
            this.btnPasteFromClipboard.Name = "btnPasteFromClipboard";
            this.btnPasteFromClipboard.Size = new System.Drawing.Size(127, 21);
            this.btnPasteFromClipboard.TabIndex = 5;
            this.btnPasteFromClipboard.Text = "Paste From Clipboard";
            this.btnPasteFromClipboard.UseVisualStyleBackColor = true;
            this.btnPasteFromClipboard.Click += new System.EventHandler(this.btnPasteFromClipboard_Click);
            // 
            // lblTip
            // 
            this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(134, 462);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(213, 13);
            this.lblTip.TabIndex = 6;
            this.lblTip.Text = "Tip: Edit your list in Excel then paste above.";
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDisplay.DetectUrls = false;
            this.rtbDisplay.Location = new System.Drawing.Point(600, 457);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(533, 87);
            this.rtbDisplay.TabIndex = 23;
            this.rtbDisplay.Text = "";
            // 
            // ActionContentTypes_EditSiteColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 542);
            this.ControlBox = false;
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnPasteFromClipboard);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgNewSiteColumns);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionContentTypes_EditSiteColumns";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Edit List of Site Columns To Create";
            this.Load += new System.EventHandler(this.ActionBulkSiteCreation_EditSitesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgNewSiteColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNewSiteColumns;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.Button btnPasteFromClipboard;
        private System.Windows.Forms.Label lblTip;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInternalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}