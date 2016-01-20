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
        public string usuarioID { get; set; }



        public string nombre { get; set; }

        public string apellido { get; set; }

        public int Telefono { get; set; }

        public string correo {get;set;}

        public string direccion { get; set; }

        public string curp { get; set; }



    }
}