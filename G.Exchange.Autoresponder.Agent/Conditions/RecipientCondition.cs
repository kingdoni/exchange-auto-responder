using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEAA_Config.Ressources;
using Microsoft.Exchange.Data.Transport.Email;
using Rules.Framework.Rules;

namespace G.Exchange.Autoresponder.Agent.Conditions
{
    [Serializable]
    public partial class RecipientCondition : RuleCondition
    {
        public RecipientCondition(string defaultValueText)
        {
            TextFormat = defaultValueText;
            DefaultValueText = geea.RecipientConditionDefaultValueText;
        }
        public RecipientCondition() : this(geea.RecipientConditionTextFormat)
        {
          
        }
        public override object Clone()
        {
            var tmp = new RecipientCondition(TextFormat);
            if (this.HasValue) tmp.Value = this.Value;
            return tmp;
        }

        public override bool Evaluate(object o)
        {
            if (!this.HasValue) return false;
            var tmp = (EmailMessage)o;
            return tmp.To.Any(x => x.NativeAddress.Contains(this.Value.ToString()));
        }
    }
}
