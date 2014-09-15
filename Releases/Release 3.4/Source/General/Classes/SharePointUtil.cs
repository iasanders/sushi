using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;

namespace SushiNS
{
    public static class SharePointUtil
    {
        public static bool SiteContainsFieldByInternalName(SPWeb web, string internalName)
        {
            foreach (SPField field in web.Fields)
                if (field.InternalName == internalName)
                    return true;

            return false;
        }

        public static bool SiteContainsFieldByDisplayName(SPWeb web, string displayName)
        {
            foreach (SPField field in web.Fields)
                if (field.Title == displayName)
                    return true;

            return false;
        }

        private static char isSharePointInstalledLocally;
        public static bool IsSharePointInstalledLocally
        {
            get
            {
                if (isSharePointInstalledLocally == char.MinValue)
                {
                    if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\Microsoft Shared\web server extensions\12\ISAPI\Microsoft.SharePoint.dll"))
                        isSharePointInstalledLocally = 'y';
                    else
                        isSharePointInstalledLocally = 'n';
                }
                return isSharePointInstalledLocally == 'y';
            }
        }

    }
}
