using SoilCorrectionNET.Nutrientes;
using System.Collections.Generic;

namespace SoilCorrectionNET.Interfaces
{
    public interface IFonteNutriente
    {
        decimal TeorFonte { get; }
        List<NutrienteAdicional> NutrientesAdicionais { get; }

        decimal CalculaNecessidade(decimal v1, decimal v2, decimal v3 = 0);
    }
}
