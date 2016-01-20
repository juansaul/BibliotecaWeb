using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Prestamo
    {
        public int prestamoID { get; set; }

        public string titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaPrestamo { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaEntrega { get; set; }

        // llaves foraneas

        public int usuarioID { get; set; }
        public Usuario usuario { get; set; }




    }
}