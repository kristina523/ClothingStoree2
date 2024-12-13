using ClothingStoree.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClothingStoreeContext _context;

        public HomeController(ClothingStoreeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var catolog = _context.Catalogs.ToList();
            return View(catolog);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Catalog catolog)
        {
            _context.Catalogs.Add(catolog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DetailsCatalog(int? id)
        {
            if (id != null)
            {
                Catalog catolog = await _context.Catalogs.FirstOrDefaultAsync(p => p.IdProduct == id);
                if (catolog != null)
                    return View(catolog);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Catalog catolog = await _context.Catalogs.FirstOrDefaultAsync(p => p.IdProduct == id);
                if (catolog != null)
                    return View(catolog);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Catalog catolog)
        {
            _context.Catalogs.Update(catolog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Catalog catolog = await _context.Catalogs.FirstOrDefaultAsync(p => p.IdProduct == id);
                if (catolog != null)
                    return View(catolog);
            }
            return NotFound();
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var catolog = await _context.Catalogs.FindAsync(id);
            if (catolog == null)
            {
                return NotFound();
            }

            _context.Catalogs.Remove(catolog);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}