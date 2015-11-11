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

namespace BuscaLogo.Forms
{
    public partial class Tweet_Reader : Form
    {
        sTweet[] sList;

        public Tweet_Reader()
        {
            InitializeComponent();

            string ReadFile = BuscaLogo.Inicio.OpenFileName;

            if(ReadFile != String.Empty)
            {
                sList = FileManipulation.readBinFile(ReadFile);
                
                if(sList != null)
                    buildListBox(sList.Count());
            }
            else
            {
                BackgroundNull.BringToFront();
                label1.BringToFront();

                BackgroundNull.Show();
                label1.Show();
            }
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

        private void Tweet_ShowSelected(object sender, EventArgs e) //activates when selected index of TweetList changes
        {
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
            string ReadFile = BuscaLogo.Inicio.OpenFileName;

            if(ReadFile != String.Empty)
            {
                sList = FileManipulation.readBinFile(ReadFile);
                buildListBox(sList.Count());
            }
        }
    }
}
