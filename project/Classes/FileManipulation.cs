using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;

using BTree;

namespace BuscaLogo
{
    class FileManipulation
    {
        public static string createBinArrayFile(IEnumerable<ITweet> listOfTweets, TweetSearchParameters searchParameters)
        {
            string date = "", time = "";
            string startDir = Directory.GetCurrentDirectory();
            string currentDir = startDir + @"\Searches\" + date;
            string filePath = "";

            GetDateTime(ref date, ref time);
            if(!Directory.Exists(currentDir))
                Directory.CreateDirectory(currentDir);
            Directory.SetCurrentDirectory(currentDir);

            sTweet[] tweetArray = ListToSerialTweet(listOfTweets, listOfTweets.Count(), searchParameters);

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

        public static sTweet[] readBinArrayFile(string path)
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
        
        public static sTweet[] ListToSerialTweet(IEnumerable<ITweet> listOfTweets, int TweetsInList, TweetSearchParameters searchParameters)
        {
            int index = 0;
            Tweetinvi.Core.Interfaces.Models.IGeoCode aux = searchParameters.GeoCode;
            
            bool isKilo = false;
            sTweet[] tweetArray = new sTweet[TweetsInList];

            foreach (var tweet in listOfTweets)
            {
                tweetArray[index].Text  = tweet.Text;
                tweetArray[index].Name  = tweet.CreatedBy.Name;
                tweetArray[index].DisplayName       = tweet.CreatedBy.ScreenName;
                tweetArray[index].DateTime          = tweet.CreatedAt;
                tweetArray[index].RetweetCount      = tweet.RetweetCount;
                tweetArray[index].FavouriteCount    = tweet.FavouriteCount;
                tweetArray[index].Id    = tweet.Id;
                tweetArray[index].IdStr = tweet.IdStr;

                if(aux.DistanceMeasure == Tweetinvi.Core.Enum.DistanceMeasure.Kilometers)
                    isKilo = true;
                else
                    isKilo = false;

                tweetArray[index].serializeParameters = new sParameters
                (
                    aux.Coordinates.Longitude,
                    aux.Coordinates.Latitude,
                    aux.Radius,
                    isKilo,
                    (byte) searchParameters.Lang,
                    (byte) searchParameters.TweetSearchType
                );

                index++;
            }

            return tweetArray;
        }

        public static string createBinTreeFile(BTree<int, sTweet> Tree)
        {
            string filePath;
            string startDir = Directory.GetCurrentDirectory();
            string currentDir = startDir + @"\Searches\";

            if(!Directory.Exists(currentDir))
                Directory.CreateDirectory(currentDir);
            Directory.SetCurrentDirectory(currentDir);

            BinaryFormatter bf = new BinaryFormatter();
            byte[] buffer;
            using(var ms = new MemoryStream())
            {
                bf.Serialize(ms, Tree);
                buffer = ms.ToArray();
            }

            filePath = String.Format("indexedTweets.bin");
            using(BinaryWriter newFile = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                newFile.Write(buffer, 0, buffer.Length);
                newFile.Close();
            }

            Directory.SetCurrentDirectory(startDir);
            return currentDir + filePath;
        }

        public static BTree<int, sTweet> readBinTreeFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            BTree<int, sTweet> Tree = (BTree<int, sTweet>) formatter.Deserialize(stream);
            stream.Close();

            return Tree;
        }

        public static BTree<int, sTweet> SerialITweetToBTree(sTweet[] TweetArray)
        {
            BTree<int, sTweet> Tree = new BTree<int, sTweet>(5);

            int index = 0;
            foreach(var tweet in TweetArray)
                Tree.Insert(index++, tweet);

            SaveTreeIndex(index, Tree.Height, Tree.Degree);
            return Tree;
        }

        private static void SaveTreeIndex(int index, int height, int degree)
        {
            string startDir = Directory.GetCurrentDirectory();
            string currentDir = startDir + @"\Searches\";
            string filePath = String.Empty;

            if(!Directory.Exists(currentDir))
                Directory.CreateDirectory(currentDir);
            Directory.SetCurrentDirectory(currentDir);

            TreeIndexCheck newTree = new TreeIndexCheck(index, height, degree);
            BinaryFormatter bf = new BinaryFormatter();
            byte[] buffer;
            using(var ms = new MemoryStream())
            {
                bf.Serialize(ms, newTree);
                buffer = ms.ToArray();
            }

            filePath = String.Format("treeIndex.bin");

            using(BinaryWriter newFile = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                newFile.Write(buffer, 0, buffer.Length);
                newFile.Close();
            }

            Directory.SetCurrentDirectory(startDir);

            return;
        }

        private static TreeIndexCheck ReadTreeIndex(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            TreeIndexCheck check = (TreeIndexCheck) formatter.Deserialize(stream);
            stream.Close();

            return check;
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
