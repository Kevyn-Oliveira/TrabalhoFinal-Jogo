using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoFinal_Jogo
{
    public partial class PalavrasForm : Form
    {
        Palavra palavras = new Palavra(Form1.nome);
        public PalavrasForm()
        {
            InitializeComponent();
        }

        private void Palavras_Load(object sender, EventArgs e)
        {
            txbNome.Text = palavras.nome;
            //txbNome.BackColor = Color.White;
        }

        private void adicionandoLetra(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            palavras.adcionandoLetra(Convert.ToChar(btn.Text.ToLower()));
            atualizandoPalavra();
        }
        private void removendoLetra(object sender, EventArgs e)
        {
            palavras.removendoLetra();
            atualizandoPalavra();
        }

        private void atualizandoPalavra()
        {
            label1.Text = string.Empty;
            foreach (char letra in palavras.atualPalavra)
            {
                label1.Text += letra;
            }
        }
    }
}
