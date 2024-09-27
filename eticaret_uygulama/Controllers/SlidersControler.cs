using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eticaret_uygulama.Data;
using eticaret_uygulama.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace eticaret_uygula.Controllers
{
    public class slidersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public slidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: sliders
        public async Task<IActionResult> Index()
        {
            return _context.Sliders != null ?
                        View(await _context.Sliders.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Slider'  is null.");
        }

        // GET: sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SliderId,SliderName,Heeader1,Heeader2,Context,SliderImage")] Slider slider, IFormFile ImageUpload)
        {
            if (ImageUpload != null)
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                string yeniisim = Guid.NewGuid().ToString() + uzanti;

                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Slider/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyToAsync(stream);
                }
                slider.SliderImage = yeniisim;
            }


            if (ModelState.IsValid)
            {
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SliderId,SliderName,Heeader1,Heeader2,Context,SliderImage")] Slider slider, IFormFile ImageUpload)
        {


            if (ImageUpload != null)
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                string yeniisim = Guid.NewGuid().ToString() + uzanti;

                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Slider/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyToAsync(stream);
                }
                slider.SliderImage = yeniisim;
            }

            if (id != slider.SliderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sliderExists(slider.SliderId))
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
            return View(slider);
        }

        // GET: sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sliders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Slider'  is null.");
            }
            var slider = await _context.Sliders.FindAsync(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
            }
            //Dosya silme
            string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Slider/" + slider.SliderImage);
            FileInfo yolFile = new FileInfo(yol);
            if (yolFile.Exists)
            {
                System.IO.File.Delete(yolFile.FullName);
                yolFile.Delete();
            }
            //Dosya Silme

            _context.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sliderExists(int id)
        {
            return (_context.Sliders?.Any(e => e.SliderId == id)).GetValueOrDefault();
        }
    }
}