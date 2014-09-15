using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SushiNS
{
    public partial class ActionParent : UserControl
    {
        public ActionParent()
        {
            HelpKey = "HOME";
            InitializeComponent();
        }

        public virtual void ActionFormActivate()
        {
        }

        #region Properties
        public Image PictureboxImage {get;set;}

        public string HelpKey { get; set; }

        //private bool _requiresSharePointAPI = true;
        //public bool RequiresSharePointAPI
        //{
        //    get { return _requiresSharePointAPI; }
        //    set { _requiresSharePointAPI = value; }
        //} 
        #endregion


        protected bool DisableIfSharePointNotInstalledLocally()
        {
            if (!SharePointUtil.IsSharePointInstalledLocally ) //&& !Environment.UserName.EndsWith("iger"))
            {
                this.Enabled = false;
                return true;
            }
            return false;
        }
    }
}
