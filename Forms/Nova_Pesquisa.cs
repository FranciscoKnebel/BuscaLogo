using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Parameters;
using Tweetinvi.Core.Parameters;

namespace BuscaLogo
{
    public partial class Nova_Pesquisa: Form
    {
        public Nova_Pesquisa()
        {
            InitializeComponent();
            GeoPosBoxParameter.SetSelected(0, true); //seta <none> como Geolocal padrão
        }

        public static IEnumerable<ITweet> listOfTweets;
        private IEnumerable<ITweet> Pesquisar()
        {
            // Creates the search parameter for the localSearch class search function.
            var searchParameter = new TweetSearchParameters(searchTextParameter.Text)
            {
                MaximumNumberOfResults = (int) numberTweetsParameter.Value,
                                 
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

            //if the <none> geolocation isn't selected, the user wants to set a geolocation.
            if (!GeoPosBoxParameter.GetSelected(0)) 
            {
                //Geocode = (Longitude, latitude, radius, measure unit)
                if (GeoPosBoxParameter.GetSelected(1))      //Campus Centro
                    searchParameter.GeoCode = new GeoCode(-51.2209625, -30.0331423, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                else if (GeoPosBoxParameter.GetSelected(2)) //Campus do Vale
                    searchParameter.GeoCode = new GeoCode(-51.1218710, -30.0710872, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                else if (GeoPosBoxParameter.GetSelected(3)) //Hospital de Clínicas
                    searchParameter.GeoCode = new GeoCode(-51.2069721, -30.0390867, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                else if (GeoPosBoxParameter.GetSelected(4)) //Aeroporto Salgado Filho
                    searchParameter.GeoCode = new GeoCode(-51.1753810, -29.9934730, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
            }
            
            listOfTweets = Search.SearchTweets(searchParameter);
            foreach(var tweet in listOfTweets)
            {
                MessageBox.Show(String.Format("Usuário {0} (@{1}) tweetou:\n\"{2}\"\nTweet com tamanho de {3} caracters.",
                  tweet.CreatedBy, tweet.CreatedBy.ScreenName, tweet.Text, tweet.CalculateLength(false)));
            }

            return listOfTweets;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
