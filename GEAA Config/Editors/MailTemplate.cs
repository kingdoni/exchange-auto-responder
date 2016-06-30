using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G.Exchange.Autoresponder.Agent.Actions;

namespace GEAA_Config.Editors
{
    public partial class MailTemplate : Form
    {
        public string ContenText => htmlEditorControl1.InnerHtml;
        public MsgTemplate Template => new MsgTemplate {Content = htmlEditorControl1.InnerHtml,Title = textBoxSujet.Text };
        public MailTemplate()
        {
            InitializeComponent();
        }

        public MailTemplate(string content):this()
        {
            htmlEditorControl1.InnerHtml = content;
        }
        public MailTemplate(MsgTemplate template) : this()
        {
            htmlEditorControl1.InnerHtml = template.Content;
            textBoxSujet.Text = template.Title;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
