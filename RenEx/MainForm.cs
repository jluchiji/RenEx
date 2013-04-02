using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using libWyvernzora.IO;
using System.Xml;

namespace RenEx
{
    public partial class MainForm : Form
    {
        private const String CONFIG_FILE = "renex.cfg";

        public MainForm()
        {
            // Load Configuration
            String configPath = Path.Combine(Application.StartupPath, CONFIG_FILE);
            if (!File.Exists(configPath))
            {
                var cfg = Configuration.Instance; // Force creation of a new instance
                using (var xw = XmlWriter.Create(configPath, new XmlWriterSettings() {Indent = true}))
                {
                    ConfigFileLoader.SaveConfiguration(cfg, xw);
                }
            } else 
                Configuration.LoadConfiguration(configPath);

            // Initialize session stuff
            DirectoryRules = new List<RenamingRule>();
            NameRules = new List<RenamingRule>();
            ExtensionRules = new List<RenamingRule>();
            Files = new List<String>();

            InitializeComponent();
            UIEventHandlers();
            RenamingTabAttachEventHandlers();


            // Main Menu Events
            tsmiAbout.Click += (@s, e) => (new AboutDialog()).ShowDialog();
            tsmiAddFiles.Click += (@s, e) =>
                {
                    OpenFileDialog dlg = new OpenFileDialog() {Multiselect = true};
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        AddFiles(dlg.FileNames);   
                    }
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
            tsmiClearAll.Click += (@s, e) =>
                {
                    Files.Clear();
                    NameRules.Clear();
                    ExtensionRules.Clear();
                    DirectoryRules.Clear();

                    UpdateUI();
                };
            tsmiOptions.Click += (@s, e) =>
                {
                    OptionsDialog dlg = new OptionsDialog();
                    dlg.ShowDialog();
                    UpdateUI();
                };
            // UI Maintenance

            UpdateUI();
        }

        #region Static Methods (Global to application)

        public static void SaveConfiguration()
        {
            // Load Configuration
            String configPath = Path.Combine(Application.StartupPath, CONFIG_FILE);
            var cfg = Configuration.Instance;
            using (var xw = XmlWriter.Create(configPath, new XmlWriterSettings() {Indent = true}))
            {
                ConfigFileLoader.SaveConfiguration(cfg, xw);
            }
        }

        #endregion

        #region Session Data and Core Renaming Methods

        public List<String> Files { get; private set; }

        public List<RenamingRule> DirectoryRules { get; private set; }
        public List<RenamingRule> NameRules { get; private set; }
        public List<RenamingRule> ExtensionRules { get; private set; }

        public Dictionary<String, String> RenameResult { get; private set; } 


        private void AddFiles(IEnumerable<String> fileNames)
        {
            Files.AddRange(fileNames.Where(t => !Files.Contains(t)));
            UpdatePreview();
        }

