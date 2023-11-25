using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrabalhoFinal_Jogo
{
    public class Palavra : Jogo
    {
        public int tentativas { get; set; }
        public string palavra { get; }

        private string[] palavras = { "sagaz", "termo", "mexer", "nobre", "senso", "afeto", "algoz", "plena", "fazer", "assim",
            "vigor","sutil", "sanar", "poder", "ideia", "cerne", "inato", "moral", "muito", "justo", "honra", "sonho", "etnia",
            "anexo", "amigo", "lapso", "haver", "expor", "tempo", "casal", "pesar", "saber", "causa", "dizer", "genro" };
        public List<char> atualPalavra = new List<char>();
        //public char[] atualPalavra = new char[5];
        public int letrasNaPalavra = 0;

        public Palavra(string nome)
        {
            this.nome = nome;
            Random random = new Random();
            palavra = palavras[random.Next(palavras.Length)];
        }

        public void adcionandoLetra(char letra)
        {
            if (letrasNaPalavra != 5) 
            {
                atualPalavra.Add(letra);
                letrasNaPalavra++;
            }
        }

        public void removendoLetra()
        {
            if (letrasNaPalavra != 0)
            {
                letrasNaPalavra--;
                atualPalavra.RemoveAt(letrasNaPalavra);
            }
        }
        
        public void resetandoPalavra()
        {
            this.atualPalavra.Clear();
            this.letrasNaPalavra = 0;
        }
    }
}