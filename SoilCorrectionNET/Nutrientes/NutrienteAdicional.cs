namespace SoilCorrectionNET.Nutrientes
{
    public class NutrienteAdicional
    {
        public NutrienteAdicional(NomeNutrienteAdicional nome, decimal teor)
        {
            this.Nome = nome;
            this.TeorNutriente = teor;
        }

        public NomeNutrienteAdicional Nome { get; private set; }

        public decimal TeorNutriente { get; private set; }

        public decimal CorrecaoAdicional { get; set; }
    }
}
