using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FLRAzure.Models
{    public class Meteo : DbContext
    {
        public DbSet<Meteo> Campioni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=meteo.db");
        }
    }
}