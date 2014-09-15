using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SUSHI.General
{
    public class LnkSelectASite : LinkLabel
    {
        private TextBox _txtTargetSite;

        public LnkSelectASite()
            :base()
        {
            this.Text = "Select A Site";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSelectASite_LinkClicked);
        }

        public void InitMeStuff(TextBox txtTargetSite)
        {
            this._txtTargetSite = txtTargetSite;
        }

        void lnkSelectASite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_txtTargetSite == null)
            {
                foreach (Control c in this.Parent.Controls)
                    if (c.GetType() == typeof(TextBox) && c.Name == "txtTargetSite")
                    {
                        _txtTargetSite = (TextBox)c;
                        break;
                    }
            }

            MTV.SelectSite.DefInstance.ShowFormGetWebURL(_txtTargetSite);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}
