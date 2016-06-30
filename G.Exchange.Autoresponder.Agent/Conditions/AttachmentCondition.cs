using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEAA_Config.Ressources;
using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Email;
using Rules.Framework.Rules;

namespace G.Exchange.Autoresponder.Agent.Conditions
{
    [Serializable]
    public partial class AttachmentCondition : RuleCondition
    {
        public AttachmentCondition(string defaultValueText)
        {
            TextFormat = defaultValueText;
            DefaultValueText = geea.Mots;
        }
        public AttachmentCondition():this(geea.AttachmentConditionTextFormat)
        {
            
            
        }
        public override object Clone()
        {
            var tmp = new AttachmentCondition(TextFormat);
            if (this.HasValue) tmp.Value = this.Value;
            return tmp;
        }

        public override bool Evaluate(object o)
        {
            if (!this.HasValue) return false;
            var tmp = (EmailMessage)o;
            return tmp.Attachments.Any(x => x.FileName.Contains(this.Value.ToString()));
            
        }
    }

    
}
