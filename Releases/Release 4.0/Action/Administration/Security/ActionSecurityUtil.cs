using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SushiNS.SecurityNs
{

    public class SushiSecurable
    {
        public SushiSecurable()
        {
            this.UorGs = new List<UorG>();
            this.SecurableLists = new List<SushiSecurable>();
        }
        public string Name;
        public string HyperLinkSiteSecurity;
        public List<UorG> UorGs;
        public List<SushiSecurable> SecurableLists;
        public bool AtLeastOnePermission;
        public string ListType;
    }

    public class UorG
    {
        public UorG(string name, bool isADgroup)
        {
            this.Name = name;
            this.RoleNames = new List<string>();
            this.IsADgroup = isADgroup;
        }
        public string Name;
        public List<string> RoleNames;
        public string HyperLinkListSecurity;
        public bool IsADgroup;
    }
}
