using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Specialized;
using System.Reflection;

namespace SushiNS
{
    internal static class SushiSettingsUtil
    {
        private static string SettingsFilePath;

        static SushiSettingsUtil()
        {
            GlobalVars.LogFilesDir = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Catapult";
            if (!Directory.Exists(GlobalVars.LogFilesDir))
                Directory.CreateDirectory(GlobalVars.LogFilesDir);

            SettingsFilePath = GlobalVars.LogFilesDir + @"\sushi_settings.xml";
        }

        internal static void LoadSushiSettings()
        {
            try
            {
                GlobalVars.SETTINGS = new SushiSettings();

                //--make sure XML file exists wich contains persisted SUSHI Settings
                if (File.Exists(SettingsFilePath))
                {
                    XmlSerializer xs = new XmlSerializer(GlobalVars.SETTINGS.GetType());
                    using (StreamReader sr = new StreamReader(SettingsFilePath))
                    {
                        GlobalVars.SETTINGS = (SushiSettings)xs.Deserialize(sr);
                    }
                }

                Type t = Type.GetType("SushiNS.SushiSettings");

                //-- initialize variables to non-null values
                foreach (FieldInfo fi in t.GetFields())
                {
                    object val = fi.GetValue(GlobalVars.SETTINGS);
                    if (val == null)
                    {
                        if (fi.FieldType.ToString() == "System.String")
                            fi.SetValue(GlobalVars.SETTINGS, string.Empty);
                        else if (fi.FieldType.ToString() == "System.Collections.Specialized.StringCollection")
                            fi.SetValue(GlobalVars.SETTINGS, new StringCollection());
                        else if (fi.FieldType.ToString() == "System.Collections.Generic.List`1[System.String]")
                            fi.SetValue(GlobalVars.SETTINGS, new List<string>());
                    }
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }

        internal static void SaveSushiSettings()
        {
            using (StreamWriter sw = new StreamWriter(SettingsFilePath))
            {
                XmlSerializer xmlSer = new XmlSerializer(GlobalVars.SETTINGS.GetType());
                xmlSer.Serialize(sw, GlobalVars.SETTINGS);
            }
        }
    }
}
