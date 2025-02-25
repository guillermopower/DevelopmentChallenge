using System.Collections;
using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Idioma : IIdioma
    {
        CultureInfo cultureInfo;

        
        public Idioma(CultureInfo cultura)
        {
            this.cultureInfo = cultura;
        }

        /// <summary>
        /// Pude haber creado un archivo de recursos. lo hice asi para simular un servicio o llamada a bbdd
        /// </summary>
       
        public string Traducir(string palabra)
        {
            string value = string.Empty;
            string resxFile;
            switch ( this.cultureInfo.Name)
            {
                case "en-US":
                    resxFile = @"..\..\Resources\Resource.en.resx";
                    break;
                case "it-IT":
                    resxFile = @"..\..\Resources\Resource.it.resx";
                    break;
                default:
                    resxFile = @"..\..\Resources\Resource.resx";
                    break;
            }
            
            try
            {
                using (ResXResourceReader resxReader = new ResXResourceReader(resxFile))
                {
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        if (((string)entry.Key).StartsWith(palabra))
                        { value = (string)entry.Value; break; }
                       
                    }
                }
            }
            catch { }

            return value;
        }
    }
}
