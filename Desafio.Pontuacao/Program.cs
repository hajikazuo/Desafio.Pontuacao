using System;

namespace Desafio.Pontuacao
{
    public class Program
    {
        static void Main(string[] args)
        {
            var palavras = new List<string> { };

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Digite a {i}ª palavra: ");
                palavras.Add(Console.ReadLine());
            }

            string maiorPontuacao = EncontraMaiorPalavra(palavras);
            Console.WriteLine($"\nA palavra de maior pontuação é: {maiorPontuacao}");
            Console.ReadKey();
        }

        static string EncontraMaiorPalavra(List<string> palavras)
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
