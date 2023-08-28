using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

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
            String output;
            String eOut;

            string line;
            

            using (openFileDialog = new OpenFileDialog())
            {

                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.UserProfile), "AndroidStudioProjects");
                //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //openFileDialog.FilterIndex = 2; 
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                //String strCmdLine = "C:\\Users\\LukasKock\\AndroidStudioProjects\\" +
                //    "WIfiList-teste\\gradlew.bat";

                //String strCmdLine = openFileDialog.FileName;

                string strCmdLine = "C:\\Users\\LukasKock\\AndroidStudioProjects\\" +
                "WIfiList-teste\\gradlew.bat";
                Process proc = new Process();
                proc.StartInfo.FileName = strCmdLine;
                proc.StartInfo.Arguments = "";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                      



                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    line = proc.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }

                /*
                 Process proc = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = strCmdLine,
        Arguments = "",
        UseShellExecute = false,
        RedirectStandardOutput = true,
        CreateNoWindow = true
    }
};


proc.Start();
while (!proc.StandardOutput.EndOfStream)
{
    line = proc.StandardOutput.ReadLine();
    Console.WriteLine(line);
}

                 */


                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //{
                //    filePath = openFileDialog.FileName;

                //    var fileStream = openFileDialog.OpenFile();
                //    using (StreamReader reader = new StreamReader(fileStream))
                //    {
                //        fileContent = reader.ReadToEnd();
                //    }
                //}
            }
            //MessageBox.Show(fileContent, "File at path: " + filePath,
            //    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //MessageBox.Show(line, "legenda", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
