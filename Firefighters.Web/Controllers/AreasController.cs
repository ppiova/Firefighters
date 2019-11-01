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
    public class AreasController : Controller
    {
        private readonly DataContext _context;

        public AreasController(DataContext context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            // check if TempData contains some error message and if yes add to the model state.
            //if (TempData["CustomError"] != null)
            //{
            //    ModelState.AddModelError(string.Empty, TempData["CustomError"].ToString());
            //}

            return View(await _context.Areas.OrderBy(a => a.AreaName).ToListAsync());
           
        }

        // GET: Areas/Details/5 
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas
                .FirstOrDefaultAsync(m => m.AreaID == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, Area area)
        {
            if (id != area.AreaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.AreaID))
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
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas
                .Include(a=> a.Elementos)
                .FirstOrDefaultAsync(m => m.AreaID == id);
            if (area == null)
            {
                return NotFound();
            }
            if (area.Elementos.Count > 0)
            {
                ModelState.AddModelError(string.Empty, "Este ITEM no se puede ELIMINAR");
                return RedirectToAction(nameof(Index));
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            TempData["CustomError"] = "Eliminación Exitosa";
            return RedirectToAction(nameof(Index));
        }

      
        private bool AreaExists(short id)
        {
            return _context.Areas.Any(e => e.AreaID == id);
        }
    }
}
