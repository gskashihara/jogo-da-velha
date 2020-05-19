using Microsoft.VisualStudio.TestTools.UnitTesting;
using JogoDaVelha.Domain;
using System;
using JogoDaVelha.Domain.Enums;
using JogoDaVelha.Domain.Exceptions;

namespace JogoDaVelha.Tests
{
    [TestClass]
    public class TabuleiroTest
    {
        public TabuleiroTest()
        {
            _tabuleiro = new Tabuleiro(3, 3);
        }
        public Tabuleiro _tabuleiro;

        [TestMethod]
        public void PreencherPosicaoValida_StatusDeveSerPreenchido()
        {
            _tabuleiro.PreencherPosicao(0, 0, ESimboloJogador.X);

            Assert.AreEqual(true, _tabuleiro.Posicoes[0, 0].Preenchido);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PreencherPosicaoInvalida_DeveRetornarUmaException()
        {
            _tabuleiro.PreencherPosicao(4, 4, ESimboloJogador.X);
        }

        [TestMethod]
        [ExpectedException(typeof(PosicaoPreenchidaException))]
        public void PreencherPosicaoJaPreenchido_DeveRetornarUmaException()
        {
            _tabuleiro.PreencherPosicao(1, 1, ESimboloJogador.X);
            _tabuleiro.PreencherPosicao(1, 1, ESimboloJogador.O);
        }
    }
}
