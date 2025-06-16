using Libreria.Modelos;
using Librerria.API.Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class LibrosController : Controller
    {
        // GET: LibrosController
        public ActionResult Index()
        {
            var data = Crud<Libro>.GetAll();
            return View(data);
        }

        // GET: LibrosController/Details/5
        public ActionResult Details(int id)
        { 
            var data = Crud<Libro>.GetById(id);
            data.Pais = Crud<Pais>.GetById(data.PaisCodigo);
            data.Editorial = Crud<Editorial>.GetById(data.EditorialCodigo);
            data.Autor = Crud<Autor>.GetById(data.AutorCodigo);
            return View(data);
        }

        // GET: LibrosController/Create
        public ActionResult Create()
        {
            ViewBag.Paises = GetPaises();
            ViewBag.Autores = GetAutores();
            ViewBag.Editoriales = GetEditoriales();
            return View();
        }

        private List<SelectListItem> GetPaises()
        {
            var paises = Crud<Pais>.GetAll();
            return paises.Select(p => new SelectListItem
            {
                Value = p.Codigo.ToString(),
                Text = p.Nombre
            }).ToList();
        }

        private List<SelectListItem> GetAutores()
        {
            var autores = Crud<Autor>.GetAll();
            return autores.Select(a => new SelectListItem
            {
                Value = a.Codigo.ToString(),
                Text = a.Nombre
            }).ToList();
        }

        private List<SelectListItem> GetEditoriales()
        {
            var editoriales = Crud<Editorial>.GetAll();
            return editoriales.Select(p => new SelectListItem
            {
                Value = p.Codigo.ToString(),
                Text = p.Nombre
            }).ToList();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro data)
        {
            try
            {
                Crud<Libro>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", $"Error creating libro: {ex.Message}");
                return View(data);
            }
        }

        // GET: LibrosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Libro>.GetById(id);
            ViewBag.Paises = GetPaises();
            ViewBag.Autores = GetAutores();
            ViewBag.Editoriales = GetEditoriales();
            data.Pais = Crud<Pais>.GetById(data.PaisCodigo);
            data.Editorial = Crud<Editorial>.GetById(data.EditorialCodigo);
            data.Autor = Crud<Autor>.GetById(data.AutorCodigo);
            return View(data);
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Libro data)
        {
            try
            {
                Crud<Libro>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error editing Libro: {ex.Message}");
                return View(data);
            }
        }

        // GET: LibrosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Libro>.GetById(id);
            data.Pais = Crud<Pais>.GetById(data.PaisCodigo);
            data.Editorial = Crud<Editorial>.GetById(data.EditorialCodigo);
            data.Autor = Crud<Autor>.GetById(data.AutorCodigo);
            return View(data);
        }

        // POST: LibrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Libro data)
        {
            try
            {
                Crud<Libro>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error deleting Libro: {ex.Message}");
                return View(data);
            }
        }
    }
}
