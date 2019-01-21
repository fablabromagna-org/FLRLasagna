using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using FLRAzure.Models;

namespace FLRAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LasagnaController : ControllerBase
    {
        Ristorante ristorante {get;set;}
        public LasagnaController(){ 

            ristorante = new Ristorante();
            if(ristorante.Menu.Count()==0)
            {
                ristorante.Menu.Add(new Menu{ MenuId=1, Nome="Menù del contadino", UrlImmagine="https://s.hswstatic.com/gif/recipes/classic-lasagna-recipe-3.jpg" });
                ristorante.Menu.Add(new Menu{ MenuId=2, Nome="Menù del cittadino", UrlImmagine="https://hips.hearstapps.com/ghk.h-cdn.co/assets/cm/15/11/54fdfb55a7565-butternut-squash-sage-lasagna-de.jpg" });
                
                ristorante.Lasagne.Add(new Lasagna{LasagnaId=1, Nome="Lasagna alla bolognese", UrlImmagine="https://s.hswstatic.com/gif/recipes/classic-lasagna-recipe-3.jpg", MenuId=1});
                ristorante.Lasagne.Add(new Lasagna{LasagnaId=2, Nome="Lasagna ai carciofi", UrlImmagine="https://hips.hearstapps.com/ghk.h-cdn.co/assets/cm/15/11/54fdfb55a7565-butternut-squash-sage-lasagna-de.jpg", MenuId=1});
                
                ristorante.SaveChanges();
            }
        }
        
        // GET api/lasagna
        [HttpGet]
        public IEnumerable<Lasagna> Get()
        {
            return ristorante.Lasagne;
        }

        // GET api/lasagna/5
        [HttpGet("{id}")]
        public ActionResult<Lasagna> Get(int id)
        {
            return (from Lasagna l in ristorante.Lasagne
                    where l.LasagnaId==id
                    select l)
                    .First();
        }

        public string GetHomePage()
        {
            string homeDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string fileName = Path.Combine(homeDir, "home.html" );
            return fileName;
        }

        // POST api/lasagna
        [HttpPost]
        public void Pippo([FromBody] Lasagna value)
        {
            if(value.LasagnaId==0)
            {
                int ultimoId = CercaUltimoIdLasagna();
                value.LasagnaId = ultimoId+1;
            }

            ristorante.Lasagne.Add(value);
            ristorante.SaveChanges();
        }

        private int CercaUltimoIdLasagna()
        {
            return (from Lasagna l in ristorante.Lasagne
                    select l.LasagnaId)
                    .Max();
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

}
