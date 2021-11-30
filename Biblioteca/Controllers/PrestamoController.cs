using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class PrestamoController : Controller
    {

        #region Contexto
        //ATRIBUTO CONTEXTO
        private BibliotecaEntities _contexto;

        //PROPIEDAD CONTEXTO
        public BibliotecaEntities Contexto
        {
            set { _contexto = value; }
            get
            {
                if (_contexto == null)
                {
                    _contexto = new BibliotecaEntities();
                }
                return _contexto;
            }
        }
        #endregion


        // GET: Prestamo
        public ActionResult Index()
        {
            return View(Contexto.Prestamos.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: /PRESTAMO/CREATE
        //REGISTRA EN LA BD
        [HttpPost]
        public ActionResult Create(Prestamos nuevoPrestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Prestamos.Add(nuevoPrestamo);
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                //MUESTRA LA VISTA CREATE CON DATOS INGRESADOS
                return View(nuevoPrestamo);
            }
            catch
            {
                //MUESTRA LA VISTA CREATE VACIA
                return View();
            }
        }

        // GET: /PRESTAMO/EDIT/5
        //MUESTRA FORMULARIO PARA EDICION
        public ActionResult Edit(int? id)
        {
            //SI EL ID ES NULO
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Prestamos prestamoEditar = Contexto.Prestamos.Find(id);

            if (prestamoEditar == null)
                return HttpNotFound();
            //ENVIA EL  PRESTAMO A EDITAR A LA VISTA
            return View(prestamoEditar);
        }


        //POST: /PRESTAMO/EDIT/5
        //REGISTRAR CAMBIOS DE LA CATEGORIA EN LA BD
        [HttpPost]
        public ActionResult Edit(Prestamos prestamoEditar)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Contexto.Entry(prestamoEditar).State = EntityState.Modified;
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                //MUESTRA LA VISTA EDIT CON LOS DATOS INGRESADOS
                return View(prestamoEditar);
            }
            catch (Exception e)
            {

                //MUESTRA LA VISTA EDIT VACIA
                return View();
            }
        }

        // GET : /PRESTAMO/DELETE/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Prestamos prestamoEliminar = Contexto.Prestamos.Find(id);

            if (prestamoEliminar == null)
                return HttpNotFound();

            return View(prestamoEliminar);
        }


        // POST: /PRESTAMOS/DELETE/5
        [HttpPost]
        public ActionResult Delete(int? id, Prestamos prestamo1)
        {
            try
            {
                Prestamos prestamoEliminar = new Prestamos();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    prestamoEliminar = Contexto.Prestamos.Find(id);

                    //SI NO ENCUENTRA LA CATEGORIA MUESTRA MENSAJE
                    if (prestamoEliminar == null)
                        return HttpNotFound();

                    Contexto.Prestamos.Remove(prestamoEliminar);
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(prestamoEliminar);
            }
            catch
            {
                return View();
            }
        }

    }
}