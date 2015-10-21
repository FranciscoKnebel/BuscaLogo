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

namespace BuscaLogo
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
            //MessageBox.Show(Ler.Texto(tweet));
            Tweet.PublishTweet(Ler.Texto(tweet));
            //string show = "The Elapsed event was raised at " + e.SignalTime;
            //System.Windows.Forms.MessageBox.Show(show);
        }
    }
}
