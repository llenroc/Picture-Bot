using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using System.IO;
using System.Text.RegularExpressions;

namespace PictureTwitterBot
{
    class Program

    {
        public static void tweetpc()
        {
            string apiKey = "your_api_key";
            string apiSecret = "your_api_secret";
            string accessToken = "_your_access_token";
            string accesstokSec = "your_access_token_sec";
            var service = new TwitterService(apiKey, apiSecret);
            service.AuthenticateWith(accessToken, accesstokSec);
            string path = @"C:\Users\ay-_-\Documents\Picture Bot"; //path which includes the pictures
            int number = chooseNum();

            var sorted = (from fn in Directory.GetFiles(path)
                          let m = Regex.Match(fn, @"(?<order>\d+)")
                          where m.Success
                          let n = int.Parse(m.Groups["order"].Value)
                          orderby n
                          select fn).ToList();



            var photo = sorted[number]; 
            string myval = photo.ToString();




            using (var stream = new FileStream(myval, FileMode.Open))
            {
                var result = service.SendTweetWithMedia(new SendTweetWithMediaOptions
                {

                    Images = new Dictionary<string, Stream> { { "image bot", stream } }
                });

                if (File.Exists(myval))
                {
                    File.Delete(myval);
                }



            }
            
        //********************** TWEET BING PICTURE************************    

 string path2 = @"C:\Users\ay-_-\Documents\Bing Picture";


            var sorted2 = (from fn in Directory.GetFiles(path2)
                           let m = Regex.Match(fn, @"(?<order>\d+)")
                           where m.Success
                           let n = int.Parse(m.Groups["order"].Value)
                           orderby n
                           select fn).ToList();



            var photo2 = sorted2[0];
            string myval2 = photo2.ToString();

            string link = "https://www.bing.com/ " + DateTime.Now;


            using (var stream2 = new FileStream(myval2, FileMode.Open))
            {

                var result = service.SendTweetWithMedia(new SendTweetWithMediaOptions
                {
                   Status=link,
                    Images = new Dictionary<string, Stream> { { "image bot tweet", stream2 } }
                });



                if (File.Exists(myval2))
                {
                    File.Delete(myval2);
                }



            }



            }

        public static int fileCounter(string path)
        {
            int fileCount = Directory.GetFiles(path).Length;
            return fileCount;

        }

        public static int chooseNum()
        {
            string path = @"C:\Users\ay-_-\Documents\Picture Bot";
            int secnum = fileCounter(path);
            var rand = new Random();
            int number = rand.Next(0, secnum);
            return number;

        }

        static void Main(string[] args)
        {
            

        tweetpc();
        Console.ReadLine();
            


        }
    }
}
