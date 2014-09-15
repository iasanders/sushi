using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace SUSHI
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

        /// <summary>
        /// Gets the Central Administration Web Application object.
        /// </summary>
        /// <returns></returns>
        public static SPWebApplication GetCentralAdminWebApplication()
        {
            SPFarm farm = SPFarm.Local;
            foreach (SPService service in farm.Services)
            {
                if (service is SPWebService && service.Name == "WSS_Administration")
                {
                    SPWebService ws = (SPWebService)service;
                    foreach (SPWebApplication webApp in ws.WebApplications)
                        return webApp;
                }
            }
            return null;
        }

        #region Is SharePoint installed?
        /// <summary>
        /// Checks to see if SharePoint 2007 is Installed Locally
        /// </summary>
        public static bool IsSharePoint2007InstalledLocally {
            get
            {
                return System.IO.File.Exists(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) +
                    @"\Microsoft Shared\web server extensions\12\ISAPI\Microsoft.SharePoint.dll");

            }
        }

        /// <summary>
        /// Checks to see if SharePoint 2010 is Installed Locally.
        /// </summary>
        public static bool IsSharePoint2010InstalledLocally { 
            get
            {
                return(System.IO.File.Exists(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + 
                    @"\Microsoft Shared\web server extensions\14\ISAPI\Microsoft.SharePoint.dll"));
            }
        }

        /// <summary>
        /// Checks to see if any instance of SharePoint is Installed Locally
        /// </summary>
        public static bool IsSharePointInstalledLocally
        {
            get
            {
                return (IsSharePoint2007InstalledLocally || IsSharePoint2010InstalledLocally);
            }

        }
        #endregion
    }   
}
