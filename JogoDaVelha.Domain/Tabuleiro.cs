using System;
using JogoDaVelha.Domain.Enums;
using JogoDaVelha.Domain.Exceptions;

namespace JogoDaVelha.Domain
{
    public class Tabuleiro
    {
        public static int TamanhoLinha { get; set; }
        public static int TamanhoColuna { get; set; }
        public Posicao[,] Posicoes { get; set; }
        public Tabuleiro(int tamanhoLinha, int tamanhocoluna)
        {
            TamanhoLinha = tamanhoLinha;
            TamanhoColuna = tamanhocoluna;
            Posicoes = new Posicao[TamanhoLinha, TamanhoColuna];
            InitTabuleiro();
        }


        public void InitTabuleiro()
        {
            for (int i = 0; i < TamanhoLinha; i++)
            {
                for (int j = 0; j < TamanhoColuna; j++)
                {
                    if (Posicoes[i, j] == null)
                    {
                        Posicoes[i, j] = new Posicao(i, j);
                    }
                }
            }
        }

        public void PreencherPosicao(int linha, int coluna, ESimboloJogador simbolo)
        {
            if (linha < 0 || linha > TamanhoLinha)
                throw new ArgumentException("Linha invalida, fora de posicao do tabuleiro");

            if (coluna < 0 || coluna > TamanhoColuna)
                throw new ArgumentException("Linha invalida, fora de posicao do tabuleiro");

            if (Posicoes[linha, coluna].Simbolo == null)
                Posicoes[linha, coluna].PreencherPosicao(simbolo);
            else
                throw new PosicaoPreenchidaException("Já foi preenchido");
        }
    }
}
