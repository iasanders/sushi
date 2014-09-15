namespace SUSHI
{
    partial class frmBuildMapping
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
            this.lblTargetDocLib = new System.Windows.Forms.Label();
            this.lblTargetContentType = new System.Windows.Forms.Label();
            this.cboTargetContentType = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblDestColumn = new System.Windows.Forms.Label();
            this.lstSource = new System.Windows.Forms.ListBox();
            this.btnAddMap = new System.Windows.Forms.Button();
            this.lstDest = new System.Windows.Forms.ListBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.lnkDeleteProfile = new System.Windows.Forms.LinkLabel();
            this.lnkClearSingleColumnMapping = new System.Windows.Forms.LinkLabel();
            this.cboClearAMapping = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTargetDocLib
            // 
            this.lblTargetDocLib.AutoSize = true;
            this.lblTargetDocLib.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetDocLib.Location = new System.Drawing.Point(1, 9);
            this.lblTargetDocLib.Name = "lblTargetDocLib";
            this.lblTargetDocLib.Size = new System.Drawing.Size(151, 13);
            this.lblTargetDocLib.TabIndex = 0;
            this.lblTargetDocLib.Text = "Target Document Library:";
            // 
            // lblTargetContentType
            // 
            this.lblTargetContentType.AutoSize = true;
            this.lblTargetContentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetContentType.Location = new System.Drawing.Point(1, 32);
            this.lblTargetContentType.Name = "lblTargetContentType";
            this.lblTargetContentType.Size = new System.Drawing.Size(128, 13);
            this.lblTargetContentType.TabIndex = 1;
            this.lblTargetContentType.Text = "Target Content Type:";
            // 
            // cboTargetContentType
            // 
            this.cboTargetContentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTargetContentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetContentType.FormattingEnabled = true;
            this.cboTargetContentType.Location = new System.Drawing.Point(129, 29);
            this.cboTargetContentType.Name = "cboTargetContentType";
            this.cboTargetContentType.Size = new System.Drawing.Size(456, 21);
            this.cboTargetContentType.TabIndex = 2;
            this.cboTargetContentType.SelectedIndexChanged += new System.EventHandler(this.cboTargetContentType_SelectedIndexChanged);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(-2, 83);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(98, 13);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Source Columns";
            // 
            // lblDestColumn
            // 
            this.lblDestColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDestColumn.AutoSize = true;
            this.lblDestColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestColumn.Location = new System.Drawing.Point(473, 83);
            this.lblDestColumn.Name = "lblDestColumn";
            this.lblDestColumn.Size = new System.Drawing.Size(242, 13);
            this.lblDestColumn.TabIndex = 4;
            this.lblDestColumn.Text = "Destination Columns of Content Type ___";
            // 
            // lstSource
            // 
            this.lstSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSource.FormattingEnabled = true;
            this.lstSource.Location = new System.Drawing.Point(3, 3);
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(396, 173);
            this.lstSource.Sorted = true;
            this.lstSource.TabIndex = 5;
            // 
            // btnAddMap
            // 
            this.btnAddMap.Location = new System.Drawing.Point(319, 287);
            this.btnAddMap.Name = "btnAddMap";
            this.btnAddMap.Size = new System.Drawing.Size(133, 23);
            this.btnAddMap.TabIndex = 6;
            this.btnAddMap.Text = "Add Column Mapping";
            this.btnAddMap.UseVisualStyleBackColor = true;
            this.btnAddMap.Click += new System.EventHandler(this.btnAddMap_Click);
            // 
            // lstDest
            // 
            this.lstDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDest.FormattingEnabled = true;
            this.lstDest.Location = new System.Drawing.Point(405, 3);
            this.lstDest.Name = "lstDest";
            this.lstDest.Size = new System.Drawing.Size(397, 173);
            this.lstDest.Sorted = true;
            this.lstDest.TabIndex = 7;
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(-2, 316);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(805, 234);
            this.rtbDisplay.TabIndex = 27;
            this.rtbDisplay.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstSource, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstDest, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-2, 99);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(805, 182);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(692, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileName.Location = new System.Drawing.Point(1, 55);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(83, 13);
            this.lblProfileName.TabIndex = 31;
            this.lblProfileName.Text = "Profile Name:";
            // 
            // txtProfileName
            // 
            this.txtProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfileName.Location = new System.Drawing.Point(129, 52);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(456, 20);
            this.txtProfileName.TabIndex = 33;
            this.txtProfileName.TextChanged += new System.EventHandler(this.txtProfileName_TextChanged);
            // 
            // lnkDeleteProfile
            // 
            this.lnkDeleteProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDeleteProfile.AutoSize = true;
            this.lnkDeleteProfile.Location = new System.Drawing.Point(512, 292);
            this.lnkDeleteProfile.Name = "lnkDeleteProfile";
            this.lnkDeleteProfile.Size = new System.Drawing.Size(70, 13);
            this.lnkDeleteProfile.TabIndex = 36;
            this.lnkDeleteProfile.TabStop = true;
            this.lnkDeleteProfile.Text = "Delete Profile";
            this.lnkDeleteProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDeleteProfile_LinkClicked);
            // 
            // lnkClearSingleColumnMapping
            // 
            this.lnkClearSingleColumnMapping.AutoSize = true;
            this.lnkClearSingleColumnMapping.Location = new System.Drawing.Point(1, 292);
            this.lnkClearSingleColumnMapping.Name = "lnkClearSingleColumnMapping";
            this.lnkClearSingleColumnMapping.Size = new System.Drawing.Size(107, 13);
            this.lnkClearSingleColumnMapping.TabIndex = 38;
            this.lnkClearSingleColumnMapping.TabStop = true;
            this.lnkClearSingleColumnMapping.Text = "Clear Single Mapping";
            this.lnkClearSingleColumnMapping.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearSingleColumnMapping_LinkClicked);
            // 
            // cboClearAMapping
            // 
            this.cboClearAMapping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClearAMapping.FormattingEnabled = true;
            this.cboClearAMapping.Location = new System.Drawing.Point(114, 289);
            this.cboClearAMapping.Name = "cboClearAMapping";
            this.cboClearAMapping.Size = new System.Drawing.Size(199, 21);
            this.cboClearAMapping.TabIndex = 39;
            this.cboClearAMapping.Visible = false;
            this.cboClearAMapping.SelectedIndexChanged += new System.EventHandler(this.cboClearAMapping_SelectedIndexChanged);
            this.cboClearAMapping.Leave += new System.EventHandler(this.cboClearAMapping_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(592, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmBuildMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 552);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboClearAMapping);
            this.Controls.Add(this.lnkClearSingleColumnMapping);
            this.Controls.Add(this.lnkDeleteProfile);
            this.Controls.Add(this.txtProfileName);
            this.Controls.Add(this.lblProfileName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.rtbDisplay);
            this.Controls.Add(this.btnAddMap);
            this.Controls.Add(this.lblDestColumn);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cboTargetContentType);
            this.Controls.Add(this.lblTargetContentType);
            this.Controls.Add(this.lblTargetDocLib);
            this.MinimizeBox = false;
            this.Name = "frmBuildMapping";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Build Mapping Profile";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTargetDocLib;
        private System.Windows.Forms.Label lblTargetContentType;
        private System.Windows.Forms.ComboBox cboTargetContentType;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblDestColumn;
        private System.Windows.Forms.ListBox lstSource;
        private System.Windows.Forms.Button btnAddMap;
        private System.Windows.Forms.ListBox lstDest;
        internal System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.LinkLabel lnkDeleteProfile;
        private System.Windows.Forms.LinkLabel lnkClearSingleColumnMapping;
        private System.Windows.Forms.ComboBox cboClearAMapping;
        private System.Windows.Forms.Button btnCancel;
    }
}