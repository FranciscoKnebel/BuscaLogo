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

namespace BuscaLogo
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            Carregar.Hide();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Credentials(); //Setup das credenciais do API  
        }

        private void Credentials()
        {
            // Set up your credentials (https://apps.twitter.com)
            // These are application-only credentials, so you can't tweet.
            string consumerKey = "";
            string consumerSecret = "";
            Auth.SetApplicationOnlyCredentials(consumerKey, consumerSecret, true);
        }
        
        public Form newSearch;
        private void NovaPesquisa_Click(object sender, EventArgs e)
        {
            if(newSearch != null)
            {
                if(!newSearch.Created)
                {
                    newSearch = new Nova_Pesquisa();
                    try
                    {
                        newSearch.Show();
                    }
                    catch(ObjectDisposedException)
                    {
                        newSearch = new Nova_Pesquisa();
                        newSearch.Show();
                    }
                }
                newSearch.Activate();
            }
            else
            {
                newSearch = new Nova_Pesquisa();
                newSearch.Show();
                newSearch.Activate();
            }

            newSearch.Location = new Point(315, newSearch.Location.Y);
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

            TweetReader.Location = new Point(1125, TweetReader.Location.Y);
        }

        public Form aboutForm;
        private void sobreOProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(aboutForm != null)
            {
                if(!aboutForm.Created)
                {
                    aboutForm = new Sobre();
                    try
                    {
                        aboutForm.Show();
                    }
                    catch(ObjectDisposedException)
                    {
                        aboutForm = new Sobre();
                        aboutForm.Show();
                    }
                }
                aboutForm.Activate();
            }
            else
            {
                aboutForm = new Sobre();
                aboutForm.Show();
                aboutForm.Activate();
            }
            aboutForm.Location = new Point(aboutForm.Location.X, 120);
        }

        private void IconAreaNotif_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Activate();
        }
        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IconAreaNotif.Visible = false;
            Application.Exit();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            IconAreaNotif.Visible = false;
            Application.Exit();
        }

        public static string OpenFileName = String.Empty;
        private void Carregar_Click(object sender, EventArgs e)
        {
            //OpenFileName = FileManipulation.getFileToRead();
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Você tem certeza disso? Todas as suas buscas serão apagadas.", "Busca por usuário", MessageBoxButtons.YesNo);
            if(choice == DialogResult.Yes)
                FileManipulation.DeleteFiles();
        }
    }

    [Serializable]
    public class sTweet
    {
        public string Text;
        public string Name;
        public string DisplayName;
        public DateTime DateTime;
        public int RetweetCount;
        public int FavouriteCount;
        public long Id;
        public string IdStr;
        
        public sParameters serializeParameters;

        public sTweet(string T, string N, string DisplayN, DateTime Date, int RetweetC, int FavouriteC, long Identif, string IdentifStr)
        {
            Text = T;
            Name = N;
            DisplayName = DisplayN;
            DateTime = Date;
            RetweetCount = RetweetC;
            FavouriteCount = FavouriteC;
            Id = Identif;
            IdStr = IdentifStr;
        }

        public sTweet()
        {

        }
    };

    [Serializable]
    public class sParameters
    {
        public double longitude;
        public double latitude;
        public double radius;
        public bool isKilometer;
        public byte language;
        public byte tweettype;

        public sParameters(double L, double l, double r, bool isKM, byte lang, byte type)
        {
            longitude = L;
            latitude = l;
            radius = r;
            isKilometer = isKM;
            language = lang;
            tweettype = type;
        }
    }

    [Serializable]
    public class TreeIndexCheck
    {
        public int index;
        public int height;
        public int degree;

        public TreeIndexCheck(int i, int h, int d)
        {
            index = i;
            height = h;
            degree = d;
        }

        override public string ToString()
        {
            string aux = string.Format("{0} {1} {2}", index, height, degree);

            return aux;
        }
    }
}
