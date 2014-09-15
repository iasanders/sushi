namespace SUSHI
{
    partial class ucCreateSchedule
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbScheduleBackup = new System.Windows.Forms.GroupBox();
            this.btnValidateScheudule = new System.Windows.Forms.Button();
            this.lnkViewScheduledBackups = new System.Windows.Forms.LinkLabel();
            this.optWeekly = new System.Windows.Forms.RadioButton();
            this.lnkOpenAutobackupLog = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.optDaily = new System.Windows.Forms.RadioButton();
            this.btnCreateScheduledBackup = new System.Windows.Forms.Button();
            this.dtpTimeofDay = new System.Windows.Forms.DateTimePicker();
            this.gbScheduleBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbScheduleBackup
            // 
            this.gbScheduleBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbScheduleBackup.Controls.Add(this.btnValidateScheudule);
            this.gbScheduleBackup.Controls.Add(this.lnkViewScheduledBackups);
            this.gbScheduleBackup.Controls.Add(this.optWeekly);
            this.gbScheduleBackup.Controls.Add(this.lnkOpenAutobackupLog);
            this.gbScheduleBackup.Controls.Add(this.label1);
            this.gbScheduleBackup.Controls.Add(this.optDaily);
            this.gbScheduleBackup.Controls.Add(this.btnCreateScheduledBackup);
            this.gbScheduleBackup.Controls.Add(this.dtpTimeofDay);
            this.gbScheduleBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbScheduleBackup.Location = new System.Drawing.Point(0, 0);
            this.gbScheduleBackup.Name = "gbScheduleBackup";
            this.gbScheduleBackup.Size = new System.Drawing.Size(599, 98);
            this.gbScheduleBackup.TabIndex = 51;
            this.gbScheduleBackup.TabStop = false;
            this.gbScheduleBackup.Text = "Schedule Backup";
            // 
            // btnValidateScheudule
            // 
            this.btnValidateScheudule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidateScheudule.Location = new System.Drawing.Point(206, 70);
            this.btnValidateScheudule.Name = "btnValidateScheudule";
            this.btnValidateScheudule.Size = new System.Drawing.Size(74, 25);
            this.btnValidateScheudule.TabIndex = 54;
            this.btnValidateScheudule.Text = "Validate";
            this.btnValidateScheudule.UseVisualStyleBackColor = true;
            this.btnValidateScheudule.Click += new System.EventHandler(this.btnValidateScheudule_Click);
            // 
            // lnkViewScheduledBackups
            // 
            this.lnkViewScheduledBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkViewScheduledBackups.AutoSize = true;
            this.lnkViewScheduledBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkViewScheduledBackups.Location = new System.Drawing.Point(486, 50);
            this.lnkViewScheduledBackups.Name = "lnkViewScheduledBackups";
            this.lnkViewScheduledBackups.Size = new System.Drawing.Size(107, 13);
            this.lnkViewScheduledBackups.TabIndex = 51;
            this.lnkViewScheduledBackups.TabStop = true;
            this.lnkViewScheduledBackups.Text = "view scheduled tasks";
            this.lnkViewScheduledBackups.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkViewScheduledBackups_LinkClicked);
            // 
            // optWeekly
            // 
            this.optWeekly.AutoSize = true;
            this.optWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optWeekly.Location = new System.Drawing.Point(25, 51);
            this.optWeekly.Name = "optWeekly";
            this.optWeekly.Size = new System.Drawing.Size(61, 17);
            this.optWeekly.TabIndex = 45;
            this.optWeekly.TabStop = true;
            this.optWeekly.Text = "Weekly";
            this.optWeekly.UseVisualStyleBackColor = true;
            // 
            // lnkOpenAutobackupLog
            // 
            this.lnkOpenAutobackupLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkOpenAutobackupLog.AutoSize = true;
            this.lnkOpenAutobackupLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpenAutobackupLog.Location = new System.Drawing.Point(508, 74);
            this.lnkOpenAutobackupLog.Name = "lnkOpenAutobackupLog";
            this.lnkOpenAutobackupLog.Size = new System.Drawing.Size(85, 13);
            this.lnkOpenAutobackupLog.TabIndex = 47;
            this.lnkOpenAutobackupLog.TabStop = true;
            this.lnkOpenAutobackupLog.Text = "open backup log";
            this.lnkOpenAutobackupLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenAutobackupLog_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Time of Day:";
            // 
            // optDaily
            // 
            this.optDaily.AutoSize = true;
            this.optDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDaily.Location = new System.Drawing.Point(25, 29);
            this.optDaily.Name = "optDaily";
            this.optDaily.Size = new System.Drawing.Size(48, 17);
            this.optDaily.TabIndex = 44;
            this.optDaily.TabStop = true;
            this.optDaily.Text = "Daily";
            this.optDaily.UseVisualStyleBackColor = true;
            // 
            // btnCreateScheduledBackup
            // 
            this.btnCreateScheduledBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateScheduledBackup.Location = new System.Drawing.Point(291, 70);
            this.btnCreateScheduledBackup.Name = "btnCreateScheduledBackup";
            this.btnCreateScheduledBackup.Size = new System.Drawing.Size(167, 25);
            this.btnCreateScheduledBackup.TabIndex = 43;
            this.btnCreateScheduledBackup.Text = "Create Scheduled Backup";
            this.btnCreateScheduledBackup.UseVisualStyleBackColor = true;
            this.btnCreateScheduledBackup.Click += new System.EventHandler(this.btnCreateScheduledBackup_Click);
            // 
            // dtpTimeofDay
            // 
            this.dtpTimeofDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeofDay.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeofDay.Location = new System.Drawing.Point(96, 70);
            this.dtpTimeofDay.Name = "dtpTimeofDay";
            this.dtpTimeofDay.ShowUpDown = true;
            this.dtpTimeofDay.Size = new System.Drawing.Size(99, 20);
            this.dtpTimeofDay.TabIndex = 48;
            this.dtpTimeofDay.Value = new System.DateTime(2007, 6, 26, 2, 0, 0, 0);
            // 
            // ucCreateSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbScheduleBackup);
            this.Name = "ucCreateSchedule";
            this.Size = new System.Drawing.Size(605, 108);
            this.Load += new System.EventHandler(this.ucCreateSchedule_Load);
            this.gbScheduleBackup.ResumeLayout(false);
            this.gbScheduleBackup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbScheduleBackup;
        private System.Windows.Forms.LinkLabel lnkViewScheduledBackups;
        private System.Windows.Forms.RadioButton optWeekly;
        private System.Windows.Forms.LinkLabel lnkOpenAutobackupLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optDaily;
        private System.Windows.Forms.Button btnCreateScheduledBackup;
        private System.Windows.Forms.DateTimePicker dtpTimeofDay;
        private System.Windows.Forms.Button btnValidateScheudule;
    }
}
