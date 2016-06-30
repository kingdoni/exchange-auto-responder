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
    public partial class SubjectCondition : RuleCondition
    {
        public SubjectCondition(string defaulTexte)
        {
            TextFormat = defaulTexte;
            DefaultValueText =geea.SubjectConditionDefaultValueText;
        }
        public SubjectCondition():this(geea.SubjectConditionTextFormat)
        {
           
           
        }
        public override object Clone()
        {
            var tmp = new SubjectCondition(TextFormat);
            if(this.HasValue) tmp.Value = this.Value;
            return tmp;
        }

        public override bool Evaluate(object o)
        {
            if (!this.HasValue) return false;
                var tmp = (EmailMessage) o;
            return this.Value.ToString().Split(' ').Any(x => tmp.Subject.Contains(x));
            
        }
    }
}
