using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using libWyvernzora.Core;
using libWyvernzora.IO;
using System.Xml;
using libWyvernzora.Utilities;

namespace RenEx
{
    public partial class MainForm : Form
    {
        private const String ConfigFile = "renex.cfg";

        public MainForm()
        {
            // Load Configuration
            String configPath = Path.Combine(Application.StartupPath, ConfigFile);
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
            Session = new RenamingSession();

            InitializeComponent();
            UIEventHandlers();
            RenamingTabAttachEventHandlers();


            // Main Menu Events
            tsmiAbout.Click += (@s, e) => (new AboutDialog()).ShowDialog();
            tsmiAddFiles.Click += (@s, e) =>
                {
                    OpenFileDialog dlg = new OpenFileDialog() { Multiselect = true };
                    if (dlg.ShowDialog() == DialogResult.OK)
                        Session.AddFile(dlg.FileNames);
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
                    Session.Clear();
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
            String configPath = Path.Combine(Application.StartupPath, ConfigFile);
            var cfg = Configuration.Instance;
            using (var xw = XmlWriter.Create(configPath, new XmlWriterSettings() {Indent = true}))
            {
                ConfigFileLoader.SaveConfiguration(cfg, xw);
            }
        }

        #endregion

        #region Session Data and Core Renaming Methods

        public RenamingSession Session { get; private set; }

        private void ApplyRenaming()
        {
            // Notify user if there are warnings
            if (Session.HasWarnings && MessageBox.Show("Your renaming session has warnings!\nDo you wish to ignore them and continue?", "Session has warnings!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            // Lock UI
            menuStrip1.Enabled = false;
            splitContainer1.Enabled = false;

            // Apply
            BackgroundWorker bw = new BackgroundWorker() { WorkerReportsProgress = true };
            bw.DoWork += (@s, e) => Session.ApplyRenaming(bw.ReportProgress);
            bw.ProgressChanged += (@s, e) => pbProgress.Value = e.ProgressPercentage;
            bw.RunWorkerCompleted += (@s, e) =>
                {
                    menuStrip1.Enabled = true;
                    splitContainer1.Enabled = true;
                    pbProgress.Value = 0;
                    UpdateUI();
                };
            bw.RunWorkerAsync();
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
                    Session.AddFile(files);
                    UpdatePreview();
                };

            // Resize
            lvPreview.Resize += (@s, a) =>
            {
                Int32 width = (lvPreview.Width - 48) / 2;
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

                        Session.RemoveFiles(from i in items select (String)i.Tag);
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
                        Session.Rules.AddRule(rule);
                    }
                };
            tsmiRemoveRules.Click += (@s, e) =>
                {
                    ListViewItem[] selection = new ListViewItem[lvRules.SelectedItems.Count];
                    lvRules.SelectedItems.CopyTo(selection, 0);

                    foreach (RenamingRule rule in selection.Select(v => v.Tag).OfType<RenamingRule>())
                        Session.Rules.RemoveRule(rule);

                    UpdateUI();
                };
            tsmiAddToTemplates.Click += (@s, e) =>
                {
                    RenamingRule rule = lvRules.SelectedItems[0].Tag as RenamingRule;
                    if (rule == null) throw new Exception();

                    OptionsDialog dlg = new OptionsDialog(1, rule);
                    dlg.ShowDialog();
                    UpdateUI();
                };
            tsmiPvAddFiles.Click += (@s, e) =>
                {
                    OpenFileDialog dlg = new OpenFileDialog() { Multiselect = true };
                    if (dlg.ShowDialog() == DialogResult.OK)
                        Session.AddFile(dlg.FileNames);
                };
            tsmiPvRemSelection.Click += (@s, e) =>
                {
                    ListViewItem[] items = new ListViewItem[lvPreview.SelectedItems.Count];
                    lvPreview.SelectedItems.CopyTo(items, 0);

                    Session.RemoveFiles(from i in items select (String)i.Tag);
                    UpdatePreview();
                };
            tsmiPvExtractRule.Click += (@s, e) =>
                {
                    String fname = lvPreview.SelectedItems[0].Tag as String;
                    if (fname == null) return;

                    var extConfig = Configuration.Instance.GetCurrentExtensionSettings();
                    var fds = new FileNameDescriptor(fname, extConfig.MaximumExtensions, extConfig.Validator);

                    RenamingRule rule = new RenamingRule
                        {
                            Type = RenamingRule.RuleType.Name,
                            RegularExpression = Regex.Escape(fds.FileName).Replace("\\ ", " "),
                            ReplacementExpression =
                                String.Format("{0}{1}", Path.GetFileNameWithoutExtension(fds.Directory), "[${i}]")
                        };

                    RuleEditorDialog dlg = new RuleEditorDialog(this) {Rule = rule};
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Session.Rules.AddRule(dlg.Rule);
                        UpdateUI();
                    }


                };
            tsmiPvRemApplied.Click += (@s, e) =>
                {
                    Session.RemoveApplied();
                    UpdatePreview();
                };

            // RUN RENAMING
            renBtnRunRename.Click += (@s, a) => ApplyRenaming();
        }

