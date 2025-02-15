using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Classes
{
    public interface IReporte
    {
        string Imprimir(List<FormaGeometrica> formas);
        string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string tipo);

    }
}