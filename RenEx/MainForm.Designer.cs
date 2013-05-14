namespace RenEx
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Name Rules", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Extension Rules", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Directory Rules", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFillPathInPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowExtInPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExtSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.renBtnRemoveRule = new System.Windows.Forms.Button();
            this.renBtnRunRename = new System.Windows.Forms.Button();
            this.renBtnAddRule = new System.Windows.Forms.Button();
            this.lvRules = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsRuleList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddRule = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveRules = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddToTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lvPreview = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsPreviewList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPvAddFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPvAddDirs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPvRemSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPvRemApplied = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPvExtractRule = new System.Windows.Forms.ToolStripMenuItem();
            this.lvPreviewState = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsmiProjectHomepage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOnlineHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cmsRuleList.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsPreviewList.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tsmiView,
            this.tsmiTools,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddFiles,
            this.tsmiAddDir,
            this.toolStripMenuItem4,
            this.tsmiClearAll});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiAddFiles
            // 
            this.tsmiAddFiles.Name = "tsmiAddFiles";
            this.tsmiAddFiles.Size = new System.Drawing.Size(164, 22);
            this.tsmiAddFiles.Text = "Add Files...";
            // 
            // tsmiAddDir
            // 
            this.tsmiAddDir.Name = "tsmiAddDir";
            this.tsmiAddDir.Size = new System.Drawing.Size(164, 22);
            this.tsmiAddDir.Text = "Add Directories...";
            this.tsmiAddDir.Visible = false;
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(161, 6);
            // 
            // tsmiClearAll
            // 
            this.tsmiClearAll.Name = "tsmiClearAll";
            this.tsmiClearAll.Size = new System.Drawing.Size(164, 22);
            this.tsmiClearAll.Text = "Clear All";
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFillPathInPrev,
            this.tsmiShowExtInPrev});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(44, 20);
            this.tsmiView.Text = "View";
            // 
            // tsmiFillPathInPrev
            // 
            this.tsmiFillPathInPrev.Name = "tsmiFillPathInPrev";
            this.tsmiFillPathInPrev.Size = new System.Drawing.Size(218, 22);
            this.tsmiFillPathInPrev.Text = "Snow Full Path in Preview";
            // 
            // tsmiShowExtInPrev
            // 
            this.tsmiShowExtInPrev.Checked = true;
            this.tsmiShowExtInPrev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiShowExtInPrev.Name = "tsmiShowExtInPrev";
            this.tsmiShowExtInPrev.Size = new System.Drawing.Size(218, 22);
            this.tsmiShowExtInPrev.Text = "Show Extensions in Preview";
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExtSettings,
            this.toolStripSeparator1,
            this.tsmiOptions});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(48, 20);
            this.tsmiTools.Text = "Tools";
            // 
            // tsmiExtSettings
            // 
            this.tsmiExtSettings.Name = "tsmiExtSettings";
            this.tsmiExtSettings.Size = new System.Drawing.Size(169, 22);
            this.tsmiExtSettings.Text = "Extension Settings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.Name = "tsmiOptions";
            this.tsmiOptions.Size = new System.Drawing.Size(169, 22);
            this.tsmiOptions.Text = "Options...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProjectHomepage,
            this.tsmiOnlineHelp,
            this.tsmiBugReport,
            this.toolStripSeparator3,
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::RenEx.Properties.Resources.Info16;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(181, 22);
            this.tsmiAbout.Text = "About RenEx";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvPreview);
            this.splitContainer1.Panel2MinSize = 350;
            this.splitContainer1.Size = new System.Drawing.Size(784, 432);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(14, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.renBtnRemoveRule);
            this.tabPage1.Controls.Add(this.renBtnRunRename);
            this.tabPage1.Controls.Add(this.renBtnAddRule);
            this.tabPage1.Controls.Add(this.lvRules);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(340, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rules";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // renBtnRemoveRule
            // 
            this.renBtnRemoveRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.renBtnRemoveRule.Image = global::RenEx.Properties.Resources.Remove16;
            this.renBtnRemoveRule.Location = new System.Drawing.Point(41, 374);
            this.renBtnRemoveRule.Name = "renBtnRemoveRule";
            this.renBtnRemoveRule.Size = new System.Drawing.Size(27, 25);
            this.renBtnRemoveRule.TabIndex = 3;
            this.renBtnRemoveRule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.renBtnRemoveRule.UseVisualStyleBackColor = true;
            // 
            // renBtnRunRename
            // 
            this.renBtnRunRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renBtnRunRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.renBtnRunRename.Image = global::RenEx.Properties.Resources.Save16;
            this.renBtnRunRename.Location = new System.Drawing.Point(245, 374);
            this.renBtnRunRename.Name = "renBtnRunRename";
            this.renBtnRunRename.Size = new System.Drawing.Size(87, 25);
            this.renBtnRunRename.TabIndex = 2;
            this.renBtnRunRename.Text = "Run!";
            this.renBtnRunRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.renBtnRunRename.UseVisualStyleBackColor = true;
            // 
            // renBtnAddRule
            // 
            this.renBtnAddRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.renBtnAddRule.Image = global::RenEx.Properties.Resources.Add16;
            this.renBtnAddRule.Location = new System.Drawing.Point(7, 374);
            this.renBtnAddRule.Name = "renBtnAddRule";
            this.renBtnAddRule.Size = new System.Drawing.Size(27, 25);
            this.renBtnAddRule.TabIndex = 1;
            this.renBtnAddRule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.renBtnAddRule.UseVisualStyleBackColor = true;
            // 
            // lvRules
            // 
            this.lvRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRules.CheckBoxes = true;
            this.lvRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1});
            this.lvRules.ContextMenuStrip = this.cmsRuleList;
            this.lvRules.FullRowSelect = true;
            this.lvRules.GridLines = true;
            listViewGroup4.Header = "Name Rules";
            listViewGroup4.Name = "lvgName";
            listViewGroup5.Header = "Extension Rules";
            listViewGroup5.Name = "lvgExt";
            listViewGroup6.Header = "Directory Rules";
            listViewGroup6.Name = "lvgDir";
            this.lvRules.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.lvRules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRules.Location = new System.Drawing.Point(3, 3);
            this.lvRules.Name = "lvRules";
            this.lvRules.Size = new System.Drawing.Size(334, 364);
            this.lvRules.TabIndex = 0;
            this.lvRules.UseCompatibleStateImageBehavior = false;
            this.lvRules.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Rule Name";
            this.columnHeader4.Width = 217;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 81;
            // 
            // cmsRuleList
            // 
            this.cmsRuleList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddRule,
            this.tsmiRemoveRules,
            this.toolStripSeparator2,
            this.tsmiAddFromTemplate,
            this.tsmiAddToTemplates});
            this.cmsRuleList.Name = "cmsRuleList";
            this.cmsRuleList.Size = new System.Drawing.Size(181, 98);
            // 
            // tsmiAddRule
            // 
            this.tsmiAddRule.Image = global::RenEx.Properties.Resources.Add16;
            this.tsmiAddRule.Name = "tsmiAddRule";
            this.tsmiAddRule.Size = new System.Drawing.Size(180, 22);
            this.tsmiAddRule.Text = "Add Rule";
            // 
            // tsmiRemoveRules
            // 
            this.tsmiRemoveRules.Enabled = false;
            this.tsmiRemoveRules.Image = global::RenEx.Properties.Resources.Remove16;
            this.tsmiRemoveRules.Name = "tsmiRemoveRules";
            this.tsmiRemoveRules.Size = new System.Drawing.Size(180, 22);
            this.tsmiRemoveRules.Text = "Remove Rule(s)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiAddFromTemplate
            // 
            this.tsmiAddFromTemplate.Name = "tsmiAddFromTemplate";
            this.tsmiAddFromTemplate.Size = new System.Drawing.Size(180, 22);
            this.tsmiAddFromTemplate.Text = "Add From Template";
            // 
            // tsmiAddToTemplates
            // 
            this.tsmiAddToTemplates.Enabled = false;
            this.tsmiAddToTemplates.Name = "tsmiAddToTemplates";
            this.tsmiAddToTemplates.Size = new System.Drawing.Size(180, 22);
            this.tsmiAddToTemplates.Text = "Add To Templates";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(340, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Automagical™ Analysis";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(18, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 348);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 42);
            this.label4.TabIndex = 1;
            this.label4.Text = "This part involves lots of black magic...\r\nThe developer is summoning demons as w" +
    "e speak...\r\nSo please be patient, magic will be here soon.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RenEx.Properties.Resources.Nargacuga;
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 286);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lvPreview
            // 
            this.lvPreview.AllowDrop = true;
            this.lvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lvPreview.ContextMenuStrip = this.cmsPreviewList;
            this.lvPreview.FullRowSelect = true;
            this.lvPreview.GridLines = true;
            this.lvPreview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPreview.LargeImageList = this.lvPreviewState;
            this.lvPreview.Location = new System.Drawing.Point(3, 3);
            this.lvPreview.Name = "lvPreview";
            this.lvPreview.Size = new System.Drawing.Size(387, 426);
            this.lvPreview.SmallImageList = this.lvPreviewState;
            this.lvPreview.TabIndex = 1;
            this.lvPreview.UseCompatibleStateImageBehavior = false;
            this.lvPreview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Old Name";
            this.columnHeader2.Width = 187;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "New Name";
            this.columnHeader3.Width = 183;
            // 
            // cmsPreviewList
            // 
            this.cmsPreviewList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPvAddFiles,
            this.tsmiPvAddDirs,
            this.toolStripMenuItem2,
            this.tsmiPvRemSelection,
            this.tsmiPvRemApplied,
            this.toolStripMenuItem3,
            this.tsmiPvExtractRule});
            this.cmsPreviewList.Name = "cmsPreviewList";
            this.cmsPreviewList.Size = new System.Drawing.Size(197, 126);
            // 
            // tsmiPvAddFiles
            // 
            this.tsmiPvAddFiles.Name = "tsmiPvAddFiles";
            this.tsmiPvAddFiles.Size = new System.Drawing.Size(196, 22);
            this.tsmiPvAddFiles.Text = "Add Files...";
            // 
            // tsmiPvAddDirs
            // 
            this.tsmiPvAddDirs.Name = "tsmiPvAddDirs";
            this.tsmiPvAddDirs.Size = new System.Drawing.Size(196, 22);
            this.tsmiPvAddDirs.Text = "Add Directories...";
            this.tsmiPvAddDirs.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // tsmiPvRemSelection
            // 
            this.tsmiPvRemSelection.Enabled = false;
            this.tsmiPvRemSelection.Name = "tsmiPvRemSelection";
            this.tsmiPvRemSelection.Size = new System.Drawing.Size(196, 22);
            this.tsmiPvRemSelection.Text = "Remove Selected Items";
            // 
            // tsmiPvRemApplied
            // 
            this.tsmiPvRemApplied.Name = "tsmiPvRemApplied";
            this.tsmiPvRemApplied.Size = new System.Drawing.Size(196, 22);
            this.tsmiPvRemApplied.Text = "Remove Applied Items";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
            // 
            // tsmiPvExtractRule
            // 
            this.tsmiPvExtractRule.Enabled = false;
            this.tsmiPvExtractRule.Name = "tsmiPvExtractRule";
            this.tsmiPvExtractRule.Size = new System.Drawing.Size(196, 22);
            this.tsmiPvExtractRule.Text = "Extract to Rule...";
            // 
            // lvPreviewState
            // 
            this.lvPreviewState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lvPreviewState.ImageStream")));
            this.lvPreviewState.TransparentColor = System.Drawing.Color.Transparent;
            this.lvPreviewState.Images.SetKeyName(0, "OK");
            this.lvPreviewState.Images.SetKeyName(1, "Warning");
            this.lvPreviewState.Images.SetKeyName(2, "Applied");
            this.lvPreviewState.Images.SetKeyName(3, "Error");
            this.lvPreviewState.Images.SetKeyName(4, "Delete");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.pbProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "Progress:";
            // 
            // pbProgress
            // 
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(700, 16);
            // 
            // tsmiProjectHomepage
            // 
            this.tsmiProjectHomepage.Name = "tsmiProjectHomepage";
            this.tsmiProjectHomepage.Size = new System.Drawing.Size(156, 22);
            this.tsmiProjectHomepage.Text = "Project Website";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // tsmiBugReport
            // 
            this.tsmiBugReport.Name = "tsmiBugReport";
            this.tsmiBugReport.Size = new System.Drawing.Size(156, 22);
            this.tsmiBugReport.Text = "Bug Report";
            // 
            // tsmiOnlineHelp
            // 
            this.tsmiOnlineHelp.Name = "tsmiOnlineHelp";
            this.tsmiOnlineHelp.Size = new System.Drawing.Size(181, 22);
            this.tsmiOnlineHelp.Text = "Online Help";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 520);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " RenEx";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cmsRuleList.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsPreviewList.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddDir;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ListView lvPreview;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList lvPreviewState;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowExtInPrev;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button renBtnRemoveRule;
        private System.Windows.Forms.Button renBtnRunRename;
        private System.Windows.Forms.Button renBtnAddRule;
        private System.Windows.Forms.ListView lvRules;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem tsmiFillPathInPrev;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsRuleList;
        private System.Windows.Forms.ContextMenuStrip cmsPreviewList;
        private System.Windows.Forms.ToolStripMenuItem tsmiPvAddFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiPvAddDirs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiPvRemSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiPvExtractRule;
        private System.Windows.Forms.ToolStripMenuItem tsmiPvRemApplied;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddRule;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveRules;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFromTemplate;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddToTemplates;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ToolStripMenuItem tsmiProjectHomepage;
        private System.Windows.Forms.ToolStripMenuItem tsmiBugReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiOnlineHelp;
    }
}

