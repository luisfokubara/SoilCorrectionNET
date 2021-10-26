using System;

namespace SoilCorrectionNET.Conversoes
{
    public class ConverteMgDm3EmKgHa : Conversao<decimal, decimal>
    {
        public decimal Converte(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException();

            return valor * 2;
        }
    }
}
