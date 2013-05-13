using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using libWyvernzora.Core;

namespace RenEx
{
    public partial class RuleEditorDialog : Form
    {
        private static Random rand = new Random();
        private MainForm parent;

        public RuleEditorDialog(MainForm parent)
        {
            this.parent = parent;
            InitializeComponent();

            // Generate Default Name
            txtName.Text = String.Format("Rule #{0}", DirectIntConv.ToHexString(rand.Next(), 8).Substring(2));

            btnOK.Click += (@s, a) =>
                {
                    if (ValidateData())
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                };
            btnCancel.Click += (@s, a) =>
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                };
            chbDelete.CheckedChanged += (@s, e) =>
                {
                    txtRepExp.Enabled = !chbDelete.Checked;
                };
            Load += (@s, a) =>
                {
                    txtName.Focus();
                    txtName.SelectAll();
                };
        }

        private Boolean ValidateData()
        {
            Boolean success = true;
            error.Clear();

            // Verify Name
            if (txtName.Text.Length == 0)
            {
                error.SetError(txtName, "Rule must have a name!");
                success = false;
            }

            /* Enforcing unique names, no need?
            List<RenamingRule> existing = radName.Checked
                                              ? parent.NameRules
                                              : radExtension.Checked ? parent.ExtensionRules : parent.DirectoryRules;
            //if (existing.Any())
            */

            // Verify Match Expression
            try
            {
                Regex rgx = new Regex(txtMatchExp.Text);
            }
            catch (Exception)
            {
                error.SetError(txtMatchExp, "Incorrect Regular Expression!");
                success = false;
            }

            // Verify Replace Expression
            if (txtRepExp.Text.Length == 0 && ! chbDelete.Checked)
            {
                error.SetError(txtRepExp, "Replacement Expression must not be empty!");
                success = false;
            }

            return success;
        }
        
        public RenamingRule Rule
        {
            get
            {
                return new RenamingRule()
                    {
                        Name = txtName.Text,
                        RegularExpression = txtMatchExp.Text,
                        ReplacementExpression = txtRepExp.Text,
                        DeleteFile = chbDelete.Checked,
                        Type =
                            radName.Checked
                                ? RenamingRule.RuleType.Name
                                : radExtension.Checked
                                      ? RenamingRule.RuleType.Extension
                                      : RenamingRule.RuleType.Directory
                    };
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value.Name))
                    txtName.Text = value.Name;
                txtMatchExp.Text = value.RegularExpression;
                txtRepExp.Text = value.ReplacementExpression;
                switch (value.Type)
                {
                    case RenamingRule.RuleType.Name:
                        radName.Checked = true;
                        break;
                    case RenamingRule.RuleType.Extension:
                        radExtension.Checked = true;
                        break;
                    default:
                        radDirectory.Checked = true;
                        break;
                }
            }
        }   
    }
}
