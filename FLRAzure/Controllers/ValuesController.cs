using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FLRAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LasagnaController : ControllerBase
    {
        static List<Lasagna> Lasagne = new List<Lasagna>();

        // GET api/lasagna
        [HttpGet]
        public IEnumerable<Lasagna> Get()
        {
            return Lasagne;
        }

        // GET api/lasagna/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/lasagna
        [HttpPost]
        public void Pippo([FromBody] Lasagna value)
        {
            Lasagne.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Lasagna 
    {
        public string Nome{get;set;}
        public string Peso{get;set;}
        public string UrlImmagine{get;set;}
    }
}
