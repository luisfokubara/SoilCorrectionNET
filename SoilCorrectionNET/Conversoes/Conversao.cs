namespace SoilCorrectionNET.Conversoes
{
    public interface Conversao<T, R>
    {
        R Converte(T valor);
    }
}
