using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Ejemplar
    {
        [Key]
        public int idEjemplar { get; set; }
        [Display(Name = "Id Ejemplar")]

        public String nombreLibro { get; set; }
        [Display(Name = "Titulo del libro")]

        public virtual Libro libroId { get; set; }

        

    }
}
