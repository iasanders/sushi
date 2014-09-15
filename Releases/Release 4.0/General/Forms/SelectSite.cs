using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace SushiNS.MTV
{
    public partial class SelectSite : Form
    {
        #region Fields, Properties
        private static SelectSite _defInstance;
        public static SelectSite DefInstance
        {
            get
            {
                if (_defInstance == null)
                {
                    SelectSite.InitTree();
                }
                return _defInstance;
            }
        }

        private TextBox _targetTextbox;
        #endregion

        #region Initialize, ShowForm
        public SelectSite()
        {
            InitializeComponent();
        }

        internal void ShowFormGetWebURL(TextBox targetTextbox)
        {
            _targetTextbox = targetTextbox;
            this.Show();
            this.BringToFront();
            //selectDefaultNodeSafely();
        }

        private static void InitTree()
        {
            _defInstance = new SelectSite();
            _defInstance.Location = new Point(MainForm.DefInstance.Left + 250, MainForm.DefInstance.Top + 100);
            //_defInstance.AddToRtbLocal("Loading...", StyleType.titleBlue);
            //_defInstance.isLoading = true;
            
            MethodInvoker mi = new MethodInvoker(_defInstance.InitTree2);
            mi.BeginInvoke(null, null);
        }

        public void InitTree2()
        {
            try
            {
                SPFarm farm = SPFarm.Local;
                foreach (SPService service in farm.Services)
                {
                    if (service is SPWebService && service.Name != "WSS_Administration")
                    {
                        SPWebService ws = (SPWebService)service;
                        foreach (SPWebApplication webApp in ws.WebApplications)
                        {
                            TreeNode nWebapp = new TreeNode(webApp.Name);
                            nWebapp.ImageKey = "subscribe.gif";
                            nWebapp.SelectedImageKey = "subscribe.gif";
                            AddToTreeViewSafely(treeviewMain.Nodes, nWebapp, false);

                            foreach (SPSite siteCol in webApp.Sites)
                            {
                                SPWeb rootWeb = siteCol.RootWeb;
                                TreeNode nSiteCol = new TreeNode(GetTreeNodeTitle(rootWeb));
                                nSiteCol.ImageKey = "LINK.GIF";
                                nSiteCol.SelectedImageKey = "LINK.GIF";
                                nSiteCol.Tag = new SpWebInfoHolder(rootWeb);
                                AddToTreeViewSafely(nWebapp.Nodes, nSiteCol, false);
                                rootWeb.Dispose();
                                siteCol.Dispose();
                            }
                        }
                        break;
                    }
                }

                doneLoadingSafely();
            }
            catch (Exception ex)
            {
                SmartStepUtil.ClearRtbSafely(rtbDisplay);
                AddToRtbLocal("error: " + ex.Message, StyleType.bodyRed);
                SmartStepUtil.ClearPicture(imgLoading);
            }
        }

        private delegate void doneLoadingDel();
        private void doneLoadingSafely()
        {
            if (_defInstance.InvokeRequired)
            {
                _defInstance.Invoke(new doneLoadingDel(doneLoadingSafely));
                return;
            }

            if (rtbDisplay.Text == "Loading...")
                rtbDisplay.Clear();
            imgLoading.Visible = false;
                
        }
        #endregion

       
        private void btnSelect_Click(object sender, EventArgs e)
        {
           
        }
        

        #region find default node
        //private delegate void selectDefaultNodeDelegate();
        //private void selectDefaultNodeSafely()
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new selectDefaultNodeDelegate(selectDefaultNodeSafely));
        //        return;
        //    }

        //    string rememberedTargetUrl = _targetTextbox.Text.Trim().ToUpper();

        //    if (!Uri.IsWellFormedUriString(rememberedTargetUrl, UriKind.Absolute))
        //        return;

        //    string[] urlParts = rememberedTargetUrl.Remove(0, 7).Split(new string[] { "/" }, StringSplitOptions.None);
        //    foreach (TreeNode nodeWebApp in treeviewMain.Nodes)
        //        foreach (TreeNode nodeSiteCol in nodeWebApp.Nodes)
        //        {
        //            NodeTagInfoHolder nti = (NodeTagInfoHolder)nodeSiteCol.Tag;
        //            if (rememberedTargetUrl.StartsWith(nti.ParentSiteCol.Url.ToUpper()))
        //            {
        //                findChildWebNodeInSiteCollection(urlParts, 1, nodeSiteCol);
        //                return;
        //            }
        //        }
        //}

        //private void findChildWebNodeInSiteCollection(string[] urlParts, int urlIndex, TreeNode subjectNode)
        //{
        //    //--loop through each of the urlParts (web url names) of the default URL until the matching treenode is found. (skip the first item which is the absolute URL)
        //    if (subjectNode.Nodes.Count == 0)
        //        AddChildnodes(subjectNode, false);

        //    foreach (TreeNode nChild in subjectNode.Nodes)
        //    {
        //        NodeTagInfoHolder nti = (NodeTagInfoHolder)nChild.Tag;
        //        string s = nti.SiteRelativeUrl.ToUpper().Trim(new char[] { '/' });
        //        if (s == urlParts[urlIndex])
        //        {
        //            //-- if this is the last urlPart, then we have arrived and can select the node.
        //            if (urlIndex == urlParts.Length - 1)
        //            {
        //                treeviewMain.SelectedNode = nChild;
        //                return;
        //            }

        //            findChildWebNodeInSiteCollection(urlParts, urlIndex + 1, nChild);
        //        }
        //    }
        //}
        #endregion

        #region treeviewMain_AfterSelect
        private void treeviewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnSelect.Enabled = false;
            lnkBrowse1.Enabled = false;
            SmartStepUtil.ClearRtbSafely(rtbDisplay);
            if (e.Node.Tag == null)
                return;

            SpWebInfoHolder nti = (SpWebInfoHolder)e.Node.Tag;
            btnSelect.Enabled = true;
            lnkBrowse1.Enabled = true;

            AddToRtbLocal(nti.AbsoluteUrl, StyleType.bodyBlueBold);
            AddChildNodesAsync(e.Node, true);
        }
        #endregion

        #region AddChildNodes
        private delegate void DelegateAdd(TreeNode v1, bool v2);
        private void AddChildNodesAsync(TreeNode n, bool pleasePopulateGrandKids)
        {
            DelegateAdd a = new DelegateAdd(AddChildnodes);
            a.BeginInvoke(n, pleasePopulateGrandKids, null, null);
        }

        private void AddChildnodes(TreeNode nSubject, bool pleasePopulateGrandKids)
        {
            if (nSubject.Tag == null)
                return;
            SpWebInfoHolder ntiParent = (SpWebInfoHolder)nSubject.Tag;

            try
            {
                //-- populate subwebs
                using (SPWeb webSubject = ntiParent.ParentSiteCol.OpenWeb(ntiParent.GuidId))
                {
                    foreach (SPWeb webChild in webSubject.Webs)
                    {
                        TreeNode n = new TreeNode(GetTreeNodeTitle(webChild));
                        n.ImageKey = "LINK.GIF";
                        n.SelectedImageKey = "LINK.GIF";
                        n.Tag = new SpWebInfoHolder(webChild);

                        AddToTreeViewSafely(nSubject.Nodes, n, true);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (Exception ex)
            {
                AddToRtbLocal("Unable to open web '" + ntiParent.AbsoluteUrl + "' " + ex.Message + "\r\n", StyleType.bodyRed);
            }

            if (pleasePopulateGrandKids)
            {
                foreach (TreeNode nChild in nSubject.Nodes)
                    AddChildnodes(nChild, false);
            }
        }

        private string GetTreeNodeTitle(SPWeb web)
        {
            string name = web.Name;
            string title = web.Title;
            name = name.Trim().Replace(" ", "").ToUpper();
            if (name == "") name = "/";
            if (name != title.Trim().Replace(" ", "").ToUpper())
                return name + " (" + title + ")";
            else
                return name;
        }

        private delegate void DelegateA(TreeNodeCollection ncParent, TreeNode nChild, bool checkIfNodeAlreadyExists);
        public void AddToTreeViewSafely(TreeNodeCollection ncParent, TreeNode nchild, bool checkIfAlreadyHasChildNode)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                DelegateA dA = new DelegateA(AddToTreeViewSafely);
                MainForm.DefInstance.Invoke(dA, new object[] { ncParent, nchild, checkIfAlreadyHasChildNode });
                return;
            }

            if (checkIfAlreadyHasChildNode)
                foreach (TreeNode n in ncParent)
                    if (n.Text == nchild.Text)
                        return;

            ncParent.Add(nchild);
        }
        #endregion

        #region Define Class NodeTagRefHolder
        public class SpWebInfoHolder
        {
            public SPSite ParentSiteCol;
            public Guid GuidId;
            public string AbsoluteUrl;
            public string SiteRelativeUrl;
            public string SiteTitle;

            public SpWebInfoHolder(SPWeb web)
            {
                this.ParentSiteCol = web.Site;
                this.GuidId = web.ID;
                this.AbsoluteUrl = web.Url;
                this.SiteRelativeUrl = web.Name;
                this.SiteTitle = web.Title;
            }
        }

        #endregion

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(rtbDisplay, strText, style);
        }
        
        #region lnkBrowse_LinkClicked
        private void lnkBrowse_Click(object sender, EventArgs e)
        {
            if (rtbDisplay.Text.ToLower().StartsWith("http"))
            {
                Util.OpenURLinDefaultBrowser(rtbDisplay.Text, rtbDisplay);
            }
        }
        #endregion
         #region btnSelect
        private void imgSelect_Click(object sender, EventArgs e)
        {
            SpWebInfoHolder nti = (SpWebInfoHolder)treeviewMain.SelectedNode.Tag;

            _targetTextbox.Text = nti.AbsoluteUrl;
            this.Hide();
        }
         #endregion
        #region Keep Code
        //private TreeNode NewNodeWithTag(string title, NodeTagInfoHolder.SpClassTypeEnum spClassType, Guid guidId, SPSite parentSiteCol, string serverRelativeUrl, string siteRelativeUrl,SPWeb nodeWeb)
        //{
        //    //string imageKey = "";
        //    //switch (spClassType)
        //    //{
        //    //    case NodeTagInfoHolder.SpClassTypeEnum.SPWebApp:
        //    //        imageKey = "subscribe.gif";
        //    //        break;
        //    //    case NodeTagInfoHolder.SpClassTypeEnum.SPWeb:
        //    //        imageKey = "LINK.GIF";
        //    //        break;
        //    //    case NodeTagInfoHolder.SpClassTypeEnum.SPList:
        //    //        imageKey = "ITGEN.GIF";
        //    //        break;
        //    //}

        //    NodeTagInfoHolder nti = new NodeTagInfoHolder(nodeWeb);

        //    //--
        //    TreeNode n = new TreeNode(title);
        //    n.ImageKey = imageKey;
        //    n.SelectedImageKey = imageKey;
        //    n.Tag = nti;
        //    return n;
        //}


        //--Validate
        //if (treeviewMain.SelectedNode == null)
        //{
        //    AddToRtbLocal("No Site Selected.", StyleType.bodyRed);
        //    return;
        //}


        //private void btnAddSite_Click(object sender, EventArgs e)
        //{
        //    SPWeb web =  MainTreeview_AddSite.ShowForm();
        //    if (web == null)
        //        return;

        //    treeviewMain.Nodes.Clear();

        //    TreeNode n = new TreeNode(web.Title + " - " + web.Url);
        //    n.Tag = new TVNodeWeb(web.RootFolder.ServerRelativeUrl);
        //    treeviewMain.Nodes.Add(n);
        //}

        //#region NewTreeNodes
        //public TreeNode NewTreeNodeWeb(SPWeb web)
        //{
        //    TreeNode n = new TreeNode(WebNodeTitle(web));
        //    n.Tag = new TVNodeWeb(web.RootFolder.ServerRelativeUrl);
        //    n.ImageIndex = 0;
        //    return n;
        //}

        //public TreeNode NewTreeNode(string title,object refObj)
        //{
        //    TreeNode n = new TreeNode(title);
        //    n.Tag = refObj;

        //    switch (refObj.GetType().Name)
        //    {
        //        case "SPSite":
        //            n.ImageIndex = 1;
        //            n.SelectedImageIndex = 1;
        //            break;
        //        case "SPWeb":
        //            n.ImageIndex = 1;
        //            n.SelectedImageIndex = 1;
        //            break;
        //        case "SPDocumentLibrary":
        //            n.ImageIndex = 1;
        //            n.SelectedImageIndex = 1;
        //            break;
        //        case "SPList":
        //            n.ImageIndex = 2;
        //            n.SelectedImageIndex = 2;
        //            break;
        //        case "":
        //            n.ImageIndex = 3;
        //            n.SelectedImageIndex = 3;
        //            break;
        //        case "1":
        //            n.ImageIndex = 4;
        //            n.SelectedImageIndex = 4;
        //            break;
        //        case "2":
        //            n.ImageIndex = 5;
        //            n.SelectedImageIndex = 5;
        //            break;
        //        case "3":
        //            n.ImageIndex = 6;
        //            n.SelectedImageIndex = 6;
        //            break;
        //        case "SPPictureLibrary":
        //            n.ImageIndex = 7;
        //            n.SelectedImageIndex = 7;
        //            break;
        //        default:
        //            n.ImageIndex = 6;
        //            n.SelectedImageIndex = 6;
        //            break;
        //    }
        //    return n;
        //}
        //#endregion


        //partial class MainTreeView
        //    {
        //        //public class NodeTagRefHolder
        //        //{
        //        //    public SPClassType SpClassType;
        //        //    public object RefInstance;
        //        //    //public Guid Id;

        //        //    public NodeTagRefHolder(SPClassType spClassType, object refInstance, Guid id)
        //        //    {
        //        //        this.SpClassType = spClassType;
        //        //        this.RefInstance = refInstance;
        //        //        this.Id = id;
        //        //    }
        //        //}

        //        //public static TreeNode CreateTreeNode(string title, SPClassType typeName, object refInstance, Guid id)
        //        //{
        //        //    TreeNode n = new TreeNode(title);
        //        //    n.Tag = new NodeTagRefHolder(typeName, refInstance,id);
        //        //    return n;
        //        //}

        //        private static SPSite _siteCollectionRef;
        //        public static SPWeb GetWebInstanceFromURLstring(string webURL)
        //        {
        //            if (_siteCollectionRef == null)
        //            {
        //                if (GlobalVars.SETTINGS.mainTreeView_rootTreeNodeUrl == "")
        //                    return null;
        //                _siteCollectionRef = new SPSite(GlobalVars.SETTINGS.mainTreeView_rootTreeNodeUrl);
        //            }
        //            if (string.IsNullOrEmpty(webURL))
        //                return null;

        //            SPWeb web;
        //            try
        //            {
        //                web = _siteCollectionRef.OpenWeb(webURL);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(MainForm.DefInstance, "Unable to connect to default SharePoint site \"" + webURL + "\" " + ex.Message, "SUSHI", MessageBoxButtons.OK);
        //                return null;
        //            }

        //            return web;
        //        }
        //    }
        //}



        #endregion
    }
}
