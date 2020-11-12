using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace PlaceMyBet.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options) : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=127.0.0.1;Database=placemybet_ef;Uid=root;Pwd=''; SslMode = none");
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Valencia", "Espanyol", "2020-09-27".AsDateTime().Date));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1.5, 1.43, 2.85, 100, 50, 1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 2.5, 1.9, 1.9, 100, 100, 1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(3, 3.5, 2.85, 1.43, 50, 100, 1));
            modelBuilder.Entity<Usuario>().HasData(new Usuario("jolame@floridauniversitaria.es", "Jose", "Lacueva", 21));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1, 2500, "Bankia", "jolame@floridauniversitaria.es"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta("Over", 10, 1000, "2020-09-27".AsDateTime().Date, 1, 1.5, 1, "jolame@floridauniversitaria.es"));
        }
    }
}