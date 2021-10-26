using System;

namespace SoilCorrectionNET.Conversoes
{
    public class ConverteCMolcDm3EmMgDm3 : Conversao<decimal, decimal>
    {

        public decimal Converte(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException();

            return valor * 391m;
        }

    }
}
