using JogoDaVelha.Domain.Enums;

namespace JogoDaVelha.Domain
{
    public class Jogador
    {
        public Jogador(string name, ESimboloJogador simbolo)
        {
            Simbolo = simbolo;
            Nome = name;
        }
        public string Nome { get; set; }
        public ESimboloJogador Simbolo { get; set; }

        public override string ToString()
        {
            return Nome;
        }

    }
}