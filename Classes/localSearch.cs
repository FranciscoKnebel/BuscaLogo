using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces.Parameters;
using Tweetinvi.Core.Parameters;

namespace BuscaLogo
{
    public class localSearch
    {
        /// <summary>
        /// Recebe uma string como parâmetro de texto para pesquisa e retorna um IEnumerable, contendo cada tweet encontrado.
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <returns></returns>
        public static IEnumerable<ITweet> Pesquisa(string searchParameter)
        {
            IEnumerable<ITweet> listOfTweets = Search.SearchTweets(searchParameter);

            return listOfTweets;
        }

        /// <summary>
        /// Recebe múltiplos parâmetros para pesquisa e retorna um IEnumerable, contendo cada tweet encontrado.
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        public static IEnumerable<ITweet> Pesquisa(ITweetSearchParameters searchParameters)
        {
            IEnumerable<ITweet> listOfTweets = Search.SearchTweets(searchParameters);

            return listOfTweets;
        }




        /*public static string Pesquisa()
        {
            // Search the tweets containing tweetinvi
            // Complex search

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
            }

            return "batata";
        }*/
    }

}
