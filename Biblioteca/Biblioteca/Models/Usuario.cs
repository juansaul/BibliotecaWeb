using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Usuario
    {
        //llave primaria
        [Key]
        public int PrestamoID { get; set; }

        public int noControl { get; set; }

        public string nombre { get; set; }

        public string apellidoP { get; set; }

        public string apellidoM { get; set; }

        public string correo {get;set;}

        public int cuatrimestre { get; set; }

        public string grupo { get; set; }

    }
}