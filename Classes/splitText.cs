using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BuscaLogo.Classes
{
    class splitText
    {
        public static void Texto(TextReader leitor, string titulo)
        {
            string buffer;
            int index = 1;
            string currentdir = Directory.GetCurrentDirectory();

            if(!Directory.Exists(currentdir + @"\Chapters"))
                Directory.CreateDirectory(currentdir + @"\Chapters");

            TextWriter escrita = null;
            do
            {
                buffer = leitor.ReadLine();

                if(buffer != null)
                {
                    if (buffer.StartsWith("CAPÍTULO"))
                    {
                        if (escrita != null)
                            escrita.Close();
                        escrita = File.CreateText(currentdir + @"\Chapters\" + titulo + index.ToString() + ".txt");
                        index++;
                    }
                }

                if(escrita != null)
                    escrita.WriteLine(buffer);
            } while (buffer != null);

            escrita.Close();
            return;
        }
    }
}
