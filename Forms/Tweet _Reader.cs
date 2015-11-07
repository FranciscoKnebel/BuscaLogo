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
using Tweetinvi.Core.Interfaces;

namespace BuscaLogo.Forms
{
    public partial class Tweet_Reader : Form
    {
        IEnumerable<ITweet> Tweets;
        ITweet[] list;
        
        public Tweet_Reader()
        {
            InitializeComponent();

            Tweets = Nova_Pesquisa.listOfTweets;
            if (Tweets != null)
            {
                list = Tweets.ToArray();
                buildListBox(list.Count());
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
            Dictionary<string, ITweet> tableSource = new Dictionary<string, ITweet>();

            for (int i = 0; i < contador; i++)
            {
                /*try
                {
                    tableSource.Add(list[i].CreatedBy.ScreenName, list[i]);
                }
                catch (ArgumentException)
                {
                    tableSource.Add(list[i].CreatedBy.ScreenName + i.ToString(), list[i]);
                }*/

                tableSource.Add(list[i].IdStr, list[i]);
            }

            TweetList.DataSource = new BindingSource(tableSource, null);
            TweetList.DisplayMember = "Key";
            TweetList.ValueMember = "Value";
            TweetList.SelectedIndex = 0;
        }

        private void Tweet_ShowSelected(object sender, EventArgs e) //activates when selected index of TweetList changes
        {
            if (list != null)
            {
                int selectedIndex = TweetList.SelectedIndex;
                ITweet aux = list[selectedIndex];

                TweetTextbox.Text = aux.Text;
                TweetName.Text = aux.CreatedBy.Name;
                TweetDisplayName.Text = "@" + aux.CreatedBy.ScreenName;
                TweetDateTime.Text = aux.CreatedAt.ToString();
                TweetRetweets.Text = aux.RetweetCount.ToString();
                TweetFavourites.Text = aux.FavouriteCount.ToString();
            }
        }

        private void TweetRefresh_Click(object sender, EventArgs e)
        {
            Tweets = Nova_Pesquisa.listOfTweets;
            if (Tweets != null)
            {
                list = Tweets.ToArray();
                buildListBox(list.Count());
            }
        }
    }
}
