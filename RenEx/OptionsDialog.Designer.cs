namespace RenEx
{
    partial class OptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbExtOptions = new System.Windows.Forms.GroupBox();
            this.txtExtList = new System.Windows.Forms.TextBox();
            this.radExtListVal = new System.Windows.Forms.RadioButton();
            this.nudExtLenMax = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudExtLenMin = new System.Windows.Forms.NumericUpDown();
            this.radExtLenVal = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.nudExtMaxExt = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbRlt = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbExtPresets = new System.Windows.Forms.ListBox();
            this.btnExtAdd = new System.Windows.Forms.Button();
            this.btnExtRemove = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExtName = new System.Windows.Forms.TextBox();
            this.gbRltOptions = new System.Windows.Forms.GroupBox();
            this.btnRltRemove = new System.Windows.Forms.Button();
            this.btnRltAdd = new System.Windows.Forms.Button();
            this.txtRltName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radRltName = new System.Windows.Forms.RadioButton();
            this.radRltExt = new System.Windows.Forms.RadioButton();
            this.radRltDir = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRltRegex = new System.Windows.Forms.TextBox();
            this.txtRltRep = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbExtOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtLenMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtLenMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtMaxExt)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.gbRltOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(14, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(552, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExtRemove);
            this.tabPage1.Controls.Add(this.btnExtAdd);
            this.tabPage1.Controls.Add(this.lbExtPresets);
            this.tabPage1.Controls.Add(this.gbExtOptions);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(544, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Extension Analysis";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbExtOptions
            // 
            this.gbExtOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExtOptions.Controls.Add(this.txtExtName);
            this.gbExtOptions.Controls.Add(this.label5);
            this.gbExtOptions.Controls.Add(this.txtExtList);
            this.gbExtOptions.Controls.Add(this.radExtListVal);
            this.gbExtOptions.Controls.Add(this.nudExtLenMax);
            this.gbExtOptions.Controls.Add(this.label4);
            this.gbExtOptions.Controls.Add(this.nudExtLenMin);
            this.gbExtOptions.Controls.Add(this.radExtLenVal);
            this.gbExtOptions.Controls.Add(this.label3);
            this.gbExtOptions.Controls.Add(this.nudExtMaxExt);
            this.gbExtOptions.Controls.Add(this.label2);
            this.gbExtOptions.Location = new System.Drawing.Point(157, 6);
            this.gbExtOptions.Name = "gbExtOptions";
            this.gbExtOptions.Size = new System.Drawing.Size(384, 312);
            this.gbExtOptions.TabIndex = 2;
            this.gbExtOptions.TabStop = false;
            this.gbExtOptions.Text = "Options";
            // 
            // txtExtList
            // 
            this.txtExtList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtList.Enabled = false;
            this.txtExtList.Location = new System.Drawing.Point(15, 152);
            this.txtExtList.Multiline = true;
            this.txtExtList.Name = "txtExtList";
            this.txtExtList.Size = new System.Drawing.Size(354, 154);
            this.txtExtList.TabIndex = 9;
            // 
            // radExtListVal
            // 
            this.radExtListVal.AutoSize = true;
            this.radExtListVal.Location = new System.Drawing.Point(12, 128);
            this.radExtListVal.Name = "radExtListVal";
            this.radExtListVal.Size = new System.Drawing.Size(345, 18);
            this.radExtListVal.TabIndex = 8;
            this.radExtListVal.Text = "Present in the following list (separated by \';\', case insensitive)";
            this.radExtListVal.UseVisualStyleBackColor = true;
            // 
            // nudExtLenMax
            // 
            this.nudExtLenMax.Location = new System.Drawing.Point(290, 101);
            this.nudExtLenMax.Name = "nudExtLenMax";
            this.nudExtLenMax.Size = new System.Drawing.Size(41, 21);
            this.nudExtLenMax.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "and no longer than";
            // 
            // nudExtLenMin
            // 
            this.nudExtLenMin.Location = new System.Drawing.Point(129, 101);
            this.nudExtLenMin.Name = "nudExtLenMin";
            this.nudExtLenMin.Size = new System.Drawing.Size(41, 21);
            this.nudExtLenMin.TabIndex = 4;
            // 
            // radExtLenVal
            // 
            this.radExtLenVal.AutoSize = true;
            this.radExtLenVal.Checked = true;
            this.radExtLenVal.Location = new System.Drawing.Point(12, 101);
            this.radExtLenVal.Name = "radExtLenVal";
            this.radExtLenVal.Size = new System.Drawing.Size(111, 18);
            this.radExtLenVal.TabIndex = 3;
            this.radExtLenVal.TabStop = true;
            this.radExtLenVal.Text = "No shorter than ";
            this.radExtLenVal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "extensions, that are...";
            // 
            // nudExtMaxExt
            // 
            this.nudExtMaxExt.Location = new System.Drawing.Point(176, 64);
            this.nudExtMaxExt.Name = "nudExtMaxExt";
            this.nudExtMaxExt.Size = new System.Drawing.Size(43, 21);
            this.nudExtMaxExt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Only consider a maximum of ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRltRemove);
            this.tabPage2.Controls.Add(this.gbRltOptions);
            this.tabPage2.Controls.Add(this.btnRltAdd);
            this.tabPage2.Controls.Add(this.lbRlt);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(544, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rule Templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbRlt
            // 
            this.lbRlt.FormattingEnabled = true;
            this.lbRlt.ItemHeight = 14;
            this.lbRlt.Location = new System.Drawing.Point(6, 6);
            this.lbRlt.Name = "lbRlt";
            this.lbRlt.Size = new System.Drawing.Size(145, 284);
            this.lbRlt.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(544, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Regex Templates";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(544, 324);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Automagic Presets";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(478, 370);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // lbExtPresets
            // 
            this.lbExtPresets.FormattingEnabled = true;
            this.lbExtPresets.ItemHeight = 14;
            this.lbExtPresets.Location = new System.Drawing.Point(6, 6);
            this.lbExtPresets.Name = "lbExtPresets";
            this.lbExtPresets.Size = new System.Drawing.Size(145, 284);
            this.lbExtPresets.TabIndex = 3;
            // 
            // btnExtAdd
            // 
            this.btnExtAdd.Image = global::RenEx.Properties.Resources.Add16;
            this.btnExtAdd.Location = new System.Drawing.Point(6, 294);
            this.btnExtAdd.Name = "btnExtAdd";
            this.btnExtAdd.Size = new System.Drawing.Size(24, 24);
            this.btnExtAdd.TabIndex = 10;
            this.btnExtAdd.UseVisualStyleBackColor = true;
            // 
            // btnExtRemove
            // 
            this.btnExtRemove.Image = global::RenEx.Properties.Resources.Remove16;
            this.btnExtRemove.Location = new System.Drawing.Point(36, 294);
            this.btnExtRemove.Name = "btnExtRemove";
            this.btnExtRemove.Size = new System.Drawing.Size(24, 24);
            this.btnExtRemove.TabIndex = 11;
            this.btnExtRemove.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Name";
            // 
            // txtExtName
            // 
            this.txtExtName.Location = new System.Drawing.Point(53, 23);
            this.txtExtName.Name = "txtExtName";
            this.txtExtName.Size = new System.Drawing.Size(313, 21);
            this.txtExtName.TabIndex = 11;
            // 
            // gbRltOptions
            // 
            this.gbRltOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRltOptions.Controls.Add(this.txtRltRep);
            this.gbRltOptions.Controls.Add(this.label9);
            this.gbRltOptions.Controls.Add(this.txtRltRegex);
            this.gbRltOptions.Controls.Add(this.label8);
            this.gbRltOptions.Controls.Add(this.radRltDir);
            this.gbRltOptions.Controls.Add(this.radRltExt);
            this.gbRltOptions.Controls.Add(this.radRltName);
            this.gbRltOptions.Controls.Add(this.label7);
            this.gbRltOptions.Controls.Add(this.txtRltName);
            this.gbRltOptions.Controls.Add(this.label6);
            this.gbRltOptions.Enabled = false;
            this.gbRltOptions.Location = new System.Drawing.Point(157, 6);
            this.gbRltOptions.Name = "gbRltOptions";
            this.gbRltOptions.Size = new System.Drawing.Size(384, 312);
            this.gbRltOptions.TabIndex = 15;
            this.gbRltOptions.TabStop = false;
            this.gbRltOptions.Text = "Options";
            // 
            // btnRltRemove
            // 
            this.btnRltRemove.Image = global::RenEx.Properties.Resources.Remove16;
            this.btnRltRemove.Location = new System.Drawing.Point(36, 294);
            this.btnRltRemove.Name = "btnRltRemove";
            this.btnRltRemove.Size = new System.Drawing.Size(24, 24);
            this.btnRltRemove.TabIndex = 13;
            this.btnRltRemove.UseVisualStyleBackColor = true;
            // 
            // btnRltAdd
            // 
            this.btnRltAdd.Image = global::RenEx.Properties.Resources.Add16;
            this.btnRltAdd.Location = new System.Drawing.Point(6, 294);
            this.btnRltAdd.Name = "btnRltAdd";
            this.btnRltAdd.Size = new System.Drawing.Size(24, 24);
            this.btnRltAdd.TabIndex = 12;
            this.btnRltAdd.UseVisualStyleBackColor = true;
            // 
            // txtRltName
            // 
            this.txtRltName.Location = new System.Drawing.Point(53, 23);
            this.txtRltName.Name = "txtRltName";
            this.txtRltName.Size = new System.Drawing.Size(313, 21);
            this.txtRltName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Type";
            // 
            // radRltName
            // 
            this.radRltName.AutoSize = true;
            this.radRltName.Checked = true;
            this.radRltName.Location = new System.Drawing.Point(53, 64);
            this.radRltName.Name = "radRltName";
            this.radRltName.Size = new System.Drawing.Size(56, 18);
            this.radRltName.TabIndex = 15;
            this.radRltName.TabStop = true;
            this.radRltName.Text = "Name";
            this.radRltName.UseVisualStyleBackColor = true;
            // 
            // radRltExt
            // 
            this.radRltExt.AutoSize = true;
            this.radRltExt.Location = new System.Drawing.Point(127, 64);
            this.radRltExt.Name = "radRltExt";
            this.radRltExt.Size = new System.Drawing.Size(76, 18);
            this.radRltExt.TabIndex = 16;
            this.radRltExt.Text = "Extension";
            this.radRltExt.UseVisualStyleBackColor = true;
            // 
            // radRltDir
            // 
            this.radRltDir.AutoSize = true;
            this.radRltDir.Location = new System.Drawing.Point(221, 64);
            this.radRltDir.Name = "radRltDir";
            this.radRltDir.Size = new System.Drawing.Size(73, 18);
            this.radRltDir.TabIndex = 17;
            this.radRltDir.Text = "Directory";
            this.radRltDir.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Regular Expression";
            // 
            // txtRltRegex
            // 
            this.txtRltRegex.Location = new System.Drawing.Point(12, 114);
            this.txtRltRegex.Multiline = true;
            this.txtRltRegex.Name = "txtRltRegex";
            this.txtRltRegex.Size = new System.Drawing.Size(354, 85);
            this.txtRltRegex.TabIndex = 19;
            // 
            // txtRltRep
            // 
            this.txtRltRep.Location = new System.Drawing.Point(12, 221);
            this.txtRltRep.Multiline = true;
            this.txtRltRep.Name = "txtRltRep";
            this.txtRltRep.Size = new System.Drawing.Size(354, 85);
            this.txtRltRep.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "Replacement Expression";
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 408);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RenEx Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbExtOptions.ResumeLayout(false);
            this.gbExtOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtLenMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtLenMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtMaxExt)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.gbRltOptions.ResumeLayout(false);
            this.gbRltOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbExtOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExtList;
        private System.Windows.Forms.RadioButton radExtListVal;
        private System.Windows.Forms.NumericUpDown nudExtLenMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudExtLenMin;
        private System.Windows.Forms.RadioButton radExtLenVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudExtMaxExt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbRlt;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.Button btnExtRemove;
        private System.Windows.Forms.Button btnExtAdd;
        private System.Windows.Forms.ListBox lbExtPresets;
        private System.Windows.Forms.TextBox txtExtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRltRemove;
        private System.Windows.Forms.GroupBox gbRltOptions;
        private System.Windows.Forms.Button btnRltAdd;
        private System.Windows.Forms.TextBox txtRltName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRltRep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRltRegex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radRltDir;
        private System.Windows.Forms.RadioButton radRltExt;
        private System.Windows.Forms.RadioButton radRltName;
        private System.Windows.Forms.Label label7;
    }
}