using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BuscaLogo;
using BuscaLogo.Classes;
using Tweetinvi.Core.Interfaces;

using BTree;
using System.IO;

namespace BuscaLogo.Forms
{
    public partial class Tweet_Reader : Form
    {
        sTweet[] sList;
        BTree<int, sTweet> sTree;

        public Tweet_Reader()
        {
            InitializeComponent();

            string ReadFile = @"\indexedTweets.bin";

            if(File.Exists(Directory.GetCurrentDirectory() + @"\Searches" + ReadFile))
            {
                TreeIndexCheck check = new TreeIndexCheck(0, 0, 0);
                sTree = FileManipulation.readBinTreeFile(ReadFile, ref check);
                sList = FileManipulation.BTreeToSerialITweet(sTree, check);

                if(sList != null)
                    buildListBox(false, 1);
            }
            else
            {
                BackgroundNull.BringToFront();
                label1.BringToFront();

                BackgroundNull.Show();
                label1.Show();
            }
        }

        public Tweet_Reader(sTweet[] lista)
        {
            InitializeComponent();

            sList = lista;

            buscaUsuario.Hide();
            TweetRefresh.Hide();    //Hides buttons that don't make sense in user search
            button2.Hide();
            button3.Hide();

            buildListBox(crescentOrder.Checked, 1);            
        }

        private void buildListBox(int contador)
        {
            Dictionary<string, sTweet> tableSource = new Dictionary<string, sTweet>();

            for (int i = 0; i < contador; i++)
            {
                tableSource.Add(sList[i].IdStr, sList[i]);
            }

            TweetList.DataSource = new BindingSource(tableSource, null);
            TweetList.DisplayMember = "Key";
            TweetList.ValueMember = "Value";
            TweetList.SelectedIndex = 0;
        }

        private void buildListBox(bool crescente, byte sort)
        {
            sTweet[] sorted;

            switch(sort)
            {
                case 1: //DateTime
                    sorted = sList.OrderBy(item => item.DateTime).ToArray();

                    break;
                case 2: //DisplayName
                    sorted = sList.OrderBy(item => item.DisplayName).ToArray();

                    break;
                case 3: //Name
                    sorted = sList.OrderBy(item => item.Name).ToArray();

                    break;
                case 4: //RetweetCount;
                    sorted = sList.OrderBy(item => item.RetweetCount).ToArray();

                    break;
                case 5: //FavouriteCount
                    sorted = sList.OrderBy(item => item.FavouriteCount).ToArray();

                    break;
                default: //order by ID
                    sorted = sList.OrderBy(item => item.Id).ToArray();
                    break;
            }

            if(!crescente)
                sorted = sorted.Reverse().ToArray();

            sList = sorted;
            buildListBox(sList.Count());            
        }


        public Form AuxTweetReader;
        private void searchTree(string user)
        {
            BTree<string, List<sTweet>> userTree = buildUserTree(5);
            Entry<string, List<sTweet>> entrada = userTree.Search(user);

            if(entrada != null)
            {
                if(AuxTweetReader != null)
                {
                    if(!AuxTweetReader.Created)
                    {
                        AuxTweetReader = new Forms.Tweet_Reader(entrada.Pointer.ToArray());
                        try
                        {
                            AuxTweetReader.Show();
                        }
                        catch(ObjectDisposedException)
                        {
                            AuxTweetReader = new Forms.Tweet_Reader(entrada.Pointer.ToArray());
                            AuxTweetReader.Show();
                        }
                        AuxTweetReader.Activate();
                    }
                }
                else
                {
                    AuxTweetReader = new Forms.Tweet_Reader(entrada.Pointer.ToArray());
                    AuxTweetReader.Show();
                    AuxTweetReader.Activate();
                }

                AuxTweetReader.Text = "Pesquisa por usuário";
                AuxTweetReader.BringToFront();
            }
            else
            {
                DialogResult choice = MessageBox.Show("Usuário não encontrado.", "Busca por Usuário", MessageBoxButtons.OK);
            }
            
        }

        private BTree<string, List<sTweet>> buildUserTree(int degree)
        {
            BTree<string, List<sTweet>> userTree = new BTree<string, List<sTweet>>(degree);
            Dictionary<string, List<sTweet>> users = new Dictionary<string, List<sTweet>>();


            foreach(var aux in sList)
            {
                if(!users.ContainsKey(aux.DisplayName))
                {
                    List<sTweet> tweets = new List<sTweet>();
                    tweets.Add(aux);

                    users.Add(aux.DisplayName, tweets);
                }
                else
                {
                    List<sTweet> tweets = new List<sTweet>();

                    users.TryGetValue(aux.DisplayName, out tweets);
                    tweets.Add(aux);
                    users[aux.DisplayName] = tweets;
                }
            }


            foreach(var entry in users)
            {
                userTree.Insert(entry.Key, entry.Value);
            }

            return userTree;
        }

        private void Tweet_ShowSelected(object sender, EventArgs e)
        {                                       //activates when selected index of TweetList changes
            if (sList != null)
            {
                int selectedIndex = TweetList.SelectedIndex;
                sTweet aux = new sTweet();
                bool Invalid = false;

                try
                {
                    aux = sList[selectedIndex];
                }
                catch(IndexOutOfRangeException) //cairá aqui se lista não conter elementos
                {
                    Invalid = true;
                }
                finally
                {
                    if(!Invalid)
                    {
                        TweetTextbox.Text = aux.Text;
                        TweetName.Text = aux.Name;
                        TweetDisplayName.Text = "@" + aux.DisplayName;
                        TweetDateTime.Text = aux.DateTime.ToString();
                        TweetRetweets.Text = aux.RetweetCount.ToString();
                        TweetFavourites.Text = aux.FavouriteCount.ToString();
                    }
                    else
                        TweetTextbox.Text = "Arquivo inválido. Tem certeza que escolheu o certo? - ERRO 003";
                }
            }
        }

        private void TweetRefresh_Click(object sender, EventArgs e)
        {
            if(File.Exists(Directory.GetCurrentDirectory() + @"\Searches\indexedTweets.bin"))
            {
                TreeIndexCheck check = new TreeIndexCheck(0, 0, 0);
                sTree = FileManipulation.readBinTreeFile(@"\indexedTweets.bin", ref check);
                sList = FileManipulation.BTreeToSerialITweet(sTree, check);

                buildListBox(crescentOrder.Checked, 1);
            }
            else
            {
                MessageBox.Show("Não foi possível localizar o arquivo.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buildListBox(crescentOrder.Checked, 1); //DateTime
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buildListBox(crescentOrder.Checked, 2); //DisplayName
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buildListBox(crescentOrder.Checked, 3); //Name
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buildListBox(crescentOrder.Checked, 4); //RetweetCount
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buildListBox(crescentOrder.Checked, 5); //FavouriteCount
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buildListBox(crescentOrder.Checked, 6); //Id
        }

        private void buscaUsuario_Click(object sender, EventArgs e)
        {
            AskString testDialog = new AskString();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if(testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                string user = testDialog.textBox1.Text;
                testDialog.Dispose();

                searchTree(user);
            }
            else
            {
                testDialog.Dispose();
            }
            
        }
    }
}
