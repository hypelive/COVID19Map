using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID19Map
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pluginsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var messageBox = MessageBox.Show("help");
        }
    }
}
