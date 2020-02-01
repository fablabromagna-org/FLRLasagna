
using System;
using System.ComponentModel.DataAnnotations;

namespace FLRWebApi
{
    public class Campione
    {
        [Key]
        public DateTime Data { get; set; }

        public int Temperatura { get; set; }

        public string Previsione { get; set; }
    }
}
