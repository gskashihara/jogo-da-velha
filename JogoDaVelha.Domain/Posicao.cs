using JogoDaVelha.Domain.Enums;

namespace JogoDaVelha.Domain
{
    public class Posicao
    {

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            Preenchido = false;
        }
        public int Linha { get; private set; }

        public int Coluna { get; private set; }

        public ESimboloJogador? Simbolo { get; private set; }

        public bool Preenchido { get; private set; }

        public void PreencherPosicao(ESimboloJogador eSimbolo)
        {
            Simbolo = eSimbolo;
            Preenchido = true;
        }
    }
}