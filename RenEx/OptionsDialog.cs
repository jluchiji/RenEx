using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libWyvernzora.IO;
using libWyvernzora.Utilities;

namespace RenEx
{
    public partial class OptionsDialog : Form
    {
        public OptionsDialog(Int32 mode = -1, Object arg = null)
        {
            // WinForms default call
            InitializeComponent();

            // Hide tab pages in development
#if !DEBUG
            tabControl1.TabPages.RemoveAt(3);
            tabControl1.TabPages.RemoveAt(2);
#endif

            // Attach Handlers
            btnOK.Click += (@s, e) => this.Close();
            Closing += (@s, e) =>
                {
                    // Apply all pending changes
                    if (ApplyExtConfig()) e.Cancel = true;

                    // Save Config File
                    MainForm.SaveConfiguration();
                };
            AttachExtensionAnalysisHandlers();
            AttachRuleTemplateHandlers();

            // Populate UI
            UpdateExtConfigList(Configuration.Instance.CurrentExtensionSettings);
            UpdateRuleTemplateList();
            //ShowExtensionSetting(Configuration.Instance.GetCurrentExtensionSettings());

            if (mode == 1)
            {
                tabControl1.SelectTab(1);

                RenamingRule rule = arg as RenamingRule;
                if (rule != null)
                {
                    String nname = "New Rule #" +
                            libWyvernzora.Core.DirectIntConv.ToHexString(Configuration.Random.Next(), 8)
                            .Substring(2);

                    if (Configuration.Instance.Rules.ContainsKey(rule.Name))
                        rule.Name = nname;

                    Configuration.Instance.Rules.Add(rule.Name, rule);
                    ShowRule(rule);
                    UpdateRuleTemplateList(rule.Name);
                    ApplyRltChanges();
                }
            }
        }

        #region Extension Analysis Tab

        private void AttachExtensionAnalysisHandlers()
        {
            // Enable/Disable Validators
            radExtLenVal.CheckedChanged += (@s, e) =>
                { nudExtLenMin.Enabled = nudExtLenMax.Enabled = radExtLenVal.Checked; };
            radExtListVal.CheckedChanged += (@s, e) =>
                { txtExtList.Enabled = radExtListVal.Checked; };

            // Preset List
            lbExtPresets.SelectedIndexChanged += (@s, e) =>
                {
                    if (lbExtPresets.SelectedItem != null)
                        ShowExtensionSetting((Configuration.ExtensionConfig)lbExtPresets.SelectedItem);

                    gbExtOptions.Enabled = lbExtPresets.SelectedItem != null;
                    btnExtRemove.Enabled =
                        !Configuration.StringComparer.Equals(lbExtPresets.SelectedItem.ToString(), "Default");
                };

            // Apply Changes
            txtExtName.Leave += (@s, e) => ApplyExtConfig();
            txtExtList.Leave += (@s, e) => ApplyExtConfig();
            radExtLenVal.Leave += (@s, e) => ApplyExtConfig();
            radExtListVal.Leave += (@s, e) => ApplyExtConfig();
            nudExtMaxExt.Leave += (@s, e) => ApplyExtConfig();
            nudExtLenMin.Leave += (@s, e) => ApplyExtConfig();
            nudExtLenMax.Leave += (@s, e) => ApplyExtConfig();

            // Add/Remove
            btnExtAdd.Click += (@s, e) =>
                {
                    String nname = "New Preset #" +
                                   libWyvernzora.Core.DirectIntConv.ToHexString(Configuration.Random.Next(), 8)
                                                .Substring(2);
                    
                    Configuration.ExtensionConfig config = Configuration.ExtensionConfig.Default;
                    config.Name = nname;
                    Configuration.Instance.ExtensionConfigs.Add(nname, config);
                    UpdateExtConfigList(nname);
                    txtExtName.Select();
                    txtExtName.SelectAll();
                };
            btnExtRemove.Click += (@s, e) =>
                {
                    Configuration.ExtensionConfig config = lbExtPresets.SelectedItem as Configuration.ExtensionConfig;
                    if (config == null) return;

                    Configuration.Instance.ExtensionConfigs.Remove(config.Name);
                    if (Configuration.StringComparer.Equals(Configuration.Instance.CurrentExtensionSettings, config.Name))
                        Configuration.Instance.CurrentExtensionSettings = "Default";
                    UpdateExtConfigList(Configuration.Instance.CurrentExtensionSettings);
                };
        }

