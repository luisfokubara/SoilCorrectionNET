using System;

namespace SoilCorrectionNET.Conversoes
{
    public class ConverteKgHaEmP2O5 : Conversao<decimal, decimal> {

    public decimal Converte(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentOutOfRangeException();

        return valor * 2.29m;
    }
}
}
