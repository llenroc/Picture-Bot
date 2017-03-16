using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using TweetSharp;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.InteropServices;



namespace DrawGraphics
{


    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
       
            this.Paint += new PaintEventHandler(f1_paint); }
        public string value = "";
        public string user = "";
        

        public void GetHashTag_Tap()
        {
            

            string apiKey = "Z33WED4YapoVlGIgW4PqdtNi0";
            string apiSecret = "HSu7l6t8ZrV5vPCOGnHFafUKo6qK59PaCidPLONZPsgjkQoMap";
            string accessToken = "837241580910161922-sB4w2dvts24puBKs2m7MhdJi4380m9K";
            string accesstokSec = "KLKq7lN9u5zEp4z180W58kFOcG89hM3trUyCc6UgpqORb";

            var service = new TwitterService(apiKey, apiSecret);
                service.AuthenticateWith(accessToken, accesstokSec);

            TwitterSearchResult tweets = service.Search(new SearchOptions { Q = "#p1ctureb0t", Lang = "en", Count=1 });
            IEnumerable<TwitterStatus> status = tweets.Statuses;
            foreach (var item in status)
            {
                user = "@"+ item.User.ScreenName;
                value = " "+ item.Text;
                
                //MessageBox.Show(user+value);
            }

            
        }

        public static void tweet()
        {
            string apiKey = "your_api_key";
            string apiSecret = "your_api_sec";
            string accessToken = "your_access_tok";
            string accesstokSec = "your_access_tok_sec";

            var service = new TwitterService(apiKey, apiSecret);
            service.AuthenticateWith(accessToken, accesstokSec);
            //string path = @"C:\Users\ay-_-\Documents\graph";
            

            //var sorted = (from fn in Directory.GetFiles(path)
            //              let m = Regex.Match(fn, @"(?<order>\d+)")
            //              where m.Success
            //              let n = int.Parse(m.Groups["order"].Value)
            //              orderby n
            //              select fn).ToList();



            //var photo = sorted[0];
            string myval = @"C:\Users\ay-_-\Documents\graph\pbot.png";





            using (var stream = new FileStream(myval, FileMode.Open))
            {
                var result1 = service.SendTweetWithMedia(new SendTweetWithMediaOptions
                {
                    Status= " I draw images for you" ,
                    Images = new Dictionary<string, Stream> { { "picturebot", stream } }
                });


                if (File.Exists(myval))
                {
                    File.Delete(myval);
                }


            }


        }

        
        private void f1_paint(object sender, PaintEventArgs e)
        {
            GetHashTag_Tap();
            // "Custom Text", Pink, Rectangle
            var col = new Color();
            string line = value;
            string pink = "pink";
            string yellow = "yellow";
            string blue = "blue";
            string green = "green";
            string purple = "purple";
            string red = "red";
          

            if (line.Contains(pink))

            {

                col = Color.Pink;

            }

            if (line.Contains(blue))

            {

                col = Color.Blue;

            }
            if (line.Contains(yellow))

            {

                col = Color.Yellow;

            }
            if (line.Contains(red))

            {

                col = Color.Red;

            }
            if (line.Contains(green))

            {

                col = Color.Green;

            }


            if (line.Contains(purple))

            {

                col = Color.Purple;

            }


            

            
            
            using (Bitmap b = new Bitmap(1000, 1000))
            {
                using (Graphics g = Graphics.FromImage(b))
                {

                    g.DrawString(user + " @p1ctureb0t", new Font("Verdana", 20),
            new SolidBrush(Color.Tomato), 40, 40);
           

                    if (line.Contains("rectangle"))

                    {

                        g.DrawRectangle(new Pen(col, 3), 75, 75, 200, 150);

                    }

                    if (line.Contains("ellipse"))

                    {

                        g.DrawEllipse(new Pen(col, 3), 100, 100, 200, 150);

                    }

                    g.DrawRectangle(new Pen(col, 3), 75, 75, 200, 150);
                }




                b.Save(@"C:\Users\ay-_-\Documents\graph\pbot.png", ImageFormat.Png);
            }
            //Bitmap btm = new Bitmap(100,100);
            //Graphics g = Graphics.FromImage(btm);
            //g.DrawString("Hello C#", new Font("Verdana", 20),
            //new SolidBrush(Color.Tomato), 40, 40);
            //g.DrawRectangle(new Pen(Color.Pink, 3), 20, 20, 150, 100);
            ////g.Dispose();
            //btm.Save(str, ImageFormat.Jpeg);
            ////btm.Dispose();
            //str.Close();
            //fi.Delete();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            // Application.Run(new Form1
            tweet();
           
         

           
        }

        
    }
}

