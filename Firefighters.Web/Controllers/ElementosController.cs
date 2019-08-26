using Firefighters.Web.Data;
using Firefighters.Web.Data.Entities;
using Firefighters.Web.Helpers;
using Firefighters.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Controllers
{
    public class ElementosController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public ElementosController(DataContext context,
                                   ICombosHelper combosHelper,
                                   IConverterHelper converterHelper)
        {
            _dataContext = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        // GET: Elementos
        public IActionResult Index()
        {
            return View(_dataContext.Elementos
                .Include(u => u.Ubicacion)
                .Include(a => a.Area)
             );
        }

        // GET: Elementos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _dataContext.Elementos
                .FirstOrDefaultAsync(m => m.ElementoID == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }

        // GET: Elementos/Create
        public IActionResult Create(int? id)
        {

            var view = new ElementoViewModel
            {
                Areas = _combosHelper.GetComboAreas(),
                Ubicaciones = _combosHelper.GetComboUbicaciones(),
                Estados = _combosHelper.GetComboEstadosElementos(),
                Titulares = _combosHelper.GetComboTitulares(),
                Activo = true
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ElementoViewModel view)
        {
            if (ModelState.IsValid)
            {
                var elemento = await _converterHelper.ToElementoAsync(view);

                _dataContext.Elementos.Add(elemento);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));



            }
            return View(view);
        }

        // GET: Elementos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _dataContext.Elementos
                .Include(e => e.Area)
                .Include(e => e.Ubicacion)
                .FirstOrDefaultAsync(e => e.ElementoID == id.Value);

            if (elemento == null)
            {
                return NotFound();
            }
            var view = _converterHelper.ToElementoViewModel(elemento);
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ElementoViewModel view)
        {
            if (ModelState.IsValid)
            {
                try { 
                        var elemento = await _converterHelper.ToElementoAsync(view);
                         elemento.ElementoID = view.ElementoID;

                        _dataContext.Elementos.Update(elemento);
                        await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementoExists(view.ElementoID))
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

            return View(view);
        }

        // GET: Elementos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _dataContext.Elementos
                .FirstOrDefaultAsync(m => m.ElementoID == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }

        // POST: Elementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elemento = await _dataContext.Elementos.FindAsync(id);
            _dataContext.Elementos.Remove(elemento);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementoExists(int id)
        {
            return _dataContext.Elementos.Any(e => e.ElementoID == id);
        }
    }
}
