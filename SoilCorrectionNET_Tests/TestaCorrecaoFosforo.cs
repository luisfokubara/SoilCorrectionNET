using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoilCorrectionNET.Conversoes;
using SoilCorrectionNET.Correcoes;
using SoilCorrectionNET.Fontes;

namespace SoilCorrectionNET_Tests
{
    [TestClass]
    public class TestaCorrecaoFosforo
    {
        [TestMethod]
        public void testaConverteMgDm3EmKgHa()
        {

            var teorFosforoAdicionarMgDm3 = 3.41m;
            var teorFosforoAdicionarKgHa = new ConverteMgDm3EmKgHa().Converte(teorFosforoAdicionarMgDm3);

            Assert.AreEqual(6.82m, teorFosforoAdicionarKgHa);
        }

        [TestMethod]
        public void testaConverteKgHaEmP2O5()
        {

            var teorFosforoAdicionarKgHa = 6.82m;
            var teorFosforoAdicionarP2O5 = new ConverteKgHaEmP2O5().Converte(teorFosforoAdicionarKgHa);

            Assert.AreEqual(15.6178m, teorFosforoAdicionarP2O5);
        }

        [TestMethod]
        public void testaNecessidadeFosforo()
        {

            var teorFosforoAdicionarP2O5 = 15.6178m;

            var correcaoFosforo = new CorrecaoNutriente<FonteFosforo>();

            var necessidadeFosforo = correcaoFosforo.CalculaEficienciaNutriente(teorFosforoAdicionarP2O5, 0.7m);

            Assert.AreEqual(22.31114285714286m, necessidadeFosforo);
        }

        [TestMethod]
        public void testaQuantidadeAplicar()
        {

            var necessidadeFosforo = 22.31114285714286m;

            var correcaoFosforo = new CorrecaoNutriente<FonteFosforo>();

            Assert.AreEqual(123.95079365079366m, correcaoFosforo.CalculaQuantidadeAplicar(necessidadeFosforo, 0, FonteFosforo.SUPERFOSFATO_SIMPLES));
        }

        [TestMethod]
        public void testaCustoReaisHa()
        {

            var correcaoFosforo = new CorrecaoNutriente<FonteFosforo>();

            var qtdeFosforoAplicar = 123.95079365079366m;

            Assert.AreEqual(156.178m, correcaoFosforo.CalculaCusto(1260.0m, qtdeFosforoAplicar));
        }

        [TestMethod]
        public void testaNutrientesAdicionais()
        {

            var correcaoFosforo = new CorrecaoNutriente<FonteFosforo>();

            var qtdeFosforoAplicar = 123.95079365079366m;

            Assert.AreEqual(2m, correcaoFosforo.ObterNutrientesAdicionais(qtdeFosforoAplicar, FonteFosforo.SUPERFOSFATO_SIMPLES).Count);
        }
    }
}
