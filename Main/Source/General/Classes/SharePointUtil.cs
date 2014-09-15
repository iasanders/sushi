using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Globalization;

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
                using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\12.0", false))
                {
                    if (regKey != null)
                    {
                        string installStatus = Convert.ToString(regKey.GetValue("SharePoint"), CultureInfo.InvariantCulture);
                        if (!string.IsNullOrEmpty(installStatus) && installStatus.Equals("installed", StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks to see if SharePoint 2010 is Installed Locally.
        /// </summary>
        public static bool IsSharePoint2010InstalledLocally { 
            get
            {
                using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\14.0", false))
                {
                    if (regKey != null)
                    {
                        string installStatus = Convert.ToString(regKey.GetValue("SharePoint"), CultureInfo.InvariantCulture);
                        if (!string.IsNullOrEmpty(installStatus) && installStatus.Equals("installed", StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks to see if SharePoint 2013 is Installed Locally.
        /// </summary>
        public static bool IsSharePoint2013InstalledLocally
        {
            get
            {
                using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\15.0", false))
                {
                    if (regKey != null)
                    {
                        string installStatus = Convert.ToString(regKey.GetValue("SharePoint"), CultureInfo.InvariantCulture);
                        if (!string.IsNullOrEmpty(installStatus) && installStatus.Equals("installed", StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks to see if any instance of SharePoint is Installed Locally
        /// </summary>
        public static bool IsSharePointInstalledLocally
        {
            get
            {
                return (IsSharePoint2007InstalledLocally || IsSharePoint2010InstalledLocally || IsSharePoint2013InstalledLocally);
            }

        }
        #endregion
    }   
}
