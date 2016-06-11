// Copyright 2007 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rules.Framework.Rules.Forms
{
    public partial class RulesWizard : Form
    {
        private RuleViewDetails ruleViewDetails;
        private int pageNr;

        private Rule ruleMaster;
        public Rule RuleMaster
        {
            get { return ruleMaster; }
        }

        private Rule rule;
        public Rule Rule
        {
            get { return rule; }
        }


        public RulesWizard()
        {
            pageNr = 0;
            rule = null;
            InitializeComponent();
            ruleViewDetails = new RuleViewDetails(this, panelRule);
        }

        public DialogResult SetupRule(IWin32Window win, Rule ruleMaster, Rule rule)
        {
            if (ruleMaster == null) throw new ArgumentNullException("ruleMaster");
            if (rule == null)
                this.rule = new Rule(); // create a new rule
            else
                this.rule = (Rule) rule.Clone(); // change/update a rule

            this.ruleMaster = ruleMaster;
            textName.Text = this.rule.Name;
            checkRuleEnable.Checked = this.rule.Enabled;
            checkApplyRuleNow.Checked = this.rule.ApplyNow;
            SetupPage(pageNr);

            ShowDialog(win);

            return DialogResult;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RuleViewItem.Prepare(listConditions);
        }

        private void SetupPage(int pagenr)
        {
            pageNr = pagenr;
            switch (pagenr)
            {
                case 0:
                    panelFinish.Visible = false;
                    panelWiz.Visible = true;
                    btnBack.Enabled = false;
                    btnNext.Enabled = true;
                    panelRuleBack.Bounds = new Rectangle(10, 246, 400, 111);
                    ListConditions(ruleMaster.Conditions, rule.Conditions);
                    labelDescription.Text = "Which condition(s) do you want to check?";
                    labelStep1.Text = "Step 1: Select &condition(s)";
                    labelStep2.Text = "Step 2: Edit the rule &descriptions (click the underlined value)";
                    break;
                case 1:
                    panelFinish.Visible = false;
                    panelWiz.Visible = true;
                    btnBack.Enabled = true;
                    btnNext.Enabled = true;
                    panelRuleBack.Bounds = new Rectangle(10, 246, 400, 111);
                    ListActions(ruleMaster.Actions, rule.Actions);
                    labelDescription.Text = "Which action(s) do you want execute?";
                    labelStep1.Text = "Step 1: Select a&ction(s)";
                    labelStep2.Text = "Step 2: Edit the rule &descriptions (click the underlined value)";
                    break;
                case 2:
                    panelFinish.Visible = false;
                    panelWiz.Visible = true;
                    btnBack.Enabled = true;
                    btnNext.Enabled = true;
                    panelRuleBack.SetBounds(10, 246, 400, 111);
                    ListConditions(ruleMaster.Exceptions, rule.Exceptions);
                    labelDescription.Text = "Are there any exceptions?";
                    labelStep1.Text = "Step 1: Select ex&ception(s)";
                    labelStep2.Text = "Step 2: Edit the rule &descriptions (click the underlined value)";
                    break;
                default:
                    panelFinish.Visible = true;
                    panelWiz.Visible = false;
                    btnBack.Enabled = true;
                    btnNext.Enabled = false;
                    panelRuleBack.SetBounds(10, 198, 400, 159);
                    labelDescription.Text = "Finish rule setup";
                    labelStep1.Text = "Step 1: Specify a &name for this rule";
                    labelStep2.Text = "Step 2: Setup rule options";
                    break;
            }
            ruleViewDetails.Display(rule);

        }

        private void ListActions(RuleActions masterlist, RuleActions list)
        {
            listConditions.Items.Clear();
            foreach (RuleAction ra in masterlist)
            {
                LinkLabel ll = new LinkLabel();
                ll.Text = ra.Text;
                ll.LinkArea = new LinkArea(ra.ValueStart, ra.ValueText.Length);
                RuleViewItem rvi = new RuleViewItem(ll);
                rvi.Tag = ra;

                if (list.FindByFormat(ra.TextFormat) != null)
                    rvi.Checked = true;

                listConditions.Items.Add(rvi);
            }
        }


        private void ListConditions(RuleConditions masterlist, RuleConditions list)
        {
            listConditions.Items.Clear();
            foreach (RuleCondition rc in masterlist)
            {
                LinkLabel ll = new LinkLabel();
                ll.Text = rc.Text;
                ll.LinkArea = new LinkArea(rc.ValueStart, rc.ValueText.Length);
                RuleViewItem rvi = new RuleViewItem(ll);
                rvi.Tag = rc;

                if (list.FindByFormat(rc.TextFormat) != null)
                    rvi.Checked = true;

                listConditions.Items.Add(rvi);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRulesWizard_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, 12, btnCancel.Top-10, 400, 2, Border3DStyle.SunkenOuter);
        }

        private void listConditions_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            listConditions.SelectedItems.Clear();
            listConditions.Items[e.Index].Selected = true;
            listConditions.Items[e.Index].Focused = true;
            RulePart rp = (RulePart)listConditions.Items[e.Index].Tag;

            switch (pageNr)
            {
                case 0:
                    if (e.NewValue == CheckState.Checked)
                    {
                        RuleCondition rc = (RuleCondition)rp.Clone();
                        if (rule.Conditions.FindByFormat(rc.TextFormat) == null)
                            rule.Conditions.Add(rc);
                    }
                    else
                        rule.Conditions.Remove((rule.Conditions.FindByFormat(rp.TextFormat)));
                    break;
                case 1:
                    if (e.NewValue == CheckState.Checked)
                    {
                        RuleAction rc = (RuleAction)rp.Clone();
                        if (rule.Actions.FindByFormat(rc.TextFormat) == null)
                            rule.Actions.Add(rc);
                    }
                    else
                        rule.Actions.Remove((rule.Actions.FindByFormat(rp.TextFormat)));
                    break;
                case 2:
                    if (e.NewValue == CheckState.Checked)
                    {
                        RuleCondition rc = (RuleCondition)rp.Clone();
                        if (rule.Exceptions.FindByFormat(rc.TextFormat) == null)
                            rule.Exceptions.Add(rc);
                    }
                    else
                        rule.Exceptions.Remove((rule.Exceptions.FindByFormat(rp.TextFormat)));
                    break;
                default:
                    break;
            }
            ruleViewDetails.Display(rule);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SetupPage(pageNr - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SetupPage(pageNr + 1);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            rule.Name = textName.Text;
            rule.ApplyNow = checkApplyRuleNow.Checked;
            rule.Enabled = checkRuleEnable.Checked;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void textName_Enter(object sender, EventArgs e)
        {
            textName.SelectAll();
        }

    }
}