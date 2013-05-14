using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RenEx
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            // Initialize Version Info
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text =
                String.Format("ver. {0}.{1}.RAWR!", version.Major, version.Minor);

            // Attach Handlers
            Click += (@s, a) => Close();
            pictureBox1.Click += (@s, a) => Close();
            label1.Click += (@s, a) => Close();
            label2.Click += (@s, a) => Close();
            label3.Click += (@s, a) => Close();
            lblVersion.Click += (@s, a) => Close();
        }
    }
}
