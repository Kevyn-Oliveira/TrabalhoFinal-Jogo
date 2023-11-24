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
        }

        private void NumeroSelecionado(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (mega.numerosSelecionados.Count() == mega.numerosNaAposta && !mega.numerosSelecionados.Contains(Convert.ToInt16(button.Text)))
            { return; }
            else { colorirBotao(button); }
            mega.AdicionarNumeroSelecionado(Convert.ToInt16(button.Text));
            nudNumerosAposta.Minimum = mega.numerosSelecionados.Count() >= 6 ? mega.numerosSelecionados.Count() : 6; 
        }

        private void colorirBotao(object button)
        {
            Button buttonColor = button as Button;
            if (buttonColor.BackColor == SystemColors.Window) { buttonColor.BackColor = Color.LightBlue; }
            else {  buttonColor.BackColor = SystemColors.Window; }
        }

        private void nudNumerosAposta_ValueChanged(object sender, EventArgs e)
        {
            mega.numerosNaAposta = Convert.ToInt16(nudNumerosAposta.Value);
        }
    }
}
