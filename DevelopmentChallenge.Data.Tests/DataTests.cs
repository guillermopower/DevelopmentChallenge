using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var reporte = new Reporte("es-AR");
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                reporte.Imprimir(new List<FormaGeometrica>()));
        }


        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var reporte = new Reporte("en-US");
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                reporte.Imprimir(new List<FormaGeometrica>()));
        }


        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var reporte = new Reporte("es-AR");
            var lista = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = reporte.Imprimir(lista);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }


        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var lista = new List<FormaGeometrica>
                {
                    new Cuadrado(5),
                    new Cuadrado(1),
                    new Cuadrado(3)
                };

            var resumen = new Reporte("en-US").Imprimir(lista);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3m),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };


            var resumen = new Reporte("en-US").Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5m),
                new Circulo(3m),
                new TrianguloEquilatero(4m),
                new Cuadrado(2m),
                new TrianguloEquilatero(9m),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = new Reporte("es-AR").Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var reporte = new Reporte("it-IT");
            var lista = new List<FormaGeometrica> { new Rectangulo(2, 4) };

            var resumen = reporte.Imprimir(lista);

            Assert.AreEqual("<h1>Rapporto sul modulo</h1>1 Rettangolo | Area 8 | Perimetro 12 <br/>TOTAL:<br/>1 forme Perimetro 12 Superficie 8", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var reporte = new Reporte("it-IT");
            var lista = new List<FormaGeometrica> { new Trapecio(2, 4, 5, 2) };

            var resumen = reporte.Imprimir(lista);

            Assert.AreEqual("<h1>Rapporto sul modulo</h1>1 Trapecio | Area 20 | Perimetro 13 <br/>TOTAL:<br/>1 forme Perimetro 13 Superficie 20", resumen);
        }
    }
}
