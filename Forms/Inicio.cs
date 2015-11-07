using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Interfaces;

namespace BuscaLogo
{
    [Serializable]
    public struct sTweet
    {
        public string Text;
        public string Name;
        public string DisplayName;
        public DateTime DateTime;
        public int RetweetCount;
        public int FavouriteCount;
        public long Id;
        public string IdStr;
    };


    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            //TextReader leitor = File.OpenText(@"A:\Documentos\Dropbox\Code\C#\BuscaLogo\BuscaLogo\dom_casmurro.txt");

            //var loggedUser = User.GetLoggedUser();
            //AutoPost.Executa(loggedUser, leitor);
            //splitText.Texto(leitor, "dom_casmurro");
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Credenciais(); //Setup das credenciais do API  
        }

        private void Credenciais()
        {
            // Set up your credentials (https://apps.twitter.com)
            // These are application-only credentials, so you can't tweet.
            Auth.SetApplicationOnlyCredentials("qNwYoorEWFMSckTcFHIlEUwFk", "ju9lDUhUplJ70FsbqzyJcxOOkhn3c8a5v8SN4jXQzMCmgbNjCR", true);
        }

        public Form aboutForm = new Sobre();
        private void sobreOProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                aboutForm.Show();
            }
            catch (ObjectDisposedException)
            {
                aboutForm = new Sobre();
                aboutForm.Show();
            }
            aboutForm.Activate();
        }
        private void IconAreaNotif_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Activate();
        }
        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Form newSearch;
        private void NovaPesquisa_Click(object sender, EventArgs e)
        {
            if(newSearch != null)
            {
                newSearch = new Nova_Pesquisa();
                try
                {
                    newSearch.Show();
                }
                catch (ObjectDisposedException)
                {
                    newSearch = new Nova_Pesquisa();
                    newSearch.Show();
                }
                newSearch.Activate();
            }
            else
            {
                newSearch = new Nova_Pesquisa();
                newSearch.Show();
                newSearch.Activate();
            }            
        }

        public Form TweetReader;
        private void TweetReaderButton_Click(object sender, EventArgs e)
        {
            if(TweetReader != null)
            {
                if (!TweetReader.Created)
                {
                    TweetReader = new Forms.Tweet_Reader();
                    try
                    {
                        TweetReader.Show();
                    }
                    catch (ObjectDisposedException)
                    {
                        TweetReader = new Forms.Tweet_Reader();
                        TweetReader.Show();
                    }
                    TweetReader.Activate();
                }
            }
            else
            {
                TweetReader = new Forms.Tweet_Reader();
                TweetReader.Show();
                TweetReader.Activate();
            }
        }
    }
}
