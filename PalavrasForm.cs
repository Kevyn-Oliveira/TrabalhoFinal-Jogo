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
        int min, seg = 0;

        public PalavrasForm()
        {
            InitializeComponent();

            InicializarMatrizTextBoxes();
        }


        private void InicializarMatrizTextBoxes()
        {
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
            if (palavras.nome == "/debug")
            {
                label1.Text = palavras.palavra;
                txbNome.Text = "Kevyn";
                return;
            }
            txbNome.Text = palavras.nome;
        }

        private void adicionandoLetra(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (coluna < textBoxes.GetLength(1))
            {
                Button btn = sender as Button;
                palavras.adcionandoLetra(Convert.ToChar(btn.Text.ToLower()));
                textBoxes[linha, coluna].Text = Convert.ToString(palavras.atualPalavra[palavras.letrasNaPalavra - 1]).ToUpper();
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
            int letrasCertas = 0;
            char[] letrasDaPalavra = palavras.palavra.ToCharArray();
            for (int i = 0; i < 5; i++)
            {
                if (palavras.atualPalavra[i] == letrasDaPalavra[i])
                {
                    textBoxes[linha, i].BackColor = Color.LightGreen;
                    pintandoTeclado(Convert.ToString(palavras.atualPalavra[i]), "certa");
                    letrasCertas++;
                    if (letrasCertas == 5)
                    {
                        timer1.Enabled = false;
                        MessageBox.Show($"Você acertou a palavra!\nSó foram precisos {min} minutos e {seg} segundos!");
                    }
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
            if (linha == 5 && letrasCertas != 5)
            {
                MessageBox.Show($"Você não conseguiu adivinhar a palavra: {(palavras.palavra).ToUpper()}\nmais sorte na próxima!");
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seg < 59)
            {
                seg++;
                atualizarRelogio(min.ToString(), seg.ToString());
            }
            else
            {
                seg = 0;
                min++;
                atualizarRelogio(min.ToString(), seg.ToString());
            }
        }

        private void atualizarRelogio(string min, string seg)
        {
            lblMinutos.Text = Convert.ToInt16(min) < 10 ? "0" + min : min;
            lblSegundos.Text = Convert.ToInt16(seg) < 10 ? "0" + seg : seg;
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