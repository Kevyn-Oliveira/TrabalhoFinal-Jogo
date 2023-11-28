using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.ComponentModel;
using System.Reflection.Emit;

namespace TrabalhoFinal_Jogo
{
    public class Palavra : Jogo
    {
        public int tentativas { get; set; }
        public string palavra { get; }

        private string[] palavras = {"sagaz","negro","termo","mexer","nobre","senso","afeto","algoz","plena","fazer","assim","vigor",
            "sutil","fosse","sanar","poder","audaz","ideia","cerne","inato","moral","sobre","desde","muito","justo","honra","sonho",
            "etnia","anexo","amigo","lapso","haver","expor","dengo","tempo","casal","seara","ardil","pesar","saber","causa","dizer",
            "genro","posse","dever","tenaz","prole","sendo","comum","temor","ainda","estar","ceder","pauta","digno","culto","mundo",
            "atroz","fugaz","censo","forte","vulgo","denso","pudor","criar","dogma","regra","mesmo","louco","jeito","ordem","clava",
            "banal","impor","todos","pedir","homem","feliz","coisa","desse","limbo","servo","prosa","forma","presa","falar","viril",
            "ontem","cunho","posso","manso","certo","meiga","vendo","valor","fluir","acaso","visar","puder","falso","legal","lugar",
            "temer","abrir","afins","cisma","pleno","obter","gerar","linda","burro","crise","fluxo","senil","havia","ajuda","enfim",
            "ritmo","tomar","morte","olhar","brega","levar","casta","favor","prumo","bravo","vital","reter","valia","vivaz","falta",
            "grato","laico","tecer","ameno","ouvir","calma","carma","viver","nicho","outro","passo","achar","noite","tendo","fator",
            "selar","pobre","rogar","fardo","coeso","farsa","terra","ativo","rever","citar","sinto","adiar","sonso","leigo","haste",
            "gente","humor","cesta","claro","deter","velho","sulco","exato","amplo","atuar","vemos","papel","feixe","igual","ponto",
            "ideal","marco","imune","gesto","fonte","terno","hiato","cauda","ficar","ambos","vazio","capaz","sonsa","jovem","inata",
            "tanto","nossa","xeque","velar","apoio","algum","relva","horda","leito","pouco","raiva","doido","entre","vimos","chuva",
            "coesa","sente","ciclo","feito","minha"};
        public List<char> atualPalavra = new List<char>();
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