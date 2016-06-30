using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEAA_Config.Editors;

namespace G.Exchange.Autoresponder.Agent.Conditions
{
   
    public partial class AttachmentCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            var s = "";


            if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            {
                Value = s;
                return true;
            }
            return false;
        }
    }

    public partial class BodyCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            var s = "";

            if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            {
                Value = s;
                return true;
            }
            return false;
        }
    }

    public partial class MessageDirectionCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            //var s = "";

            //if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            //{
            //    Value = s;
            //    return true;
            //}
            var dlg = new CheckListForm(typeof(MailDirection), Value);
            if (dlg.ShowDialog(form) == DialogResult.OK)
            {
                Value = dlg.Selected;
                return true;
            }
            return false;
        }
    }

    public partial class MessageTypeCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            var s = "";

            if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            {
                Value = s;
                return true;
            }
            return false;
        }
    }

    public partial class RecipientCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            var s = "";

            if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            {
                Value = s;
                return true;
            }
            return false;
        }
    }

    public partial class SecureMessageCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            //var s = "";

            //if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            //{
            //    Value = s;
            //    return true;
            //}
            var dlg = new CheckListForm(typeof(MailSecurity), Value);
            if (dlg.ShowDialog(form) == DialogResult.OK)
            {
                Value = dlg.Selected;
                return true;
            }
            return false;
        }
    }

    public partial class SenderCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            var s = "";

            if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            {
                Value = s;
                return true;
            }
            return false;
        }
    }
    public partial class SubjectCondition
    {
        public override bool UpdateValue(object sender)
        {
            Form form = (Form)sender;

            var s = "";

            if ((s = Microsoft.VisualBasic.Interaction.InputBox(HasValue ? Value.ToString() : "")) != string.Empty)
            {
                Value = s;
                return true;
            }
            return false;
        }
    }
}
