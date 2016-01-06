using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO;
using Tweetinvi;
using Tweetinvi.Core.Credentials;

namespace BuscaLogo.Classes
{
    public class AutoPost
    {
        private static System.Timers.Timer aTimer = new System.Timers.Timer(300000); //5 minutos em ms

        private static TextReader tweet;
        private static Tweetinvi.Core.Interfaces.ILoggedUser loggedUser;

        public static void Executa(Tweetinvi.Core.Interfaces.ILoggedUser logado, TextReader leitor)
        {
            tweet = leitor;
            loggedUser = logado;

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);    //Verificador do Timer. Quando o tempo tiver terminado, ele executada o evento OnTimedEvent.
            aTimer.Enabled = true;                                      //Reseta o timer, para outra verificação.
        }

        // Specify what you want to happen when the Elapsed event is 
        // raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //MessageBox.Show(Texto(tweet));
            Tweet.PublishTweet(Texto(tweet));
            //string show = "The Elapsed event was raised at " + e.SignalTime;
            //System.Windows.Forms.MessageBox.Show(show);
        }

        public static string Texto(TextReader leitor)
        {
            char[] buffer = new char[140];
            StringBuilder builder = new StringBuilder("");

            leitor.ReadBlock(buffer, 0, 140);   //lê um bloco de 140 caracteres e coloca no buffer
                                                //foreach (var caracter in buffer)
                                                //show = show + caracter.ToString();

            foreach (char c in buffer)          //transforma o char[] em um construtor de strings
                builder.Append(c);
            //if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))


            return builder.ToString();          //retorna a string lida
        }
    }
}
