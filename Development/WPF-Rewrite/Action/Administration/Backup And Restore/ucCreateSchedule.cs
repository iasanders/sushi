using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SUSHI
{
    public partial class ucCreateSchedule : UserControl
    {
        #region Constructor, Properties and Load
        public ucCreateSchedule()
        {
            InitializeComponent();
        }

        private AutoStartUtil.AutoStartMode _autostartType;
        public AutoStartUtil.AutoStartMode AutoStartType
        {
            get { return _autostartType; }
            set { _autostartType = value; }
        }

        private RichTextBox rtbDisplay;
        public RichTextBox RtbDisplay
        {
            get{return rtbDisplay;}
            set{rtbDisplay = value;}
        }

        private void ucCreateSchedule_Load(object sender, EventArgs e)
        {
            //--
            dtpTimeofDay.Value = DateTime.Today.AddHours(1);
            optDaily.Checked = true;

            if (_autostartType == AutoStartUtil.AutoStartMode.Catapult_SharePoint_Autobackup)
                gbScheduleBackup.Text = "Schedule Backup";
            else if (_autostartType == AutoStartUtil.AutoStartMode.Catapult_SharePoint_Cache)
                gbScheduleBackup.Text = "Schedule Site Cache";
        }
        #endregion

        #region control events
        private void btnValidateScheudule_Click(object sender, EventArgs e)
        {
            createSchedule(true);
        }

        private void btnCreateScheduledBackup_Click(object sender, EventArgs e)
        {
            createSchedule(false);
        }

        private void lnkOpenAutobackupLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (this._autostartType)
            {
                case AutoStartUtil.AutoStartMode.Catapult_SharePoint_Autobackup:
                    Process.Start(AutoBackup.BackupLogFullFileName);
                    break;
                case AutoStartUtil.AutoStartMode.Catapult_SharePoint_Cache:
                    Process.Start(AutoCache.CacheLogFullFileName);       
                    break;
            }
        }

        private void lnkViewScheduledBackups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.openFolderInWindowsExplorer(@"C:\WINDOWS\TASKS");
        }
        #endregion

        private void createSchedule(bool validateOnly)
        {
            try
            {
                rtbDisplay.Clear();
                string sc = optWeekly.Checked ? "WEEKLY" : "DAILY";

                string taskToRun = Environment.CurrentDirectory + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe -autostart:" + this._autostartType.ToString();
                string systemName = @"\\" + Environment.MachineName;
                string taskName = this._autostartType.ToString().Replace("_"," ");
                string args = "SCHTASKS /create /sc " + sc + " /mo 1 /tn \"" + taskName + "\" /tr \"" + taskToRun + "\" /s " + systemName;
                args += " /st " + dtpTimeofDay.Value.ToString("HH:mm") + " /F";
                args += " /u " + Environment.UserDomainName + "\\" + Environment.UserName;
                
                if (!validateOnly)
                {
                    string batFilename = System.IO.Path.GetTempPath() + "\\SUSHI_schedule_backup_tempfile.bat";
                    using (StreamWriter sw = new StreamWriter(batFilename))
                    {
                        sw.WriteLine(@"CD \");
                        sw.WriteLine(args);
                        sw.WriteLine("PAUSE");
                    }
                    ProcessStartInfo si = new ProcessStartInfo(batFilename);
                    Process ret = Process.Start(si);
                    SmartStepUtil.AddToRTB(rtbDisplay, "scheduled:\r\n", Color.Blue, 10, true);
                    SmartStepUtil.AddToRTB(rtbDisplay, args);
                }
                else 
                {
                    SmartStepUtil.AddToRTB(rtbDisplay, "to be scheduled:\r\n", Color.Blue, 10, true);
                    SmartStepUtil.AddToRTB(rtbDisplay, args);
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }



    }
}
