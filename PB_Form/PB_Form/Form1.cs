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

namespace PB_Form
{
    public partial class Form1 : Form
    {

        private System.Windows.Forms.Timer tmr;
        Timer tmr2;
        private int counter = 3600;   //3600  1 hour
        private int counter2 = (3600*24);


        public Form1()
        {
            InitializeComponent();

           

        }




        static void LaunchCommandLineApp() // 
        {
            const string ex1 = "C";
            const string ex2 = "CDir";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\Users\ay-_-\Desktop\PictureTwitterBot\PictureTwitterBot\bin\Debug\PictureTwitterBot.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments =" -f j - o + ex1 + -z 1.0 - s y + ex2";

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
            }
        }

        static void LaunchCommandLineAppBing()
        {
            const string ex1 = "C";
            const string ex2 = "CDir";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\Users\ay-_-\Desktop\Bing\BingBackground\bin\Debug\BingBackground.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = " -f j - o + ex1 + -z 1.0 - s y + ex2";

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
            }
        }


        static void LaunchCommandLineAppPbBing()
        {
            const string ex1 = "C";
            const string ex2 = "CDir";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\Users\ay-_-\Desktop\PictureTwitterBot_Bing\PictureTwitterBot\bin\Debug\PictureTwitterBot.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = " -f j - o + ex1 + -z 1.0 - s y + ex2";

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
            }
        }


        private void tmr_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                tmr.Stop();
                LaunchCommandLineApp();
            }
            label1.Text = counter.ToString();

           
        }

        private void tmr_Tick2(object sender, EventArgs e)
        {
            counter2--;
            if (counter2 == 0)
            {
                tmr2.Stop();
                LaunchCommandLineAppBing();
                LaunchCommandLineAppPbBing();
            }
            
            label2.Text = counter2.ToString();



           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Interval = 1000; // 1 second
            tmr.Start();
            label1.Text = counter.ToString();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tmr2 = new System.Windows.Forms.Timer();
            tmr2.Tick += new EventHandler(tmr_Tick2);
            tmr2.Interval = 1000; // 1 second
            tmr2.Start();
            label2.Text = counter.ToString();
        }
    }
}
