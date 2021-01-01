using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2_DIARS.Models;

namespace T2_DIARS.DB.Configuraciones
{
    public class PokemonsConfigurations : IEntityTypeConfiguration<Pokemons>
    {
        public void Configure(EntityTypeBuilder<Pokemons> builder)
        {
            builder.ToTable("Pokemons");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Tipo)
                .WithMany()
                .HasForeignKey(o => o.TipoId);

        }
    }
}
