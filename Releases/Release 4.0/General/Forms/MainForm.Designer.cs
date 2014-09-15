namespace SushiNS
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvNav = new System.Windows.Forms.TreeView();
            this.imageListForTvNav = new System.Windows.Forms.ImageList(this.components);
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.rtbTitle = new System.Windows.Forms.RichTextBox();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.pictureBoxTop = new System.Windows.Forms.PictureBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvNav);
            this.splitContainer1.Panel1.Controls.Add(this.txtInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(898, 603);
            this.splitContainer1.SplitterDistance = 157;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvNav
            // 
            this.tvNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNav.HideSelection = false;
            this.tvNav.ImageIndex = 0;
            this.tvNav.ImageList = this.imageListForTvNav;
            this.tvNav.Location = new System.Drawing.Point(0, 0);
            this.tvNav.Name = "tvNav";
            this.tvNav.SelectedImageIndex = 0;
            this.tvNav.ShowLines = false;
            this.tvNav.ShowPlusMinus = false;
            this.tvNav.Size = new System.Drawing.Size(157, 516);
            this.tvNav.TabIndex = 0;
            this.tvNav.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvNav_MouseClick);
            this.tvNav.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNav_AfterSelect);
            this.tvNav.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvNav_KeyDown);
            // 
            // imageListForTvNav
            // 
            this.imageListForTvNav.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForTvNav.ImageStream")));
            this.imageListForTvNav.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForTvNav.Images.SetKeyName(0, "tvNavicon_data.gif");
            this.imageListForTvNav.Images.SetKeyName(1, "tvNavicon_information.gif");
            this.imageListForTvNav.Images.SetKeyName(2, "tvNavicon_jobs.gif");
            this.imageListForTvNav.Images.SetKeyName(3, "tvNavicon_messages.gif");
            this.imageListForTvNav.Images.SetKeyName(4, "tvNavicon_overview.gif");
            this.imageListForTvNav.Images.SetKeyName(5, "tvNavicon_schedule.gif");
            this.imageListForTvNav.Images.SetKeyName(6, "tvnavicon_schedule_over.gif");
            this.imageListForTvNav.Images.SetKeyName(7, "tvnavicon_data_over.gif");
            this.imageListForTvNav.Images.SetKeyName(8, "tvnavicon_information_over.gif");
            this.imageListForTvNav.Images.SetKeyName(9, "tvnavicon_jobs_over.gif");
            this.imageListForTvNav.Images.SetKeyName(10, "tvnavicon_messages_over.gif");
            this.imageListForTvNav.Images.SetKeyName(11, "tvnavicon_operatorconsole_over.gif");
            this.imageListForTvNav.Images.SetKeyName(12, "tvNavicon_reporting.gif");
            this.imageListForTvNav.Images.SetKeyName(13, "tvNavicon_reporting_over.gif");
            this.imageListForTvNav.Images.SetKeyName(14, "copy_a_view.png");
            this.imageListForTvNav.Images.SetKeyName(15, "copy_a_view_h.png");
            this.imageListForTvNav.Images.SetKeyName(16, "themes_h.png");
            this.imageListForTvNav.Images.SetKeyName(17, "bulk_list_creation.png");
            this.imageListForTvNav.Images.SetKeyName(18, "bulk_list_creation_h.png");
            this.imageListForTvNav.Images.SetKeyName(19, "bulk_site_creation.png");
            this.imageListForTvNav.Images.SetKeyName(20, "bulk_site_creation_h.png");
            this.imageListForTvNav.Images.SetKeyName(21, "deleteold_doc.png");
            this.imageListForTvNav.Images.SetKeyName(22, "deleteold_doc_h.png");
            this.imageListForTvNav.Images.SetKeyName(23, "email_test.png");
            this.imageListForTvNav.Images.SetKeyName(24, "email_test_h.png");
            this.imageListForTvNav.Images.SetKeyName(25, "help_settings.png");
            this.imageListForTvNav.Images.SetKeyName(26, "help_settings_h.png");
            this.imageListForTvNav.Images.SetKeyName(27, "metadata.png");
            this.imageListForTvNav.Images.SetKeyName(28, "metadata_h.png");
            this.imageListForTvNav.Images.SetKeyName(29, "more.png");
            this.imageListForTvNav.Images.SetKeyName(30, "more_h.png");
            this.imageListForTvNav.Images.SetKeyName(31, "profile_image_import.png");
            this.imageListForTvNav.Images.SetKeyName(32, "profile_image_import_h.png");
            this.imageListForTvNav.Images.SetKeyName(33, "restore.png");
            this.imageListForTvNav.Images.SetKeyName(34, "restore_h.png");
            this.imageListForTvNav.Images.SetKeyName(35, "themes.png");
            this.imageListForTvNav.Images.SetKeyName(36, "import_doc.png");
            this.imageListForTvNav.Images.SetKeyName(37, "import_doc_h.png");
            this.imageListForTvNav.Images.SetKeyName(38, "admin.gif");
            this.imageListForTvNav.Images.SetKeyName(39, "admin_h.png");
            this.imageListForTvNav.Images.SetKeyName(40, "security_report.png");
            this.imageListForTvNav.Images.SetKeyName(41, "security_reports_h.png");
            this.imageListForTvNav.Images.SetKeyName(42, "backup.png");
            this.imageListForTvNav.Images.SetKeyName(43, "backup_h.png");
            this.imageListForTvNav.Images.SetKeyName(44, "del_h.png");
            this.imageListForTvNav.Images.SetKeyName(45, "del.png");
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInfo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.ForeColor = System.Drawing.Color.DimGray;
            this.txtInfo.Location = new System.Drawing.Point(0, 516);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(157, 87);
            this.txtInfo.TabIndex = 2;
            this.txtInfo.TabStop = false;
            this.txtInfo.Text = "UserName:\r\nVersion: \r\n";
            // 
            // rtbTitle
            // 
            this.rtbTitle.BackColor = System.Drawing.SystemColors.Control;
            this.rtbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTitle.ForeColor = System.Drawing.Color.Black;
            this.rtbTitle.Location = new System.Drawing.Point(94, 0);
            this.rtbTitle.Name = "rtbTitle";
            this.rtbTitle.ReadOnly = true;
            this.rtbTitle.Size = new System.Drawing.Size(733, 35);
            this.rtbTitle.TabIndex = 9;
            this.rtbTitle.Text = "<SUSHI>";
            // 
            // pbHelp
            // 
            this.pbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHelp.Image = global::SushiNS.Properties.Resources.help_h1;
            this.pbHelp.Location = new System.Drawing.Point(863, -1);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(35, 36);
            this.pbHelp.TabIndex = 10;
            this.pbHelp.TabStop = false;
            this.pbHelp.MouseLeave += new System.EventHandler(this.pbHelp_MouseLeave);
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            this.pbHelp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbHelp_MouseDown);
            this.pbHelp.MouseHover += new System.EventHandler(this.pbHelp_MouseHover);
            this.pbHelp.MouseEnter += new System.EventHandler(this.pbHelp_MouseEnter);
            // 
            // pictureBoxTop
            // 
            this.pictureBoxTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxTop.Image = global::SushiNS.Properties.Resources.actionImage_operator_console;
            this.pictureBoxTop.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTop.Name = "pictureBoxTop";
            this.pictureBoxTop.Size = new System.Drawing.Size(898, 35);
            this.pictureBoxTop.TabIndex = 0;
            this.pictureBoxTop.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 638);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.rtbTitle);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pictureBoxTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SUSHI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.TreeView tvNav;
        private System.Windows.Forms.TextBox txtInfo;
        internal System.Windows.Forms.ImageList imageListForTvNav;
        private System.Windows.Forms.RichTextBox rtbTitle;
        internal System.Windows.Forms.PictureBox pictureBoxTop;
        private System.Windows.Forms.PictureBox pbHelp;
    }
}