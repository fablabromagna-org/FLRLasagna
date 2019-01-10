using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FLRAzure.Models;
using HtmlAgilityPack;

namespace FLRAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StampeController : ControllerBase
    {
        static IEnumerable<RecordStampa> Stampe;
        
        // GET api/stampe
        [HttpGet]
        public IEnumerable<RecordStampa> Get()
        {
            string homeDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string fileName = Path.Combine(homeDir, "wwwroot", "home.html" );

            Stampe = getPage( fileName );
            return Stampe;
        }

        public IEnumerable<RecordStampa> getPage( string nomeFile )
        {
            List<RecordStampa> Stampe = new List<RecordStampa>();

            var doc = new HtmlDocument();
            doc.Load( nomeFile );

            int cnt = -3;

            foreach( var a in doc.DocumentNode.Descendants( "tr" ))
            {
                RecordStampa r = new RecordStampa();
                foreach ( var item in a.Descendants("font") )
                {
                    string s = item.InnerText;
                    //Console.WriteLine($"{cnt} {s}");

                    switch( cnt++ )
                    {
                        case 0:
                            r.NomeDocumento = s;
                            break;

                        case 1:
                            r.Proprietario = s;
                            break;

                        case 2:
                            r.NumeroTotalePagine = s;
                            break;

                        case 3:
                            r.OraInizioStampa = RecordStampa.ToDateTime(s);
                            break;

                        case 4:
                            r.OraFineStampa = RecordStampa.ToDateTime(s);
                            break;

                        case 5:
                            // La durata la calcolo invece di importarla.
                            //r.OraStampa2 = RecordStampa.ToDateTime(s);
                            break;

                        case 6:
                            r.FormatoStampa = s;
                            break;

                        case 7:
                            r.TipoCarta = s;
                            break;

                        case 8:
                            r.InchiostroConsumato = RecordStampa.ToDouble(s);
                            break;

                        case 9:
                            r.RisultatoStampa = s;
                            break;

                        case 10:
                            r.CartaConsumata = RecordStampa.ToDouble(s);
                            break;

                        case 11:
                            r.LarghezzaCarta = s;
                            break;

                        case 12:
                            r.LunghezzaCarta = s;
                            
                            cnt = 0;
                            Stampe.Add( r );

                            r = new RecordStampa();
                            break;
                    }
                }
            }
         
            return Stampe;
        }
    }
}
