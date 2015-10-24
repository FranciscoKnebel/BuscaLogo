using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tweetinvi;
using Tweetinvi.Core.Interfaces;

using BuscaLogo.Classes;

namespace BuscaLogo
{
    class FileManipulation
    {
        public static void createFile()
        {
            string date = "", time = "";
            string currentDir = Directory.GetCurrentDirectory() + @"\Data\";

            GetDateTime(ref date, ref time);

            if (!Directory.Exists(currentDir))
                Directory.CreateDirectory(currentDir);
            
            if(!Directory.Exists(currentDir + date))
            {
                Directory.CreateDirectory(currentDir);
            }
            FileStream newFile;
            for (int i = 0; i < 10; i++)
            {
                GetDateTime(ref date, ref time);
                newFile = File.Create(date + i + ".txt");
                AddText(newFile, "string\r\n");  
                newFile.Close();
            }
        }
        
        public static void createFile(IEnumerable<ITweet> listOfTweets)
        {
            string curDir = Directory.GetCurrentDirectory();
            string aux = "";
            Arvore raiz = new Arvore();

            foreach(var tweet in listOfTweets)
                raiz.Insere(tweet);

        }

        private static void GetDateTime(ref string date, ref string time)
        {
            date = DateTime.Now.ToString("yyyy-MM-dd ", System.Globalization.DateTimeFormatInfo.InvariantInfo);    //returns string of current date, year-month-day.   Ex: 2015-10-23
            time = DateTime.Now.ToString("HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo);       //returns string of current time, hourminutesecond. EX: 202318
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private static void OpenUTF8stream(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] buffer = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    MessageBox.Show(temp.GetString(buffer));
                }
            }
        }
    }
}
