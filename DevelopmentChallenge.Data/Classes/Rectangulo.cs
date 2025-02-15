namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaBase
    {
        protected decimal LadoBase { get; set; }
        public Rectangulo(decimal ladoBase, decimal ladoAltura)
        {
            base.Lado = ladoAltura;
            this.LadoBase = ladoBase;
        }

        public  override decimal CalcularArea()
        {
            return this.LadoBase * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return (Lado * 2 + LadoBase * 2);
        }
    }
}
