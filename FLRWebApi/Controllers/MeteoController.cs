using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FLRWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeteoController : ControllerBase
    {
        private static readonly string[] Previsioni = new[]
        {
            "Gelo", "Freddo", "Fresco", "Mite", "Caldo", "Molto caldo",  "Afoso", "Rovente"
        };

        private readonly ILogger<MeteoController> _logger;

        public MeteoController(ILogger<MeteoController> logger)
        {
            _logger = logger;

            dbMeteo = new Meteo();
            if(dbMeteo.Campioni.Count()==0)
            {
                dbMeteo.Campioni.Add(new Campione{Data=DateTime.Now, Previsione="Afoso", Temperatura=28 });
                //ristorante.Menu.Add(new Menu{ MenuId=2, Nome="Menù del cittadino", UrlImmagine="https://hips.hearstapps.com/ghk.h-cdn.co/assets/cm/15/11/54fdfb55a7565-butternut-squash-sage-lasagna-de.jpg" });
                
                //ristorante.Lasagne.Add(new Lasagna{LasagnaId=1, Nome="Lasagna alla bolognese", UrlImmagine="https://s.hswstatic.com/gif/recipes/classic-lasagna-recipe-3.jpg", MenuId=1});
                //ristorante.Lasagne.Add(new Lasagna{LasagnaId=2, Nome="Lasagna ai carciofi", UrlImmagine="https://hips.hearstapps.com/ghk.h-cdn.co/assets/cm/15/11/54fdfb55a7565-butternut-squash-sage-lasagna-de.jpg", MenuId=1});
                
                dbMeteo.SaveChanges();
            }
        }
        Meteo dbMeteo { get; set; }
        

        [HttpGet]
        public IEnumerable<Campione> Get()
        {
            return dbMeteo.Campioni;
            
            /*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Campione
            {
                Data = DateTime.Now.AddDays(index),
                Temperatura = rng.Next(-20, 55),
                Previsione = Previsioni[rng.Next(Previsioni.Length)]
            })
            .ToArray(); */
        }

        [HttpPost]
        public Campione Post( Campione m )
        {
            m.Data = DateTime.Now;
            return m;
        }
    }
}
