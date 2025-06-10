using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Libreria.Modelos;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libreria.Modelos.Pais> Paises { get; set; } = default!;

        public DbSet<Libreria.Modelos.Autor> Autores { get; set; } = default!;

        public DbSet<Libreria.Modelos.Editorial> Editoriales { get; set; } = default!;

        public DbSet<Libreria.Modelos.Libro> Libros { get; set; } = default!;
    }
