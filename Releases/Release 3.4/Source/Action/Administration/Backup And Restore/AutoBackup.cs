using System;
using Microsoft.SharePoint;
using System.Diagnostics;
using System.IO;

namespace SushiNS
{
    internal static class AutoBackup
    {
        static int _totalSites;

        internal static void StartBackup()
        {
            try
            {
                //--default to an error code, incase of premature failure.
                Environment.ExitCode = 6;

                //--initiate log file
                WriteToBackupLog("----------------------STARTING BACKUP " + DateTime.Now.ToString());
                //--validate
                if (!System.IO.Directory.Exists(GlobalVars.SETTINGS.backup_backupFilesPath))
                {
                    WriteErrorToBackupLog("Backup folder '" + GlobalVars.SETTINGS.backup_backupFilesPath + "' does not exist.");
                    return;
                }

                if (GlobalVars.SETTINGS.backup_siteURLcollection.Count == 0)
                {
                    WriteErrorToBackupLog("List of sites to backup is empty.");
                    return;
                }
                _totalSites = 0;

                //--
                if (GlobalVars.SETTINGS.backup_includeSubsites)
                    WriteToBackupLog("include subsites=true\r\n");
                else
                    WriteToBackupLog("include subsites=false\r\n");
                WriteToBackupLog("--");

                //--
                foreach (string siteUrl in GlobalVars.SETTINGS.backup_siteURLcollection)
                    KickoffBackup(siteUrl);

                //--
                WriteToBackupLog("BACKUP COMPLETE. Total sites backed up: " + _totalSites);

                //--success exitCode
                Environment.ExitCode = 0;
            }
            catch (Exception ex)
            {
                WriteErrorToBackupLog(ex.ToString() + "\r\n");
            }
        }

        private static void KickoffBackup(string siteUrl)
        {
            SPSite sps;
            try
            {
                sps = new SPSite(siteUrl);
            }
            catch (Exception ex)
            {
                WriteToBackupLog("site '" + siteUrl + "' not found: " + ex.Message);
                return;
            }
            SPWeb web = sps.OpenWeb();

            //--
            WriteToBackupLog("Site to backup: " + web.Url);

            BackupRecursively(web, true, false);
            WriteToBackupLog("--");
        }

        private static void BackupRecursively(SPWeb web, bool isTopLevelSite, bool isCompress)
        {
            //--loop through all subsites, call StartBackup3 recursively
            if (GlobalVars.SETTINGS.backup_includeSubsites)
            {
                foreach (SPWeb subweb in web.Webs)
                    if (isCompress)
                        BackupRecursively(subweb, false, true);
                    else
                        BackupRecursively(subweb, false, false);
                if (isTopLevelSite)
                    return;
            }

            _totalSites++;
            string cleanSubWebName = fetchCleanBackupFileName(web.Url);
            string backupFileName = GlobalVars.SETTINGS.backup_backupFilesPath + "\\" + cleanSubWebName + ".SUSHIbackup";

            //--do backup of site
            ProcessStartInfo si = new ProcessStartInfo();
            si.Arguments = fetchStsadmCmdArgsForBackup(web.Url, backupFileName, isCompress);
            si.FileName = GlobalVars.StsadmExePath;

            WriteToBackupLog("starting backup, command: stsadm.exe " + si.Arguments);
            Process ret = Process.Start(si);
            ret.WaitForExit();
        }

        internal static string fetchCleanBackupFileName(string siteUrl)
        {
            siteUrl = siteUrl.Replace("http://", "");
            siteUrl = siteUrl.Replace("https://", "https#");
            siteUrl = siteUrl.Replace(":", "}").Replace("/", "#");
            return siteUrl;
        }

        internal static string fetchStsadmCmdArgsForBackup(string url, string backupFilename, bool IsCompress)
        {
            if (!IsCompress)
                return string.Format(@"-o export -url ""{0}"" -filename ""{1}"" -overwrite -cabsize 200 -nofilecompression", url, backupFilename);
            else
                return string.Format(@"-o export -url ""{0}"" -filename ""{1}"" -overwrite -cabsize 200", url, backupFilename);

        }

        #region WriteToLog
        internal static string BackupLogFullFileName
        {
            get { return GlobalVars.LogFilesDir + @"\SUSHIautoBackup.log"; }
        }

        private static void WriteToBackupLog(string msg)
        {
            AutoStartUtil.WriteToLog(BackupLogFullFileName, msg, false);
        }

        private static void WriteErrorToBackupLog(string msg)
        {
            AutoStartUtil.WriteToLog(BackupLogFullFileName, msg, true);
        }
        #endregion

    }
}
