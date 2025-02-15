using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaBase
    {
        public TrianguloEquilatero(decimal lado)
        {
            base.Lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}
