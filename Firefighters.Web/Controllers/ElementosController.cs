using Firefighters.Web.Data;
using Firefighters.Web.Data.Entities;
using Firefighters.Web.Helpers;
using Firefighters.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Controllers
{
    public class ElementosController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IComprobanteHelper _comprobanteHelper;

        private IHostingEnvironment _env { get; }

        public ElementosController(DataContext context,
                                   ICombosHelper combosHelper,
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

        // GET: Elementos
        public IActionResult Index()
        {
            return View(_dataContext.Elementos
                .Where(e => e.Activo == true && e.BajaFecha == null)
                .Include(u => u.Ubicacion)
                .Include(a => a.Area)
                .Include(i => i.ElementoImages)
                
             );
        }

        public IActionResult NoActivos()
        {
            return View(_dataContext.Elementos
                .Where(e => e.Activo == false && e.BajaFecha != null)
                .Include(u => u.Ubicacion)
                .Include(a => a.Area)
                .Include(i => i.ElementoImages)
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
                .Include(u => u.Ubicacion)
                .Include(a => a.Area)
                .Include(i => i.ElementoImages)
                .Include(c => c.ElementoComprobantes)

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
        public async Task<IActionResult> Create(ElementoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var elemento = await _converterHelper.ToElementoAsync(model, true);

                elemento.Activo = true;
                _dataContext.Elementos.Add(elemento);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(model);
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
        public async Task<IActionResult> Edit(ElementoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try { 
                        var elemento = await _converterHelper.ToElementoAsync(model, false);
                         elemento.ElementoID = model.ElementoID;

                        _dataContext.Elementos.Update(elemento);
                        await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementoExists(model.ElementoID))
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
            model.Areas = _combosHelper.GetComboAreas();
            model.Ubicaciones = _combosHelper.GetComboUbicaciones();
            model.Estados = _combosHelper.GetComboEstadosElementos();
            model.Titulares = _combosHelper.GetComboTitulares();

            return View(model);
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

        public async Task<IActionResult> AddImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _dataContext.Elementos.FindAsync(id.Value);
            if (elemento == null)
            {
                return NotFound();
            }

            var model = new ElementoImageViewModel
            {
                ElementoImageId = elemento.ElementoID
                
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(ElementoImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }

                var elementoImage = new ElementoImage
                {
                    ImageUrl = path,
                    Elemento = await _dataContext.Elementos.FindAsync(model.ElementoImageId)
                };

                _dataContext.ElementoImages.Add(elementoImage);
                await _dataContext.SaveChangesAsync();
                //return RedirectToAction($"{nameof(Details)}/{model.ElementoImageId}");
                return RedirectToAction("Details", "Elementos", new { @id = elementoImage.Elemento.ElementoID });

            }

            return View(model);
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoImage = await _dataContext.ElementoImages
                .Include(e => e.Elemento)
                .FirstOrDefaultAsync(e => e.ElementoImageId == id.Value);
            if (elementoImage == null)
            {
                return NotFound();
            }

            _dataContext.ElementoImages.Remove(elementoImage);
            await _dataContext.SaveChangesAsync();

            //return RedirectToAction($"{nameof(Details)}/{elementoImage.Elemento.ElementoID}");
            return RedirectToAction("Details", "Elementos", new { @id = elementoImage.Elemento.ElementoID });
        }

        public ActionResult DownloadImage(string ImagePath)
        {
            string filePath = ImagePath;
          
            string file = _env.WebRootPath + filePath;
            
            return File(new FileStream(file, FileMode.Open), "image/jpeg");

        }




        public async Task<IActionResult> AddComprobante(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _dataContext.Elementos.FindAsync(id.Value);
            if (elemento == null)
            {
                return NotFound();
            }

            var model = new ElementoComprobanteViewModel
            {
                ElementoComprobanteId = elemento.ElementoID

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComprobante(ElementoComprobanteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ComprobanteFile != null)
                {
                    path = await _comprobanteHelper.UploadComprobanteAsync(model.ComprobanteFile);

                }

                var elementoComprobante = new ElementoComprobante
                {
                    ComprobanteUrl = path,
                    Elemento = await _dataContext.Elementos.FindAsync(model.ElementoComprobanteId),
                    ComprobanteNombre = model.ComprobanteFile.FileName
                };

                _dataContext.ElementoComprobantes.Add(elementoComprobante);
                await _dataContext.SaveChangesAsync();
                //return RedirectToAction($"{nameof(Details)}/{model.ElementoImageId}");
                return RedirectToAction("Details", "Elementos", new { @id = elementoComprobante.Elemento.ElementoID });

            }

            return View(model);
        }

        public async Task<IActionResult> DeleteComprobante(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoComprobante = await _dataContext.ElementoComprobantes
                .Include(e => e.Elemento)
                .FirstOrDefaultAsync(e => e.ElementoComprobanteId == id.Value);
            if (elementoComprobante == null)
            {
                return NotFound();
            }

            _dataContext.ElementoComprobantes.Remove(elementoComprobante);
            await _dataContext.SaveChangesAsync();

            //return RedirectToAction($"{nameof(Details)}/{elementoImage.Elemento.ElementoID}");
            return RedirectToAction("Details", "Elementos", new { @id = elementoComprobante.Elemento.ElementoID });
        }

        public ActionResult DownloadComprobante(string ComprobantePath)
        {
            string filePath = ComprobantePath;

            string file = _env.WebRootPath + filePath;

            return File(new FileStream(file, FileMode.Open, FileAccess.Read), "application/pdf");

        }
    }
}
