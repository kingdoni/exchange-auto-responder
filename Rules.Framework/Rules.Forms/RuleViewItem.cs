// Copyright 2007 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;

namespace Rules.Framework.Rules.Forms
{

    public class RuleViewItem : ListViewItem
    {
        #region static ListView extentsion methods
        public static void Prepare(ListView listView)
        {
            listView.OwnerDraw = true;
            listView.DrawSubItem += new DrawListViewSubItemEventHandler(listView_DrawSubItem);
            listView.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listView_DrawColumnHeader);
        }

        static void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        static void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (e.Item is RuleViewItem)
            {
                RuleViewItem rvi = (RuleViewItem)e.Item;                
                Brush bgBrush = rvi.Selected ? SystemBrushes.Highlight : SystemBrushes.HighlightText;
                e.Graphics.FillRectangle(bgBrush, e.Bounds);

                Color backColor = rvi.Selected ? SystemColors.Highlight : SystemColors.HighlightText;
                Color linkColor = rvi.Selected ? SystemColors.HighlightText : SystemColors.Highlight;
                Color foreColor = rvi.Selected ? SystemColors.HighlightText : SystemColors.WindowText;
                //rvi.Label.BackColor = Color.Yellow;
                
                //rvi.label.PaintLabel(e.Graphics, foreColor, backColor, linkColor, new Rectangle(e.Bounds.X + 23, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

                PaintLinkLabel(e.Graphics, rvi.label.Text, rvi.label.LinkArea, rvi.label.Font, foreColor, backColor, linkColor, new Rectangle(e.Bounds.X + 23, e.Bounds.Y, e.Bounds.Width-23, e.Bounds.Height));
                
                if (rvi.Checked)
                    ControlPaint.DrawCheckBox(e.Graphics, 5, e.Bounds.Top+1, 15, 15, ButtonState.Flat | ButtonState.Checked);
                else
                    ControlPaint.DrawCheckBox(e.Graphics, 5, e.Bounds.Top+1, 15, 15, ButtonState.Flat);

                if (rvi.Focused && listView.Focused)
                    ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
            }
            else
                e.DrawDefault = true;

        }

        static void listView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        #endregion static ListView extentsion methods

        #region RuleViewItem implementation
        public RuleViewItem()
            : this(new LinkLabel())
        {
        }

        public RuleViewItem(LinkLabel label)
        {
            this.label = label;
            this.label.TextAlign = ContentAlignment.MiddleLeft;
            this.label.AutoSize = true;
        }

        private LinkLabel label;
        public LinkLabel Label
        {
            get { return label; }
        }



        protected void PaintLabel(Graphics g, Rectangle bounds)
        {
            Bitmap bm = new Bitmap(bounds.Width, bounds.Height);
            Label.DrawToBitmap(bm, bounds);
            g.DrawImage(bm, bounds);
            bm.Dispose();
        }

        #endregion RuleViewItem implementation

        #region helper functions
        private static void PaintLinkLabel(Graphics g, string text, LinkArea linkArea, Font font, Color foreColor, Color backColor, Color linkColor, Rectangle bounds)
        {
            Rectangle textBounds = bounds;

            Brush bgBr = new SolidBrush(backColor);
            Brush frBr = new SolidBrush(foreColor);
            Brush lkBr = new SolidBrush(linkColor);
            
            StringFormat format = new StringFormat(StringFormatFlags.NoFontFallback);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            g.FillRectangle(bgBr, bounds);

            string text1 = text.Substring(0, linkArea.Start);
            string text2 = text.Substring(linkArea.Start, linkArea.Length);
            string text3 = text.Substring(linkArea.Start + linkArea.Length);

            g.DrawString(text1, font, frBr, textBounds, format);
            textBounds.X += MeasureDisplayStringWidth(g, text1, font);
            //SizeF size = g.MeasureString(text1, font, 0, format);
            //textBounds.X += (int)size.Width;

            Font lkFont = new Font(font, FontStyle.Underline);
            g.DrawString(text2, lkFont, lkBr, textBounds, format);
            textBounds.X += MeasureDisplayStringWidth(g, text2, lkFont);
            //size = g.MeasureString(text2, lkFont, 1000, format);
            //textBounds.X += (int)size.Width;

            g.DrawString(text3, font, frBr, textBounds, format);

            lkFont.Dispose();
            bgBr.Dispose();
            frBr.Dispose();
            lkBr.Dispose();
        }

        /// <summary>
        /// this function actually works better then the MeasureString method of the graphics object
        /// see: http://www.codeproject.com/cs/media/measurestring.asp by Pierre Arnaud.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        private static int MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
        {
            System.Drawing.StringFormat format  = new System.Drawing.StringFormat ();
            System.Drawing.RectangleF   rect    = new System.Drawing.RectangleF(0, 0, 1000, 1000);
            System.Drawing.CharacterRange[] ranges  = 
                                               { new System.Drawing.CharacterRange(0, text.Length) };

            System.Drawing.Region[]         regions = new System.Drawing.Region[1];
            format.SetMeasurableCharacterRanges (ranges);

            regions = graphics.MeasureCharacterRanges (text, font, rect, format);
            rect    = regions[0].GetBounds (graphics);

            return (int)(rect.Right + 1.0f);
        }        
        #endregion
    }
}
