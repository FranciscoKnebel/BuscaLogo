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
        IEnumerable<ITweet> Tweets;
        sTweet[] sList;
        
        public Tweet_Reader()
        {
            InitializeComponent();

            Tweets = Nova_Pesquisa.listOfTweets;
            if (Tweets != null)
            {
                sList = FileManipulation.ListToSerialTweet(Tweets, Tweets.Count());
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
                sTweet aux = sList[selectedIndex];

                TweetTextbox.Text = aux.Text;
                TweetName.Text = aux.Name;
                TweetDisplayName.Text = "@" + aux.DisplayName;
                TweetDateTime.Text = aux.DateTime.ToString();
                TweetRetweets.Text = aux.RetweetCount.ToString();
                TweetFavourites.Text = aux.FavouriteCount.ToString();
            }
        }

        private void TweetRefresh_Click(object sender, EventArgs e)
        {
            Tweets = Nova_Pesquisa.listOfTweets;
            sList = FileManipulation.ListToSerialTweet(Tweets, Tweets.Count());

            if (Tweets != null)
            {
                buildListBox(sList.Count());
            }
        }
    }
}
