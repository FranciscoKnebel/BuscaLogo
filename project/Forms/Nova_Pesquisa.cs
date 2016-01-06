using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;
using System.Linq;

namespace BuscaLogo
{
    public partial class Nova_Pesquisa: Form
    {
        public Nova_Pesquisa()
        {
            InitializeComponent();
        }

        private void Nova_Pesquisa_Load(object sender, EventArgs e)
        {
            GeoPosBoxParameter.SetSelected(0, true);        //seta <none> como Geolocal padrão
            tweetSearchTypeParameter.SetSelected(0, true);  //seta Todos os Tweets como tipo de pesquisa padrão

            //Loads the listbox language values
            Dictionary<string, Language> langParameterSource = new Dictionary<string, Language>();
            langParameterSource.Add("<undefined>", Language.Undefined);
            langParameterSource.Add("Português", Language.Portuguese);
            langParameterSource.Add("English", Language.English);
            langParameterSource.Add("Español", Language.Spanish);

            //Bind the source Dictionary object to Combobox
            langParameter.DataSource = new BindingSource(langParameterSource, null);
            langParameter.DisplayMember = "Key";
            langParameter.ValueMember = "Value";

            //((KeyValuePair<string, Language>)langParameter.SelectedItem).Key;   //get key of selected item in listbox   
            //((KeyValuePair<string, Language>)langParameter.SelectedItem).Value; //get value of selected item in listbox
        }

        public static BTree.BTree<int, sTweet> TreeOfTweets;
        private void button1_Click(object sender, EventArgs e)
        {
            TreeOfTweets = Pesquisar();

            TreeIndexCheck newCheck = new TreeIndexCheck(0, 0, 0);
            sTweet[] TweetArray = FileManipulation.GetNewArrayToBin(TreeOfTweets);
            TreeOfTweets = FileManipulation.SerialITweetToBTree(TweetArray, ref newCheck);
            FileManipulation.createBinTreeFile(TreeOfTweets, newCheck);
        }

