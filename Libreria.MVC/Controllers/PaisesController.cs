using Libreria.Modelos;
using Librerria.API.Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.MVC.Controllers
{
    public class PaisesController : Controller
    {
        // GET: PaisesController
        public ActionResult Index()
        {
            var data = Crud<Pais>.GetAll();
            return View(data);
        }

        // GET: PaisesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Pais>.GetById(id);
            data.Autores = Crud<Autor>.GetBy("pais", id);
            data.Editoriales = Crud<Editorial>.GetBy("pais", id);
            return View(data);
        }

        // GET: PaisesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pais data)
        {
            try
            {
                Crud<Pais>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", $"Error creating pais: {ex.Message}");
                return View(data);
            }
        }

        // GET: PaisesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Pais>.GetById(id);
            return View(data);
        }

        // POST: PaisesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pais data)
        {
            try
            {
                Crud<Pais>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error editing pais: {ex.Message}");
                return View(data);
            }
        }

        // GET: PaisesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Pais>.GetById(id);
            return View(data);
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pais data)
        {
            try
            {
                Crud<Pais>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", $"Error deleting pais: {ex.Message}");
                return View(data);
            }
        }
    }
}
