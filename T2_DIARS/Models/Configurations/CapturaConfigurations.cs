using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2_DIARS.Models;

namespace T2_DIARS.DB.Configuraciones
{
    public class CapturaConfigurations : IEntityTypeConfiguration<Captura>
    {
        public void Configure(EntityTypeBuilder<Captura> builder)
        {
            builder.ToTable("UsuarioPokemon");
            builder.HasKey(o => o.Id);

            builder.HasOne(c => c.Pokemons).WithMany(c => c.Captura).HasForeignKey(c => c.IdPokemons);
        }
    }
}
