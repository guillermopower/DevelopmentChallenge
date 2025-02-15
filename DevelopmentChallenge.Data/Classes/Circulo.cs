using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaBase
    {
        public Circulo(decimal diametro)
        {
            base.Lado = diametro;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (decimal)Math.Pow((double)(Lado) / 2, 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)(Math.PI * (double)(Lado));
        }
    }
}
