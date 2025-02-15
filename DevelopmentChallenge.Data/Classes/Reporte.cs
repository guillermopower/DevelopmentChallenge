using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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
                sb.Append("<h1>" + idioma.Traducir("listavacia") + "</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER

                sb.Append("<h1>" + idioma.Traducir("listanovacia") + "</h1>");

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
                sb.Append(this.Totales.Sum(x => x.Cantidad) + " " + idioma.Traducir("forma", true).ToLower());
                sb.Append(" ");
                sb.Append(idioma.Traducir("perimetro") + " " + (this.Totales.Sum(x => x.SumatoriaPerimetro)).ToString(idioma.FormatoDecimales) + " ").Replace('.', ',');
                sb.Append(idioma.Traducir("area") + " " + (this.Totales.Sum(x => x.SumatoriaArea).ToString(idioma.FormatoDecimales)).Replace('.', ','));
            }

            return sb.ToString();
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo)
        {
            if (cantidad > 0)
            {
                return (cantidad.ToString() + " " + idioma.Traducir(tipo.ToLower(), cantidad > 1) + " | Area " + area.ToString(idioma.FormatoDecimales)
                    + " | " + idioma.Traducir("perimetro") + " " + perimetro.ToString(idioma.FormatoDecimales) + " <br/>").Replace('.', ',');
            }

            return string.Empty;
        }
    }
}
