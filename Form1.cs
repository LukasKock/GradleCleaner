using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradleCleaner
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private String fileContent;
        private String filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            using ( openFileDialog = new OpenFileDialog()) {
                //openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.InitialDirectory = "C:\\Users\\LukasKock\\Desktop\\teste";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2; 
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK) { 
                    filePath = openFileDialog.FileName;
                    
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream)) {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            MessageBox.Show(fileContent, "File at path: " + filePath, 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ofg = new OpenFileDialog();

        }
    }
}
