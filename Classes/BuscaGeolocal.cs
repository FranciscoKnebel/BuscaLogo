using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces.Parameters;
using Tweetinvi.Core.Parameters;

namespace BuscaLogo
{
    public class BuscaGeolocal
    {
        public static string Pesquisa()
        {
            // Search the tweets containing tweetinvi
            // Complex search
            /* var searchParameter = new TweetSearchParameters("tweetinvi")
             {
                 GeoCode = new GeoCode(-122.398720, 37.781157, 5, DistanceMeasure.Kilometers),
                 //Lang = Language.English,
                 SearchType = SearchResultType.Popular,
                 MaximumNumberOfResults = 100,
                 //Until = new DateTime(2015, 06, 02),
                 //SinceId = 399616835892781056,
                 //MaxId = 405001488843284480,
                 //Filters = TweetSearchFilters.Images
             };*/
            var matchingTweets = Search.SearchTweets("tweetinvi");
            foreach(var tweet in matchingTweets)
            {
                MessageBox.Show(tweet.Text);
            }
 

            //var tweets = Search.SearchTweets(searchParameter);
            /*foreach(var tweet in tweets)
            {
                MessageBox.Show("algumacoisa");
                string aux = "User " + tweet.CreatedBy + "(@" + tweet.CreatedBy.ScreenName + ") posted this tweet:\n\"" + tweet.Text + "\"\n\nWith size " + tweet.PublishedTweetLength;
                MessageBox.Show(aux);
                MessageBox.Show("algumacoisa");
            }*/

            return "batata";
        }

        /// <summary>
        /// Recebe uma string como parâmetro de pesquisa e retorna uma lista de strings, contendo o texto de cada tweet encontrado.
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <returns></returns>
        public static List<string> Pesquisa(string searchParameter)
        {
            List <string> ListaDeTweets = new List<string>();

            var search = Search.SearchTweets(searchParameter);
            foreach(var tweet in search)
            {
                ListaDeTweets.Add(tweet.Text);
            }

            return ListaDeTweets;
        }
    }

}
