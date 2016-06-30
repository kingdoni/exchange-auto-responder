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
    public partial class SenderCondition : RuleCondition
    {
        public SenderCondition(string defaultValueText) 
        {
            DefaultValueText = geea.SenderConditionDefaultValueText;
            TextFormat = defaultValueText;
        }
        public SenderCondition():this( geea.SenderConditionTextFormat)
        {
            
           
        }
        public override object Clone()
        {
            var tmp = new SenderCondition(TextFormat);
            if (this.HasValue) tmp.Value = this.Value;
            return tmp;
        }

        public override bool Evaluate(object o)
        {
            if (!this.HasValue) return false;
            var tmp = (EmailMessage)o;
            return tmp.From.NativeAddress.Contains(this.Value.ToString());
        }
    }
}
