using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using G.Exchange.Autoresponder.Agent.Actions;
using G.Exchange.Autoresponder.Agent.Conditions;
using Rules.Framework.Rules;

namespace G.Exchange.Autoresponder.Agent
{
    [Serializable]
    [XmlInclude(typeof(AutoReplyAction))]
    [XmlInclude(typeof(AttachmentCondition))]
    [XmlInclude(typeof(BodyCondition))]
    [XmlInclude(typeof(MessageDirectionCondition))]
    [XmlInclude(typeof(MessageTypeCondition))]
    [XmlInclude(typeof(SecureMessageCondition))]
    [XmlInclude(typeof(RecipientCondition))]
    [XmlInclude(typeof(SenderCondition))]
    [XmlInclude(typeof(SubjectCondition))]
    public class RuleSerializer
    {
        public RuleSerializer()
        {
        }

        public List<Rule> Rule;
        public static List<Rule> LoadRule(string filename)
        {
            FileStream s = File.OpenRead(filename);
            //BinaryFormatter b = new BinaryFormatter();
            System.Xml.Serialization.XmlSerializer b = new System.Xml.Serialization.XmlSerializer(typeof(RuleSerializer));
            RuleSerializer rs = (RuleSerializer)b.Deserialize(s);
            s.Close();

            return rs.Rule;
        }

        public static void SaveRule(List<Rule> rule, string filename)
        {
            RuleSerializer rs = new RuleSerializer {Rule = rule};

            FileStream s = File.Create(filename);
            //BinaryFormatter b = new BinaryFormatter();
            System.Xml.Serialization.XmlSerializer b = new System.Xml.Serialization.XmlSerializer(typeof(RuleSerializer));
            b.Serialize(s, rs);
            s.Close();
        }
    }
}
