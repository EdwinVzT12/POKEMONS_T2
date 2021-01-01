using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS.Models
{
    public class Captura
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPokemons { get; set; }
        public DateTime Fecha_Captura { get; set; }
        public Pokemons Pokemons { get; set; }
    }
}

