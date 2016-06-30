using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GEAA_Config.Editors
{
    public partial class CheckListForm : Form
    {
        public object Selected => Enum.Parse(_elemenType, radioListBoxItems.SelectedItem.ToString());
        private readonly Type _elemenType;

        public CheckListForm(Type elemenType,Object value)
        {
            _elemenType = elemenType;
            InitializeComponent();
            string[] eltArray = Enum.GetNames(elemenType);
            radioListBoxItems.Items.AddRange(eltArray);
            if (value != null)
                radioListBoxItems.SelectedItem = value.ToString();
        }



        private void checkedListBoxElements_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            
        }

        //private void checkedListBoxElements_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    buttonOK.Enabled = checkedListBoxElements.CheckedIndices.Count==0 && e.NewValue == CheckState.Checked;
        //}

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = radioListBoxItems.SelectedItems.Count == 1;
        }
    }
    public class RadioListBox : ListBox
    {
        private StringFormat Align;
        private bool IsTransparent = false;
        private Brush BackBrush;

        // Allows the BackColor to be transparent
        public override Color BackColor
        {
            get
            {
                if (IsTransparent)
                    return Color.Transparent;
                else
                    return base.BackColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    IsTransparent = true;
                    base.BackColor = (this.Parent == null) ? SystemColors.Window : this.Parent.BackColor;
                }
                else
                {
                    IsTransparent = false;
                    base.BackColor = value;
                }

                if (this.BackBrush != null)
                    this.BackBrush.Dispose();
                BackBrush = new SolidBrush(base.BackColor);

                Invalidate();
            }
        }

        // Hides these properties in the designer
        [Browsable(false)]
        public override DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                if (value != DrawMode.OwnerDrawFixed)
                    throw new Exception("Invalid value for DrawMode property");
                else
                    base.DrawMode = value;
            }
        }
        [Browsable(false)]
        public override SelectionMode SelectionMode
        {
            get
            {
                return base.SelectionMode;
            }
            set
            {
                if (value != SelectionMode.One)
                    throw new Exception("Invalid value for SelectionMode property");
                else
                    base.SelectionMode = value;
            }
        }

        // Public constructor
        public RadioListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.SelectionMode = SelectionMode.One;
            this.ItemHeight = this.FontHeight;

            this.Align = new StringFormat(StringFormat.GenericDefault);
            this.Align.LineAlignment = StringAlignment.Center;

            // Force transparent analisys
            this.BackColor = this.BackColor;
        }

        // Main paiting method
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            int maxItem = this.Items.Count - 1;

            if (e.Index < 0 || e.Index > maxItem)
            {
                // Erase all background if control has no items
                e.Graphics.FillRectangle(BackBrush, this.ClientRectangle);
                return;
            }

            int size = e.Font.Height; // button size depends on font height, not on item height

            // Calculate bounds for background, if last item paint up to bottom of control
            Rectangle backRect = e.Bounds;
            if (e.Index == maxItem)
                backRect.Height = this.ClientRectangle.Top + this.ClientRectangle.Height - e.Bounds.Top;
            e.Graphics.FillRectangle(BackBrush, backRect);

            // Determines text color/brush
            Brush textBrush;
            bool isChecked = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            RadioButtonState state = isChecked ? RadioButtonState.CheckedNormal : RadioButtonState.UncheckedNormal;
            if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
            {
                textBrush = SystemBrushes.GrayText;
                state = isChecked ? RadioButtonState.CheckedDisabled : RadioButtonState.UncheckedDisabled;
            }
            else if ((e.State & DrawItemState.Grayed) == DrawItemState.Grayed)
            {
                textBrush = SystemBrushes.GrayText;
                state = isChecked ? RadioButtonState.CheckedDisabled : RadioButtonState.UncheckedDisabled;
            }
            else
            {
                textBrush = SystemBrushes.FromSystemColor(this.ForeColor);
            }

            // Determines bounds for text and radio button
            Size glyphSize = RadioButtonRenderer.GetGlyphSize(e.Graphics, state);
            Point glyphLocation = e.Bounds.Location;
            glyphLocation.Y += (e.Bounds.Height - glyphSize.Height) / 2;

            Rectangle bounds = new Rectangle(e.Bounds.X + glyphSize.Width, e.Bounds.Y, e.Bounds.Width - glyphSize.Width, e.Bounds.Height);

            // Draws the radio button
            RadioButtonRenderer.DrawRadioButton(e.Graphics, glyphLocation, state);

            // Draws the text
            if (!string.IsNullOrEmpty(DisplayMember)) // Bound Datatable? Then show the column written in Displaymember
                e.Graphics.DrawString(((System.Data.DataRowView)this.Items[e.Index])[this.DisplayMember].ToString(),
                    e.Font, textBrush, bounds, this.Align);
            else
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, textBrush, bounds, this.Align);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        // Prevent background erasing
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x0014)  // WM_ERASEBKGND
            {
                m.Result = (IntPtr)1; // avoid default background erasing
                return;
            }

            base.DefWndProc(ref m);
        }

        // Other event handlers
        protected override void OnHandleCreated(EventArgs e)
        {
            if (this.FontHeight > this.ItemHeight)
                this.ItemHeight = this.FontHeight;

            base.OnHandleCreated(e);
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            if (this.FontHeight > this.ItemHeight)
                this.ItemHeight = this.FontHeight;
            Update();
        }
        protected override void OnParentChanged(EventArgs e)
        {
            // Force to change backcolor
            this.BackColor = this.BackColor;
        }
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            // Force to change backcolor
            this.BackColor = this.BackColor;
        }
    }

}