        private BTree.BTree<int, sTweet> Pesquisar()
        {
            // Creates the search parameter for the search function.
            var searchParameter = new TweetSearchParameters(searchTextParameter.Text)
            {
                MaximumNumberOfResults = (int) numberTweetsParameter.Value,
                Lang = ((KeyValuePair<string, Language>) langParameter.SelectedItem).Value, //get language value of selected item in langParameter listbox
                TweetSearchType = Type(),    //get Tweet Search Type from selected item in tweetsearchtypeparameter listbox
            };           
            
            //if the <none> geolocation isn't selected, the user wants to set a geolocation.
            //Searches through index of listbox and finds which option the user choose.
            int indexGeoPosParameter = GeoPosBoxParameter.SelectedIndex;
            switch (indexGeoPosParameter)
            {
                case 1: //Campus Centro
                    searchParameter.GeoCode = new GeoCode(-51.2209625, -30.0331423, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                    break;
                case 2: //Campus do Vale
                    searchParameter.GeoCode = new GeoCode(-51.1218710, -30.0710872, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                    break;
                case 3: //Hospital de Clínicas
                    searchParameter.GeoCode = new GeoCode(-51.2069721, -30.0390867, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                    break;
                case 4: //Aeroporto Salgado Filho
                    searchParameter.GeoCode = new GeoCode(-51.1753810, -29.9934730, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                    break;
                case 5: //Mercado Público
                    searchParameter.GeoCode = new GeoCode(-51.2278460, -30.0275120, (double)radiusParameter.Value, DistanceMeasure.Kilometers);
                    break;
                case 6: //Cristo Redentor
                    searchParameter.GeoCode = new GeoCode(-43.2104845, -22.9519098, (double) radiusParameter.Value, DistanceMeasure.Kilometers);
                    break;
                case 7: //Aeropuerto Tegucigalpa
                    searchParameter.GeoCode = new GeoCode(-87.2170801, 14.0608254, (double) radiusParameter.Value, DistanceMeasure.Kilometers);
                    break;
                default: //Geolocale not defined
                    break;
            }

            return Pesquisar(searchParameter);
        }

        private BTree.BTree<int, sTweet> Pesquisar(TweetSearchParameters searchParameter)
        {
            string aux = button1.Text;
            if ((searchParameter.SearchQuery != "") || (searchParameter.GeoCode != null)) //usuário passou parâmetros
            {
                progressBar.Show();
                button1.Text = "Searching, please wait...";
                IEnumerable<ITweet> list = Search.SearchTweets(searchParameter);

                progressBar.Step = 33;
                progressBar.PerformStep();

                sTweet[] tweetArray = FileManipulation.ListToSerialTweet(list, list.Count(), searchParameter);
                progressBar.PerformStep();

                TreeIndexCheck check = new TreeIndexCheck(0, 0, 0);
                BTree.BTree<int, sTweet> Tree = FileManipulation.SerialITweetToBTree(tweetArray, ref check);
                progressBar.PerformStep();
              

                int i = list.Count();
                button1.Text = aux;

                MessageBox.Show("Todos tweets lidos. Retornando a lista com " + i.ToString() + " elementos.");
                progressBar.Value = 0;

                return Tree;
            }
            else
            {
                MessageBox.Show("Pesquisa sem parâmetros!\nInsira pelos menos um query de texto ou um geolocal.", "ERROR 001");
                return null;
            }
        }

        private bool checkTreeFileIntegrity(BTree.BTree<int, sTweet> tree, TreeIndexCheck checkNewTree)
        {
            if(tree.Degree != checkNewTree.degree || tree.Height != checkNewTree.height)
            {
                MessageBox.Show(@"Problema com a árvore lida! Houve problema no salvamento dos arquivos,
                                \nOu alguém alterou informações de dentro dos arquivos.", "ERRO 004");
                return false;
            }
            else
            {
                MessageBox.Show(String.Format("Árvore salva com sucesso!\n\nHeight:\t{0}\nDegree:\t{1}\nIndex:\t{2}", tree.Height, tree.Degree, checkNewTree.index));
                return true;
            }
        }

        private IEnumerable<ITweet> PesquisarTimeline(string userScreenName)
        {
            var userTimelineParameter = new UserTimelineParameters()
            {
                MaximumNumberOfTweetsToRetrieve = 200,
                ExcludeReplies = true,
                IncludeRTS = false,
            };

            string aux = button1.Text;
            button1.Text = "Searching, please wait...";
            var listOfTweets = Timeline.GetUserTimeline(userScreenName, userTimelineParameter);
            button1.Text = aux;
            foreach (var tweet in listOfTweets)
            {
                MessageBox.Show(String.Format("Usuário {0} (@{1}) tweetou:\n\"{2}\"\nTweet com tamanho de {3} caracters.",
                  tweet.CreatedBy, tweet.CreatedBy.ScreenName, tweet.Text, tweet.CalculateLength(false)));
            }

            return listOfTweets;
        }

        private TweetSearchType Type()
        {
            TweetSearchType retorno;

            int index = tweetSearchTypeParameter.SelectedIndex;
            switch (index)
            {
                case 0:
                    retorno = TweetSearchType.All;
                    break;
                case 1:
                    retorno = TweetSearchType.OriginalTweetsOnly;
                    break;
                case 2:
                    retorno = TweetSearchType.RetweetsOnly;
                    break;
                default:
                    MessageBox.Show("Tipo inválido. Contate o administrador.\nPesquisa não irá filtrar por nenhum tipo.", "ERRO 0002");
                    retorno = TweetSearchType.All;
                    break;
            }

            return retorno;
        }

        private void Trending()
        {
            var trendingTopics = Trends.GetTrendsAt(455823); //trending em Porto Alegre. 455823 é o WOEID da cidade.

            foreach(var trend in trendingTopics.Trends)
            {
                var tweets = Search.SearchTweets(trend.Name);
            }
        }

    }
}
