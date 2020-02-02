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
        Meteo dbMeteo { get; set; }

        public MeteoController(ILogger<MeteoController> logger)
        {
            _logger = logger;

            dbMeteo = new Meteo();
            if(dbMeteo.Campioni.Count()==0)
            {
                dbMeteo.Campioni.Add(new Campione{Data=DateTime.Now, Previsione="Afoso", Temperatura=28 });
                dbMeteo.Campioni.Add(new Campione{Data=DateTime.Now.Subtract(TimeSpan.FromHours(1)), Previsione="Fresco", Temperatura=20 });
                dbMeteo.SaveChanges();
            }
        }

        // Torna l'Id più grande
        private Campione UltimoInserito()
        {
            int maxId = (from Campione c in dbMeteo.Campioni
                         select c.MeteoId).Max();

            var m = (from Campione c in dbMeteo.Campioni
                     where c.MeteoId == maxId
                     select c).First();

            return m;
        }

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
        public int Post( Campione m )
        {
            var rng = new Random();
            if( m != null ) {

                // La data è sempre quella attuale
                m.Data = DateTime.Now;

                // Se non mi arrivano previsioni le valorizzo io...
                if( String.IsNullOrEmpty(m.Previsione) )
                    m.Previsione = Previsioni[rng.Next(Previsioni.Length)];

                dbMeteo.Campioni.Add( m );
                dbMeteo.SaveChanges();
            }

            return dbMeteo.Campioni.Count();
        }

        [HttpDelete]
        public int Delete( )
        {
            // Cancella tutti i record dal db...
            dbMeteo.Campioni.RemoveRange( dbMeteo.Campioni );
            dbMeteo.SaveChanges();

            return dbMeteo.Campioni.Count();
        }

        [HttpDelete("{id}")]
        public bool Delete( int id )
        {
            var m = (from c in dbMeteo.Campioni
                    where c.MeteoId == id
                    select c).First();
            
            if( m != null ) {
                dbMeteo.Campioni.Remove( m );
                dbMeteo.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
