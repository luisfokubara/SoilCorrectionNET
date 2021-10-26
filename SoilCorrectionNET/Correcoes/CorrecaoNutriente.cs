using SoilCorrectionNET.Fontes;
using SoilCorrectionNET.Interfaces;
using SoilCorrectionNET.Nutrientes;
using System;
using System.Collections.Generic;

namespace SoilCorrectionNET.Correcoes
{
    public class CorrecaoNutriente<T> where T : IFonteNutriente
    {
        public decimal CalculaCusto(decimal custoFonte, decimal qtdeAplicar)
        {
            if (custoFonte <= 0)
                throw new Exception("Custo não pode ser menor ou igual a zero!");

            if (qtdeAplicar <= 0)
                throw new Exception("Quantidade a aplicar não pode ser menor ou igual a zero!");

            return custoFonte * qtdeAplicar / 1000;
        }

        public List<NutrienteAdicional> ObterNutrientesAdicionais(decimal qtdeAplicar, T fonteNutriente)
        {
            fonteNutriente
                .NutrientesAdicionais
                .ForEach(item =>
                {
                    item.CorrecaoAdicional = item.TeorNutriente * qtdeAplicar;
                });

            return fonteNutriente.NutrientesAdicionais;
        }

        public decimal CalculaEficienciaNutriente(decimal qtdeNutrienteAdicionar, decimal eficienciaNutriente)
        {
            if (qtdeNutrienteAdicionar <= 0)
                throw new Exception("Qtd. nutriente adicionar não pode ser menor ou igual a zero!");

            if (eficienciaNutriente <= 0)
                throw new Exception("Eficiência nutriente não pode ser menor ou igual a zero!");

            return qtdeNutrienteAdicionar / eficienciaNutriente;
        }

        public decimal CalculaQuantidadeAplicar(decimal necessidade, decimal eficiencia, T fonteNutriente, decimal participacao = 0)
        {
            if (necessidade <= 0)
                throw new Exception("Necessidade não pode ser menor ou igual a zero!");

            return fonteNutriente.CalculaNecessidade(necessidade, eficiencia, participacao);
        }
    }
}
