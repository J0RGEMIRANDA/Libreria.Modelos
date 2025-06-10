using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Pais
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Capital { get; set; }
        public string Continente { get; set; }
        public string Idioma { get; set; }
        public string Moneda { get; set; }

        public List<Libro>? Libros { get; set; }
        public List<Editorial>? Editoriales { get; set; }
        public List<Autor>? Autores { get; set; }
    }
}
