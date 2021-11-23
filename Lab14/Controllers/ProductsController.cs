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
    public class ProductsController : Controller
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

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: /PRODUCTS/CREATE
        //MUESTRA EL FORMULARIO
        public ActionResult Create()
        {
            return View();
        }

        //POST: /PRODUCTS/CREATE
        //REGISTRA NUEVO PRODUCTO EN LA BD
        [HttpPost]
        public ActionResult Create(Products nuevoProducto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Products.Add(nuevoProducto);
                    Contexto.SaveChanges();

                    return RedirectToAction("Details", "Categories", new { id = nuevoProducto.CategoryID });
                }
                //MUESTRA LA VISTA CREATE CON DATOS INGRESADOS


               
                return View(nuevoProducto);
            }
            catch
            {
                //MUESTRA LA VISTA CREATE VACIA
                return View();
            }
        }

        // GET: /PRODUCTS/EDIT/5
        //MUESTRA FORMULARIO PARA EDICION
        public ActionResult Edit(int? id)
        {
            //SI EL ID ES NULO
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Products productoEditar = Contexto.Products.Find(id);

            if (productoEditar == null)
                return HttpNotFound();
            //ENVIA LA CATEGORIA A EDITAR A LA VISTA
            return View(productoEditar);
        }

        //POST: /PRODUCTS/EDIT/5
        //REGISTRAR CAMBIOS DEL PRODUCTO EN LA BD
        [HttpPost]
        public ActionResult Edit(Products productoEditar)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Contexto.Entry(productoEditar).State = EntityState.Modified;
                    Contexto.SaveChanges();

                    return RedirectToAction("Details", "Categories", new { id = productoEditar.CategoryID });
                }
                //MUESTRA LA VISTA EDIT CON LOS DATOS INGRESADOS
                return View(productoEditar);
            }
            catch (Exception e)
            {

                //MUESTRA LA VISTA EDIT VACIA
                return View();
            }
        }

        // GET : /PRODUCTS/DELETE/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Products productoEliminar = Contexto.Products.Find(id);

            if (productoEliminar == null)
                return HttpNotFound();

            return View(productoEliminar);
        }

        // POST: /PRODUCTS/DELETE/5
        [HttpPost]
        public ActionResult Delete(int? id,Products producto1)
        {
            try
            {
                Products productoEliminar = new Products();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    productoEliminar = Contexto.Products.Find(id);
                   

                    //SI NO ENCUENTRA EL PRODUCTO MUESTRA MENSAJE
                    if (productoEliminar == null)
                        return HttpNotFound();

                    Contexto.Products.Remove(productoEliminar);
                    Contexto.SaveChanges();

                    return RedirectToAction("Details", "Categories", new { id = productoEliminar.CategoryID });
                }
                return View(productoEliminar);
            }
            catch
            {
                return View();
            }
        }
    }
}