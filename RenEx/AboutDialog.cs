using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RenEx
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            Click += (@s, a) => Close();
            pictureBox1.Click += (@s, a) => Close();
            label1.Click += (@s, a) => Close();
            label2.Click += (@s, a) => Close();
            label3.Click += (@s, a) => Close();
            label4.Click += (@s, a) => Close();
        }
    }
}
