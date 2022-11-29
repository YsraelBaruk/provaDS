using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProva
{
    public partial class FormTutor : Form
    {
        public FormTutor()
        {
            InitializeComponent();
        }

        private void btnCadastrr_Click(object sender, EventArgs e)
        {

        }

        private void FormTutor_Load(object sender, EventArgs e)
        {
            tbcTutor.Size = new Size(ClientSize.Width - 15, ClientSize.Height - 15);
            dtTutor.Size = new Size(ClientSize.Width - 20, ClientSize.Height - 30);            

        }


        private void FormTutor_Resize(object sender, EventArgs e)
        {
            tbcTutor.Size = new Size(ClientSize.Width - 15, ClientSize.Height - 15);
            dtTutor.Size = new Size(ClientSize.Width - 20, ClientSize.Height - 30);
        }
        
        private void txtBusca_Enter(object sender, EventArgs e)
        {
            
            if (txtBusca.Text == "Busque aqui...")
            {
                txtBusca.Text = "";
                txtBusca.ForeColor = Color.Black;
            }
        }

        private void txtBusca_Leave(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
            {
                txtBusca.Text = "Busque aqui...";
                txtBusca.ForeColor = Color.DarkGray;
            }
        }
    }
}
