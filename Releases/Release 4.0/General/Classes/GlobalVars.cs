using System;
using System.Collections.Generic;
using System.Text;

namespace SushiNS
{
    public static class GlobalVars
    {
        public static string MyAppVersion;
        public static bool AutoStartBackup;
        public static bool CancelRunning;

        public static string LogFilesDir;
        private static SushiSettings settings;
        public static SushiSettings SETTINGS
        {
            get { return settings; }
            set { settings = value; }
        }

        public static string StsadmExePath
        {
            get { return "\"" + Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\Microsoft Shared\web server extensions\12\bin\stsadm.exe"""; } //Test:
        }

        public const string MsgTitle = "SharePoint SUSHI";
    }
}
