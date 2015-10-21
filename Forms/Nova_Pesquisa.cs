using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;

namespace BuscaLogo
{
    public partial class Nova_Pesquisa: Form
    {
        public Nova_Pesquisa()
        {
            InitializeComponent();
        }

        public static IEnumerable<ITweet> listOfTweets;
        private void Pesquisar()
        {

            //Geocode = Longitude, latitude, raio, unidade de medida do raio
            //  Campus do Vale
            //-51.1218710,-30.0710872
            //

            var searchParameter = new TweetSearchParameters(searchTextParameter.Text)
             {
                 GeoCode = new GeoCode(-51.1218710,-30.0710872, 1, DistanceMeasure.Kilometers),
                 //Lang = Language.English,
                 //SearchType = SearchResultType.Popular,
                 MaximumNumberOfResults = 100,
                 //Until = new DateTime(2015, 06, 02),
                 //SinceId = 399616835892781056,
                 //MaxId = 405001488843284480,
                 //Filters = TweetSearchFilters.Images
                 
                 /* These are all the TweetSearchParameters:

                TweetSearchFilters Filters { get; set; }
                IGeoCode GeoCode { get; set; }
                Language Lang { get; set; }
                string Locale { get; set; }
                long MaxId { get; set; }
                int MaximumNumberOfResults { get; set; }
                string SearchQuery { get; set; }
                SearchResultType SearchType { get; set; }
                DateTime Since { get; set; }
                long SinceId { get; set; }
                TweetSearchType TweetSearchType { get; set; }
                DateTime Until { get; set; } */
            };
            

            listOfTweets = localSearch.Pesquisa(searchParameter);

            string aux = "";
            int i = 0;
            foreach(var tweet in listOfTweets)
            {
                aux = String.Format("{0}\n{1}", aux, tweet.Text);
                i++;
            }
            MessageBox.Show(String.Format("{0}\nN: {1}",aux,i));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
