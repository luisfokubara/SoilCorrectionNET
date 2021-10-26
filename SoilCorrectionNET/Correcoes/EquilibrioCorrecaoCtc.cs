namespace SoilCorrectionNET.Correcoes
{
    public class EquilibrioCorrecaoCtc
    {
        public decimal CalculaSCmol(decimal potassio, decimal calcio, decimal magnesio)
        {
            return potassio + calcio + magnesio;
        }

        public decimal CalculaCTCCmol(decimal potassio, decimal calcio, decimal magnesio, decimal hidrogenioAluminio)
        {
            return CalculaSCmol(potassio, calcio, magnesio) + hidrogenioAluminio;
        }

        public decimal CalculaVPercentual(decimal Scmol, decimal CTCcmol)
        {
            if (Scmol > 0 && CTCcmol > 0)
            {
                return Scmol / CTCcmol * 100;
            }
            else
            {
                return 0.0m;
            }
        }

        public decimal CalculaMOPercentual(decimal mo)
        {
            if (mo > 0)
            {
                return mo / 10;
            }
            else
            {
                return 0.0m;
            }
        }

        public decimal CalculaCarbono(decimal moPercentual)
        {

            if (moPercentual > 0)
            {
                return moPercentual / 1.72m * 10m;

            }
            else
            {
                return 0.0m;
            }
        }

    }
}
