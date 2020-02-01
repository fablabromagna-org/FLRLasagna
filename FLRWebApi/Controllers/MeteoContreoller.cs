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
            "Gelo", "Fresco", "Freddo", "Freddo", "Molto caldo", "Mite", "Caldo", "Afoso", "Rovente"
        };

        private readonly ILogger<MeteoController> _logger;

        public MeteoController(ILogger<MeteoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Meteo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Meteo
            {
                Data = DateTime.Now.AddDays(index),
                Temperatura = rng.Next(-20, 55),
                Previsione = Previsioni[rng.Next(Previsioni.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public int Post()
        {
            return 10;
        }
    }
}
