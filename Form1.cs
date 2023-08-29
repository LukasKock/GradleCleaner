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
 
            using ( openFileDialog = new OpenFileDialog()) {

                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.UserProfile), "AndroidStudioProjects");
                //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //openFileDialog.FilterIndex = 2; 
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                //String strCmdLine = "C:\\Users\\LukasKock\\AndroidStudioProjects\\" +
                //    "WIfiList-teste\\gradlew.bat";

                //String strCmdLine = openFileDialog.FileName;




                //String strCmdLine = "C:\\Users\\LukasKock\\AndroidStudioProjects\\" +
                //"WIfiList-teste\\gradlew.bat";
                String strCmdLine = "C:\\Users\\LukasKock\\AndroidStudioProjects\\" +
                "WIfiList-teste\\gradlew.bat";



                try
                {
                    //Process myProcess = Process.Start(strCmdLine);
                    var myProcess = new Process();
                    myProcess.StartInfo.WorkingDirectory = "C:\\Users\\LukasKock\\" +
                        "AndroidStudioProjects\\WIfiList-teste\\";
                    myProcess.StartInfo.FileName = strCmdLine;
                    myProcess.StartInfo.Arguments = "";
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.RedirectStandardError = true;
                    Console.WriteLine(myProcess.StartInfo.FileName);
                    myProcess.Start();

                    string output = myProcess.StandardError.ReadToEnd();
                    myProcess.WaitForExit();

                    Console.WriteLine("\nError Stream: ", output);
                    //myProcess.Close();
                }
                catch
                {
                    throw new Exception();
                }





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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
