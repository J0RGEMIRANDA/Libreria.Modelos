using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Autor
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int PaisCodigo { get; set; }
        public DateTime FechaNacmiento { get; set; } 

        public List<Libro>? Libros { get; set; }
        public Pais? Pais { get; set; }
    }
}
