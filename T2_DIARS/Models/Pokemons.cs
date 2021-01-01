using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T2_DIARS.Models
{
    public class Pokemons
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int TipoId { get; set; }
        public string Imagen { get; set; }
        public Tipo Tipo { get; set; }
        public List<Captura> Captura { get; set; }

    }
}
