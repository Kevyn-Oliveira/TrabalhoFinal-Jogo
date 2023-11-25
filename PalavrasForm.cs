using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoFinal_Jogo
{
    public partial class PalavrasForm : Form
    {
        Palavra palavras = new Palavra(Form1.nome);
        TextBox[,] textBoxes;
        private int linha, coluna = 0;
        Color cor;

        public PalavrasForm()
        {
            InitializeComponent();

            InicializarMatrizTextBoxes();
        }


        private void InicializarMatrizTextBoxes()
        {
            // Inicializar a matriz de TextBoxes
            textBoxes = new TextBox[6,5]
            {
            { this.textBox1, textBox2, textBox3, textBox4, textBox5 },
            { textBox6, textBox7, textBox8, textBox9, textBox10 },
            { textBox11, textBox12, textBox13, textBox14, textBox15 },
            { textBox16, textBox17, textBox18, textBox19, textBox20 },
            { textBox21, textBox22, textBox23, textBox24, textBox25 },
            { textBox26, textBox27, textBox28, textBox29, textBox30 }
            };
        }

        private void Palavras_Load(object sender, EventArgs e)
        {
            txbNome.Text = palavras.nome;
            //txbNome.BackColor = Color.White;
            //label1.Text = palavras.palavra;
        }

        private void adicionandoLetra(object sender, EventArgs e)
        {
            if (coluna < textBoxes.GetLength(1))
            {
                Button btn = sender as Button;
                palavras.adcionandoLetra(Convert.ToChar(btn.Text.ToLower()));
                textBoxes[linha, coluna].Text =
                    Convert.ToString(palavras.atualPalavra[palavras.letrasNaPalavra - 1]).ToUpper();
                coluna++;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (palavras.atualPalavra.Count == 5)
            {

                comparandoPalavras();
                linha++;
                coluna = 0;

                palavras.resetandoPalavra();


            }
        }

        private void removendoLetra(object sender, EventArgs e)
        {
            if (coluna > 0)
            {
                palavras.removendoLetra();
                coluna--;
                textBoxes[linha, coluna].Text = string.Empty;
            }
        }

        private void comparandoPalavras()
        {
            char[] letrasDaPalavra = palavras.palavra.ToCharArray();
            for (int i = 0; i < 5; i++)
            {
                if (palavras.atualPalavra[i] == letrasDaPalavra[i])
                {
                    textBoxes[linha, i].BackColor = Color.LightGreen;
                    pintandoTeclado(Convert.ToString(palavras.atualPalavra[i]), "certa");
                    continue;
                }

                bool letraCorreta = false;
                for (int j = 0; j < 5; j++)
                {
                    if (palavras.atualPalavra[i] == letrasDaPalavra[j])
                    {
                        textBoxes[linha, i].BackColor = Color.LightYellow;
                        pintandoTeclado(Convert.ToString(palavras.atualPalavra[i]), "posicao");
                        letraCorreta = true;
                        break;
                    }
                }

                if (!letraCorreta)
                {
                    textBoxes[linha, i].BackColor = Color.LightGray;
                    desativandoTecla(textBoxes[linha, i].Text);
                    pintandoTeclado(Convert.ToString(palavras.atualPalavra[i]), "errada");
                }
            }
        }

        private void pintandoTeclado(string letra, string opcao)
        {
            switch (opcao)
            {
                case "certa":
                    cor = Color.LightGreen;
                    break;
                case "posicao":
                    cor = Color.LightYellow;
                    break;
                case "errada":
                    cor = Color.LightGray;
                    break;
            }
            Button btn = procurarBotao(letra.ToUpper());
            btn.BackColor = cor;
        }

        private void desativandoTecla(string letra)
        {
            Button btn = procurarBotao(letra.ToUpper());
            btn.Enabled = false;
        }

        private Button procurarBotao(string letra)
        {
            foreach (Control controle in this.Controls)
            {
                if (controle is Button && controle.Text == letra)
                {
                    return controle as Button;
                }
            }
            return null;
        }
    }
}