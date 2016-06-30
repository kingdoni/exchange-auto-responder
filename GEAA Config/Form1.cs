using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G.Exchange.Autoresponder.Agent;
using G.Exchange.Autoresponder.Agent.Actions;
using G.Exchange.Autoresponder.Agent.Conditions;
using GEAA_Config.Ressources;
using Rules.Framework.Rules;
using Rules.Framework.Rules.Forms;
using Rule = Rules.Framework.Rules.Rule;

namespace GEAA_Config
{
    public partial class Form1 : Form
    {
    Rules.Framework.Rules.Rule _ruleMaster;
        Rules.Framework.Rules.Rule _theRule;
        private RuleViewDetails _ruleViewDetails;

        public Form1()
        {
            InitializeComponent();
            _ruleMaster = new Rules.Framework.Rules.Rule();

            // setup conditions
            _ruleMaster.Conditions.Add(new SubjectCondition());
            _ruleMaster.Conditions.Add(new AttachmentCondition());
            _ruleMaster.Conditions.Add(new BodyCondition());
            _ruleMaster.Conditions.Add(new MessageTypeCondition());
            _ruleMaster.Conditions.Add(new MessageDirectionCondition());
            _ruleMaster.Conditions.Add(new RecipientCondition());

            _ruleMaster.Conditions.Add(new SecureMessageCondition());
            _ruleMaster.Conditions.Add(new SenderCondition());


            _ruleMaster.Actions.Add(new AutoReplyAction());


            _ruleMaster.Exceptions.Add(new SubjectCondition($"{geea.Except} {geea.SubjectConditionTextFormat}"));
            _ruleMaster.Exceptions.Add(new AttachmentCondition($"{geea.Except} {geea.AttachmentConditionTextFormat}"));
            _ruleMaster.Exceptions.Add(new BodyCondition($"{geea.Except} {geea.BodyConditionTextFormat}"));
            _ruleMaster.Exceptions.Add(new MessageTypeCondition($"{geea.Except} {geea.MessageTypeConditionTextFormat}"));
            _ruleMaster.Exceptions.Add(new MessageDirectionCondition($"{geea.Except} {geea.MessageDirectionConditionTextFormat}"));
            _ruleMaster.Exceptions.Add(new RecipientCondition($"{geea.Except} {geea.RecipientConditionTextFormat}"));

            _ruleMaster.Exceptions.Add(new SecureMessageCondition($"{geea.Except} {geea.SecureMessageConditionTextFormat}"));
            _ruleMaster.Exceptions.Add(new SenderCondition($"{geea.Except} {geea.SenderConditionTextFormat}"));

            _ruleViewDetails = new RuleViewDetails(this, panel4);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            RulesWizard wizard = new RulesWizard();
            if (wizard.SetupRule(this, _ruleMaster, new Rule()) == DialogResult.OK)
            {
                _theRule = wizard.Rule;
                if (_theRule != null)
                {
                    var viewItem = new ListViewItem(_theRule.Name,0) {Tag = _theRule};
                    listViewRules.Items.Add(viewItem);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RulesWizard wizard = new RulesWizard();
            if (wizard.SetupRule(this, _ruleMaster,(Rule) listViewRules.SelectedItems[0].Tag) == DialogResult.OK)
            {
                //_theRule = wizard.Rule;
                if (wizard.Rule != null)
                {
                    listViewRules.SelectedItems[0].Tag = wizard.Rule;
                    listViewRules.SelectedItems[0].Text = wizard.Rule.Name;
                    //var viewItem = new ListViewItem(_theRule.Name) { Tag = wizard.Rule };
                    //listViewRules.Items.Add(viewItem);
                }
            }
        }

        private void listViewRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEdit.Enabled = ((ListView) sender).SelectedItems.Count == 1;
            buttonDelete.Enabled = buttonEdit.Enabled;
            if (buttonEdit.Enabled)
            {
                _ruleViewDetails.DisplayWithoutLink((Rule) ((ListView) sender).SelectedItems[0].Tag);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialogRls.ShowDialog(this) == DialogResult.OK)
            {
                var liste = RuleSerializer.LoadRule(openFileDialogRls.FileName);
                listViewRules.Items.Clear();
                liste.ForEach(x =>
                {
                    var viewItem = new ListViewItem(x.Name,0) { Tag = x };
                    listViewRules.Items.Add(viewItem);
                });
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialogRls.ShowDialog(this) == DialogResult.OK)
            {
                
                RuleSerializer.SaveRule(listViewRules.Items.OfType<ListViewItem>().Select(x => (Rule)x.Tag).ToList(),saveFileDialogRls.FileName);
            }
        }
    }
}
