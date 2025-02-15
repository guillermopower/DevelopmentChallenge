namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        protected decimal Lado { get; set; }
        /// <summary>
        /// Calcula el área
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalcularArea();

        /// <summary>
        /// Calcula el perímetro
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalcularPerimetro();
    }
}
