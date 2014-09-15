using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace SUSHI
{
    public static class AutoCache
    {
        internal static void StartCache()
        {
            try
            {
                WriteToCacheLog("----------STARTING SITE CACHE " + DateTime.Now.ToString());

                if (GlobalVars.SETTINGS.cache_sitesToCache.Count == 0)
                    WriteToCacheLog("Unable to cache sites because list of sites to cache is empty.");

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                foreach(string url in GlobalVars.SETTINGS.cache_sitesToCache)
                {
                    WriteToCacheLog("Caching site " + url);
                    WebRequest wr = WebRequest.Create(url);
                    wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    try
                    {
                        System.Net.HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
                        WriteToCacheLog("  response length:" + response.ContentLength);
                    }
                    catch (Exception ex)
                    {
                        WriteToCacheLog("Error while retrieving site '" + url + "' error message: " + ex.Message);
                    }
                    
                }

                WriteToCacheLog("CACHING COMPLETE, caching duration was: " + sw.Elapsed.ToString() + "\r\n");
            }
            catch (Exception ex)
            {
                WriteErrorToCacheLog(ex.ToString());
            }
        }


        #region WriteToLog
        internal static string CacheLogFullFileName
        {
            get { return GlobalVars.LogFilesDir + @"\SUSHIautocache.log"; }
        }

        private static void WriteToCacheLog(string msg)
        {
            AutoStartUtil.WriteToLog(CacheLogFullFileName, msg, false);
        }

        private static void WriteErrorToCacheLog(string msg)
        {
            AutoStartUtil.WriteToLog(CacheLogFullFileName, msg, true);
        }
        #endregion

    }
}
