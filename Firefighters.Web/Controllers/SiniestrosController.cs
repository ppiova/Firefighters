using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firefighters.Web.Data;
using Firefighters.Web.Data.Entities;

namespace Firefighters.Web.Controllers
{
    public class SiniestrosController : Controller
    {
        private readonly DataContext _context;

        public SiniestrosController(DataContext context)
        {
            _context = context;
        }

        // GET: Siniestros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Siniestros.ToListAsync());
        }

        // GET: Siniestros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _context.Siniestros
                .FirstOrDefaultAsync(m => m.SiniestroID == id);
            if (siniestro == null)
            {
                return NotFound();
            }

            return View(siniestro);
        }

        // GET: Siniestros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Siniestros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiniestroID,FechaSiniestro,Denunciante,Damnificado,DirUbicación,RutaKm")] Siniestro siniestro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siniestro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siniestro);
        }

        // GET: Siniestros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _context.Siniestros.FindAsync(id);
            if (siniestro == null)
            {
                return NotFound();
            }
            return View(siniestro);
        }

        // POST: Siniestros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiniestroID,FechaSiniestro,Denunciante,Damnificado,DirUbicación,RutaKm")] Siniestro siniestro)
        {
            if (id != siniestro.SiniestroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siniestro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiniestroExists(siniestro.SiniestroID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(siniestro);
        }

        // GET: Siniestros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _context.Siniestros
                .FirstOrDefaultAsync(m => m.SiniestroID == id);
            if (siniestro == null)
            {
                return NotFound();
            }

            return View(siniestro);
        }

        // POST: Siniestros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siniestro = await _context.Siniestros.FindAsync(id);
            _context.Siniestros.Remove(siniestro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiniestroExists(int id)
        {
            return _context.Siniestros.Any(e => e.SiniestroID == id);
        }
    }
}
