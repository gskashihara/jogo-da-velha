using JogoDaVelha.Domain.Enums;
using System.Linq;

namespace JogoDaVelha.Domain
{
    public class Jogo
    {
        public Jogo(Jogador jogador1, Jogador jogador2)
        {
            Tabuleiro = new Tabuleiro(3, 3);
            Jogador1 = jogador1;
            Jogado2 = jogador2;
            Status = EStatusJogo.EmAndamento;
        }

        public Tabuleiro Tabuleiro { get; set; }

        public Jogador Jogador1 { get; set; }

        public Jogador Jogado2 { get; set; }

        public EStatusJogo Status { get; set; }

        public void Reset()
        {
            Tabuleiro = new Tabuleiro(3, 3);
            Status = EStatusJogo.EmAndamento;
        }

        public void Jogar(int linha, int coluna, Jogador jogador)
        {
            Tabuleiro.PreencherPosicao(linha, coluna, jogador.Simbolo);
            VerificarStatusJogo();
        }

        private void VerificarStatusJogo()
        {
            if (VerificarColunas() || VerificarLinhas() || VerificarDiagonais())
                Status = EStatusJogo.Vitoria;

            if (VerificarEmpate())
                Status = EStatusJogo.Empate;
        }

        /// <summary>
        /// Verifico se tem alguma coluna preenchida com o mesmos simbolos
        /// </summary>
        /// <returns></returns>
        private bool VerificarColunas()
        {
            int i = 0;

            for (int j = 0; j < Tabuleiro.TamanhoColuna; j++)
            {
                if (Tabuleiro.Posicoes[i, j].Preenchido)
                {
                    if ((Tabuleiro.Posicoes[i, j].Simbolo == Tabuleiro.Posicoes[i + 1, j].Simbolo) &&
                        (Tabuleiro.Posicoes[i, j].Simbolo == Tabuleiro.Posicoes[i + 2, j].Simbolo))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifico se tem alguma linha preenchida com o mesmos simbilo
        /// </summary>
        /// <returns></returns>
        private bool VerificarLinhas()
        {
            int j = 0;

            for (int i = 0; i < Tabuleiro.TamanhoLinha; i++)
            {
                if (Tabuleiro.Posicoes[i, j].Preenchido)
                {
                    if ((Tabuleiro.Posicoes[i, j].Simbolo == Tabuleiro.Posicoes[i, j + 1].Simbolo) &&
                        (Tabuleiro.Posicoes[i, j].Simbolo == Tabuleiro.Posicoes[i, j + 2].Simbolo))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifico se tem alguma diagonal preenchida com o mesmos simbolos, considerando tabuleiro 3 x 3
        /// </summary>
        /// <returns></returns>
        private bool VerificarDiagonais()
        {
            if (Tabuleiro.Posicoes[1, 1].Preenchido)
            {
                if (((Tabuleiro.Posicoes[0, 0].Simbolo == Tabuleiro.Posicoes[1, 1].Simbolo) &&
                    (Tabuleiro.Posicoes[0, 0].Simbolo == Tabuleiro.Posicoes[2, 2].Simbolo)) ||
                    ((Tabuleiro.Posicoes[2, 0].Simbolo == Tabuleiro.Posicoes[1, 1].Simbolo) &&
                    (Tabuleiro.Posicoes[2, 0].Simbolo == Tabuleiro.Posicoes[0, 2].Simbolo)))
                    return true;
            }

            return false;
        }

        private bool VerificarEmpate()
        {
            int count = 0;

            for (int i = 0; i < Tabuleiro.TamanhoLinha; i++)
            {
                for (int j = 0; j < Tabuleiro.TamanhoColuna; j++)
                {
                    if (Tabuleiro.Posicoes[i, j].Preenchido)
                        count++;
                }
            }

            return count == 9;
        }
    }
}