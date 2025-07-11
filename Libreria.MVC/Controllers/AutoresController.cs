﻿using Libreria.Modelos;
using Librerria.API.Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class AutoresController : Controller
    {
        // GET: AutoresController
        public ActionResult Index()
        {
            var data = Crud<Autor>.GetAll();
            return View(data);
        }

        // GET: AutoresController/Details/5
        public ActionResult Details(int id)
        {   
            var data= Crud<Autor>.GetById(id);
            data.Libros = Crud<Libro>.GetBy("autor", id);
            data.Pais = Crud<Pais>.GetById(data.PaisCodigo);
            return View(data);
        }

        // GET: AutoresController/Create
        public ActionResult Create()
        {   
            ViewBag.Paises = GetPaises();
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
        // POST: AutoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor data)
        {
            try
            { 
                Crud<Autor>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", $"Error creating author: {ex.Message}");
                return View(data);
            }
        }

        // GET: AutoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Autor>.GetById(id);
            ViewBag.Paises = GetPaises();
            data.Pais = Crud<Pais>.GetById(data.PaisCodigo);
            return View(data);
        }

        // POST: AutoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Autor data)
        {
            try
            {
                Crud<Autor>.Update(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error editing author: {ex.Message}");
                return View(data);
            }
        }

        // GET: AutoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Autor>.GetById(id);
            data.Pais = Crud<Pais>.GetById(data.PaisCodigo);
            return View(data);
        }

        // POST: AutoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Autor data)
        {
            try
            {
                Crud<Autor>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error deleting author: {ex.Message}");
                return View(data);
            }
        }
    }
}
