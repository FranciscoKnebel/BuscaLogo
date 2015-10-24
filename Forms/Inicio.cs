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
            Dispose();
        }

        private void MostraTimeline()
        {
            var loggedUser = User.GetLoggedUser();
            var pegatimeline = loggedUser.GetUserTimeline();

            foreach (var tweet in pegatimeline)
            {
                string aux = String.Format("Usuário {0} (@{1}) postou este tweet:\n {2} \nTamanho {3}.", 
                    tweet.CreatedBy, 
                    tweet.CreatedBy.ScreenName, 
                    tweet.Text, 
                    tweet.PublishedTweetLength);

                MessageBox.Show(aux);
            }
        }
        private void MostraMentions()
        {
            var loggedUser = User.GetLoggedUser();
            var pegatimeline = loggedUser.GetMentionsTimeline();

            foreach (var tweet in pegatimeline)
            {
                string aux = String.Format("Usuário {0} (@{1}) postou esta menção para @{2}:\n {3} \nTamanho {4}.",
                    tweet.CreatedBy, 
                    tweet.CreatedBy.ScreenName, 
                    tweet.InReplyToScreenName, 
                    tweet.Text, 
                    tweet.PublishedTweetLength);

                MessageBox.Show(aux);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MostraTimeline();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MostraMentions();     
        }

        public Form newSearch = new Nova_Pesquisa();
        private void NovaPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                newSearch.Show();
            }
            catch(ObjectDisposedException)
            {
                newSearch = new Nova_Pesquisa();
                newSearch.Show();
            }
            newSearch.Activate();
        }


    }
}
