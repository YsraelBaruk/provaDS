using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProva
{
    public partial class FormPet : Form
    {
        public FormPet()
        {
            InitializeComponent();
            carregarDt();
        }

        private void carregarDt()
        {
            dtAnimais.Rows.Clear();
            string cmdSql = "CALL `petSelect`()";
            DataTable listaAnimais = Program.cx.SELECT(cmdSql);
            if (listaAnimais != null)
            {
                foreach (DataRow linha in listaAnimais.Rows)
                {
                    dtAnimais.Rows.Add(linha[1], linha[2], linha[3], linha[4], linha[5], linha[6], linha[7]);
                }
            }
        }

        private void barraBusca()
        {
            dtAnimais.Rows.Clear();
            string busca = textBox1.Text;
            string cmdSql = $"CALL `petSelectDt`('{busca}');";
            DataTable listaAnimais = Program.cx.SELECT(cmdSql);
            if (listaAnimais != null)
            {
                foreach (DataRow linha in listaAnimais.Rows)
                {
                    dtAnimais.Rows.Add(linha[1], linha[2], linha[3], linha[4], linha[5], linha[6], linha[7]);
                }
            }
        }

        private void FormAdocao_Resize(object sender, EventArgs e)
        {            
            tbcCadastrar.Size = new Size(ClientSize.Width - 15, ClientSize.Height-15);
            dtAnimais.Size = new Size(ClientSize.Width - 20, ClientSize.Height - 30);

        }
        List<string[]> animais;
        private void FormAdocao_Load(object sender, EventArgs e)
        {
            tbcCadastrar.Size = new Size(ClientSize.Width - 15, ClientSize.Height - 15);
            dtAnimais.Size = new Size(ClientSize.Width - 20, ClientSize.Height - 30);

            string[] Mamiferos = { "Cão", "Gato", "Furão", "Cavalo", "Coelho", "Hamster", "Rato", "Camundongo", "Porquinho-da-índia", "Porco doméstico", "Chinchila", "Gerbil" };
            string[] Aves = { "Piriquitos", "Canário", "Caturra (Calopsita)", "Cacatuas", "Papagaios", "Galinha (Galo)", "Peru", "Pato", "Arara", "Mandarim", "Agapornis", "Pardal doméstico", "Galah", "Calafate", "Cardeal (ave)", "Curió", "Canário-da-terra", "Trinca-Ferro" };
            string[] Repteis = { "Cágados", "Tartarugas", "Jabutis", "Lagartos (Teiú, Iguana, gecko, etc…)", "Cobras (Serpentes)" };
            string[] Anfibios = { "Sapos", "Perereca", "Salamandras" };
            string[] Peixes = { "Poecilídeos (Platy, lebiste, etc...)", "Betta", "Kinguio", "Carpa", "Barbos", "Peixe-palhaço", "Tetras (néon, Matogrosso, rodóstomus, etc...)", "Acarás", "Oscar", "Cirurgiões", "Cascudos", "Coridoras" };

            animais = new List<string[]> { Mamiferos, Aves, Repteis, Anfibios, Peixes };

        }

        private void cbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEspecie.SelectedIndex > -1) 
            {
                cbAnimal.Items.Clear();
                int index = cbEspecie.SelectedIndex;
                string[] especieEscolhida = animais[index];
                foreach (string animal in especieEscolhida) 
                {
                    cbAnimal.Items.Add(animal);
                }
            }
        }

        private void BtnCadastrr_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string especie = cbEspecie.Text;
            string animal = cbAnimal.Text;
            DateTime date = Convert.ToDateTime(dtpDataNasc.Text);
            //double peso = txtPeso.Text;
            double peso = Convert.ToDouble(txtPeso.Text);
            int vacinado = radioButton2.Checked? 0 : 0;
            if (rbVacinadoSim.Checked)
            {
                vacinado = 1;
            }
            string sobre = txtSobre.Text;

            string cmdSql = $"CALL petInsert('{nome}', '{especie}', '{animal}', '{date}', '{peso}', '{vacinado}', '{sobre}')";

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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            barraBusca();
        }
    }
}
