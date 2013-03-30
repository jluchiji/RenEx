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
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Name Rules", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Extension Rules", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Directory Rules", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFillPathInPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowExtInPrev = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.optBtnApply = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.optTxtExtList = new System.Windows.Forms.TextBox();
            this.optRadValidateList = new System.Windows.Forms.RadioButton();
            this.optRadValidateLength = new System.Windows.Forms.RadioButton();
            this.optPnlValLenOptions = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.optNudValLenMin = new System.Windows.Forms.NumericUpDown();
            this.optNudValLenMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.optNudMaxExt = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lvPreview = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPreviewState = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.optPnlValLenOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optNudValLenMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optNudValLenMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optNudMaxExt)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
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
            this.tsmiAddDir});
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
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFillPathInPrev,
            this.tsmiShowExtInPrev});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "View";
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::RenEx.Properties.Resources.Info16;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(141, 22);
            this.tsmiAbout.Text = "About RenEx";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Size = new System.Drawing.Size(784, 537);
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 521);
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
            this.tabPage1.Size = new System.Drawing.Size(340, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rules";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // renBtnRemoveRule
            // 
            this.renBtnRemoveRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.renBtnRemoveRule.Image = global::RenEx.Properties.Resources.Remove16;
            this.renBtnRemoveRule.Location = new System.Drawing.Point(41, 463);
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
            this.renBtnRunRename.Location = new System.Drawing.Point(245, 463);
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
            this.renBtnAddRule.Location = new System.Drawing.Point(7, 463);
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
            this.lvRules.FullRowSelect = true;
            this.lvRules.GridLines = true;
            listViewGroup7.Header = "Name Rules";
            listViewGroup7.Name = "lvgName";
            listViewGroup8.Header = "Extension Rules";
            listViewGroup8.Name = "lvgExt";
            listViewGroup9.Header = "Directory Rules";
            listViewGroup9.Name = "lvgDir";
            this.lvRules.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup7,
            listViewGroup8,
            listViewGroup9});
            this.lvRules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRules.Location = new System.Drawing.Point(3, 3);
            this.lvRules.Name = "lvRules";
            this.lvRules.Size = new System.Drawing.Size(334, 453);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(340, 494);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Automagical™ Analysis";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.optBtnApply);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(340, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // optBtnApply
            // 
            this.optBtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optBtnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optBtnApply.Location = new System.Drawing.Point(245, 462);
            this.optBtnApply.Name = "optBtnApply";
            this.optBtnApply.Size = new System.Drawing.Size(87, 25);
            this.optBtnApply.TabIndex = 3;
            this.optBtnApply.Text = "Apply";
            this.optBtnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optBtnApply.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Location = new System.Drawing.Point(7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 55);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurations";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::RenEx.Properties.Resources.Add16;
            this.button2.Location = new System.Drawing.Point(260, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::RenEx.Properties.Resources.Remove16;
            this.button1.Location = new System.Drawing.Point(291, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 22);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.optTxtExtList);
            this.groupBox2.Controls.Add(this.optRadValidateList);
            this.groupBox2.Controls.Add(this.optRadValidateLength);
            this.groupBox2.Controls.Add(this.optPnlValLenOptions);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.optNudMaxExt);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 304);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Extension Analysis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Separate extensions using \";\", case insensitive.";
            // 
            // optTxtExtList
            // 
            this.optTxtExtList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optTxtExtList.Enabled = false;
            this.optTxtExtList.Location = new System.Drawing.Point(7, 219);
            this.optTxtExtList.Multiline = true;
            this.optTxtExtList.Name = "optTxtExtList";
            this.optTxtExtList.Size = new System.Drawing.Size(310, 78);
            this.optTxtExtList.TabIndex = 13;
            // 
            // optRadValidateList
            // 
            this.optRadValidateList.AutoSize = true;
            this.optRadValidateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optRadValidateList.Location = new System.Drawing.Point(7, 177);
            this.optRadValidateList.Name = "optRadValidateList";
            this.optRadValidateList.Size = new System.Drawing.Size(205, 17);
            this.optRadValidateList.TabIndex = 12;
            this.optRadValidateList.Text = "Only allow following extensions:\r\n";
            this.optRadValidateList.UseVisualStyleBackColor = true;
            // 
            // optRadValidateLength
            // 
            this.optRadValidateLength.AutoSize = true;
            this.optRadValidateLength.Checked = true;
            this.optRadValidateLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optRadValidateLength.Location = new System.Drawing.Point(7, 75);
            this.optRadValidateLength.Name = "optRadValidateLength";
            this.optRadValidateLength.Size = new System.Drawing.Size(220, 17);
            this.optRadValidateLength.TabIndex = 11;
            this.optRadValidateLength.TabStop = true;
            this.optRadValidateLength.Text = "Validate extensions by their length";
            this.optRadValidateLength.UseVisualStyleBackColor = true;
            // 
            // optPnlValLenOptions
            // 
            this.optPnlValLenOptions.Controls.Add(this.label3);
            this.optPnlValLenOptions.Controls.Add(this.optNudValLenMin);
            this.optPnlValLenOptions.Controls.Add(this.optNudValLenMax);
            this.optPnlValLenOptions.Controls.Add(this.label5);
            this.optPnlValLenOptions.Location = new System.Drawing.Point(7, 99);
            this.optPnlValLenOptions.Name = "optPnlValLenOptions";
            this.optPnlValLenOptions.Size = new System.Drawing.Size(312, 58);
            this.optPnlValLenOptions.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Only consider extensions longer than";
            // 
            // optNudValLenMin
            // 
            this.optNudValLenMin.Location = new System.Drawing.Point(216, 1);
            this.optNudValLenMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.optNudValLenMin.Name = "optNudValLenMin";
            this.optNudValLenMin.Size = new System.Drawing.Size(51, 21);
            this.optNudValLenMin.TabIndex = 4;
            // 
            // optNudValLenMax
            // 
            this.optNudValLenMax.Location = new System.Drawing.Point(216, 32);
            this.optNudValLenMax.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.optNudValLenMax.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.optNudValLenMax.Name = "optNudValLenMax";
            this.optNudValLenMax.Size = new System.Drawing.Size(51, 21);
            this.optNudValLenMax.TabIndex = 7;
            this.optNudValLenMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "and shorter than";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "extension(s).";
            // 
            // optNudMaxExt
            // 
            this.optNudMaxExt.Location = new System.Drawing.Point(166, 33);
            this.optNudMaxExt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.optNudMaxExt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.optNudMaxExt.Name = "optNudMaxExt";
            this.optNudMaxExt.Size = new System.Drawing.Size(58, 21);
            this.optNudMaxExt.TabIndex = 1;
            this.optNudMaxExt.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Only consider maximum of";
            // 
            // lvPreview
            // 
            this.lvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lvPreview.FullRowSelect = true;
            this.lvPreview.GridLines = true;
            this.lvPreview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPreview.LargeImageList = this.lvPreviewState;
            this.lvPreview.Location = new System.Drawing.Point(3, 3);
            this.lvPreview.Name = "lvPreview";
            this.lvPreview.Size = new System.Drawing.Size(393, 520);
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
            // lvPreviewState
            // 
            this.lvPreviewState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lvPreviewState.ImageStream")));
            this.lvPreviewState.TransparentColor = System.Drawing.Color.Transparent;
            this.lvPreviewState.Images.SetKeyName(0, "OK");
            this.lvPreviewState.Images.SetKeyName(1, "Warning");
            this.lvPreviewState.Images.SetKeyName(2, "Applied");
            this.lvPreviewState.Images.SetKeyName(3, "Error");
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(18, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 348);
            this.panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = " RenEx";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.optPnlValLenOptions.ResumeLayout(false);
            this.optPnlValLenOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optNudValLenMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optNudValLenMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optNudMaxExt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button optBtnApply;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox optTxtExtList;
        private System.Windows.Forms.RadioButton optRadValidateList;
        private System.Windows.Forms.RadioButton optRadValidateLength;
        private System.Windows.Forms.Panel optPnlValLenOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown optNudValLenMin;
        private System.Windows.Forms.NumericUpDown optNudValLenMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown optNudMaxExt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFillPathInPrev;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}

