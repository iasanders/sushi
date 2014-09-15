using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SUSHI
{
    public static class AutoStartUtil
    {
        #region WriteToLog
        internal static void WriteToLog(string logFile, string msg, bool isError)
        {
            string strError = isError ? "ERROR: " : "";

            using (StreamWriter sw = new StreamWriter(logFile,  true))
            {
                sw.WriteLine(strError + msg);
                sw.Flush();
            }
        }
        #endregion

        public enum AutoStartMode
        {
            none,
            Catapult_SharePoint_Autobackup,
            Catapult_SharePoint_Cache 
        }
    }
}