        private void UpdateExtConfigList(String selection = null)
        {
             
            using (new ActionLock(lbExtPresets.BeginUpdate, lbExtPresets.EndUpdate))
            {
                lbExtPresets.Items.Clear();
                foreach (var k in Configuration.Instance.ExtensionConfigs.Values)
                {
                    lbExtPresets.Items.Add(k);
                    if (selection != null && Configuration.StringComparer.Equals(k.Name, selection))
                        lbExtPresets.SelectedItem = k;
                }
            }
        }
        
        private void ShowExtensionSetting(Configuration.ExtensionConfig config)
        {

            txtExtName.Enabled = !Configuration.StringComparer.Equals(config.Name, "Default");
            txtExtName.Text = config.Name;
            nudExtMaxExt.Value = config.MaximumExtensions;

            if (config.Validator is FileExtLengthValidator)
            {
                var validator = (FileExtLengthValidator) config.Validator;
                radExtLenVal.Checked = true;
                nudExtLenMin.Value = validator.MinimumLength;
                nudExtLenMax.Value = validator.MaximumLength;

                // Set defaults
                txtExtList.Clear();
            }
            else
            {
                var validator = (FileExtListValidator) config.Validator;
                radExtListVal.Checked = true;
                txtExtList.Text = String.Join(";", validator.Extensions);

                // Set defaults
                nudExtLenMin.Value = 0;
                nudExtLenMax.Value = 4;
            }
        }

        private Configuration.ExtensionConfig GetConfigurationFromUi()
        {
            Configuration.ExtensionConfig config = new Configuration.ExtensionConfig();

            config.Name = txtExtName.Text;
            config.MaximumExtensions = (Int32) nudExtMaxExt.Value;

            if (radExtLenVal.Checked)
                config.Validator = new FileExtLengthValidator((Int32) nudExtLenMin.Value, (Int32) nudExtLenMax.Value);
            else
                config.Validator = new FileExtListValidator(from ext in txtExtList.Text.Split(';') select ext.Trim(' '));

            return config;
        }

        private Boolean ApplyExtConfig()
        {
            error.Clear();
            Configuration.ExtensionConfig oldc = (Configuration.ExtensionConfig) lbExtPresets.SelectedItem;
            Configuration.ExtensionConfig newc = GetConfigurationFromUi();

            // Validate Data
            if (String.IsNullOrWhiteSpace(newc.Name))
            {
                error.SetError(txtExtName, "Preset name cannot be empty or all whitespaces!");
                return true;
            }

            // Check duplicates
            if (!Configuration.StringComparer.Equals(oldc.Name, newc.Name)
                && Configuration.Instance.ExtensionConfigs.ContainsKey(newc.Name))
            {
                DialogResult dr = MessageBox.Show(
                    "There is already a preset with exactly the same name.\nDo you want to overwrite it?",
                    "Overwrite?!", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.No) return false;
                else if (dr == DialogResult.Cancel) return true;
            }

            Configuration.Instance.ExtensionConfigs.Remove(oldc.Name);
            Configuration.Instance.ExtensionConfigs.Add(newc.Name, newc);
            UpdateExtConfigList(newc.Name);
            return false;
        }

        #endregion

        #region Rule Templates Tab

