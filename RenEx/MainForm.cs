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
            RenameResult = new Dictionary<String, RenExFileNameDescriptor>();
            Rules = new RenamingRuleCollection();
            Files = new List<string>();

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
                    RenameResult.Clear();
                    Rules.NameRules.Clear();
                    Rules.ExtensionRules.Clear();
                    Rules.DirectoryRules.Clear();

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

        public List<String> Files { get; private set; }

        public RenamingRuleCollection Rules { get; private set; }

        public Dictionary<String, RenExFileNameDescriptor> RenameResult { get; private set; }
        

        private void AddFiles(IEnumerable<String> fileNames)
        {
            Files.AddRange(fileNames.Where(t => !Files.Contains(t)));
            UpdatePreview();
        }
        
        private void ApplyRenaming()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;

            bw.DoWork += (@s, e) =>
                {
                    Configuration.ExtensionConfig config =
                        Configuration.Instance.ExtensionConfigs[Configuration.Instance.CurrentExtensionSettings];
                    
                    // Rename Files
                    for (int i = 0; i < Files.Count; i++)
                    {
                        if (bw.CancellationPending) break;

                        String fname = Files[i];

                        if (RenameResult.ContainsKey(fname) && RenameResult[fname].IsApplied)
                            continue;

                        RenExFileNameDescriptor descriptor = new RenExFileNameDescriptor(fname, config.MaximumExtensions,
                                                                                         config.Validator);
                        RenExFileNameDescriptor destination = Rules.TransformSingle(descriptor);

                        try
                        {

                            int progress = (int) ((double) i / Files.Count * 100);
                            bw.ReportProgress(progress, descriptor.FileName);

                            if (destination.MarkForDelete)
                                File.Delete(descriptor.ToString());
                            else
                            {
                                if (!Directory.Exists(destination.Directory))
                                    Directory.CreateDirectory(destination.Directory);
                                File.Move(descriptor.ToString(), destination.ToString());
                            }

                            destination.IsApplied = true;
                        }
                        catch (Exception x)
                        {
                            destination.ErrorObject = x;
                        }

                        RenameResult[descriptor.ToString()] = destination;
                    }
                };

            bw.ProgressChanged += (@s, e) =>
                {
                    pbProgress.Value = e.ProgressPercentage;
                };

            bw.RunWorkerCompleted += (@s, e) =>
                {
                    pbProgress.Value = 0;
                    splitContainer1.Enabled = true;
                    menuStrip1.Enabled = true;
                    UpdatePreview();
                };

            splitContainer1.Enabled = false;
            menuStrip1.Enabled = false;

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

                        foreach (
                            RenExFileNameDescriptor fds in items.Select(f => f.Tag).OfType<RenExFileNameDescriptor>())
                        {
                            RenameResult.Remove(fds.ToString());
                            Files.RemoveAll(f => f.Equals(fds.ToString()));
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
                        Rules.AddRule(rule);
                    }
                };
            tsmiRemoveRules.Click += (@s, e) =>
                {
                    ListViewItem[] selection = new ListViewItem[lvRules.SelectedItems.Count];
                    lvRules.SelectedItems.CopyTo(selection, 0);

                    foreach (RenamingRule rule in selection.Select(v => v.Tag).OfType<RenamingRule>())
                    {
                        if (rule.Type == RenamingRule.RuleType.Name)
                            Rules.NameRules.Remove(rule);
                        else if (rule.Type == RenamingRule.RuleType.Extension)
                            Rules.ExtensionRules.Remove(rule);
                        else
                            Rules.DirectoryRules.Remove(rule);
                    }

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
                    {
                        AddFiles(dlg.FileNames);
                    }
                };
            tsmiPvRemSelection.Click += (@s, e) =>
                {
                    ListViewItem[] items = new ListViewItem[lvPreview.SelectedItems.Count];
                    lvPreview.SelectedItems.CopyTo(items, 0);

                    foreach (RenExFileNameDescriptor fds in items.Select(f => f.Tag).OfType<RenExFileNameDescriptor>())
                        RenameResult.Remove(fds.ToString());

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
                                    Rules.NameRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Extension:
                                {
                                    Rules.ExtensionRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Directory:
                                {
                                    Rules.DirectoryRules.Add(rule);
                                }
                                break;
                        }

                        UpdateUI();
                    }


                };
            tsmiPvRemApplied.Click += (@s, e) =>
                {
                    List<String> items = new List<string>();
                    items.AddRange(from f in RenameResult where RenameResult.ContainsKey(f.ToString()) && RenameResult[f.ToString()].ErrorObject == null select f.ToString());
                    foreach (var v in items) RenameResult.Remove(v);
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
            foreach (ListViewItem lvi in Rules.NameRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgName"];
                lvRules.Items.Add(lvi);
            }

            foreach (ListViewItem lvi in Rules.ExtensionRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
            {
                lvi.Group = lvRules.Groups["lvgExt"];
                lvRules.Items.Add(lvi);
            }

            foreach (ListViewItem lvi in Rules.DirectoryRules.Select(item => new ListViewItem(new[] { item.Name, item.Type.ToString() }) { Checked = item.Active, Tag = item }))
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

                // Add Items
                foreach (
                    var f in
                        (from s in Files
                         select new RenExFileNameDescriptor(s, extConfig.MaximumExtensions, extConfig.Validator)))
                {
                    // Create the item
                    ListViewItem item = new ListViewItem(FileDescriptorToString(f)) { Tag = f };
                    RenExFileNameDescriptor preview = Rules.TransformSingle(f);

                    // Determine the item status
                    if (RenameResult != null && RenameResult.ContainsKey(f.ToString()))
                    {
                        // The file is already in the result list, get the result
                        RenExFileNameDescriptor result = RenameResult[f.ToString()];

                        // Having the file in the renaming results means it was applied
                        if (result.ErrorObject != null)
                        {
                            // Applied with error
                            item.ImageKey = "Error";
                            item.SubItems.Add("Error: " + result.ErrorObject.Message);
                        }
                        else
                        {
                            // Successfully Applied
                            item.ImageKey = "Applied";
                            item.SubItems.Add("Successfully applied.");
                        }
                    }
                    else if (f.Equals(preview))
                    {
                        // No rule matched since preview was not modified.
                        item.SubItems.Add("No rule matched this file.");
                    }
                    else if (preview.ErrorObject != null)
                    {
                        // There is an error attached to the preview
                        item.SubItems.Add("An error occured.");
                        item.ImageKey = "Warning";
                    }
                    else if (preview.MarkForDelete)
                    {
                        // File is marked for deletion
                        item.SubItems.Add("The file will be deleted.");
                        item.ImageKey = "Delete";
                    }
                    else
                    {
                        // Everything OK, ready to rename
                        item.ImageKey = "OK";
                        item.SubItems.Add(FileDescriptorToString(preview));
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

        private void AddTemplateRUleMenuClick(Object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi == null) return;
            RenamingRule rule = tsmi.Tag as RenamingRule;
            if (rule == null) return;

            Rules.AddRule(rule);
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
                                    Rules.NameRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Extension:
                                {
                                    Rules.ExtensionRules.Add(rule);
                                }
                                break;
                            case RenamingRule.RuleType.Directory:
                                {
                                    Rules.DirectoryRules.Add(rule);
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
                            Rules.NameRules.Remove(rule);
                        else if (rule.Type == RenamingRule.RuleType.Extension)
                            Rules.ExtensionRules.Remove(rule);
                        else
                            Rules.DirectoryRules.Remove(rule);
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
