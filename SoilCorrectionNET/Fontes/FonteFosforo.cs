using SoilCorrectionNET.Interfaces;
using SoilCorrectionNET.Nutrientes;
using System;
using System.Collections.Generic;

namespace SoilCorrectionNET.Fontes
{
    public class FonteFosforo : IFonteNutriente
    {
        string display;

        public decimal TeorFonte { get; private set; }
        public List<NutrienteAdicional> NutrientesAdicionais { get; private set; }

        FonteFosforo(string display, decimal teor, List<NutrienteAdicional> adicionais) 
        { 
            this.display = display;
            this.TeorFonte = teor;
            this.NutrientesAdicionais = adicionais;
        }

        public override string ToString() { return display; }

        public decimal CalculaNecessidade(decimal teorSolo, decimal participacaoCTCExistente, decimal participacaoCTCDesejada = 0)
        {
            if (teorSolo <= 0)
                throw new Exception("Teor Solo não pode ser menor ou igual a zero!");

            if (participacaoCTCExistente <= 0)
                throw new Exception("Participacao CTC Existente não pode ser menor ou igual a zero!");

            if (participacaoCTCDesejada <= 0)
                throw new Exception("Participação CTC Desejada não pode ser menor ou igual a zero!");

            return (teorSolo * participacaoCTCDesejada / participacaoCTCExistente) - teorSolo;
        }

        //Declaracao dos tipos
        public static readonly FonteFosforo SUPERFOSFATO_SIMPLES = new FonteFosforo("SUPERFOSFATO_SIMPLES", 0.18m, new List<NutrienteAdicional> 
        {
            new NutrienteAdicional(NomeNutrienteAdicional.ENXOFRE, 0.1m),
            new NutrienteAdicional(NomeNutrienteAdicional.CALCIO, 0.28m)
        });

        public static readonly FonteFosforo SUPERFOSFATO_TRIPLO = new FonteFosforo("SUPERFOSFATO_TRIPO", 0.41m, new List<NutrienteAdicional>
        {
            new NutrienteAdicional(NomeNutrienteAdicional.CALCIO, 0.2m)
        });

        public static readonly FonteFosforo MAP = new FonteFosforo("MAP", 0.48m, new List<NutrienteAdicional>
        {
            new NutrienteAdicional(NomeNutrienteAdicional.CALCIO, 0.09m)
        });
    }
}
