namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaBase
    {
        public Cuadrado(decimal lado)
        {
            base.Lado = lado;
        }

        public override decimal CalcularArea()
        {
            return this.Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 4;
        }
    }
}
