using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace SUSHI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //--
            //FutureDev: make sure user has sufficient priviledges to open files and run SUSHI.

            //--initialize settings
            SushiSettingsUtil.LoadSushiSettings();

            //--command line args
            parseArgs(args);
            if (GlobalVars.AutoStartBackup)
            {
                AutoBackup.StartBackup();
                return;
            }

            //--windows init stuff
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException); //note: don't want to add this handler when starting from commandline, because we don't want to try and show a message box.
            
            //--Splash screen
            //SplashScreen.Definstance = new SplashScreen();
            //SplashScreen.Definstance.Show();
            //Application.DoEvents();

            //Resolve Assemblies
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                if (e.Name == "Microsoft.SharePoint")
                {
                    if (SharePointUtil.IsSharePoint2007InstalledLocally)
                    {
                        return Assembly.Load("Microsoft.SharePoint, Version=12.0.0.0");
                    }
                    else
                        if (SharePointUtil.IsSharePoint2010InstalledLocally)
                        {
                            return Assembly.Load("Microsoft.SharePoint, Version=14.0.0.0");
                        }
                        else
                            if (SharePointUtil.IsSharePoint2013InstalledLocally)
                            {
                                return Assembly.Load("Microsoft.SharePoint, Version=15.0.0.0");
                            }
                            else throw new Exception("SharePoint is not installed.  You must run SUSHI locally from a machine that has SharePoint installed.");
                }
                else return null;
            };

            //--kick off main Form of SUSHI
            MainForm.DefInstance = new MainForm();
            Application.Run(MainForm.DefInstance);
        }

        #region parseArgs
        private static void parseArgs(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    if (args[0].ToLower() == "-autostart:" + AutoStartUtil.AutoStartMode.Catapult_SharePoint_Autobackup.ToString().ToLower())
                        GlobalVars.AutoStartBackup = true;
                }
            }
            catch (Exception ex)
            {
                Eh.GlobalErrorHandler(ex);
            }
        }
        #endregion

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Eh.GlobalErrorHandler(e.Exception,"Exception");
        }
    }
}