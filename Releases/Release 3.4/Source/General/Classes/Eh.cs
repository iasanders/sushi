using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SushiNS
{
    public static class Eh
    {

        public static void GlobalErrorHandler(Exception ex)
        {
            GlobalErrorHandler(ex, ""); 
        } 

        public static void GlobalErrorHandler(Exception ex, string errorDesc)
        {
            string strNL = (errorDesc == "") ? "" : "\r\n\r\n";
            MessageBox.Show(errorDesc + strNL + ex.Message, "SUSHI - Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public class CancelException : ApplicationException
        {
            public CancelException()
                : base()
            {}
        }
    }

}
