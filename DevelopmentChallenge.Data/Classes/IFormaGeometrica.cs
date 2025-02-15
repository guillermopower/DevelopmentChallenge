namespace DevelopmentChallenge.Data.Classes
{
    public interface IFormaGeometrica
    {
        /// <summary>
        /// Calcula el área
        /// </summary>
        /// <returns></returns>
        decimal CalcularArea();

        /// <summary>
        /// Calcula el perímetro
        /// </summary>
        /// <returns></returns>
            decimal CalcularPerimetro();
    }
}
