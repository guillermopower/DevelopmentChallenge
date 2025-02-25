using DevelopmentChallenge.Data.Classes;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopmentChallenge.Data.Tests
{
    [TestClass]
    public class DataTests
    {

        [TestMethod]
        public void TestResumenListaVacia()
        {
            var reporte = new Reporte("es-AR");
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                reporte.Imprimir(new List<FormaGeometrica>()));
        }


        [TestMethod]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var reporte = new Reporte("en-US");
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                reporte.Imprimir(new List<FormaGeometrica>()));
        }


        [TestMethod]
        public void TestResumenListaConUnCuadrado()
        {
            var reporte = new Reporte("es-AR");
            var lista = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = reporte.Imprimir(lista);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 forma Perímetro 20 Area 25", resumen);
        }


        [TestMethod]
        public void TestResumenListaConMasCuadrados()
        {
            var lista = new List<FormaGeometrica>
                {
                    new Cuadrado(5),
                    new Cuadrado(1),
                    new Cuadrado(3)
                };

            var resumen = new Reporte("en-US").Imprimir(lista);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squad | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shape Perimeter 36 Area 35", resumen);
        }

        [TestMethod]
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
                "<h1>Shapes report</h1>2 Squad | Area 29 | Perimeter 28 <br/>2 Circle | Area 13,01 | Perimeter 18,06 <br/>3 Triangle | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shape Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestMethod]
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
                "<h1>Reporte de Formas</h1>2 Cuadrado | Area 29 | Perímetro 28 <br/>2 Círculo | Area 13,01 | Perímetro 18,06 <br/>3 Triángulo Equilátero | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 forma Perímetro 97,66 Area 91,65",
                resumen);
        }

        [TestMethod]
        public void TestResumenListaConUnRectangulo()
        {
            var reporte = new Reporte("it-IT");
            var lista = new List<FormaGeometrica> { new Rectangulo(2, 4) };

            var resumen = reporte.Imprimir(lista);

            Assert.AreEqual("<h1>Rapporto sul modulo</h1>1 Rettangolo | Area 8 | Perimetro 12 <br/>TOTAL:<br/>1 forme Perimetro 12 Area 8", resumen);
        }

        [TestMethod]
        public void TestResumenListaConUnTrapecio()
        {
            var reporte = new Reporte("it-IT");
            var lista = new List<FormaGeometrica> { new Trapecio(2, 4, 5, 2) };

            var resumen = reporte.Imprimir(lista);

            Assert.AreEqual("<h1>Rapporto sul modulo</h1>1 Trapecio | Area 20 | Perimetro 13 <br/>TOTAL:<br/>1 forme Perimetro 13 Area 20", resumen);
        }
    }
}
