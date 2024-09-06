using System;
using Spectre.Console;

namespace Desafio.Pontuacao
{
    public class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Write(new Rule("Desafio do Jotinha").RuleStyle("cyan"));
            AnsiConsole.MarkupLine("[aqua]Digite palavras separando por espaço:[/]");
            string[] palavras = Console.ReadLine().ToLower().Split(' ');

            for (int i = 0; i < palavras.Length; i++)
            {
                palavras[i] = palavras[i].Trim();
            }

            if (!ValidaPalavras(palavras))
            {
                AnsiConsole.MarkupLine("[yellow]Alerta: Números e acentos dão pontuações diferentes!![/]");
            }

            string maiorPontuacao = EncontraMaiorPalavra(palavras);

            AnsiConsole.Write(new Rule("A palavra de maior pontuação é:").RuleStyle("cyan"));
            AnsiConsole.Write(new FigletText(maiorPontuacao).Centered().Color(Color.Red));

        }

        static string EncontraMaiorPalavra(string[] palavras)
        {
            string maiorPalavra = "";
            int maiorPontuacao = 0;

            var table = new Table();
            table.Border = TableBorder.Double;
            table.AddColumn("Palavra");
            table.AddColumn("Pontuação");

            foreach (var palavra in palavras)
            {
                int pontuacao = CalculaPontuacao(palavra);

                table.AddRow(palavra, pontuacao.ToString());

                if (pontuacao > maiorPontuacao)
                {
                    maiorPontuacao = pontuacao;
                    maiorPalavra = palavra;
                }
            }

            table.Expand();
            AnsiConsole.Write(table);

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

        static bool ValidaPalavras(string[] palavras)
        {
            foreach (var palavra in palavras)
            {
                if (!palavra.All(char.IsLetter))
                {
                    return false;  
                }
            }
            return true;  
        }
    }
}
