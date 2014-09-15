using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;

namespace SushiNS
{
    internal static class ActionCopyViewUtil
    {
        internal static List<FavoriteView> FavoriteViews;

        internal static void LoadFavoriteViews()
        {
            FavoriteViews = new List<FavoriteView>();
            try
            {
                for (int i = 0; i <= GlobalVars.SETTINGS.createViews_viewUrls.Count - 1; i++)
                {
                    FavoriteView fv = new FavoriteView(GlobalVars.SETTINGS.createViews_viewUrls[i], GlobalVars.SETTINGS.createViews_viewWebs[i]);
                    FavoriteViews.Add(fv);
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex, "problem while Loading Favorite Views for 'Copy A View' ");
            }
        }

        internal static void SaveFavoriteViews()
        {
            GlobalVars.SETTINGS.createViews_viewUrls = new List<string>();
            GlobalVars.SETTINGS.createViews_viewWebs = new List<string>();
            foreach(FavoriteView fv in FavoriteViews)
            {
                GlobalVars.SETTINGS.createViews_viewUrls.Add(fv.ViewURL);
                GlobalVars.SETTINGS.createViews_viewWebs.Add(fv.ParentWebURL);
            }
        }

    }
    #region Class Definitions

    [Serializable]
    public class FavoriteView
    {
        public string ViewURL;
        public string ParentWebURL;

        public FavoriteView(string viewURL, string parentWebURL)
        {
            this.ViewURL = viewURL;
            this.ParentWebURL = parentWebURL;
        }

        public override string ToString()
        {
            //return ParentWebURL == "/" ? ViewURL : ParentWebURL + "/" + ViewURL;

            return ParentWebURL + "/" + ViewURL;
        }
    }


    #endregion
}
