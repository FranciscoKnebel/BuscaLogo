using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaLogo.Forms
{
    public partial class AskString: Form
    {
        public AskString()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            {
                this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
