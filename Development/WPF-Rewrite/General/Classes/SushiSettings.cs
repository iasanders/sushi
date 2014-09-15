using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Xml;


namespace SUSHI
{

    public class SushiSettings
    {
        public bool backup_includeSubsites;
        public string backup_backupFilesPath;
        public string bulkListCreate_siteUrl;
        public string bulkListCreate_siteTemplate;
        public string bulkSiteCreate_siteUrl;
        public string bulkSiteCreate_siteTemplate;
        public bool bulkSiteCreate_onlyCustomTemplates;
        public string bulkWebPartCreate_siteUrl;
        public string bulkWebPartCustomization_defaultProfile;
        public StringCollection backup_siteURLcollection;
        public string contentTypes_siteUrl;
        public StringCollection cache_sitesToCache;
        public string createViews_siteUrl;
        public string createViews_siteUrl_forAddFavoriteView;
        public List<string> createViews_viewUrls;
        public List<string> createViews_viewWebs;
        public string createViews_defaultFavoriteView;
        public string delete_archiveDate;
        public string delete_archiveDestFolder;
        //public string delete_archiveOldFolder;
        //public StringCollection delete_checkedDocumentLibraries;
        public string delete_Sharepointsite;
        public string delete_doListFilenames;
        public StringCollection general_AllSitesList;                    
        public string general_appVersionForUpgradeSettings;
        public string general_lastOpenTreenode;
        public string errors_targetSite;
        public string errors_errorsNotFound_targetSite;
        public string errors_errorsNotFound_defaultLocalErrorFile;
        public bool errors_errorsNotFound_checkedShowHyperlink;
        public string metadata_siteURL;
        public int metadata_selectedTab;
        public XmlDocument metadata_MappingProfiles;
        public string metadata_defaultContentTypeForApplyCT;
        public string profilePics_domainName;
        public string profilePics_sourceDir;
        public string profilePics_targetPictureLibary;
        public string profilePics_targetSharepointSite;
        public string renameList_siteUrl;
        public bool restore_includeUserSecurity;
        public string settings_testEmailFrom;
        public string settings_testEmailSMTP;
        public string security_siteURL;
        public string security_optWhichReport;
        public string theme_siteURL;
        public string theme_defaultTheme;
        public string theme_ApplyToChildSitesOption;
        public string upload_createRootFolder;
        public string upload_fileExtentionsToExclude;
        public string upload_localSourceDir;
        public string upload_targetDocLib;
        public string upload_targetSharepointSite;
        public string miscUtil_siteUrl;

    }
}
