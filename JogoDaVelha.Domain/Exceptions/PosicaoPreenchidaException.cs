using System;

namespace JogoDaVelha.Domain.Exceptions
{
    public class PosicaoPreenchidaException : Exception
    {

        public PosicaoPreenchidaException(string message) : base(message)
        {
        }
    }
}