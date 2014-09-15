using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;

namespace SUSHI
{
    public partial class FrmAddContnetTypeToDocLib : Form
    {
        public FrmAddContnetTypeToDocLib()
        {
            InitializeComponent();
        }

        SPDocumentLibrary m_docLib;
        public static void ShowForm(SPDocumentLibrary docLib)
        {
            FrmAddContnetTypeToDocLib f = new FrmAddContnetTypeToDocLib();
            f.m_docLib = docLib;

            //--
            SPWeb rootWeb = docLib.ParentWeb.Site.RootWeb;
            foreach (SPContentType ct in rootWeb.ContentTypes)
            {
                if (ct.Parent.Name == "Document" && ct.Group != "_Hidden")
                    f.cboRootContentTypes.Items.Add(new ContentTypeHolder(ct));
            }

            f.Text = "Add Content Type to " + docLib.Title;
            f.lblAvailableCT.Text = "Content Types available to add from " + rootWeb.Url;
            f.Location = new Point(MainForm.DefInstance.Left + 10, MainForm.DefInstance.Top + 10);
            f.ShowDialog();
        }

        public class ContentTypeHolder
        {
            public ContentTypeHolder(SPContentType ct)
            {
                this.CT = ct;
            }

            public SPContentType CT;

            public override string ToString()
            {
                return CT.Group + " - " + CT.Name;
            }
        }

        private void btnAddCt_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: add validate button
                SPContentType newCT = ((ContentTypeHolder)cboRootContentTypes.SelectedItem).CT;
                RichTextBox rtb = ActionMetadata.DefInstance.rtbDisplay;
                rtb.Clear();
                AddToRtbLocal("Adding Content Type to Document Library " + m_docLib.Title + "...\r\n", StyleType.titleSeagreen);

                //--
                if (!m_docLib.ContentTypesEnabled)
                {
                    m_docLib.ContentTypesEnabled = true;
                    m_docLib.Update();
                    AddToRtbLocal("Content Type management enabled for " + m_docLib.Title + "\r\n", StyleType.bodySeaGreen);
                }

                //--
                bool found = false;
                foreach (SPContentType ct in m_docLib.ContentTypes)
                {
                    if (ct.Name == newCT.Name)
                        found = true;
                }
                if (!found)
                {
                    m_docLib.ContentTypes.Add(newCT);
                    AddToRtbLocal("Content Type " + newCT.Name + " added to " + m_docLib.Title + "\r\n", StyleType.bodySeaGreen);
                }
                else
                    AddToRtbLocal("Content Type " + newCT.Name + " was already previously added to " + m_docLib.Title + "\r\n", StyleType.bodyChocolate);

                GlobalVars.SETTINGS.metadata_defaultContentTypeForApplyCT = newCT.Group + " - " + newCT.Name;

                //--
                if (chkChangeAllDocumentsToContentType.Checked)
                {
                    int counter = 0;
                    AddToRtbLocal("Changing all documents in library to new ContentType\r\n",StyleType.bodyBlack);
                    FrmCancelRunning.ToggleEnabled(true);  //ActionMetadata.DefInstance.toggleEnabled(true);
                    for (int i = 0; i <= m_docLib.Items.Count -1; i++)
                    {
                        if (GlobalVars.CancelRunning)
                            throw new Eh.CancelException();

                        SPListItem listitem = m_docLib.Items[i];
                        SPContentTypeId currentContentTypeId = (SPContentTypeId)listitem["ContentTypeId"];
                                                    
                        if (!currentContentTypeId.IsChildOf(newCT.Id))
                        {
                            listitem["ContentTypeId"] = newCT.Id;
                            listitem.Update();
                            counter++;
                            AddToRtbLocal(listitem.File.Name, StyleType.bodySeaGreen);
                            AddToRtbLocal(" ContentType-> " + newCT.Name + "\r\n", StyleType.bodyBlack);
                            SmartStepUtil.ScrollToBottom(rtb);
                            Application.DoEvents();
                        }
                    }
                    AddToRtbLocal("STATS: changed ContentType for " + counter + " documents, " + " total items in library: " + m_docLib.Items.Count + "\r\n", StyleType.bodyDarkGray);
                }

                SmartStepUtil.AddToRTB(rtb, "Done\r\n", Color.Black, 10, true);
                //--
                this.Close();
            }
            catch (Eh.CancelException)
            {
                AddToRtbLocal("canceled by user\r\n", StyleType.bodyBlackBold);
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
            finally
            {
                //ActionMetadata.DefInstance.toggleEnabled(false);
                FrmCancelRunning.ToggleEnabled(false);
            }
        }

        private void cboRootContentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddCt.Enabled = true;
        }

        private void frmAddContnetTypeToDocLib_Load(object sender, EventArgs e)
        {
            int i = cboRootContentTypes.FindStringExact(GlobalVars.SETTINGS.metadata_defaultContentTypeForApplyCT);
            if (i > -1)
                cboRootContentTypes.SelectedIndex = i;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddToRtbLocal(string strText, StyleType style)
        {
            SmartStepUtil.AddToRTB(ActionMetadata.DefInstance.rtbDisplay, strText, style);
        }
    }
}