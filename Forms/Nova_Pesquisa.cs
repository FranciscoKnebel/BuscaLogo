using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaLogo
{
    public partial class Nova_Pesquisa: Form
    {
        public Nova_Pesquisa()
        {
            InitializeComponent();
        }

        public static List<string> Lista = new List<string>();
        private void Pesquisar()
        {
            Lista.Add(BuscaGeolocal.Pesquisa());

             for (int i = 0; i < 10; i++)
             {
                 MessageBox.Show(Lista[i]);
             }

        }
    }
}
