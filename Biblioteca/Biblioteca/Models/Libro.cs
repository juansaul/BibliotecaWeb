using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Libro
    {

        [Key]
        public int libroId { get; set;}

        public String nombre { set; get; }

        public String autor { set; get; }

        public String editorial { set; get; }

        public int año { get; set; }

    }
}