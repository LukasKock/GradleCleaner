using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradleCleaner
{
    public partial class Form1 : Form
    {
        private OpenFileDialog ofg;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofg = new OpenFileDialog();
            ofg.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ofg = new OpenFileDialog();

        }
    }
}
