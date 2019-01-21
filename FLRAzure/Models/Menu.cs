using System.Collections.Generic;

namespace FLRAzure.Models
{
    public class Menu 
    {
        public int MenuId{get;set;}
        public string Nome{get;set;}
        public string UrlImmagine{get;set;}
        public ICollection<Lasagna> Lasagne { get; set; }
    }
}