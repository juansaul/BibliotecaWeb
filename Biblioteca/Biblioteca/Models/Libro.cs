using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Libro
    {

        [Key]
        public int libroId { get; set;}

        public String nombre { set; get; }

        public String isbn { set; get; }

        public String autor { set; get; }

        public String editorial { set; get; }

        public String descripcion { set; get; }

        public int año { get; set; }

        public int noEjemplares { get; set; }

        public Image imagenPortada { get; set; }

        public virtual ICollection<Ejemplar> ejemplares { get; set; }

    }
}