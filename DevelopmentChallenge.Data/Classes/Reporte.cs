using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public class Reporte : IReporte
    {
        public List<Total> Totales = new List<Total>();
        Idioma idioma;

        public Reporte(string cultura)
        {
            try
            {
                CultureInfo ci = new CultureInfo(cultura);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                this.idioma = new Idioma(new CultureInfo(cultura));
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public string Imprimir(List<FormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>" + Resources.Resource.listavacia + "</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER

                sb.Append("<h1>" + Resources.Resource.listanovacia + "</h1>");

                for (var i = 0; i < formas.Count; i++)
                {
                    Type tipo = formas[i].GetType();

                    Total subtotal = new Total();
                    subtotal.Cantidad = 1;
                    subtotal.TipoForma = tipo;
                    subtotal.SumatoriaArea = formas[i].CalcularArea();
                    subtotal.SumatoriaPerimetro = formas[i].CalcularPerimetro();

                    this.Totales.Add(subtotal);
                }

                this.Totales.GroupBy(x => x.TipoForma).ToList().ForEach(grupo =>
                {
                    var sumCantidad = grupo.Sum(z => z.Cantidad);
                    var sumAreas = grupo.Sum(z => z.SumatoriaArea);
                    var sumPerimetro = grupo.Sum(z => z.SumatoriaPerimetro);

                    sb.Append(ObtenerLinea(sumCantidad, sumAreas, sumPerimetro, grupo.FirstOrDefault().TipoForma.Name));

                });

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(this.Totales.Sum(x => x.Cantidad) + " " + Resources.Resource.forma.ToLower());
                sb.Append(" ");
                sb.Append(Resources.Resource.perimetro + " " + (this.Totales.Sum(x => x.SumatoriaPerimetro)).ToString("#.##") + " ").Replace('.', ',');
                sb.Append(Resources.Resource.area + " " + (this.Totales.Sum(x => x.SumatoriaArea).ToString("#.##")).Replace('.', ','));
            }

            return sb.ToString();
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo)
        {
            if (cantidad > 0)
            {
                return (cantidad.ToString() + " " + idioma.Traducir(tipo.ToLower()) + " | "  + Resources.Resource.area + " " + area.ToString("#.##")
                    + " | " + Resources.Resource.perimetro + " " + perimetro.ToString("#.##") + " <br/>").Replace('.', ',');
            }

            return string.Empty;
        }
    }
}
