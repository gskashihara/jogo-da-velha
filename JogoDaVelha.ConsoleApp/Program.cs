using System;
using JogoDaVelha.Domain;
using JogoDaVelha.Domain.Enums;
using JogoDaVelha.Domain.Exceptions;

namespace JogoDaVelha.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Bem vindo ao jogo da velha!!");

                    Console.WriteLine(" ____________________________ ");
                    Console.WriteLine("|                            |");
                    Console.WriteLine("|Jogador 1: Seu símbolo é 'X'|");
                    Console.WriteLine("|Jogador 2: Seu símbolo é 'O'|");
                    Console.WriteLine("|____________________________|");
                    Console.WriteLine("");

                    Jogador jogador1 = new Jogador("Jogador 1", ESimboloJogador.X);
                    Jogador jogador2 = new Jogador("jogador 2", ESimboloJogador.O);

                    Jogo jogo = new Jogo(jogador1, jogador2);

                    PrintTabuleiro(jogo.Tabuleiro);

                    Jogador jogadorAtual = jogador1;

                    while (jogo.Status == EStatusJogo.EmAndamento)
                    {
                        Console.WriteLine($" { jogadorAtual.ToString()} é a sua vez!");

                        Console.WriteLine("Informe a linha (0 ou 1 ou 2");
                        int linha = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");

                        Console.WriteLine("Informe a coluna (0 ou 1 ou 2");
                        int coluna = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");

                        try
                        {
                            jogo.Jogar(linha, coluna, jogadorAtual);
                        }
                        catch (PosicaoPreenchidaException)
                        {
                            Console.WriteLine("Posição já foi preenchida, escolha outra posição");
                            continue;
                        }

                        PrintTabuleiro(jogo.Tabuleiro);

                        jogadorAtual = jogadorAtual == jogador1 ? jogador2 : jogador1;
                    }

                    if (jogo.Status == EStatusJogo.Vitoria)
                    {
                        Console.WriteLine($"Vitoria!!!  { jogadorAtual.ToString() } venceu =] ");
                    }
                    else
                    {
                        Console.WriteLine("Empate!!!");
                    }

                    Console.WriteLine("Pressiona enter para começar um novo jogo!");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PrintTabuleiro(Tabuleiro tabuleiro)
        {
            Console.WriteLine("   0   1   2");
            Console.WriteLine("");
            Console.WriteLine("0  " + SimboloToString(tabuleiro.Posicoes[0, 0].Simbolo) + "  | " + SimboloToString(tabuleiro.Posicoes[0, 1].Simbolo) + " | " + SimboloToString(tabuleiro.Posicoes[0, 2].Simbolo));
            Console.WriteLine("   ___|___|___");
            Console.WriteLine("1  " + SimboloToString(tabuleiro.Posicoes[1, 0].Simbolo) + "  | " + SimboloToString(tabuleiro.Posicoes[1, 1].Simbolo) + " | " + SimboloToString(tabuleiro.Posicoes[1, 2].Simbolo));
            Console.WriteLine("   ___|___|___");
            Console.WriteLine("2  " + SimboloToString(tabuleiro.Posicoes[2, 0].Simbolo) + "  | " + SimboloToString(tabuleiro.Posicoes[2, 1].Simbolo) + " | " + SimboloToString(tabuleiro.Posicoes[2, 2].Simbolo));
            Console.WriteLine("      |   |   ");
            Console.WriteLine("");
        }

        static string SimboloToString(ESimboloJogador? simbolo)
        {
            switch (simbolo)
            {
                case ESimboloJogador.X:
                    return "X";
                case ESimboloJogador.O:
                    return "O";
                default:
                    return " ";
            }
        }
    }
}
