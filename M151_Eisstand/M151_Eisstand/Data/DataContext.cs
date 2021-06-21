using M151_Eisstand.Modell;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M151_Eisstand.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<Bestellung> Bestellung { get; set; }
        public DbSet<Kugeln> Kugeln { get; set; }
    }
}