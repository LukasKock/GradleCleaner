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
using System.Xml;
using System.ComponentModel.Design;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace GradleCleaner
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private String fileContent;
        private String filePath;
        private String folderPath;


        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;

            //int formWidth = this.Width;
            //if (formWidth < textBox1.Width + 100)
            //{
            //    textBox1.Width = formWidth;
            //}
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            string line;

            //using (openFileDialog = new OpenFileDialog())
            //            using (var fdb = new FolderBrowserDialog())
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                //openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(
                //   Environment.SpecialFolder.UserProfile), "AndroidStudioProjects");
                //openFileDialog.Multiselect = true;
                dialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.UserProfile), "AndroidStudioProjects");
                dialog.Multiselect = true;
                dialog.IsFolderPicker = true;
                //openFileDialog.RestoreDirectory = true;
                //DialogResult result = fdb.ShowDialog();



                //if (openFileDialog.ShowDialog() == DialogResult.OK)
                //if (result == DialogResult.OK && !string.IsNullOrEmpty(fdb.SelectedPath))
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    //filePath = openFileDialog.FileName;
                    //string folderpathtest = Path.GetDirectoryName(filePath);
                    //Console.WriteLine(folderpathtest);
                    
                    folderPath = dialog.FileName;
                    Console.WriteLine(folderPath);

                    //string[] paths = Directory.GetDirectories(fdb.SelectedPath);
                    //Console.WriteLine(paths);


                    //String strCmdLine = openFileDialog.FileName;

                    string strCmdLine = "C:\\Users\\LukasKock\\AndroidStudioProjects\\" +
                    "WIfiList-teste\\gradlew.bat";
                    Process proc = new Process();
                    proc.StartInfo.WorkingDirectory = "C:\\Users\\LukasKock\\AndroidStudioProjects\\" +
                    "WIfiList-teste\\";
                    proc.StartInfo.FileName = strCmdLine;
                    proc.StartInfo.Arguments = "build";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.CreateNoWindow = true;




                    proc.Start();
                    while (!proc.StandardOutput.EndOfStream)
                    {
                        line = proc.StandardOutput.ReadLine();
                        textBox1.Enabled = true;
                        textBox1.ScrollBars = ScrollBars.Both;
                        textBox1.AppendText(line);
                        textBox1.AppendText(Environment.NewLine);
                        textBox1.Multiline = true;

                        Console.WriteLine(line);
                    }




                    //var fileStream = openFileDialog.OpenFile();
                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
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
