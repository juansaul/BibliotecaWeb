﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.Models;
using System.Data.Entity;

namespace Biblioteca.DAL
{
    public class Contexto : DbContext
    {

        public Contexto() : base("ConexionBiblioteca")
        {

        }

        //Defnicion de tablas a partir de las entidades
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Ejemplar> Ejemplares { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}