using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FLRWebApi
{    public class Meteo : DbContext
    {
        // Per inizializzare il db, seguire queste istruzioini
        // https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli#create-the-database
        
        public DbSet<Campione> Campioni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=meteo.db");
        }
    }
}