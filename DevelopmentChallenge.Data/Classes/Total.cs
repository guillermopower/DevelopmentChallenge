using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Total
    {
        public Total() { }
        public Total(Type tipo, int cantidad, decimal sumatoriaPerimetro, decimal sumatoriaArea)
        {
            this.TipoForma = tipo;
            this.Cantidad = cantidad;
            this.SumatoriaPerimetro = sumatoriaPerimetro;
            this.SumatoriaArea = sumatoriaArea;
        }

        public Type TipoForma { get; set; }
        public int Cantidad { get; set; } = 0;
        public decimal SumatoriaPerimetro { get; set; } = 0;
        public decimal SumatoriaArea { get; set; } = 0;
    }
}
