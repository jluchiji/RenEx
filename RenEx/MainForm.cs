using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using libWyvernzora.IO;

namespace RenEx
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // Initialize session stuff
            DirectoryRules = new List<RenamingRule>();
            NameRules = new List<RenamingRule>();
            ExtensionRules = new List<RenamingRule>();
            Files = new List<String>();

            InitializeComponent();
            RenamingTabAttachEventHandlers();
            OptionsTabAttachEventHandlers();

            // Main Menu Events
            tsmiAbout.Click += (@s, e) => (new AboutDialog()).ShowDialog();
            tsmiAddFiles.Click += (@s, e) =>
                {
                    OpenFileDialog dlg = new OpenFileDialog() {Multiselect = true};
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Files.AddRange(dlg.FileNames.Where(t => !Files.Contains(t)));
                    }
                    UpdateUI();
                };
            tsmiShowExtInPrev.Click += (@s, a) =>
                {
                    tsmiShowExtInPrev.Checked = !tsmiShowExtInPrev.Checked;
                    UpdatePreview();
                };
            tsmiFillPathInPrev.Click += (@s, a) =>
                {
                    tsmiFillPathInPrev.Checked = !tsmiFillPathInPrev.Checked;
                    UpdatePreview();
                };

            // UI Maintenance
            lvPreview.Resize += (@s, a) =>
                {
                    Int32 width = (lvPreview.Width - 32) / 2;
                    lvPreview.Columns[0].Width = width;
                    lvPreview.Columns[1].Width = width;
                };
            renBtnRunRename.Click += (@s, a) => ApplyRenaming();

        }

        #region Session Data and Core Renaming Methods

        public IFileExtValidator ExtensionValidator
        {
            get
            {
                if (optRadValidateLength.Checked)
                    return new FileExtLengthValidator((Int32)optNudValLenMin.Value, (Int32)optNudValLenMax.Value);
                else
                    return new FileExtListValidator(from d in optTxtExtList.Text.Split(';') select d.Trim(' '));
            }
        }

        public List<String> Files { get; private set; }

        public List<RenamingRule> DirectoryRules { get; private set; }
        public List<RenamingRule> NameRules { get; private set; }
        public List<RenamingRule> ExtensionRules { get; private set; }

        public KeyValuePair<String, String>[] RenameResult { get; private set; } 


        private FileNameDescriptor TransformSingle(FileNameDescriptor f)
        {
            // Clone old one
            FileNameDescriptor fds = new FileNameDescriptor(f.ToString(), (Int32)optNudMaxExt.Value, ExtensionValidator);

            try
            {
                // Run Name Rules
                foreach (RenamingRule rule in NameRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(f.FileName, rule.RegularExpression);
                    if (!match.Success) continue;

                    fds.FileName = match.Result(rule.ReplacementExpression);
                    break;
                }

                // Run Extension Rules
                foreach (RenamingRule rule in ExtensionRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(f.Extensions, rule.RegularExpression);
                    if (!match.Success) continue;

                    fds.Extensions = match.Result(rule.ReplacementExpression);
                    break;
                }

                // Run Directory Rules
                foreach (RenamingRule rule in DirectoryRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(f.Directory, rule.RegularExpression);
                    if (!match.Success) continue;

                    fds.Directory = match.Result(rule.ReplacementExpression);
                    break;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return StringComparer.InvariantCultureIgnoreCase.Equals(f.ToString(), fds.ToString()) ? f : fds;
        }

        private void ApplyRenaming()
        {
            // Get Parameters
            Int32 maxExt = (Int32) optNudMaxExt.Value;
            IFileExtValidator validator = ExtensionValidator;

            // Build Renaming List
            var renaming = new List<KeyValuePair<FileNameDescriptor, FileNameDescriptor>>();
            for (int i = 0; i < Files.Count; i++)
            {
                FileNameDescriptor original = new FileNameDescriptor(Files[i], maxExt, validator);
                FileNameDescriptor destination = TransformSingle(original);

                // Fetch results if available
                KeyValuePair<String, String>? result = null;
                if (RenameResult != null)
                    result = RenameResult.FirstOrDefault(
                        t => StringComparer.InvariantCultureIgnoreCase.Equals(t.Key, original.ToString()));

                // Skip file if it is already applied
                if (result.HasValue && result.Value.Value == null) continue;

                // Add file if it is modified by a rule
                if (!StringComparer.InvariantCultureIgnoreCase.Equals(original.ToString(), destination.ToString()))
                    renaming.Add(new KeyValuePair<FileNameDescriptor, FileNameDescriptor>(original, destination));
            }

            
            ProcessingDialog dlg = new ProcessingDialog(renaming.ToArray());
            dlg.ShowDialog();

            RenameResult = dlg.RenameResult;
            UpdatePreview();
        }

        #endregion

        #region UI Maintenance

        private void UpdateRuleList()
        {
            lvRules.BeginUpdate();

            lvRules.Items.Clear();
            foreach (ListViewItem lvi in NameRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgName"];
                lvRules.Items.Add(lvi);
            }

            foreach (ListViewItem lvi in ExtensionRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgExt"];
                lvRules.Items.Add(lvi);
            }

            foreach (ListViewItem lvi in DirectoryRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgDir"];
                lvRules.Items.Add(lvi);
            }

            lvRules.EndUpdate();
        }

        private void UpdatePreview()
        {
            lvPreview.BeginUpdate();
            lvPreview.Items.Clear();

            IFileExtValidator validator = ExtensionValidator;
            
            foreach (var f in (from s in Files select new FileNameDescriptor(s, (Int32)optNudMaxExt.Value, validator)))
            {
                ListViewItem lvi = new ListViewItem(FileDescriptorToString(f));
                FileNameDescriptor preview = TransformSingle(f);

                // Fetch results if available
                KeyValuePair<String, String>? result = null;
                if (RenameResult != null)
                    result = RenameResult.FirstOrDefault(
                        t => StringComparer.InvariantCultureIgnoreCase.Equals(t.Key, f.ToString()));


                if (result.HasValue)
                {
                    if (result.Value.Value == null)
                    {
                        // Successfully applied
                        lvi.ImageKey = "Applied";
                        lvi.SubItems.Add("Successfully applied.");
                    }
                    else
                    {
                        // Applied with errors
                        lvi.ImageKey = "Error";
                        lvi.SubItems.Add("Error: " + result.Value.Value);
                    }
                }
                else if (f.Equals(preview))
                {
                    lvi.SubItems.Add("No rule matches this file.");
                    //lvi.BackColor = Color.Moccasin;
                }
                else if (preview != null)
                {
                    lvi.SubItems.Add(FileDescriptorToString(preview));
                    lvi.ImageKey = "OK";
                    //lvi.BackColor = Color.LightGreen;
                }
                else
                {
                    lvi.SubItems.Add("An error occured.");
                    lvi.ImageKey = "Warning";
                    //lvi.BackColor = Color.LightPink;
                }

                lvPreview.Items.Add(lvi);

                lvPreview.EndUpdate();
            }
        }

        private void UpdateUI()
        {
            UpdateRuleList();
            UpdatePreview();
        }
        

        private String FileDescriptorToString(FileNameDescriptor f)
        {
            String s = f.FileName;
            if (tsmiShowExtInPrev.Checked) s += f.Extensions;
            if (tsmiFillPathInPrev.Checked) s = f.ToString();
            return s;
        }

        #endregion

        #region Renaming Tab

        private void RenamingTabAttachEventHandlers()
        {
            renBtnAddRule.Click += (@s, e) =>
                {
                    RuleEditorDialog dlg = new RuleEditorDialog(this);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        RenamingRule rule = dlg.Rule;
                        rule.Active = true;

                        switch (rule.Type)
                        {
                            case RenamingRule.RuleType.Name:
                                {
                                    NameRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Extension:
                                {
                                    ExtensionRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Directory:
                                {
                                    DirectoryRules.Add(rule);
                                }
                                break;
                        }

                        UpdateUI();
                    }
                };
            lvRules.ItemChecked += (@s, a) =>
                {
                    RenamingRule rule = a.Item.Tag as RenamingRule;
                    if (rule == null) return;

                    if (rule.Active != a.Item.Checked)
                    {
                        rule.Active = a.Item.Checked;
                        UpdatePreview();
                    }
                };
        }

        #endregion

        #region Options Tab

        private void OptionsTabAttachEventHandlers()
        {
            optRadValidateLength.CheckedChanged += (@s, e) =>
                {
                    optPnlValLenOptions.Enabled = optRadValidateLength.Checked;
                };
            optRadValidateList.CheckedChanged += (@s, e) =>
                {
                    optTxtExtList.Enabled = optRadValidateList.Checked;
                };
            optBtnApply.Click += (@s, a) => UpdatePreview();
        }

        #endregion
    }
}
