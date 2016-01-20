using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    class Ejemplar
    {
        public int idEjemplar { get; set; }

        public String nombreLibro { get; set; }

        public virtual Libro libroId { get; set; }

    }
}
