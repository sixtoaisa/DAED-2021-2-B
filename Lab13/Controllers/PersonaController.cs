using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab13.Models;

namespace Lab13.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        private List<Persona> llenarPersona()
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona
            {
                PersonaID = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                Direccion = "Av. Evergreen 123",
                FechaNac = Convert.ToDateTime("1997-11-07"),
                Email = "juan@gmail.com"
            });

            personas.Add(new Persona
            {
                PersonaID = 2,
                Nombre = "Maria",
                Apellido = "Salas",
                Direccion = "Av. Progreso 325",
                FechaNac = Convert.ToDateTime("1995-10-28"),
                Email = "maria@gmail.com"
            });

            personas.Add(new Persona
            {
                PersonaID = 3,
                Nombre = "Carlos",
                Apellido = "martinez",
                Direccion = "Av. Los manzanos 101",
                FechaNac = Convert.ToDateTime("1982-02-14"),
                Email = "carlos@gmail.com"
            });

            return personas;
        }

        public ActionResult Listar()
        {

            List<Persona> personas = llenarPersona();
            return View(personas);
        }


        public ActionResult Mostrar(int id)
        {

            List<Persona> personas = llenarPersona();

            Persona persona = (from p in personas
                               where p.PersonaID == id
                               select p).FirstOrDefault();


            return View(persona);
        }

        public ActionResult Buscar(String criterio)
        {

            List<Persona> personas = llenarPersona();

            if (criterio == null)
            {
                criterio = "";
            }

            var query = (from p in personas
                               where p.Nombre == criterio || p.Apellido == criterio
                         select p);


            return View(query.ToList());
        }
    }
}