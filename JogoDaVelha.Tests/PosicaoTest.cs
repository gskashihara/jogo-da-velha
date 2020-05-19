using JogoDaVelha.Domain;
using JogoDaVelha.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JogoDaVelha.Tests
{
    [TestClass]
    public class PosicaoTest
    {
        public Posicao _posicao;

        public PosicaoTest()
        {
            _posicao = new Posicao(0, 0);
        }

        [TestMethod]
        public void PreencherPosicao_StatusPreenchido()
        {
            _posicao.PreencherPosicao(ESimboloJogador.X);

            Assert.AreEqual(true, _posicao.Preenchido);
        }
    }
}