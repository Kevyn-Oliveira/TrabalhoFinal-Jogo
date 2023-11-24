using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoFinal_Jogo
{
    public partial class MegaSenaForm : Form
    {
        MegaSena mega = new MegaSena(Form1.nome, 6);

        public MegaSenaForm()
        {
            InitializeComponent();
        }

        private void MegaSenaForm_Load(object sender, EventArgs e)
        {
            txbNome.Text = mega.nome;
            txbNome.BackColor = Color.White;
            txbNome.ForeColor = Color.Black;
            txbEscolhidos.BackColor = Color.White;
            txbNumerosSorteados.BackColor = Color.White;
        }

        private void NumeroSelecionado(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (mega.numerosSelecionados.Count() == mega.numerosNaAposta && !mega.numerosSelecionados.Contains(Convert.ToInt16(button.Text)))
            { return; }
            else { colorirBotao(button); }
            mega.AdicionarNumeroSelecionado(Convert.ToInt16(button.Text));
            nudNumerosAposta.Minimum = mega.numerosSelecionados.Count() >= 6 ? mega.numerosSelecionados.Count() : 6;
            imprimirNumerosSelecionados();
        }

        private void colorirBotao(object button)
        {
            Button buttonColor = button as Button;
            if (buttonColor.BackColor == Color.White) { buttonColor.BackColor = Color.LightBlue; }
            else {  buttonColor.BackColor = Color.White; }
        }

        private void imprimirNumerosSelecionados()
        {
            int[] numeros = mega.numerosSelecionados.ToArray();
            txbEscolhidos.Text = string.Empty;
            foreach (int numero in numeros)
            {
                txbEscolhidos.Text += numero.ToString() + " ";
            }
        }

        private void nudNumerosAposta_ValueChanged(object sender, EventArgs e)
        {
            mega.numerosNaAposta = Convert.ToInt16(nudNumerosAposta.Value);
        }

        private void compararNumeros()
        {
            int acertos = 0;
            foreach (int numero in mega.numerosSelecionados)
            {
                foreach (int numeroSorteado in mega.numerosSorteados)
                {
                    if (numero == numeroSorteado) { acertos++; }
                }
            }
            if (acertos == 6) { lblResultado.Text = "Ganhou!"; }
            else { lblResultado.Text = "Não foi dessa vez!"; }
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            txbNumerosSorteados.Text = string.Empty;
            mega.SortearNumeros();
            foreach (int numero in mega.numerosSorteados)
            {
                txbNumerosSorteados.Text += numero.ToString() + " ";
            }
            compararNumeros();
        }
    }
}
