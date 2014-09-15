using System.Windows.Forms;

namespace SUSHI.General
{
    public class LnkBrowseSite :LinkLabel
    {
        TextBox _txtBox;
        RichTextBox _rtb;
        public void InitMeStuff(TextBox txt,RichTextBox rtb)
        {
            this._txtBox = txt;
            this._rtb = rtb;
            this.LinkClicked += new LinkLabelLinkClickedEventHandler(LnkBrowseSite_LinkClicked);
            this.Text = "Browse";
        }

        void LnkBrowseSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.OpenURLinDefaultBrowser(_txtBox.Text, _rtb);
        }



    }
}
