namespace FLRAzure.Models
{
    public class Lasagna 
    {
        public int LasagnaId{get;set;}
        public string Nome{get;set;}
        public string Peso{get;set;}
        public string UrlImmagine{get;set;}

        public int MenuId{get;set;}
        public Menu Menu{get;set;}
    }
}