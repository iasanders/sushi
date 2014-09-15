namespace SushiNS
{
    partial class ActionEmail
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSMTP = new System.Windows.Forms.TextBox();
            this.lblFromEmailAddress = new System.Windows.Forms.Label();
            this.txtFromEmail = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtToEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lnkDisplayCurrentInfo = new System.Windows.Forms.LinkLabel();
            this.lnkBrowseToOutboundEmail = new System.Windows.Forms.LinkLabel();
            this.groupboxToolkit = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.groupboxToolkit.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDisplay.Location = new System.Drawing.Point(2, 184);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(677, 428);
            this.rtbDisplay.TabIndex = 22;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDisplay_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "SMTP Server:";
            // 
            // txtSMTP
            // 
            this.txtSMTP.Location = new System.Drawing.Point(5, 113);
            this.txtSMTP.Name = "txtSMTP";
            this.txtSMTP.Size = new System.Drawing.Size(309, 20);
            this.txtSMTP.TabIndex = 78;
            // 
            // lblFromEmailAddress
            // 
            this.lblFromEmailAddress.AutoSize = true;
            this.lblFromEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromEmailAddress.Location = new System.Drawing.Point(5, 51);
            this.lblFromEmailAddress.Name = "lblFromEmailAddress";
            this.lblFromEmailAddress.Size = new System.Drawing.Size(121, 13);
            this.lblFromEmailAddress.TabIndex = 77;
            this.lblFromEmailAddress.Text = "From Email Address:";
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.Location = new System.Drawing.Point(5, 67);
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(309, 20);
            this.txtFromEmail.TabIndex = 76;
            this.txtFromEmail.TextChanged += new System.EventHandler(this.txtFromEmail_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(7, 146);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(123, 23);
            this.btnSend.TabIndex = 75;
            this.btnSend.Text = "Send Test Email";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtToEmail
            // 
            this.txtToEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToEmail.Location = new System.Drawing.Point(365, 67);
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.ReadOnly = true;
            this.txtToEmail.Size = new System.Drawing.Size(309, 20);
            this.txtToEmail.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(362, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "To Email Address:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(5, 14);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(145, 17);
            this.lblDescription.TabIndex = 82;
            this.lblDescription.Text = "Send a Test Email:";
            // 
            // lnkDisplayCurrentInfo
            // 
            this.lnkDisplayCurrentInfo.AutoSize = true;
            this.lnkDisplayCurrentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDisplayCurrentInfo.Location = new System.Drawing.Point(6, 21);
            this.lnkDisplayCurrentInfo.Name = "lnkDisplayCurrentInfo";
            this.lnkDisplayCurrentInfo.Size = new System.Drawing.Size(197, 13);
            this.lnkDisplayCurrentInfo.TabIndex = 83;
            this.lnkDisplayCurrentInfo.TabStop = true;
            this.lnkDisplayCurrentInfo.Text = "Display Current Outbound Email Settings";
            this.lnkDisplayCurrentInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDisplayCurrentInfo_LinkClicked);
            // 
            // lnkBrowseToOutboundEmail
            // 
            this.lnkBrowseToOutboundEmail.AutoSize = true;
            this.lnkBrowseToOutboundEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBrowseToOutboundEmail.Location = new System.Drawing.Point(6, 42);
            this.lnkBrowseToOutboundEmail.Name = "lnkBrowseToOutboundEmail";
            this.lnkBrowseToOutboundEmail.Size = new System.Drawing.Size(173, 13);
            this.lnkBrowseToOutboundEmail.TabIndex = 84;
            this.lnkBrowseToOutboundEmail.TabStop = true;
            this.lnkBrowseToOutboundEmail.Text = "Browse to Outbound Email Settings";
            this.lnkBrowseToOutboundEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrowseToOutboundEmail_LinkClicked);
            // 
            // groupboxToolkit
            // 
            this.groupboxToolkit.Controls.Add(this.lnkDisplayCurrentInfo);
            this.groupboxToolkit.Controls.Add(this.lnkBrowseToOutboundEmail);
            this.groupboxToolkit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupboxToolkit.Location = new System.Drawing.Point(363, 105);
            this.groupboxToolkit.Name = "groupboxToolkit";
            this.groupboxToolkit.Size = new System.Drawing.Size(241, 68);
            this.groupboxToolkit.TabIndex = 86;
            this.groupboxToolkit.TabStop = false;
            this.groupboxToolkit.Text = "Tools";
            // 
            // ActionEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.groupboxToolkit);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSMTP);
            this.Controls.Add(this.lblFromEmailAddress);
            this.Controls.Add(this.txtFromEmail);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbDisplay);
            this.Name = "ActionEmail";
            this.Load += new System.EventHandler(this.ActionEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.groupboxToolkit.ResumeLayout(false);
            this.groupboxToolkit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RichTextBox rtbDisplay;
        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSMTP;
        private System.Windows.Forms.Label lblFromEmailAddress;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtToEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.LinkLabel lnkDisplayCurrentInfo;
        private System.Windows.Forms.LinkLabel lnkBrowseToOutboundEmail;
        private System.Windows.Forms.GroupBox groupboxToolkit;

    }
}
