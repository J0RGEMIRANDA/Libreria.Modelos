using Libreria.Modelos;
using Librerria.API.Consumer;

namespace Libreria.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProbarLibros();

            Console.ReadLine();
        }

        private static void ProbarLibros()
        { 
            Crud<Libro>.EndPoint = "https://localhost:7041/api/Libros";

            // crear un objeto de la clase libro
            var libro = Crud<Libro>.Create(new Libro
            {
                Codigo = 0,   // para crear un registro nuevo
                Titulo = "El Principito",
                AutorCodigo = 1,
                EditorialCodigo = 1,
                AnioPublicacion = 1943,
                CantidadEjemplares = 10,
                Genero = "Ficción",
                CantidadPaginas = 96,
                PaisCodigo = 1
            });

            // actualizar el libro
            libro.Titulo = "El Principito Actualizado";
            Crud<Libro>.Update(libro.Codigo, libro);

            // obtener todos los libros
            var libros = Crud<Libro>.GetAll();

            foreach (var l in libros)
            {
                Console.WriteLine($"Codigo: {l.Codigo}, Titulo: {l.Titulo}, Autor: {l.Autor.Nombre}, Editorial: {l.Editorial.Nombre}, AnioPublicacion: {l.AnioPublicacion}, CantidadEjemplares: {l.CantidadEjemplares}, Genero: {l.Genero}, CantidadPaginas: {l.CantidadPaginas}");
            }
        }

        private static void ProbarPaises()
        {
            Crud<Pais>.EndPoint = "https://localhost:7041/api/Paises";

            // crear un objeto de la clase pais
            var pais = Crud<Pais>.Create(new Pais
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Argentina",
                Continente = "America",
                Moneda = "Peso",
                Idioma = "Español",
                Capital = "Buenos Aires"
            });

            // actualizar el pais
            pais.Nombre = "Argentina Actualizado";
            Crud<Pais>.Update(pais.Codigo, pais);
            
            // obtener todos los paises
            var paises = Crud<Pais>.GetAll();

            foreach (var p in paises)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Continente: {p.Continente}, Moneda: {p.Moneda}, Idioma: {p.Idioma}, Capital: {p.Capital}");
            }
        }

        private static void ProbarAutores()
        { 
            Crud<Autor>.EndPoint = "https://localhost:7041/api/Autores";
            // crear un objeto de la clase autor
            var autor = Crud<Autor>.Create(new Autor
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Juan ",
                Apellido = "Lopez",
                FechaNacmiento = new DateTime(1990, 1, 1),
                PaisCodigo = 1
            });

            // actualizar el autor
            autor.Nombre = "Juan Actualizado";
            Crud<Autor>.Update(autor.Codigo, autor);

            // obtener todos los autores
            var autores = Crud<Autor>.GetAll();
            foreach (var a in autores)
            {
                Console.WriteLine($"Codigo: {a.Codigo}, Nombre: {a.Nombre}, Apellido: {a.Apellido}, FechaNacmiento: {a.FechaNacmiento.ToShortDateString()}, PaisCodigo: {a.Pais.Nombre}");
            }
        }

        private static void ProbarEditoriales()
        {
            Crud<Editorial>.EndPoint = "https://localhost:7041/api/Editoriales";

            // crear un objeto de la clase editorial
            var santillana = Crud<Editorial>.Create(new Editorial
            {
                Codigo = 0,   // para crear un registro nuevo
                Nombre = "Santillana 2",
                PaisCodigo = 1
            });

            // actualizar la editorial
            santillana.Nombre = "Santillana 2 Actualizado";
            Crud<Editorial>.Update(santillana.Codigo, santillana);

            // obtener todas las editoriales
            var editoriales = Crud<Editorial>.GetAll();
            foreach (var e in editoriales)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, PaisCodigo: {e.Pais.Nombre}");
            }
        }
    }
}
