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
            carregarDt();
        }

        private void carregarDt()
        {
            dtTutor.Rows.Clear();
            string cmdSql = "CALL `tutorSelect`()";
            DataTable listaTutor = Program.cx.SELECT(cmdSql);
            if (listaTutor != null)
            {
                foreach (DataRow linha in listaTutor.Rows)
                {
                    dtTutor.Rows.Add(linha[1], linha[2], linha[3], linha[4], linha[5], linha[6]);
                }
            }
        }

        private void btnCadastrr_Click(object sender, EventArgs e)
        {
            //tutor.cep, tutor.uf, tutor.cidade, tutor.bairro, tutor.logradouro, tutor.numero
            string cpf = txtCpf.Text;
            string nome = txtNome.Text;
            string tel = txtTelefone.Text;
            string email = txtEmail.Text;
            DateTime date = Convert.ToDateTime(dtDataNasc.Text);            
            string cep = txtCEP.Text;
            string uf = cbUF.Text;
            string cidade = txtCidade.Text;
            string bairro = txtBairro.Text;
            string logra = txtLogradouro.Text;
            string numero = txtNumero.Text;

            string cmdSql = $"CALL tutorInsert('{cpf}', '{nome}', '{tel}', '{email}', '{date}', '{cep}', '{uf}', '{cidade}', '{bairro}', '{logra}', '{numero}')";

            if (Program.cx.INSERT(cmdSql) > 0)
            {
                MessageBox.Show("Animal adicionado com sucesso", "Cadastro de Animal");
                carregarDt();
            }
            else
            {
                MessageBox.Show("Pet não foi confirmado");
            }
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
