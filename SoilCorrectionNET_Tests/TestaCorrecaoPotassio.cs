using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoilCorrectionNET.Conversoes;
using SoilCorrectionNET.Correcoes;
using SoilCorrectionNET.Fontes;

namespace SoilCorrectionNET_Tests
{
    [TestClass]
    public class TestaCorrecaoPotassio
    {
        [TestMethod]
        public void testaNecessidadeAdicionarCMolcDM3()
        {

            var correcaoPotassio = new CorrecaoNutriente<FontePotassio>();

            var necessidadeAdicionarCMolcDM3 = correcaoPotassio.CalculaQuantidadeAplicar(0.15m, 0.01164m, null, 0.03m);

            Assert.AreEqual(0.23659793814432992m, necessidadeAdicionarCMolcDM3);
        }

        [TestMethod]
        public void testaConverteCMolcDm3EmMgDm3()
        {

            var necessidadeAdicionarCMolcDM3 = 0.23659793814432992m;

            var cmolcConvertido = new ConverteCMolcDm3EmMgDm3().Converte(necessidadeAdicionarCMolcDM3);

            Assert.AreEqual(92.509793814433m, cmolcConvertido);
        }

        [TestMethod]
        public void testaConverteKgHaEmK2O()
        {

            var valorKgHa = 185.10m;
            var valorK2o = new ConverteKgHaEmK2O().Converte(valorKgHa);

            Assert.AreEqual(222.11999999999998m, valorK2o);
        }

        [TestMethod]
        public void testaCalculaEficienciaNutriente()
        {

            var correcaoPotassio = new CorrecaoNutriente<FontePotassio>();

            var eficiencia = correcaoPotassio.CalculaEficienciaNutriente(222.12m, 0.85m);

            Assert.AreEqual(261.3176470588235m, eficiencia);
        }

        [TestMethod]
        public void testaQuantidadeAplicar()
        {

            var correcaoPotassio = new CorrecaoNutriente<FontePotassio>();

            var eficiencia = 261.3176470588235m;

            Assert.AreEqual(450.54766734279923m, correcaoPotassio.CalculaQuantidadeAplicar(0, eficiencia, FontePotassio.CLORETO_POTASSIO));
        }

        [TestMethod]
        public void testaCustoReaisHa()
        {

            var correcaoPotassio = new CorrecaoNutriente<FontePotassio>();

            var qtdeAplicar = 450.54766734279923m;

            Assert.AreEqual(1126.3691683569982m, correcaoPotassio.CalculaCusto(2500.0m, qtdeAplicar));
        }


        [TestMethod]
        public void testaNutrientesAdicionais()
        {

            var correcaoPotassio = new CorrecaoNutriente<FontePotassio>();

            var qtdePotassioAplicar = 450.54766734279923m;

            Assert.AreEqual(0m, correcaoPotassio.ObterNutrientesAdicionais(qtdePotassioAplicar, FontePotassio.CLORETO_POTASSIO).Count);
        }
    }
}
