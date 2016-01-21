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
        [Display(Name = "Nombre")]
        public String nombre { set; get; }
        [Display(Name = "ISBN")]
        public String isbn { set; get; }
        [Display(Name = "Autor")]
        public String autor { set; get; }
        [Display(Name = "Editorial")]
        public String editorial { set; get; }
        [Display(Name = "Descripción")]
        public String descripcion { set; get; }
        [Display(Name = "Año")]
        public int año { get; set; }
        [Display(Name = "No. Ejemplares")]
        public int noEjemplares { get; set; }

        public virtual ICollection<Ejemplar> ejemplares { get; set; }

    }
}