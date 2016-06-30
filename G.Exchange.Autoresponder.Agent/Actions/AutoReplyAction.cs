
using System;
using System.IO;
using System.Text;
using Microsoft.Exchange.Data.Transport.Email;
using Rules.Framework.Rules;

namespace G.Exchange.Autoresponder.Agent.Actions
{
    [Serializable]
    public partial class AutoReplyAction : RuleAction
    {
        public MsgTemplate Template { get; set; }
        public AutoReplyAction()
        {
            this.DefaultValueText = "modèle";
            this.TextFormat = "Repondre par un message avec le modèle {0}";
            Template = new MsgTemplate();


        }
        public override object Clone()
        {
            var tmp = new AutoReplyAction {DefaultValueText = this.DefaultValueText,TextFormat = this.TextFormat,Template = this.Template};
            if (this.HasValue) tmp.Value = this.Value;
            return tmp;
        }
       
        public override void Execute(object o)
        {
            
        }
        public static void SaveMessage(EmailMessage msg, string filePath)
        {
            try
            {
                FileStream file = new FileStream(filePath, System.IO.FileMode.Create);
                msg.MimeDocument.WriteTo(file);
                file.Close();
            }
            catch
            {
                LogMessage("SaveMessage",
                    String.Format("Failed to save message, {0}, to {1}.",
                        msg.Subject, filePath));
                throw;
            }
        }

        public static void LogMessage(string methodName, string message)
        {
            try
            {
                StringBuilder traceMessage = new StringBuilder();
                traceMessage.Append(System.DateTime.Now.ToString("s"));
                traceMessage.Append("|");
                traceMessage.Append(methodName);
                traceMessage.Append("|");
                traceMessage.Append(message);
                traceMessage.Append("\r\n");

                System.Diagnostics.Debug.WriteLine(traceMessage.ToString());

                //File.AppendAllText(
                //    String.Concat(OutputPath, "log.txt"),
                //    traceMessage.ToString());
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(String.Format("Failed to log message, {0}, to 'log.txt' in {1}.",
                //    message, OutputPath));
                System.Diagnostics.Debug.WriteLine(String.Format("Exception: {0}", ex.Message));
            }
        }
    }

    [Serializable]
    public class MsgTemplate
    {
        public string Content { get; set; }
        public string Title { get; set; }
    }
}
