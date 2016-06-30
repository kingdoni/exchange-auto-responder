using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEAA_Config.Editors;

namespace G.Exchange.Autoresponder.Agent.Actions
{
    public partial class AutoReplyAction
    {
        public override bool UpdateValue(object sender)
        {
            var cd = new MailTemplate(Template);


            if (cd.ShowDialog((Form) sender) != DialogResult.OK) return false;

            Template = cd.Template;
            Value = Template.Title;
            return true;
        }
    }
}
