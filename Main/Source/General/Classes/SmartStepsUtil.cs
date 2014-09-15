using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SUSHI
{
    public enum StyleType
    {
        bodyBlack,
        bodyBlackBold,
        bodyBlue,
        bodyBlueBold,
        bodyChocolate,
        bodyChocolateBold,
        bodyDarkGray,
        bodyMidnightBlue,
        bodyOrange,
        bodyPurple,
        bodyRed,
        bodySeaGreen,
        bodySeaGreenBold,
        titleChocolate,
        titleSeagreen,
        titleBlue,
        titleBlack
    }

    public static class SmartStepUtil
    {
        public static void AddToRTB(RichTextBox rtb, string strText, StyleType style)
        {
            AddToRTB(rtb, strText, style, enumIcon.no_icon);
        }

        public static void AddToRTB(RichTextBox rtb, string strText, StyleType style, enumIcon icon)
        {
            switch (style)
            {
                case StyleType.bodyBlack:
                    AddToRTB(rtb, strText, Color.Black, 8, false, icon);
                    break;
                case StyleType.bodyBlackBold:
                    AddToRTB(rtb, strText, Color.Black, 8, true, icon);
                    break;
                case StyleType.bodyBlue:
                    AddToRTB(rtb, strText, Color.Blue, 8, false, icon);
                    break;
                case StyleType.bodyBlueBold:
                    AddToRTB(rtb, strText, Color.Blue, 8, true, icon);
                    break;
                case StyleType.bodyChocolate:
                    AddToRTB(rtb, strText, Color.Chocolate, 8, false, icon);
                    break;
                case StyleType.bodyChocolateBold:
                    AddToRTB(rtb, strText, Color.Chocolate, 8, true, icon);
                    break;
                case StyleType.bodyDarkGray:
                    AddToRTB(rtb, strText, Color.DarkGray, 8, false, icon);
                    break;
                case StyleType.bodyMidnightBlue:
                    AddToRTB(rtb, strText, Color.MidnightBlue, 8, false, icon);
                    break;
                case StyleType.bodyOrange:
                    AddToRTB(rtb, strText, Color.Orange, 8, false, icon);
                    break;
                case StyleType.bodyPurple:
                    AddToRTB(rtb, strText, Color.Purple, 8, false, icon);
                    break;
                case StyleType.bodyRed:
                    AddToRTB(rtb, strText, Color.Red, 8, false, icon);
                    break;
                case StyleType.bodySeaGreen:
                    AddToRTB(rtb, strText, Color.SeaGreen, 8, false, icon);
                    break;
                case StyleType.bodySeaGreenBold:
                    AddToRTB(rtb, strText, Color.SeaGreen, 8, true, icon);
                    break;
                case StyleType.titleBlack:
                    AddToRTB(rtb, strText, Color.Black, 14, true, icon);
                    break;
                case StyleType.titleBlue:
                    AddToRTB(rtb, strText, Color.Blue, 14, true, icon);
                    break;
                case StyleType.titleChocolate:
                    AddToRTB(rtb, strText, Color.Chocolate, 14, true, icon);
                    break;
                case StyleType.titleSeagreen:
                    AddToRTB(rtb, strText, Color.SeaGreen, 14, true, icon);
                    break;
                default:
                    AddToRTB(rtb, strText, Color.Black, 8, false, icon);
                    break;
            }
        }

        public static void AddToRTB(RichTextBox rtb,string strText)
        {
            AddToRTB(rtb,strText, Color.Black, 8, false, enumIcon.no_icon);
        }

        public static void AddToRTB(RichTextBox rtb,string strText, Color textColor, float fontSize, bool bold)
        {
            AddToRTB(rtb,strText, textColor, fontSize, bold, enumIcon.no_icon);
        }

        public static void AddToRTB(RichTextBox rtb, Exception ex)
        {
            AddToRTB(rtb, ex.Message, StyleType.bodyRed, enumIcon.no_icon);
        }

        private delegate void delA(RichTextBox a,string b,Color c,float d,bool e,enumIcon f);
        public static void AddToRTB(RichTextBox rtb,string strText, Color textColor, float fontSize, bool bold, enumIcon icon)
        {
            if(rtb.InvokeRequired)
            {
                rtb.BeginInvoke(new delA(AddToRTB), new object[] { rtb, strText, textColor, fontSize, bold, icon });
                return;
            }
            FontStyle style1 = bold ? FontStyle.Bold : FontStyle.Regular;
            if (fontSize <= 0)
                fontSize = 8;
            Font font1 = new Font("Courier New", fontSize, style1, GraphicsUnit.Point, 0);
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionFont = font1;
            rtb.SelectionColor = textColor;
            rtb.SelectedText = strText;
            addIconToRtb(rtb,icon);
        }

        private delegate void delB(RichTextBox v1);
        public static void ScrollToBottom(RichTextBox rtb)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                MainForm.DefInstance.BeginInvoke(new delB(ScrollToBottom), new object[] { rtb });
                return;
            }
            rtb.Focus();
            rtb.Select(rtb.Text.Length , 0);
            rtb.ScrollToCaret();
        }

        private delegate void delRTB(RichTextBox rtb);
        public static void ClearRtbSafely(RichTextBox rtb)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                MainForm.DefInstance.BeginInvoke(new delRTB(ClearRtbSafely), new object[] { rtb });
                return;
            }
            rtb.Clear();
        }

        private delegate void delImg(PictureBox pic);
        public static void ClearPicture(PictureBox pic)
        {
            if (MainForm.DefInstance.InvokeRequired)
            {
                MainForm.DefInstance.BeginInvoke(new delImg(ClearPicture), new object[] { pic });
                return;
            }
            pic.Visible = false;
        }

        private static void addIconToRtb(RichTextBox rtb,enumIcon icon)
        {

            if (icon != enumIcon.no_icon)
            {
                Font font1 = new Font("Wingdings", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                rtb.SelectionStart = rtb.TextLength;
                rtb.SelectionFont = font1;
                switch (icon)
                {
                    case enumIcon.brown_arrow:
                        rtb.SelectionColor = Color.Brown;
                        rtb.SelectedText = asciiToString(182);
                        break;
                    case enumIcon.green_check:
                        rtb.SelectionColor = Color.Green;
                        rtb.SelectedText = asciiToString(252);
                        break;
                    case enumIcon.orange_dotdotdot:
                        rtb.SelectionColor = Color.Orange;
                        rtb.SelectedText = asciiToString(160) + asciiToString(160) + asciiToString(160);
                        break;
                    case enumIcon.red_x:
                        rtb.SelectionColor = Color.Red;
                        rtb.SelectedText = asciiToString(251);
                        break;
                }
            }
        }

        private static string asciiToString(int asciiCode)
        {
            return ((char)asciiCode).ToString();
        }

        public enum enumIcon
        {
            brown_arrow,
            green_check,
            no_icon,
            orange_dotdotdot,
            red_x
        }

    }
}
