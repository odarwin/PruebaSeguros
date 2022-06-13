using Microsoft.AspNetCore.Mvc;
using ProjectChubb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectChubb.Controllers
{
    public class PersonaController : Controller
    {
        private readonly db_segurosContext _context;

        public PersonaController(db_segurosContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Persona> listaPersonas = _context.Personas;

            return View(listaPersonas);
        }

        public IActionResult CreatePerson()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreatePerson(Persona p)
        {
            p.IdPersona = 0;
            if (ModelState.IsValid)
            {
                _context.Personas.Add(p);
                _context.SaveChanges();
                TempData["mensaje"] = "El cliente se creo correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPerson(Persona p)
        {
            if (ModelState.IsValid)
            {
                _context.Personas.Update(p);
                _context.SaveChanges();
                TempData["mensaje"] = "El cliente se actualizo correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditPerson(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();

            }
            var p = _context.Personas.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);

        }

        //Delete
        public IActionResult DeletePerson(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();

            }
            var p = _context.Personas.Find(id);

            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }



        //Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePerson(Persona pe)
        {
            //var pe = _context.Personas.Find(id);
            if (pe == null)
            {
                return NotFound();

            }
            _context.Personas.Remove(pe);
            _context.SaveChanges();
            TempData["mensaje"] = "El cliente se elimino correctamente";
            return RedirectToAction("Index");

        }

    }
}
