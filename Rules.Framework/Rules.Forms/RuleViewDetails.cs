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
using System.Windows.Forms;

namespace Rules.Framework.Rules.Forms
{


    public class RuleViewDetails
    {
        ScrollableControl control;
        Form form;

        private string textAnd = "and";
        private string textOr = "or";

        private Rule rule;

        private class RulePartTag
        {
            public RulePart RulePart;
            public int Index;
            public int Type; // 0=condition, 1 = action, 2=exception

            public RulePartTag(RulePart part, int type, int index)
            {
                RulePart = part;
                Type = type;
                Index = index;
            }
        }

        public RuleViewDetails(Form form, ScrollableControl control)
        {
            rule = null;
            this.form = form;
            this.control = control;
        }

        public void Display(Rule rule)
        {
            this.rule = rule;
            int startY = 4;
            int startX = 4;
            int index = 0;
            string prefix = "";

            control.SuspendLayout();
            control.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = rule.TriggerText;
            lbl.AutoSize = true;
            control.Controls.Add(lbl);
            lbl.SetBounds(2, startX, lbl.Width, lbl.Height);
            startY += lbl.Height + 4;

            // show conditions
            foreach (RuleCondition rc in rule.Conditions)
            {
                LinkLabel ll = new LinkLabel();
                ll.AutoSize = true;
                SetLinkLabel(ll, prefix, rc);
                ll.Click += new EventHandler(ll_Click);
                ll.SetBounds(startX, startY, ll.Width, ll.Height);
                ll.Tag = new RulePartTag(rc, 0, index);
                control.Controls.Add(ll);
                startY += ll.Height;
                startX = 12;
                prefix = textAnd + " ";
                index++;
            }

            // show actions
            startX = 4;
            prefix = "";
            index = 0;
            foreach (RuleAction ra in rule.Actions)
            {
                LinkLabel ll = new LinkLabel();
                ll.AutoSize = true;
                SetLinkLabel(ll, prefix, ra);
                ll.Click += new EventHandler(ll_Click);
                ll.SetBounds(startX, startY, ll.Width, ll.Height);
                ll.Tag = new RulePartTag(ra, 1, index);
                control.Controls.Add(ll);
                startY += ll.Height;
                startX = 12;
                prefix = textAnd + " ";
            }
            
            //show exceptions
            startX = 4;
            prefix = "";
            index = 0;
            foreach (RuleCondition rc in rule.Exceptions)
            {
                LinkLabel ll = new LinkLabel();
                ll.AutoSize = true;
                SetLinkLabel(ll, prefix, rc);
                ll.Click += new EventHandler(ll_Click);
                ll.SetBounds(startX, startY, ll.Width, ll.Height);
                ll.Tag = new RulePartTag(rc, 2, index);
                control.Controls.Add(ll);
                startY += ll.Height;
                startX = 12;
                prefix = textOr + " ";
            }
            
            control.ResumeLayout();
        }
        public void DisplayWithoutLink(Rule rule)
        {
            this.rule = rule;
            int startY = 4;
            int startX = 4;
            int index = 0;
            string prefix = "";

            control.SuspendLayout();
            control.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = rule.TriggerText;
            lbl.AutoSize = true;
            control.Controls.Add(lbl);
            lbl.SetBounds(2, startX, lbl.Width, lbl.Height);
            startY += lbl.Height + 4;

            // show conditions
            foreach (RuleCondition rc in rule.Conditions)
            {
                LinkLabel ll = new LinkLabel {AutoSize = true};
                SetLinkLabel(ll, prefix, rc);
                //ll.Click += new EventHandler(ll_Click);
                ll.SetBounds(startX, startY, ll.Width, ll.Height);
                ll.Tag = new RulePartTag(rc, 0, index);
                control.Controls.Add(ll);
                startY += ll.Height;
                startX = 12;
                prefix = textAnd + " ";
                index++;
            }

            // show actions
            startX = 4;
            prefix = "";
            index = 0;
            foreach (RuleAction ra in rule.Actions)
            {
                LinkLabel ll = new LinkLabel {AutoSize = true};
                SetLinkLabel(ll, prefix, ra);
                //ll.Click += new EventHandler(ll_Click);
                ll.SetBounds(startX, startY, ll.Width, ll.Height);
                ll.Tag = new RulePartTag(ra, 1, index);
                control.Controls.Add(ll);
                startY += ll.Height;
                startX = 12;
                prefix = textAnd + " ";
            }

            //show exceptions
            startX = 4;
            prefix = "";
            index = 0;
            foreach (RuleCondition rc in rule.Exceptions)
            {
                LinkLabel ll = new LinkLabel {AutoSize = true};
                SetLinkLabel(ll, prefix, rc);
                //ll.Click += new EventHandler(ll_Click);
                ll.SetBounds(startX, startY, ll.Width, ll.Height);
                ll.Tag = new RulePartTag(rc, 2, index);
                control.Controls.Add(ll);
                startY += ll.Height;
                startX = 12;
                prefix = textOr + " ";
            }

            control.ResumeLayout();
        }

        private void ll_Click(object sender, EventArgs e)
        {
            string prefix = "";
            LinkLabel ll = (LinkLabel)sender;
            RulePartTag tag = ll.Tag as RulePartTag;

            if (tag.RulePart.UpdateValue(form))
            {
                if (tag.Index > 0)
                    if (tag.Type == 2)
                        prefix = textOr + " ";
                    else
                        prefix = textAnd + " ";

                SetLinkLabel(ll, prefix, tag.RulePart);
            }
        }

        private void SetLinkLabel(LinkLabel ll, string prefix, RulePart part)
        {
            ll.Text = prefix + part.Text;
            ll.LinkArea = new LinkArea(part.ValueStart + prefix.Length, part.ValueText.Length);
            ll.AutoSize = false;
            ll.AutoSize = true;
        }

    }
}
