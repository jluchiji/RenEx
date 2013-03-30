namespace RenEx
{
    partial class ProcessingDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.pbOverall = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.lblProgressDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current File";
            // 
            // pbOverall
            // 
            this.pbOverall.Location = new System.Drawing.Point(12, 36);
            this.pbOverall.Name = "pbOverall";
            this.pbOverall.Size = new System.Drawing.Size(345, 10);
            this.pbOverall.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(147, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Abort";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblProgressDetails
            // 
            this.lblProgressDetails.AutoEllipsis = true;
            this.lblProgressDetails.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblProgressDetails.Location = new System.Drawing.Point(85, 19);
            this.lblProgressDetails.Name = "lblProgressDetails";
            this.lblProgressDetails.Size = new System.Drawing.Size(272, 14);
            this.lblProgressDetails.TabIndex = 6;
            this.lblProgressDetails.Text = "Detailed Progress String Here";
            // 
            // ProcessingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 94);
            this.ControlBox = false;
            this.Controls.Add(this.lblProgressDetails);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbOverall);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProcessingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Working...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbOverall;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblProgressDetails;
    }
}