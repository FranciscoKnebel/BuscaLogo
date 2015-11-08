using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tweetinvi;
using Tweetinvi.Core.Interfaces;

using System.Runtime.Serialization.Formatters.Binary;

namespace BuscaLogo
{
    class FileManipulation
    {
        public static string createBinFile(IEnumerable<ITweet> listOfTweets)
        {
            string date = "", time = "";
            string startDir = Directory.GetCurrentDirectory();
            string currentDir = startDir + @"\Searches\" + date;
            string filePath = "";

            GetDateTime(ref date, ref time);
            if(!Directory.Exists(currentDir))
                Directory.CreateDirectory(currentDir);
            Directory.SetCurrentDirectory(currentDir);

            sTweet[] tweetArray = ListToSerialTweet(listOfTweets, listOfTweets.Count());
            BinaryFormatter bf = new BinaryFormatter();
            byte[] buffer;
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, tweetArray);
                buffer = ms.ToArray();
            }

            filePath = String.Format("{0}_{1}.bin", date, time);

            using (BinaryWriter newFile = new BinaryWriter(File.Open(filePath, FileMode.CreateNew)))
            {
                newFile.Write(buffer, 0, buffer.Length);
                newFile.Close();
            }
            
            Directory.SetCurrentDirectory(startDir);
            return currentDir + filePath;
        }

        public static sTweet[] readBinFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            sTweet[] tweetArray = (sTweet[])formatter.Deserialize(stream);
            stream.Close();

            return tweetArray;
        }

        public static string getFileToRead()
        {
            string currentDir = Directory.GetCurrentDirectory() + @"\Searches\";
            string strFileName = String.Empty;

            if(!Directory.Exists(currentDir))
                Directory.CreateDirectory(currentDir);

            OpenFileDialog newfileDialog = new OpenFileDialog();
            newfileDialog.Filter = "bin files (*.bin)|*.bin"; //|All files (*.*)|*.*";
            newfileDialog.RestoreDirectory = true;
            newfileDialog.Title = "Carregar";
            newfileDialog.InitialDirectory = currentDir;

            if(newfileDialog.ShowDialog() == DialogResult.OK)
                strFileName = newfileDialog.FileName;
            
            if(strFileName == String.Empty)
                return String.Empty;    //user didn't select a file to open
            else
                return strFileName;     //returns filepath of chosen file
        }
        
        public static sTweet[] ListToSerialTweet(IEnumerable<ITweet> listOfTweets, int TweetsInList)
        {
            int index = 0;
            sTweet[] tweetArray = new sTweet[TweetsInList];

            foreach (var tweet in listOfTweets)
            {
                tweetArray[index].Text = tweet.Text;
                tweetArray[index].Name = tweet.CreatedBy.Name;
                tweetArray[index].DisplayName = tweet.CreatedBy.ScreenName;
                tweetArray[index].DateTime = tweet.CreatedAt;
                tweetArray[index].RetweetCount = tweet.RetweetCount;
                tweetArray[index].FavouriteCount = tweet.FavouriteCount;
                tweetArray[index].Id = tweet.Id;
                tweetArray[index].IdStr = tweet.IdStr;
                index++;
            }

            return tweetArray;
        }

        private static void GetDateTime(ref string date, ref string time)
        {
            date = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);  //returns string of current date, year-month-day.   Ex: 2015-10-23
            time = DateTime.Now.ToString("HH-mm-ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);      //returns string of current time, hourminutesecond. EX: 202318
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
