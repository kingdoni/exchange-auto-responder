using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEAA_Config.Ressources;
using Microsoft.Exchange.Data.Transport.Email;
using Rules.Framework.Rules;

namespace G.Exchange.Autoresponder.Agent.Conditions
{

    public enum MailSecurity : byte
    {
        Oui = 0,
        Non
    }
    [Serializable]
    public partial class SecureMessageCondition : RuleCondition
    {
        public SecureMessageCondition(string defaultValueText) 
        {
            TextFormat = defaultValueText;
            DefaultValueText = geea.SecureMessageConditionDefaultValueText;
           // Value = MailSecurity.Non;
        }
        public SecureMessageCondition() : this(geea.SecureMessageConditionTextFormat)
        {
           
            
        }
        public override object Clone()
        {
            var tmp = new SecureMessageCondition(TextFormat);
            if (this.HasValue) tmp.Value = this.Value;
            return tmp;
        }

        public override bool Evaluate(object o)
        {
            if (!this.HasValue) return false;
            var tmp = (EmailMessage)o;
            return true;
        }
    }
}
