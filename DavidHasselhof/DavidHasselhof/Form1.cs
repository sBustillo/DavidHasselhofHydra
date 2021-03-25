using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace DavidHasselhof
{
    public partial class DavidHasselhof : Form
    {
        public DavidHasselhof()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToLower() == "no volveré a dejar el pc sin bloquear")
            {

                System.Windows.Forms.Application.Exit();
            }
            else { 
                 // si no lo es, poner en un labbel que ponga que lo has escrito mal.
            }
        }

        private void DavidHasselhof_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }

        private void DavidHasselhof_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(textBox1.Text.ToLower() != "no volveré a dejar el pc sin bloquear") { 
                    Process David = new Process();
                    David.StartInfo.FileName = "DavidHasselhof.exe";
                    David.StartInfo.Arguments = "ProcessStart.cs"; // if you need some
                    David.Start();
                }
            }
            finally
            {



            }
        }


        void Base64EncodedCommand()
        {
            var psCommmand = @"echo ""quoted value"" 
                             echo ""Second Line""
                             pause";

            var psCommandBytes = System.Text.Encoding.Unicode.GetBytes(psCommmand);
            var psCommandBase64 = Convert.ToBase64String(psCommandBytes);

            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -EncodedCommand {psCommandBase64}",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }

    }
}
