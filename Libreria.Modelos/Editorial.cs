using System.ComponentModel.DataAnnotations;

namespace Libreria.Modelos
{
    public class Editorial
    {
        [Key] public int Codigo { get; set; }

        public string Nombre { get; set; } 

        public int PaisCodigo { get; set; } 

        public Pais? Pais { get; set; }
        public List<Libro>? Libros { get; set; } 
    }
}
