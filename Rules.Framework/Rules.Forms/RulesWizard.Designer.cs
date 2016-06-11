namespace Rules.Framework.Rules.Forms
{
    partial class RulesWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("from people or distribution list");
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.panelWiz = new System.Windows.Forms.Panel();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.listConditions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelRuleBack = new System.Windows.Forms.Panel();
            this.panelRule = new System.Windows.Forms.Panel();
            this.panelFinish = new System.Windows.Forms.Panel();
            this.textName = new System.Windows.Forms.TextBox();
            this.checkRuleEnable = new System.Windows.Forms.CheckBox();
            this.checkApplyRuleNow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelWiz.SuspendLayout();
            this.panelRuleBack.SuspendLayout();
            this.panelFinish.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(87, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(173, 391);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "< &Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(249, 391);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(335, 391);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "&Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(5, 5);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(207, 13);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "Which condition(s) do you want to check?";
            // 
            // labelStep1
            // 
            this.labelStep1.AutoSize = true;
            this.labelStep1.Location = new System.Drawing.Point(5, 19);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(131, 13);
            this.labelStep1.TabIndex = 7;
            this.labelStep1.Text = "Step 1: Select condition(s)";
            // 
            // panelWiz
            // 
            this.panelWiz.Controls.Add(this.labelStep2);
            this.panelWiz.Controls.Add(this.listConditions);
            this.panelWiz.Controls.Add(this.labelStep1);
            this.panelWiz.Controls.Add(this.labelDescription);
            this.panelWiz.Location = new System.Drawing.Point(3, 1);
            this.panelWiz.Name = "panelWiz";
            this.panelWiz.Size = new System.Drawing.Size(417, 243);
            this.panelWiz.TabIndex = 8;
            // 
            // labelStep2
            // 
            this.labelStep2.AutoSize = true;
            this.labelStep2.Location = new System.Drawing.Point(7, 228);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(289, 13);
            this.labelStep2.TabIndex = 10;
            this.labelStep2.Text = "Step 2: Edit the rule &descriptions (click the underlined value)";
            // 
            // listConditions
            // 
            this.listConditions.CheckBoxes = true;
            this.listConditions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listConditions.FullRowSelect = true;
            this.listConditions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem1.StateImageIndex = 0;
            this.listConditions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listConditions.Location = new System.Drawing.Point(7, 37);
            this.listConditions.Name = "listConditions";
            this.listConditions.Size = new System.Drawing.Size(400, 172);
            this.listConditions.TabIndex = 8;
            this.listConditions.UseCompatibleStateImageBehavior = false;
            this.listConditions.View = System.Windows.Forms.View.Details;
            this.listConditions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listConditions_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Rule";
            this.columnHeader1.Width = 396;
            // 
            // panelRuleBack
            // 
            this.panelRuleBack.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelRuleBack.Controls.Add(this.panelRule);
            this.panelRuleBack.Location = new System.Drawing.Point(10, 196);
            this.panelRuleBack.Name = "panelRuleBack";
            this.panelRuleBack.Padding = new System.Windows.Forms.Padding(1);
            this.panelRuleBack.Size = new System.Drawing.Size(400, 161);
            this.panelRuleBack.TabIndex = 10;
            // 
            // panelRule
            // 
            this.panelRule.AutoScroll = true;
            this.panelRule.BackColor = System.Drawing.SystemColors.Window;
            this.panelRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRule.Location = new System.Drawing.Point(1, 1);
            this.panelRule.Name = "panelRule";
            this.panelRule.Size = new System.Drawing.Size(398, 159);
            this.panelRule.TabIndex = 0;
            // 
            // panelFinish
            // 
            this.panelFinish.Controls.Add(this.textName);
            this.panelFinish.Controls.Add(this.checkRuleEnable);
            this.panelFinish.Controls.Add(this.checkApplyRuleNow);
            this.panelFinish.Controls.Add(this.label4);
            this.panelFinish.Controls.Add(this.label3);
            this.panelFinish.Controls.Add(this.label1);
            this.panelFinish.Controls.Add(this.label2);
            this.panelFinish.Location = new System.Drawing.Point(2, 2);
            this.panelFinish.Name = "panelFinish";
            this.panelFinish.Size = new System.Drawing.Size(417, 195);
            this.panelFinish.TabIndex = 12;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(7, 55);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(400, 20);
            this.textName.TabIndex = 15;
            this.textName.Enter += new System.EventHandler(this.textName_Enter);
            // 
            // checkRuleEnable
            // 
            this.checkRuleEnable.AutoSize = true;
            this.checkRuleEnable.Checked = true;
            this.checkRuleEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRuleEnable.Location = new System.Drawing.Point(9, 143);
            this.checkRuleEnable.Name = "checkRuleEnable";
            this.checkRuleEnable.Size = new System.Drawing.Size(102, 17);
            this.checkRuleEnable.TabIndex = 14;
            this.checkRuleEnable.Text = "&Turn on this rule";
            this.checkRuleEnable.UseVisualStyleBackColor = true;
            // 
            // checkApplyRuleNow
            // 
            this.checkApplyRuleNow.AutoSize = true;
            this.checkApplyRuleNow.Location = new System.Drawing.Point(9, 120);
            this.checkApplyRuleNow.Name = "checkApplyRuleNow";
            this.checkApplyRuleNow.Size = new System.Drawing.Size(108, 17);
            this.checkApplyRuleNow.TabIndex = 13;
            this.checkApplyRuleNow.Text = "R&un this rule now";
            this.checkApplyRuleNow.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Step 3: Review rule &description (click an underlined value to edit)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Step 2: Setup rule options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Step 1: Specify a &name for this rule";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Finish rule setup.";
            // 
            // RulesWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(423, 426);
            this.Controls.Add(this.panelWiz);
            this.Controls.Add(this.panelRuleBack);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RulesWizard";
            this.Text = "Rules Wizard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRulesWizard_Paint);
            this.panelWiz.ResumeLayout(false);
            this.panelWiz.PerformLayout();
            this.panelRuleBack.ResumeLayout(false);
            this.panelFinish.ResumeLayout(false);
            this.panelFinish.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelStep1;
        private System.Windows.Forms.Panel panelWiz;
        private System.Windows.Forms.ListView listConditions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Panel panelRuleBack;
        private System.Windows.Forms.Panel panelFinish;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.CheckBox checkRuleEnable;
        private System.Windows.Forms.CheckBox checkApplyRuleNow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelRule;
    }
}

