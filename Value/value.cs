using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace text_file
{
    class Program
    {
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

            string path = @"C:\Users\ay-_-\Documents\Picture Bot";
            int number = chooseNum();

            var sorted = (from fn in Directory.GetFiles(path)
                          let m = Regex.Match(fn, @"(?<order>\d+)")
                          where m.Success
                          let n = int.Parse(m.Groups["order"].Value)
                          orderby n
                          select fn).ToList();



            var photo = sorted[number];
            string myval = photo.ToString();


            string path2 = @"C:\Users\ay-_-\Documents\myval.txt";
            if (!File.Exists(path2))
            {
                File.Create(path2);

            }
            if (File.Exists(path2))
            {
                TextWriter tw = new StreamWriter(path2);
                tw.WriteLine(myval);
                tw.Close();
            }


        }
    }
}