        public void AttachRuleTemplateHandlers()
        {
            // Item Selection
            lbRlt.SelectedValueChanged += (@s, e) =>
                {
                    if (lbRlt.SelectedItem != null)
                        ShowRule((RenamingRule) lbRlt.SelectedItem);
                    else
                    {
                        txtRltName.Clear();
                        txtRltRegex.Clear();
                        txtRltRep.Clear();
                        radRltName.Checked = true;
                    }

                    gbRltOptions.Enabled = lbRlt.SelectedItem != null;
                };

            // Apply changes
            txtRltName.Leave += (@s, e) => ApplyRltChanges();
            radRltDir.Leave += (@s, e) => ApplyRltChanges();
            radRltExt.Leave += (@s, e) => ApplyRltChanges();
            radRltName.Leave += (@s, e) => ApplyRltChanges();
            txtRltRegex.Leave += (@s, e) => ApplyRltChanges();
            txtRltRep.Leave += (@s, e) => ApplyRltChanges();
            chbRltDelete.CheckedChanged += (@s, e) =>
                {
                    txtRltRep.Enabled = !chbRltDelete.Checked;
                    ApplyRltChanges();
                };

            // Add/Remove
            btnRltAdd.Click += (@s, e) =>
                {
                    String nname = "New Rule #" +
                            libWyvernzora.Core.DirectIntConv.ToHexString(Configuration.Random.Next(), 8)
                            .Substring(2);

                    RenamingRule rule = new RenamingRule() {Name = nname, Type = RenamingRule.RuleType.Name, RegularExpression = "", ReplacementExpression = ""};
                    Configuration.Instance.Rules.Add(nname, rule);
                    UpdateRuleTemplateList(nname);
                    txtRltName.Select();
                    txtRltName.SelectAll();
                };
            btnRltRemove.Click += (@s, e) =>
            {
                RenamingRule rule = lbRlt.SelectedItem as RenamingRule;
                if (rule == null) return;

                Configuration.Instance.Rules.Remove(rule.Name);
                UpdateRuleTemplateList();
            };
        }

        private void ShowRule(RenamingRule rule)
        {
            txtRltName.Text = rule.Name;
            switch (rule.Type)
            {
                case RenamingRule.RuleType.Name:
                    radRltName.Checked = true;
                    break;
                case RenamingRule.RuleType.Extension:
                    radRltExt.Checked = true;
                    break;
                default:
                    radRltDir.Checked = true;
                    break;
            }

            txtRltRegex.Text = rule.RegularExpression;
            txtRltRep.Text = rule.ReplacementExpression;

            chbRltDelete.Checked = rule.DeleteFile;
        }

        private void UpdateRuleTemplateList(String selection = null)
        {
            // Action Lock to make sure BeginUpdate and EndUpdate are both called =w=
            using (new ActionLock(lbRlt.BeginUpdate, lbRlt.EndUpdate))
            {
                lbRlt.Items.Clear();
                foreach (var v in Configuration.Instance.Rules.Values)
                {
                    lbRlt.Items.Add(v);
                    if (Configuration.StringComparer.Equals(v.Name, selection))
                        lbRlt.SelectedItem = v;
                }
            }

            if (selection == null)
                lbRlt.SelectedItem = null;

            if (lbRlt.Items.Count == 0 || lbRlt.SelectedItem == null)
            {
                txtRltName.Clear();
                txtRltRegex.Clear();
                txtRltRep.Clear();
                radRltName.Checked = true;
                gbRltOptions.Enabled = false;
            }
        }

        private Boolean ApplyRltChanges()
        {
            error.Clear();

            RenamingRule oldr = (RenamingRule)lbRlt.SelectedItem;
            RenamingRule newr = GetRuleFromUi();

            // Validate Data
            if (String.IsNullOrWhiteSpace(newr.Name))
            {
                error.SetError(txtRltName, "Rule name cannot be empty or all whitespaces!");
                return true;
            }

            // Check duplicates
            if (!Configuration.StringComparer.Equals(oldr.Name, newr.Name)
                && Configuration.Instance.Rules.ContainsKey(newr.Name))
            {
                DialogResult dr = MessageBox.Show(
                    "There is already a rule with exactly the same name.\nDo you want to overwrite it?",
                    "Overwrite?!", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.No) return false;
                else if (dr == DialogResult.Cancel) return true;
            }

            Configuration.Instance.Rules.Remove(oldr.Name);
            Configuration.Instance.Rules.Add(newr.Name, newr);
            UpdateRuleTemplateList(newr.Name);
            return false;
        }

        private RenamingRule GetRuleFromUi()
        {
            RenamingRule rule = new RenamingRule
                {
                    Name = txtRltName.Text,
                    RegularExpression = txtRltRegex.Text,
                    ReplacementExpression = txtRltRep.Text,
                    DeleteFile = chbRltDelete.Checked,
                    Type = radRltName.Checked
                               ? RenamingRule.RuleType.Name
                               : radRltExt.Checked
                                     ? RenamingRule.RuleType.Extension
                                     : RenamingRule.RuleType.Directory
                };

            return rule;
        }

        #endregion
    }
}