        private FileNameDescriptor TransformSingle(FileNameDescriptor f)
        {
            Configuration.ExtensionConfig extConfig =
                Configuration.Instance.ExtensionConfigs[Configuration.Instance.CurrentExtensionSettings];

            // Clone old one
            FileNameDescriptor fds = new FileNameDescriptor(f.ToString(), extConfig.MaximumExtensions, extConfig.Validator);

            try
            {
                // Run Name Rules
                foreach (RenamingRule rule in NameRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(f.FileName, rule.RegularExpression, RegexOptions.IgnoreCase);
                    if (!match.Success) continue;

                    fds.FileName = match.Result(rule.ReplacementExpression);
                    break;
                }

                // Run Extension Rules
                foreach (RenamingRule rule in ExtensionRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(f.Extensions, rule.RegularExpression, RegexOptions.IgnoreCase);
                    if (!match.Success) continue;

                    fds.Extensions = match.Result(rule.ReplacementExpression);
                    break;
                }

                // Run Directory Rules
                foreach (RenamingRule rule in DirectoryRules.Where(r => r.Active))
                {
                    Match match = Regex.Match(f.Directory, rule.RegularExpression, RegexOptions.IgnoreCase);
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
            Configuration.ExtensionConfig extConfig =
            Configuration.Instance.ExtensionConfigs[Configuration.Instance.CurrentExtensionSettings];

            // Build Renaming List
            var renaming = new List<KeyValuePair<FileNameDescriptor, FileNameDescriptor>>();
            for (int i = 0; i < Files.Count; i++)
            {
                FileNameDescriptor original = new FileNameDescriptor(Files[i], extConfig.MaximumExtensions, extConfig.Validator);
                FileNameDescriptor destination = TransformSingle(original);

                // Fetch results if available

                // Skip file if it is already applied
                if (RenameResult != null && RenameResult.ContainsKey(original.ToString()) && RenameResult[original.ToString()] == null)
                    continue;

                // Add file if it is modified by a rule
                if (!StringComparer.InvariantCultureIgnoreCase.Equals(original.ToString(), destination.ToString()))
                    renaming.Add(new KeyValuePair<FileNameDescriptor, FileNameDescriptor>(original, destination));
            }

            
            ProcessingDialog dlg = new ProcessingDialog(renaming.ToArray());
            dlg.ShowDialog();

            if (RenameResult == null) RenameResult = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            foreach (var v in dlg.RenameResult) RenameResult[v.Key] = v.Value;
            UpdatePreview();
        }

        #endregion

        #region UI Maintenance

        private void UIEventHandlers()
        {
            // Drag Drop Files
            lvPreview.DragEnter += (@s, a) =>
                {
                    if (a.Data.GetDataPresent(DataFormats.FileDrop))
                        a.Effect = DragDropEffects.Link;
                };
            lvPreview.DragDrop += (@s, e) =>
                {
                    String[] files = (String[]) e.Data.GetData(DataFormats.FileDrop);
                    AddFiles(files);
                };

            // Resize
            lvPreview.Resize += (@s, a) =>
            {
                Int32 width = (lvPreview.Width - 32) / 2;
                lvPreview.Columns[0].Width = width;
                lvPreview.Columns[1].Width = width;
            };
            lvPreview.KeyDown += (@s, e) =>
                {
                    if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
                    {
                        foreach (ListViewItem i in lvPreview.Items)
                            i.Selected = true;
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        ListViewItem[] items = new ListViewItem[lvPreview.SelectedItems.Count];
                        lvPreview.SelectedItems.CopyTo(items, 0);

                        foreach (FileNameDescriptor fds in items.Select(f => f.Tag).OfType<FileNameDescriptor>())
                        {
                            Files.RemoveAll(t => StringComparer.InvariantCultureIgnoreCase.Equals(fds.ToString(), t));
                        }

                        UpdatePreview();
                    }
                };
            

            // Context Menus
            lvPreview.ItemSelectionChanged += (@s, e) =>
                {
                    Int32 count = lvPreview.SelectedItems.Count;

                    tsmiPvRemSelection.Enabled = count > 0;
                    tsmiPvExtractRule.Enabled = count == 1;
                };
            lvRules.ItemSelectionChanged += (@s, e) =>
                {
                    Int32 count = lvRules.SelectedItems.Count;

                    tsmiRemoveRules.Enabled = count > 0;
                    tsmiAddToTemplates.Enabled = count == 1;
                };
            tsmiAddRule.Click += (@s, e) =>
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
            tsmiRemoveRules.Click += (@s, e) =>
                {
                    ListViewItem[] selection = new ListViewItem[lvRules.SelectedItems.Count];
                    lvRules.SelectedItems.CopyTo(selection, 0);

                    foreach (RenamingRule rule in selection.Select(v => v.Tag).OfType<RenamingRule>())
                    {
                        if (rule.Type == RenamingRule.RuleType.Name)
                            NameRules.Remove(rule);
                        else if (rule.Type == RenamingRule.RuleType.Extension)
                            ExtensionRules.Remove(rule);
                        else
                            DirectoryRules.Remove(rule);
                    }

                    UpdateUI();
                };
            tsmiPvAddFiles.Click += (@s, e) =>
                {
                    OpenFileDialog dlg = new OpenFileDialog() { Multiselect = true };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        AddFiles(dlg.FileNames);
                    }
                };
            tsmiPvRemSelection.Click += (@s, e) =>
                {
                    ListViewItem[] items = new ListViewItem[lvPreview.SelectedItems.Count];
                    lvPreview.SelectedItems.CopyTo(items, 0);

                    foreach (FileNameDescriptor fds in items.Select(f => f.Tag).OfType<FileNameDescriptor>())
                    {
                        Files.RemoveAll(t => StringComparer.InvariantCultureIgnoreCase.Equals(fds.ToString(), t));
                    }

                    UpdatePreview();
                };
            tsmiPvExtractRule.Click += (@s, e) =>
                {
                    FileNameDescriptor fds = lvPreview.SelectedItems[0].Tag as FileNameDescriptor;
                    if (fds == null) return;

                    RenamingRule rule = new RenamingRule();
                    rule.Type = RenamingRule.RuleType.Name;
                    rule.RegularExpression = Regex.Escape(fds.FileName).Replace("\\ ", " ");
                    rule.ReplacementExpression = String.Format("{0}{1}", Path.GetFileNameWithoutExtension(fds.Directory), "[${i}]");

                    RuleEditorDialog dlg = new RuleEditorDialog(this);
                    dlg.Rule = rule;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        rule = dlg.Rule;
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
            tsmiPvRemApplied.Click += (@s, e) =>
                {
                    List<String> items = new List<string>();
                    items.AddRange(from f in Files where RenameResult.ContainsKey(f) && RenameResult[f] == null select f);
                    foreach (var v in items) Files.Remove(v);
                    RenameResult.Clear();
                    UpdatePreview();
                };

            // RUN RENAMING
            renBtnRunRename.Click += (@s, a) => ApplyRenaming();
        }

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

            Configuration.ExtensionConfig extConfig =
                Configuration.Instance.ExtensionConfigs[Configuration.Instance.CurrentExtensionSettings];


            foreach (var f in (from s in Files select new FileNameDescriptor(s, extConfig.MaximumExtensions, extConfig.Validator)))
            {
                ListViewItem lvi = new ListViewItem(FileDescriptorToString(f));
                FileNameDescriptor preview = TransformSingle(f);


                if (RenameResult != null && RenameResult.ContainsKey(f.ToString()))
                {
                    String result = RenameResult[f.ToString()];
                    if (result == null)
                    {
                        // Successfully applied
                        lvi.ImageKey = "Applied";
                        lvi.SubItems.Add("Successfully applied.");
                    }
                    else
                    {
                        // Applied with errors
                        lvi.ImageKey = "Error";
                        lvi.SubItems.Add("Error: " + result);
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

                lvi.Tag = f;
                lvPreview.Items.Add(lvi);

            }
                lvPreview.EndUpdate();
        }

        private void UpdateMenus()
        {
            // Update Extension Settings Menu
            tsmiExtSettings.DropDownItems.Clear();
            foreach (var v in Configuration.Instance.ExtensionConfigs)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(v.Key) {Tag = v.Value};
                if (StringComparer.InvariantCultureIgnoreCase.Equals(v.Key,
                                                                     Configuration.Instance.CurrentExtensionSettings))
                    tsmi.Checked = true;
                tsmi.Click += ExtensionSettingsMenuClick;
                tsmiExtSettings.DropDownItems.Add(tsmi);
            }

        }

        private void UpdateUI()
        {
            UpdateRuleList();
            UpdatePreview();
            UpdateMenus();
        }
       
        private String FileDescriptorToString(FileNameDescriptor f)
        {
            String s = f.FileName;
            if (tsmiShowExtInPrev.Checked) s += f.Extensions;
            if (tsmiFillPathInPrev.Checked) s = f.ToString();
            return s;
        }


        private void ExtensionSettingsMenuClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;
            Configuration.ExtensionConfig config = item.Tag as Configuration.ExtensionConfig;
            if (config == null) return;

            // Check the item while unchecking all others
            foreach (ToolStripMenuItem v in tsmiExtSettings.DropDownItems)
                v.Checked = v == item;

            // Apply new preset
            Configuration.Instance.CurrentExtensionSettings = config.Name;
            UpdatePreview();
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
            renBtnRemoveRule.Click += (@s, e) =>
                {
                    ListViewItem[] selection = new ListViewItem[lvRules.SelectedItems.Count];
                    lvRules.SelectedItems.CopyTo(selection, 0);

                    foreach (RenamingRule rule in selection.Select(v => v.Tag).OfType<RenamingRule>())
                    {
                        if (rule.Type == RenamingRule.RuleType.Name)
                            NameRules.Remove(rule);
                        else if (rule.Type == RenamingRule.RuleType.Extension)
                            ExtensionRules.Remove(rule);
                        else
                            DirectoryRules.Remove(rule);
                    }

                    UpdateUI();
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
    }
}