        private void UpdateRuleList()
        {
            lvRules.BeginUpdate();

            lvRules.Items.Clear();
            foreach (ListViewItem lvi in Session.Rules.NameRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgName"];
                lvRules.Items.Add(lvi);
            }

            foreach (ListViewItem lvi in Session.Rules.ExtensionRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgExt"];
                lvRules.Items.Add(lvi);
            }

            foreach (ListViewItem lvi in Session.Rules.DirectoryRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgDir"];
                lvRules.Items.Add(lvi);
            }

            lvRules.EndUpdate();
        }

        private void UpdatePreview()
        {
            using (new ActionLock(lvPreview.BeginUpdate, lvPreview.EndUpdate))
            {
                // Clear Items
                lvPreview.Items.Clear();

                // Get Active extension settings
                var extConfig = Configuration.Instance.ExtensionConfigs[Configuration.Instance.CurrentExtensionSettings];

                    // Update Analysis Rule
                Session.UpdatePreview(extConfig);

                // Add Items
                foreach (var file in Session)
                {
                    // Create ListViewItem
                    ListViewItem item = new ListViewItem(GetOriginalDisplayPath(file));
                    item.Tag = file.ToString();

                    if (file.State.HasFlag(RenExFileNameDescriptor.RenameState.Applied))
                    {   // Applied
                        if (file.State.HasFlag(RenExFileNameDescriptor.RenameState.Error))
                        {
                            item.ImageKey = "Error";
                            item.SubItems.Add("Error: " + file.ErrorObject.Message);
                        }
                        else
                        {
                            item.ImageKey = "Applied";
                            item.SubItems.Add("Successfully applied.");
                        }
                    }
                    else if (file.State.HasFlag(RenExFileNameDescriptor.RenameState.Preview))
                    {   // Not Applied
                        if (file.State.HasFlag(RenExFileNameDescriptor.RenameState.Error))
                        {
                            // Preview has an error
                            item.ImageKey = "Error";
                            item.SubItems.Add("Error: " + file.ErrorObject.Message);
                        }
                        else if (file.MarkForDelete)
                        {
                            // File is marked for deletion
                            item.SubItems.Add("The file will be deleted.");
                            item.ImageKey = "Delete";
                        }
                        else if (file.State.HasFlag(RenExFileNameDescriptor.RenameState.Warning))
                        {
                            // Preview has a warning
                            item.ImageKey = "Warning";
                            item.SubItems.Add("Warning: " + file.ErrorObject.Message);
                        }
                        else if (file.IsTransformed)
                        {
                            // Preview is OK
                            item.ImageKey = "OK";
                            item.SubItems.Add(GetTransformedDisplayPath(file));
                        }
                        else
                        {
                            item.SubItems.Add("No rule matches this file.");
                        }
                    }
                    
                    lvPreview.Items.Add(item);
                }
            }
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

            // Update Template Rule Menu
            tsmiAddFromTemplate.DropDownItems.Clear();
            foreach (ToolStripMenuItem tsmi in Configuration.Instance.Rules.Select(v => new ToolStripMenuItem(v.Key) {Tag=v.Value}))
            {
                tsmi.Click += AddTemplateRUleMenuClick;
                tsmiAddFromTemplate.DropDownItems.Add(tsmi);
            }
            if (tsmiAddFromTemplate.DropDownItems.Count == 0)
                tsmiAddFromTemplate.DropDownItems.Add(
                    new ToolStripMenuItem("(No Templates Available)") {Enabled = false});
        }

        private void UpdateUI()
        {
            UpdateRuleList();
            UpdatePreview();
            UpdateMenus();
        }
       
        private String GetOriginalDisplayPath(RenExFileNameDescriptor f)
        {
            String s = f.FileName;
            if (tsmiShowExtInPrev.Checked) s += f.Extensions;
            if (tsmiFillPathInPrev.Checked) s = f.ToString();
            return s;
        }

        private String GetTransformedDisplayPath(RenExFileNameDescriptor f)
        {
            String s = f.TransformedFileName;
            if (tsmiShowExtInPrev.Checked) s += f.TransformedExtensions;
            if (tsmiFillPathInPrev.Checked) s = f.TransformedFilePath;
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

        private void AddTemplateRUleMenuClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi == null) return;
            RenamingRule rule = tsmi.Tag as RenamingRule;
            if (rule == null) return;

            Session.Rules.AddRule(rule);
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
                                    Session.Rules.NameRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Extension:
                                {
                                    Session.Rules.ExtensionRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Directory:
                                {
                                    Session.Rules.DirectoryRules.Add(rule);
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
                            Session.Rules.NameRules.Remove(rule);
                        else if (rule.Type == RenamingRule.RuleType.Extension)
                            Session.Rules.ExtensionRules.Remove(rule);
                        else
                            Session.Rules.DirectoryRules.Remove(rule);
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
