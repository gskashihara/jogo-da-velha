using JogoDaVelha.Domain;
using JogoDaVelha.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JogoDaVelha.Tests
{
    [TestClass]
    public class JogoTest
    {
        public Jogo _jogoVelha;
        public Jogador _jogador1;

        public Jogador _jogador2;
        public JogoTest()
        {
            _jogador1 = new Jogador("Jogador 1", ESimboloJogador.X);
            _jogador1 = new Jogador("Jogador 2", ESimboloJogador.O);
            _jogoVelha = new Jogo(_jogador1, _jogador2);
        }

        [TestMethod]
        public void VerificarSeJogoTerminouPorColunas()
        {
            _jogoVelha.Reset();
            //prrencho a coluna 0 
            _jogoVelha.Jogar(0, 0, _jogador1);
            _jogoVelha.Jogar(1, 0, _jogador1);
            _jogoVelha.Jogar(2, 0, _jogador1);

            Assert.AreEqual(EStatusJogo.Vitoria, _jogoVelha.Status);
        }


        [TestMethod]
        public void VerificarSeJogoTerminouPorLinhas()
        {
            _jogoVelha.Reset();
            //prrencho a coluna 0 
            _jogoVelha.Jogar(0, 0, _jogador1);
            _jogoVelha.Jogar(0, 1, _jogador1);
            _jogoVelha.Jogar(0, 2, _jogador1);

            Assert.AreEqual(EStatusJogo.Vitoria, _jogoVelha.Status);
        }


        [TestMethod]
        public void VerificarSeJogoTerminouPorDiagonal()
        {
            _jogoVelha.Reset();
            //prrencho a coluna 0 
            _jogoVelha.Jogar(0, 0, _jogador1);
            _jogoVelha.Jogar(1, 1, _jogador1);
            _jogoVelha.Jogar(2, 2, _jogador1);

            Assert.AreEqual(EStatusJogo.Vitoria, _jogoVelha.Status);
        }








    }
}