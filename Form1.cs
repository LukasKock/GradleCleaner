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


        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            progressBar1.Value = 0;

            //int formWidth = this.Width;
            //if (formWidth < textBox1.Width + 100)
            //{
            //    textBox1.Width = formWidth;
            //}
        }

        private void GradleClean_Click(object sender, EventArgs e)
        {
            RunGradle("clean");
        }


        private void Form1_Load(object sender, EventArgs e)
        {        }

        private void GradleBuild_Click(object sender, EventArgs e)
        {
            RunGradle("build");
        }
        private void RunGradle(String command)
        {
            string outputLine;

            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.UserProfile), "AndroidStudioProjects");
                dialog.Multiselect = true;
                dialog.IsFolderPicker = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    textBox1.Enabled = true;
                    textBox1.Multiline = true;
                    textBox1.ScrollBars = ScrollBars.Both;
                    progressBar1.Value = 0;

                    String Gradle = "\\gradlew.bat";
                    foreach (String folderPath in dialog.FileNames)
                    {

                        if (File.Exists(folderPath + "\\build.gradle"))
                        {
                            //folderPath = dialog.FileName;
                            Console.WriteLine(folderPath);
                            Process proc = new Process();
                            proc.StartInfo.WorkingDirectory = folderPath;
                            proc.StartInfo.FileName = folderPath + Gradle;
                            proc.StartInfo.Arguments = command;
                            proc.StartInfo.UseShellExecute = false;
                            proc.StartInfo.RedirectStandardOutput = true;
                            proc.StartInfo.CreateNoWindow = true;

                            proc.Start();
                            if (proc.ExitCode == 0)
                            {
                                while (!proc.StandardOutput.EndOfStream)
                                {
                                    outputLine = proc.StandardOutput.ReadLine();
                                    textBox1.AppendText(outputLine);
                                    textBox1.AppendText(Environment.NewLine);
                                }
                                proc.WaitForExit();
                                proc.Close();

                                progressBar1.Value = 100;

                                textBox1.AppendText(Environment.NewLine);
                            }
                            else {
                                textBox1.AppendText("Unvalid Java version for " + folderPath);
                                textBox1.AppendText(Environment.NewLine);
                                proc.Close();

                            }
                        }
                        else {
                            textBox1.AppendText("This isn't a project folder");
                            textBox1.AppendText(Environment.NewLine);
                        }



                    }


                }
            }

        }

    }
}
