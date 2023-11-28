using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
            numerosSelecionados.Sort();
        }

        public void SortearNumeros()
        {
            if (nome == "/debug")
            {
                numerosSorteados.Clear();
                for (int i = 0; i < 6; i++)
                {
                    numerosSorteados.Add(numerosSelecionados[i]);
                }
                return;
            }
            HashSet<int> numeros = new HashSet<int>();
            Random random = new Random();
            for (int i = 0; numeros.Count() < 6; i++)
            {
                numeros.Add(random.Next(1, 61));
            }
            numerosSorteados = numeros.ToList<int>();
            numerosSorteados = numeros.ToList<int>();
            numerosSorteados.Sort();
        }
    }
}