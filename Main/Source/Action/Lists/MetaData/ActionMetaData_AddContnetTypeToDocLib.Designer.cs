namespace SUSHI
{
    partial class FrmAddContnetTypeToDocLib
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
            this.cboRootContentTypes = new System.Windows.Forms.ComboBox();
            this.lblAvailableCT = new System.Windows.Forms.Label();
            this.btnAddCt = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkChangeAllDocumentsToContentType = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboRootContentTypes
            // 
            this.cboRootContentTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRootContentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRootContentTypes.FormattingEnabled = true;
            this.cboRootContentTypes.Location = new System.Drawing.Point(7, 33);
            this.cboRootContentTypes.MaxDropDownItems = 20;
            this.cboRootContentTypes.Name = "cboRootContentTypes";
            this.cboRootContentTypes.Size = new System.Drawing.Size(379, 21);
            this.cboRootContentTypes.Sorted = true;
            this.cboRootContentTypes.TabIndex = 0;
            this.cboRootContentTypes.SelectedIndexChanged += new System.EventHandler(this.cboRootContentTypes_SelectedIndexChanged);
            // 
            // lblAvailableCT
            // 
            this.lblAvailableCT.AutoSize = true;
            this.lblAvailableCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableCT.Location = new System.Drawing.Point(7, 17);
            this.lblAvailableCT.Name = "lblAvailableCT";
            this.lblAvailableCT.Size = new System.Drawing.Size(149, 13);
            this.lblAvailableCT.TabIndex = 1;
            this.lblAvailableCT.Text = "Available Content Types ";
            // 
            // btnAddCt
            // 
            this.btnAddCt.Enabled = false;
            this.btnAddCt.Location = new System.Drawing.Point(7, 92);
            this.btnAddCt.Name = "btnAddCt";
            this.btnAddCt.Size = new System.Drawing.Size(205, 23);
            this.btnAddCt.TabIndex = 2;
            this.btnAddCt.Text = "Add Content Type to Document Library";
            this.btnAddCt.UseVisualStyleBackColor = true;
            this.btnAddCt.Click += new System.EventHandler(this.btnAddCt_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkChangeAllDocumentsToContentType
            // 
            this.chkChangeAllDocumentsToContentType.AutoSize = true;
            this.chkChangeAllDocumentsToContentType.Location = new System.Drawing.Point(7, 63);
            this.chkChangeAllDocumentsToContentType.Name = "chkChangeAllDocumentsToContentType";
            this.chkChangeAllDocumentsToContentType.Size = new System.Drawing.Size(246, 17);
            this.chkChangeAllDocumentsToContentType.TabIndex = 4;
            this.chkChangeAllDocumentsToContentType.Text = "Change all documents in library to content type";
            this.chkChangeAllDocumentsToContentType.UseVisualStyleBackColor = true;
            // 
            // FrmAddContnetTypeToDocLib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 165);
            this.Controls.Add(this.chkChangeAllDocumentsToContentType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddCt);
            this.Controls.Add(this.lblAvailableCT);
            this.Controls.Add(this.cboRootContentTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddContnetTypeToDocLib";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Content Type to _____";
            this.Load += new System.EventHandler(this.frmAddContnetTypeToDocLib_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRootContentTypes;
        private System.Windows.Forms.Label lblAvailableCT;
        private System.Windows.Forms.Button btnAddCt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkChangeAllDocumentsToContentType;
    }
}