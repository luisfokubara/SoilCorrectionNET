using System;

namespace SoilCorrectionNET.Conversoes
{
    public class ConverteKgHaEmK2O : Conversao<decimal, decimal>
    {

        public decimal Converte(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException();

            return valor * 1.2m;
        }
    }
}
