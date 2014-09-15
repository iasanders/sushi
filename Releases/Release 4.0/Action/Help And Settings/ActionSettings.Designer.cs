namespace SushiNS
{
    partial class ActionSettings
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
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.lnkOpen = new System.Windows.Forms.LinkLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bgHelp = new System.Windows.Forms.GroupBox();
            this.lnkOpenHelp = new System.Windows.Forms.LinkLabel();
            this.txtHelpIntro = new System.Windows.Forms.TextBox();
            this.gbMisc = new System.Windows.Forms.GroupBox();
            this.lnkDonate = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.bgHelp.SuspendLayout();
            this.gbMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.Location = new System.Drawing.Point(255, 50);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(159, 28);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save Settings To Disk";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lblConfirm);
            this.gbSettings.Controls.Add(this.btnSaveSettings);
            this.gbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSettings.Location = new System.Drawing.Point(6, 180);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(667, 161);
            this.gbSettings.TabIndex = 7;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(438, 94);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(0, 22);
            this.lblConfirm.TabIndex = 11;
            // 
            // lnkOpen
            // 
            this.lnkOpen.AutoSize = true;
            this.lnkOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpen.Location = new System.Drawing.Point(26, 58);
            this.lnkOpen.Name = "lnkOpen";
            this.lnkOpen.Size = new System.Drawing.Size(123, 13);
            this.lnkOpen.TabIndex = 10;
            this.lnkOpen.TabStop = true;
            this.lnkOpen.Text = "Open Log Files Directory";
            this.lnkOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpen_LinkClicked);
            // 
            // bgHelp
            // 
            this.bgHelp.Controls.Add(this.lnkOpenHelp);
            this.bgHelp.Controls.Add(this.txtHelpIntro);
            this.bgHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgHelp.Location = new System.Drawing.Point(6, 2);
            this.bgHelp.Name = "bgHelp";
            this.bgHelp.Size = new System.Drawing.Size(667, 161);
            this.bgHelp.TabIndex = 9;
            this.bgHelp.TabStop = false;
            this.bgHelp.Text = "Help";
            // 
            // lnkOpenHelp
            // 
            this.lnkOpenHelp.AutoSize = true;
            this.lnkOpenHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpenHelp.Location = new System.Drawing.Point(251, 89);
            this.lnkOpenHelp.Name = "lnkOpenHelp";
            this.lnkOpenHelp.Size = new System.Drawing.Size(164, 24);
            this.lnkOpenHelp.TabIndex = 2;
            this.lnkOpenHelp.TabStop = true;
            this.lnkOpenHelp.Text = "Open Online Help";
            this.lnkOpenHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenHelp_LinkClicked);
            // 
            // txtHelpIntro
            // 
            this.txtHelpIntro.BackColor = System.Drawing.SystemColors.Control;
            this.txtHelpIntro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHelpIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHelpIntro.Location = new System.Drawing.Point(110, 32);
            this.txtHelpIntro.Multiline = true;
            this.txtHelpIntro.Name = "txtHelpIntro";
            this.txtHelpIntro.Size = new System.Drawing.Size(447, 54);
            this.txtHelpIntro.TabIndex = 0;
            this.txtHelpIntro.Text = "Online help and documentation is availble for the SUSHI Sharepoint Utilty in a wi" +
                "ki format hosted at http://www.codeplex.com/sushi.";
            // 
            // gbMisc
            // 
            this.gbMisc.Controls.Add(this.lnkDonate);
            this.gbMisc.Controls.Add(this.lnkOpen);
            this.gbMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMisc.Location = new System.Drawing.Point(6, 358);
            this.gbMisc.Name = "gbMisc";
            this.gbMisc.Size = new System.Drawing.Size(667, 161);
            this.gbMisc.TabIndex = 12;
            this.gbMisc.TabStop = false;
            this.gbMisc.Text = "Misc";
            // 
            // lnkDonate
            // 
            this.lnkDonate.AutoSize = true;
            this.lnkDonate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDonate.Location = new System.Drawing.Point(424, 58);
            this.lnkDonate.Name = "lnkDonate";
            this.lnkDonate.Size = new System.Drawing.Size(135, 13);
            this.lnkDonate.TabIndex = 12;
            this.lnkDonate.TabStop = true;
            this.lnkDonate.Text = "Make a donation to SUSHI";
            this.lnkDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDonate_LinkClicked);
            // 
            // ActionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.gbMisc);
            this.Controls.Add(this.bgHelp);
            this.Controls.Add(this.gbSettings);
            this.Name = "ActionSettings";
            this.Load += new System.EventHandler(this.ActionSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.bgHelp.ResumeLayout(false);
            this.bgHelp.PerformLayout();
            this.gbMisc.ResumeLayout(false);
            this.gbMisc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox bgHelp;
        private System.Windows.Forms.LinkLabel lnkOpenHelp;
        private System.Windows.Forms.TextBox txtHelpIntro;
        private System.Windows.Forms.LinkLabel lnkOpen;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.GroupBox gbMisc;
        private System.Windows.Forms.LinkLabel lnkDonate;

    }
}
