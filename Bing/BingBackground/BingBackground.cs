using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BingBackground {

    class BingBackground {

        private static void Main(string[] args) {
            string urlBase = GetBackgroundUrlBase();
            Image background = DownloadBackground(urlBase + GetResolutionExtension(urlBase));
            SaveBackground(background);
            
          
            Console.ReadLine();
        }

        private static dynamic DownloadJson() {
            using (WebClient webClient = new WebClient()) {
                Console.WriteLine("Downloading JSON...");
                string jsonString = webClient.DownloadString("https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US");
                return JsonConvert.DeserializeObject<dynamic>(jsonString);
            }
        }

        private static string GetBackgroundUrlBase() {
            dynamic jsonObject = DownloadJson();
            return "https://www.bing.com" + jsonObject.images[0].urlbase;
        }

        private static string GetBackgroundTitle() {
            dynamic jsonObject = DownloadJson();
            string copyrightText = jsonObject.images[0].copyright;
            return copyrightText.Substring(0, copyrightText.IndexOf(" ("));
        }

        private static bool WebsiteExists(string url) {
            try {
                WebRequest request = WebRequest.Create(url);
                request.Method = "HEAD";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            } catch {
                return false;
            }
        }

        private static string GetResolutionExtension(string url) {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            string widthByHeight = resolution.Width + "x" + resolution.Height;
            string potentialExtension = "_" + widthByHeight + ".jpg";
            if (WebsiteExists(url + potentialExtension)) {
                Console.WriteLine("Background for " + widthByHeight + " found.");
                return potentialExtension;
            } else {
                Console.WriteLine("No background for " + widthByHeight + " was found.");
                Console.WriteLine("Using 1920x1080 instead.");
                return "_1920x1080.jpg";
            }
        }

        private static void SetProxy() {
            string proxyUrl = Properties.Settings.Default.Proxy;
            if (proxyUrl.Length > 0) {
                var webProxy = new WebProxy(proxyUrl, true);
                webProxy.Credentials = CredentialCache.DefaultCredentials;
                WebRequest.DefaultWebProxy = webProxy;
            }

            Console.WriteLine(proxyUrl);
            
        }

        private static Image DownloadBackground(string url) {
            Console.WriteLine("Downloading background...");
            SetProxy();
            WebRequest request = WebRequest.Create(url);
            WebResponse reponse = request.GetResponse();
            Stream stream = reponse.GetResponseStream();
            return Image.FromStream(stream);
        }

        private static string GetBackgroundImagePath() {
            string directory = @"C:\Users\ay-_-\Documents\Bing Picture";
            Directory.CreateDirectory(directory);
            return Path.Combine(directory, DateTime.Now.ToString("M-d-yyyy") + ".jpeg");
        }

        private static void SaveBackground(Image background) {
            Console.WriteLine("Saving background...");
            background.Save(GetBackgroundImagePath(), System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        
          
        }

    }

