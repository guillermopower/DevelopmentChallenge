namespace DevelopmentChallenge.Data.Classes
{
    public class Palabra
    {
        public Palabra() { }
        public Palabra(string key, string cultura, string traduccion, string traduccionPlural = null)
        {
            this.Key = key;
            this.Cultura = cultura;
            this.Traduccion = traduccion;
            this.TraduccionPlural = traduccionPlural;
        }

        public string Key { get; set; }
        public string Cultura { get; set; }
        public string Traduccion { get; set; }
        public string TraduccionPlural { get; set; }
    }
}
