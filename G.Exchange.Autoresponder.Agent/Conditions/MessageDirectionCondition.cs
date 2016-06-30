
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using GEAA_Config.Ressources;
using Microsoft.Exchange.Data.Transport.Email;
using Rules.Framework.Rules;

namespace G.Exchange.Autoresponder.Agent.Conditions
{
    /// <summary>
    /// 
    /// </summary>
    public enum MailDirection : byte
    {
        Sortant = 0,
        Entrant
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class MessageDirectionCondition : RuleCondition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValueText"></param>
        public MessageDirectionCondition(string defaultValueText) 
        {
            DefaultValueText = geea.MessageDirectionConditionDefaultValueText;
            TextFormat = defaultValueText;
            //Value = MailDirection.Entrant;
        }
        /// <summary>
        /// 
        /// </summary>
        public MessageDirectionCondition():this(geea.MessageDirectionConditionTextFormat)
        {
            
        }
        public override object Clone()
        {
            var tmp = new MessageDirectionCondition(TextFormat);
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
