using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab14.Models;

namespace Lab14.Controllers
{
    public class CategoriesController : Controller
    {      
        #region Contexto
        //ATRIBUTO CONTEXTO
        private NORTHWNDEntities1 _contexto;

        //PROPIEDAD CONTEXTO
        public NORTHWNDEntities1 Contexto
        {
            set { _contexto = value; }
            get
            {
                if (_contexto == null)
                {
                    _contexto = new NORTHWNDEntities1();
                }
                return _contexto;
            }
        }
        #endregion

        //GET: CATEGORIES
        public ActionResult Index()
        {
            return View(Contexto.Categories.ToList());
        }

        //GET : /CATEGORIES/DETAILS/5
        public ActionResult Details(int id)
        {

            var productosPorCategoria = from p in Contexto.Products
                                        orderby p.ProductName ascending

                                        where p.CategoryID == id
                                        select p;
            return View(productosPorCategoria.ToList());
        }

        // GET: /CATEGORIES/CREATE
        //MUESTRA EL FORMULARIO
        public ActionResult Create()
        {
            return View();
        }

        //POST: /CATEGORIES/CREATE
        //REGISTRA NUEVA CATEGORIA EN LA BD
        [HttpPost]
        public ActionResult Create(Categories nuevaCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Categories.Add(nuevaCategoria);
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                //MUESTRA LA VISTA CREATE CON DATOS INGRESADOS
                return View(nuevaCategoria);
            }
            catch
            {
                //MUESTRA LA VISTA CREATE VACIA
                return View();
            }
        }

        // GET: /CATEGORIES/EDIT/5
        //MUESTRA FORMULARIO PARA EDICION
        public ActionResult Edit(int? id)
        {
            //SI EL ID ES NULO
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Categories categoriaEditar = Contexto.Categories.Find(id);

            if (categoriaEditar == null)
                return HttpNotFound();
            //ENVIA LA CATEGORIA A EDITAR A LA VISTA
            return View(categoriaEditar);
        }

        //POST: /CATEGORIES/EDIT/5
        //REGISTRAR CAMBIOS DE LA CATEGORIA EN LA BD
        [HttpPost]
        public ActionResult Edit(Categories CategoriaEditar)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Contexto.Entry(CategoriaEditar).State = EntityState.Modified;
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                //MUESTRA LA VISTA EDIT CON LOS DATOS INGRESADOS
                return View(CategoriaEditar);
            }
            catch(Exception e)
            {
                
                //MUESTRA LA VISTA EDIT VACIA
                return View();
            }
        }

        // GET : /CATEGORIES/DELETE/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Categories categoriaEliminar = Contexto.Categories.Find(id);

            if (categoriaEliminar == null)
                return HttpNotFound();

            return View(categoriaEliminar);
        }

        // POST: /CATEGORIES/DELETE/5
        [HttpPost]
        public ActionResult Delete(int? id, Categories categoria1)
        {
            try
            {
                Categories categoriaEliminar = new Categories();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    categoriaEliminar = Contexto.Categories.Find(id);

                    //SI NO ENCUENTRA LA CATEGORIA MUESTRA MENSAJE
                    if (categoriaEliminar == null)
                        return HttpNotFound();

                    Contexto.Categories.Remove(categoriaEliminar);
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(categoriaEliminar);
            }
            catch
            {
                return View();
            }
        }
    }
}