using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using T2_DIARS.DB.Configuraciones;
using T2_DIARS.Models;



namespace T2_DIARS.Models
{
    public class AppPruebaContext : DbContext
    {
        public DbSet<Pokemons> Pokemones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Captura> Capturas { get; set; }

        public AppPruebaContext(DbContextOptions<AppPruebaContext> options)
            : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PokemonsConfigurations());
            modelBuilder.ApplyConfiguration(new TipoConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new CapturaConfigurations());

        }
    }
}