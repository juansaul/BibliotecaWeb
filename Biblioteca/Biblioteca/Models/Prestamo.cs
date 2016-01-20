using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    class Prestamo
    {
        [Key]
        public int idPrestamo { get; set; }
        
        public String nombre { get; set; }

        public DateTime fechaPrestamo { get; set; }

        public DateTime fechaEntrega { get; set; }

        public virtual Usuario usuario { get; set; }

        public virtual Ejemplar idEjemplar { get; set; }
    }
}
