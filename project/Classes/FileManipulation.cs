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
using System.Collections;

namespace BuscaLogo
{
    public class FileManipulation
    {
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

        //Type converters
        public static sTweet[] ListToSerialTweet(IEnumerable<ITweet> listOfTweets, int TweetsInList, TweetSearchParameters searchParameters)
        {
            int index = 0;
            Tweetinvi.Core.Interfaces.Models.IGeoCode aux = searchParameters.GeoCode;
            
            bool isKilo = false;
            sTweet[] tweetArray = new sTweet[TweetsInList];

            foreach (var tweet in listOfTweets)
            {
                tweetArray[index] = new sTweet(tweet.Text, tweet.CreatedBy.Name, tweet.CreatedBy.ScreenName, tweet.CreatedAt, tweet.RetweetCount, tweet.FavouriteCount, tweet.Id, tweet.IdStr);

                if(aux != null)
                {
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
                else
                {
                    tweetArray[index].serializeParameters = new sParameters(-1, -1, -1, false, (byte) searchParameters.Lang, (byte) searchParameters.TweetSearchType);

                    index++;
                }

            }

            return tweetArray;
        }

        public static sTweet[] BTreeToSerialITweet(BTree<int, sTweet> Tree, TreeIndexCheck check)
        {
            Entry<int, sTweet> chave = new Entry<int, sTweet>();
            sTweet[] TweetArray = new sTweet[check.index];

            for(int index = 0; index < check.index; index++)
            {
                chave = Tree.Search(index);
                TweetArray[index] = chave.Pointer; //salva ponteiro da árvore no array
            }

            return TweetArray;
        }

        public static BTree<int, sTweet> SerialITweetToBTree(sTweet[] TweetArray, ref TreeIndexCheck check)
        {
            BTree<int, sTweet> Tree = new BTree<int, sTweet>(5);

            int index = 0;
            foreach(var tweet in TweetArray)
                Tree.Insert(index++, tweet);

            check = new TreeIndexCheck(index, Tree.Height, Tree.Degree);
            return Tree;
        }


        //File manipulators
        public static string createBinTreeFile(BTree<int, sTweet> Tree, TreeIndexCheck check)
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
            SaveTreeIndex(check.index, check.height, check.degree);
            
            return currentDir + filePath;
        }

        public static BTree<int, sTweet> readBinTreeFile(string path, ref TreeIndexCheck check)
        {
            string currentdir = Directory.GetCurrentDirectory() + @"\Searches\";

            BinaryFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new FileStream(currentdir + path, FileMode.Open, FileAccess.Read, FileShare.Read);
            BTree<int, sTweet> Tree = (BTree<int, sTweet>) formatter.Deserialize(stream);
            stream.Close();

            check = ReadTreeIndex(currentdir + @"\treeIndex.bin");

            return Tree;
        }

        public static sTweet[] GetNewArrayToBin(BTree<int, sTweet> newTree)
        {
            TreeIndexCheck checkTree = new TreeIndexCheck(0,0,0);
            sTweet[] auxNew;
            
            TreeIndexCheck newTreeCheck;

            if(!File.Exists(Directory.GetCurrentDirectory() + @"\Searches\indexedTweets.bin"))
            {
                newTreeCheck = GetTreeIndexCheck(newTree);
                auxNew = BTreeToSerialITweet(newTree, newTreeCheck);  //auxNew contains the new tree that the function received

                return auxNew;
            }            
            else
            {
                BTree<int, sTweet> Tree = readBinTreeFile("indexedTweets.bin", ref checkTree);
                sTweet[] auxTweetArray = BTreeToSerialITweet(Tree, checkTree); //auxTweetArray contains the old tree that was in memory

                newTreeCheck = GetTreeIndexCheck(newTree);
                auxNew = BTreeToSerialITweet(newTree, newTreeCheck);  //auxNew contains the new tree that the function received

                //sTweet[] combined = auxTweetArray.Concat(auxNew).ToArray();    //combines the two arrays, with no sorting

                //combined = checkIfRepeatedTweets(combined);

                sTweet[] combined = checkIfRepeatedTweets(auxNew, auxTweetArray);

                return combined;
            }
        }

        private static sTweet[] checkIfRepeatedTweets(sTweet[] newArray, sTweet[] oldArray)
        {
            ArrayList flagindex = new ArrayList();
            ArrayList final = new ArrayList(oldArray);

            for(int i = 0; i < oldArray.Count(); i++)
                for(int j = 0; j < newArray.Count(); j++)
                    if(oldArray.ElementAt(i).Id == newArray.ElementAt(j).Id)
                        flagindex.Add(j);

            for(int i = 0; i < newArray.Count(); i++)
            {
                if(flagindex.Contains(i) == false)
                    final.Add(newArray.ElementAt(i));
            }

            return (sTweet[]) final.ToArray(typeof(sTweet));
        }

        public static bool DeleteFiles()
        {
            File.Delete(Directory.GetCurrentDirectory() + @"\Searches\indexedTweets.bin");
            File.Delete(Directory.GetCurrentDirectory() + @"\Searches\treeIndex.bin");

            return true;
        }

        //Tree functions
        public static TreeIndexCheck GetTreeIndexCheck(BTree<int, sTweet> Tree)
        {
            TreeIndexCheck check;
            int index = 0;
            bool flag = false;
            Entry<int, sTweet> temp;

            while(flag != true)
            {
                temp = Tree.Search(index++);
                if(temp == null)
                    flag = true;
            }

            check = new TreeIndexCheck(--index, Tree.Height, Tree.Degree);

            return check;
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

        public static void ReadTree(Node<int, sTweet> node, ref string numbers)
        {
            if(!node.IsLeaf)
            {
                List<Entry<int, sTweet>> leaves = node.Entries;

                foreach(var leaf in leaves)
                    numbers = numbers + leaf.Key.ToString();

                List<Node<int, sTweet>> children = node.Children;

                foreach(var childrenNode in children)
                {
                    ReadTree(childrenNode, ref numbers);
                }
            }
            else
            {
                List< Entry<int,sTweet> > leaves = node.Entries;

                foreach(var leaf in leaves)
                {
                    numbers = numbers + leaf.Key.ToString();
                }
            }
        }


        //OLD UNUSED CODE//
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
            using(var ms = new MemoryStream())
            {
                bf.Serialize(ms, tweetArray);
                buffer = ms.ToArray();
            }

            filePath = String.Format("{0}_{1}.bin", date, time);

            using(BinaryWriter newFile = new BinaryWriter(File.Open(filePath, FileMode.CreateNew)))
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
            sTweet[] tweetArray = (sTweet[]) formatter.Deserialize(stream);
            stream.Close();

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
            using(FileStream fs = File.OpenRead(path))
            {
                byte[] buffer = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while(fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    MessageBox.Show(temp.GetString(buffer));
                }
            }
        }
    }
}
