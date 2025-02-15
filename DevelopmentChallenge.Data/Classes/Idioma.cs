using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DevelopmentChallenge.Data.Classes
{
    public class Idioma : IIdioma
    {
        CultureInfo cultureInfo;
        public readonly string FormatoDecimales;

        public List<Palabra> Diccionario = new List<Palabra>();
        public Idioma(CultureInfo cultura)
        {
            this.cultureInfo = cultura;
            this.FormatoDecimales = "#.##";
            CargarDiccionario();
        }

        /// <summary>
        /// Pude haber creado un archivo de recursos. lo hice asi para simular un servicio o llamada a bbdd
        /// </summary>
        private void CargarDiccionario()
        {
            Diccionario.AddRange(new List<Palabra>()
            {
                new Palabra("cuadrado", "es-AR", "Cuadrado", "Cuadrados"),
                new Palabra("circulo", "es-AR", "Círculo", "Círculos"),
                new Palabra("trianguloequilatero", "es-AR", "Triángulo", "Triángulos"),
                new Palabra("rectangulo", "es-AR", "Rectangulo", "Rectangulos"),
                new Palabra("trapecio", "es-AR", "Trapecio", "Trapecios"),
                new Palabra("area", "es-AR", "Area", "Areas"),
                new Palabra("perimetro", "es-AR", "Perimetro", "Perimetros"),
                new Palabra("forma", "es-AR", "Forma", "Formas"),
                new Palabra("listavacia", "es-AR", "Lista vacía de formas!"),
                new Palabra("listanovacia", "es-AR", "Reporte de Formas"),

                new Palabra("cuadrado", "en-US", "Squad", "Squares"),
                new Palabra("circulo", "en-US", "Circle", "Circles"),
                new Palabra("trianguloequilatero", "en-US", "Triangle", "Triangles"),
                new Palabra("rectangulo", "en-US", "Rectangule", "Rectangules"),
                new Palabra("trapecio", "en-US", "Trapeze", "Trapezes"),
                new Palabra("area", "en-US", "Area", "Areas"),
                new Palabra("perimetro", "en-US", "Perimeter", "Perimeters"),
                new Palabra("forma", "en-US", "Shape", "Shapes"),
                new Palabra("listavacia", "en-US", "Empty list of shapes!"),
                new Palabra("listanovacia", "en-US", "Shapes report"),

                new Palabra("cuadrado", "it-IT", "Piazza", "Piazze"),
                new Palabra("circulo", "it-IT", "Cerchio", "Cerchi"),
                new Palabra("trianguloequilatero", "it-IT", "Triangolo", "Triangoli"),
                new Palabra("rectangulo", "it-IT", "Rettangolo", "Rettangoli"),
                new Palabra("trapecio", "it-IT", "Trapecio", "Trapecios"),
                new Palabra("area", "it-IT", "Superficie", "Superfici"),
                new Palabra("perimetro", "it-IT", "Perimetro", "Perimetri"),
                new Palabra("forma", "it-IT", "Foma", "Forme"),
                new Palabra("listavacia", "it-IT", "Elenco vuoto di forme!"),
                new Palabra("listanovacia", "it-IT", "Rapporto sul modulo"),
            }
            );
        }

        public string Traducir(string palabra, bool plural = false)
        {
            string value = string.Empty;
            try
            {
                var palabraEncontrada = Diccionario.FirstOrDefault(x => x.Cultura == this.cultureInfo.Name && x.Key == palabra);
                value = plural ? palabraEncontrada.TraduccionPlural : palabraEncontrada.Traduccion;
            }
            catch { }

            return value;
        }
    }
}
