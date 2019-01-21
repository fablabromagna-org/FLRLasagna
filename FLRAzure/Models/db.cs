using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FLRAzure.Models
{
    public class Ristorante : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Lasagna> Lasagne { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ristorante.db");
        }
    }
}