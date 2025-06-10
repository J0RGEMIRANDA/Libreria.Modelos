using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Libro
    {
        [Key] public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; } 
        public int AnioPublicacion { get; set; }
        public int CantidadPaginas { get; set; }
        public int CantidadEjemplares { get; set; }

        // FK's
        public int PaisCodigo { get; set; }
        public int AutorCodigo { get; set; }
        public int EditorialCodigo { get; set; }

        // Navigation properties
        public Pais? Pais { get; set; }
        public Autor? Autor { get; set; }
        public Editorial? Editorial { get; set; }
    }
}
