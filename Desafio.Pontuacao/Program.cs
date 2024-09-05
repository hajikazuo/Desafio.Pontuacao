using System;

namespace Desafio.Pontuacao
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Digite uma série de palavras separando por espaço: ");
            string[] palavras = Console.ReadLine().ToLower().Split(' ');

            for (int i = 0; i < palavras.Length; i++)
            {
                palavras[i] = palavras[i].Trim();
            }

            string maiorPontuacao = EncontraMaiorPalavra(palavras);
            Console.WriteLine($"\nA palavra de maior pontuação é: {maiorPontuacao}");
            Console.ReadKey();
        }

        static string EncontraMaiorPalavra(string[] palavras)
        {
            string maiorPalavra = "";
            int maiorPontuacao = 0;

            foreach (var palavra in palavras)
            {
                int pontuacao = CalculaPontuacao(palavra);

                Console.WriteLine($"\n{palavra}: {pontuacao}");

                if (pontuacao > maiorPontuacao)
                {
                    maiorPontuacao = pontuacao;
                    maiorPalavra = palavra;
                }
            }

            return maiorPalavra;
        }

        static int CalculaPontuacao(string palavra)
        {
            int pontuacao = 0;

            foreach (char letra in palavra)
            {
                pontuacao += letra - 'a' + 1;
            }

            return pontuacao;
        }


    }
}
