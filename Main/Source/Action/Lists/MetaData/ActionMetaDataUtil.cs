using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;

namespace SUSHI
{
    internal static class ActionMetaDataUtil
    {
        internal static List<MappingProfile> MappingProfiles;

        internal static void LoadMappingProfilesFromXml()
        {
            MappingProfiles = new List<MappingProfile>();
            try
            {
                if (GlobalVars.SETTINGS.metadata_MappingProfiles == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.AppendChild(doc.CreateElement("root"));
                    GlobalVars.SETTINGS.metadata_MappingProfiles = doc;
                }  

                foreach (XmlElement xNode in GlobalVars.SETTINGS.metadata_MappingProfiles.DocumentElement.ChildNodes)
                {
                    string name = xNode.Attributes["ProfileName"].InnerText;
                    string targetContentTypeName = xNode.Attributes["TargetContentTypeName"].InnerText;
                    MappingProfile mp = new MappingProfile(name, targetContentTypeName);
                    mp.MappingItems = new List<MappingItem>();
                    foreach (XmlElement x2 in xNode.ChildNodes)
                    {
                        MappingItem mi = new MappingItem(x2.Attributes["SourceColumn"].InnerText, x2.Attributes["DestColumn"].InnerText);
                        mp.MappingItems.Add(mi);
                    }
                    mp.MappingItems.Sort();
                    MappingProfiles.Add(mp);
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }

        internal static void SaveMappingProfileToXml()
        {
            try
            {
                XmlDocument doc = new System.Xml.XmlDocument();
                doc.AppendChild(doc.CreateElement("root"));
                foreach (MappingProfile mp in MappingProfiles)
                {
                    XmlElement xMP = doc.CreateElement("MappingProfile");
                    doc.DocumentElement.AppendChild(xMP);
                    xMP.Attributes.Append(Util.MakeAttribute(doc, "ProfileName", mp.ProfileName));
                    xMP.Attributes.Append(Util.MakeAttribute(doc, "TargetContentTypeName", mp.TargetContentTypeName));
                    foreach (MappingItem mi in mp.MappingItems)
                    {
                        XmlElement xMI = doc.CreateElement("MappingItem");
                        xMP.AppendChild(xMI);
                        xMI.Attributes.Append(Util.MakeAttribute(doc, "SourceColumn", mi.SourceColumn));
                        xMI.Attributes.Append(Util.MakeAttribute(doc, "DestColumn", mi.DestColumn));
                    }
                }
                GlobalVars.SETTINGS.metadata_MappingProfiles = doc;
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }
    }

    #region Class Definitions
    [Serializable]
    public class MappingProfile
    {
        public MappingProfile(string name, string targetContentTypeName)
        {
            this.ProfileName = name;
            this.TargetContentTypeName = targetContentTypeName;
        }

        public string ProfileName;
        public string TargetContentTypeName;
        public List<MappingItem> MappingItems;

        public override string ToString()
        {
            return ProfileName;
        }
    }

    [Serializable]
    public class MappingItem : IComparable<MappingItem>
    {
        public MappingItem(string sourceColumn, string destColumn)
        {
            this.SourceColumn = sourceColumn;
            this.DestColumn = destColumn;
        }
        public string SourceColumn;
        public string DestColumn;
        public Guid sourceID; //--note, this is not persisted in Settings file, this is just a working field
        public Guid destID; //-- note, this is not persisted in Settings file, this is just a working field
        public string sourceTypeAsString;
        public string destTypeAsString;

        public override string ToString()
        {
            return SourceColumn + " -> " + DestColumn;
        }

        public int CompareTo(MappingItem other)
        {
            return string.Compare(this.ToString(), other.ToString());
        }
    }

    public class FieldAndContentType
    {
        public FieldAndContentType(SPField field, SPContentType contentType)
        {
            this.ContentType = contentType;
            this.Field = field;
        }

        public SPContentType ContentType;
        public SPField Field;

        public override string ToString()
        {
            return Field.Title + " (" + Field.InternalName + ") [" + ContentType.Name + "]";
        }
    }
    #endregion
}
