using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaBase
    {
        protected decimal BaseMenor { get; set; }
        protected decimal BaseMayor { get; set; }
        protected decimal Altura { get; set; }
        public Trapecio(decimal lado, decimal baseMenor, decimal baseMayor, decimal altura)
        {
            base.Lado = lado;
            this.BaseMenor = baseMenor;
            this.BaseMayor = baseMayor;
            this.Altura = altura;

            if (this.BaseMenor > this.BaseMayor)
                throw new ArgumentException("La base mayor debe ser superior a la base menor");
        }

        public override decimal CalcularArea()
        {
            return (this.BaseMayor * this.BaseMenor) / 2 * Altura;
        }

        public override decimal CalcularPerimetro()
        {
            return (this.BaseMenor + this.BaseMayor + (2 * this.Lado));
        }
    }
}
