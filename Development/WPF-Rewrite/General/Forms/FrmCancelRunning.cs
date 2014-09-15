using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SUSHI
{
    public partial class FrmCancelRunning : Form
    {
        internal static FrmCancelRunning DefInstance;

        public FrmCancelRunning()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalVars.CancelRunning = true;
            this.btnCancel.Text = "Cancel Pending..";
            this.btnCancel.Enabled = false;
        }

        public static void ShowCancelRunningFormOn2ndThread()
        {
            MethodInvoker mi = new MethodInvoker(ShowCancelRunningForm2);
            mi.BeginInvoke(null, null);
        }

        private static void ShowCancelRunningForm2()
        {
            FrmCancelRunning frmCR = new FrmCancelRunning();
            frmCR.Location = new Point(MainForm.DefInstance.Left + 10, MainForm.DefInstance.Top + 10);
            DefInstance = frmCR;

            DefInstance.ShowDialog();
        }

        private delegate void delC();
        public static void CloseCancelRunningFormSafely()
        {
            if (DefInstance == null)
                return;

            if (DefInstance.InvokeRequired)
            {
                DefInstance.Invoke(new delC(CloseCancelRunningFormSafely));
                return;
            }
           
            DefInstance.Close();
            DefInstance = null;
        }

        private delegate void delTE(bool r);
        public static void ToggleEnabled(bool running)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                MainForm.DefInstance.Invoke(new delTE(ToggleEnabled), running);
                return;
            }

            if (running == true)
            {
                GlobalVars.CancelRunning = false;
                FrmCancelRunning.ShowCancelRunningFormOn2ndThread();
            }
            else
            {
                FrmCancelRunning.CloseCancelRunningFormSafely();
            }
            MainForm.DefInstance.Enabled = !running;
        }

    }
}