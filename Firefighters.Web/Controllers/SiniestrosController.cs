using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firefighters.Web.Data;
using Firefighters.Web.Data.Entities;
using Firefighters.Web.Helpers;
using Microsoft.AspNetCore.Hosting;
using Firefighters.Web.Models;

namespace Firefighters.Web.Controllers
{
    public class SiniestrosController : Controller
    {
        
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IComprobanteHelper _comprobanteHelper;
        private IHostingEnvironment _env { get; }

        public SiniestrosController(DataContext context, ICombosHelper combosHelper,
                                               IConverterHelper converterHelper,
                                               IImageHelper imageHelper,
                                               IComprobanteHelper comprobanteHelper,
                                               IHostingEnvironment env)
        {
            _dataContext = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
            _comprobanteHelper = comprobanteHelper;
            _env = env;
        }

        // GET: Siniestros
        public IActionResult Index()
        {
            return View(_dataContext.Siniestros
                  .Include(l => l.Localidad)
                  .Include(e => e.Emergencia)


               );
        }

        // GET: Siniestros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _dataContext.Siniestros
                .Include(l => l.Localidad)
                .Include(e => e.Emergencia)
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
            var view = new SiniestroViewModel
            {
                Localidades = _combosHelper.GetComboLocalidades(),
                Emergencias = _combosHelper.GetComboEmergencias()
               
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SiniestroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var siniestro = await _converterHelper.ToSiniestroAsync(model, true);

                _dataContext.Add(siniestro);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Siniestros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _dataContext.Siniestros
                .Include(e => e.Localidad)
                .Include(e => e.Emergencia)
                .FirstOrDefaultAsync(e => e.SiniestroID == id.Value);

            if (siniestro == null)
            {
                return NotFound();
            }
            var view = _converterHelper.ToSiniestroViewModel(siniestro);
            return View(view);
        }
           
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SiniestroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var siniestro = await _converterHelper.ToSiniestroAsync(model, false);
                    siniestro.SiniestroID = model.SiniestroID;

                    _dataContext.Siniestros.Update(siniestro);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiniestroExists(model.SiniestroID))
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
            model.Emergencias = _combosHelper.GetComboEmergencias();
            model.Localidades = _combosHelper.GetComboLocalidades();
           

            return View(model);
        }

        // GET: Siniestros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _dataContext.Siniestros
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
            var siniestro = await _dataContext.Siniestros.FindAsync(id);
            _dataContext.Siniestros.Remove(siniestro);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiniestroExists(int id)
        {
            return _dataContext.Siniestros.Any(e => e.SiniestroID == id);
        }
    }
}
