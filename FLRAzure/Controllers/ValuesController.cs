﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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
            string homeDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string fileName = Path.Combine(homeDir, "home.html" );
            return fileName;
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
