using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BuscaLogo.Classes
{
    class Ler
    {
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
