using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrabalhoFinal_Jogo
{
    public class MegaSena : Jogo
    {
        public List<int> numerosSelecionados = new List<int>();
        public List<int> numerosSorteados = new List<int>();
        public int numerosNaAposta { get; set; }


        public MegaSena(string nome, int numerosNaAposta) 
        {
            this.nome = nome;
            this.numerosNaAposta = numerosNaAposta;
        }

        public void AdicionarNumeroSelecionado(int numero)
        {
            if(numerosSelecionados.Contains(numero)) { numerosSelecionados.Remove(numero); }
            else { numerosSelecionados.Add(numero); }
        }
    }
}