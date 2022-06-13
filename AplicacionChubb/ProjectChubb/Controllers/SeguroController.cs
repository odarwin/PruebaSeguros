using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectChubb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectChubb.Controllers
{
    public class SeguroController : Controller
    {
        private readonly db_segurosContext _context;

        public SeguroController(db_segurosContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Seguro> listaSeguros = _context.Seguros;

            return View(listaSeguros);
        }
        public IActionResult CreateSeguro()
        {
            //ViewBag.opcionestipos = _context.optionsTiposSeguro;
            ViewBag.opcionestipos = new SelectList(_context.TipoSeguros, "IdTipoSeguro", "TipoSeguro1");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSeguro(Seguro p)
        {
            p.IdSeguro = 0;
            p.FechaModificacionSeguro = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Seguros.Add(p);
                _context.SaveChanges();
                TempData["mensaje"] = "El seguro creo correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult CreateTipoSeguro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTipoSeguro(TipoSeguro p)
        {
            p.IdTipoSeguro = 0;

            if (ModelState.IsValid)
            {
                _context.TipoSeguros.Add(p);
                _context.SaveChanges();
                TempData["mensaje"] = "El tipo de seguro creo correctamente";
                return RedirectToAction("CreateSeguro");
            }
            return View();
        }
        
        public IActionResult EditSeguro(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();

            }
            var p = _context.Seguros.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }


    }
}
