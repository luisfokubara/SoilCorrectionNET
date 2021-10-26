using SoilCorrectionNET.Interfaces;
using SoilCorrectionNET.Nutrientes;
using System.Collections.Generic;

namespace SoilCorrectionNET.Fontes
{
    public class FontePotassio : IFonteNutriente
    {
        string display;

        public decimal TeorFonte { get; private set; }
        public List<NutrienteAdicional> NutrientesAdicionais { get; private set; }

        FontePotassio(string display, decimal teor, List<NutrienteAdicional> adicionais) 
        { 
            this.display = display;
            this.TeorFonte = teor;
            this.NutrientesAdicionais = adicionais;
        }

        public override string ToString() { return display; }

        public decimal CalculaNecessidade(decimal v1, decimal v2, decimal v3 = 0)
        {
            return 0;
        }

        //Declaracao dos tipos
        public static readonly FontePotassio CLORETO_POTASSIO = new FontePotassio("CLORETO_POTASSIO", 0.18m, new List<NutrienteAdicional>());

        public static readonly FontePotassio SULFATO_POTASSIO = new FontePotassio("SULFATO_POTASSIO", 0.41m, new List<NutrienteAdicional>
        {
            new NutrienteAdicional(NomeNutrienteAdicional.ENXOFRE, 0.17m)
        });

        public static readonly FontePotassio SULFATO_POTASSIO_MAGNESIO = new FontePotassio("SULFATO_POTASSIO_MAGNESIO", 0.48m, new List<NutrienteAdicional>
        {
            new NutrienteAdicional(NomeNutrienteAdicional.ENXOFRE, 0.22m),
            new NutrienteAdicional(NomeNutrienteAdicional.MAGNESIO, 0.18m)
        });
    }
}
