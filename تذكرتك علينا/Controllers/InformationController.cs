using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using تذكرتك_علينا.Data;
using تذكرتك_علينا.Models;

namespace تذكرتك_علينا.Controllers
{
    public class InformationController : Controller
    {
        private readonly تذكرتك_عليناContext _context;

        public InformationController(تذكرتك_عليناContext context)
        {
            _context = context;
        }

        // GET: Information
        public async Task<IActionResult> Index(string type, string searchString)
        {
            if (_context.infomodel == null)
            {
                return Problem("Entity set 'تذكرتك_عليناContext.infomodel'  is null.");
            }
           
            IQueryable<string> genreQuery = from m in _context.infomodel
                                            orderby m.YOurTeam
                                            select m.YOurTeam;
            var M = from m in _context.infomodel
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                M = M.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(type))
            {
                M = M.Where(x => x.YOurTeam == type);
            }

            var MM = new Searchmodel
            {
                name = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Match = await M.ToListAsync()
            };

            return View(MM);
        }

        // GET: Information/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.infomodel == null)
            {
                return NotFound();
            }

            var infomodel = await _context.infomodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infomodel == null)
            {
                return NotFound();
            }

            return View(infomodel);
        }

        // GET: Information/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,YOurTeam,Price,Place,Phone,Ispuy,Date")] Models.infomodel infomodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infomodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return base.View(infomodel);
        }

        // GET: Information/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.infomodel == null)
            {
                return NotFound();
            }

            var infomodel = await _context.infomodel.FindAsync(id);
            if (infomodel == null)
            {
                return NotFound();
            }
            return View(infomodel);
        }

        // POST: Information/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,YOurTeam,Price,Place,Phone,Ispuy,Date")] Models.infomodel infomodel)
        {
            if (id != infomodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infomodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!infomodelExists(infomodel.Id))
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
            return base.View(infomodel);
        }

        // GET: Information/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.infomodel == null)
            {
                return NotFound();
            }

            var infomodel = await _context.infomodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infomodel == null)
            {
                return NotFound();
            }

            return View(infomodel);
        }

        // POST: Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.infomodel == null)
            {
                return Problem("Entity set 'تذكرتك_عليناContext.infomodel'  is null.");
            }
            var infomodel = await _context.infomodel.FindAsync(id);
            if (infomodel != null)
            {
                _context.infomodel.Remove(infomodel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool infomodelExists(int? id)
        {
          return (_context.infomodel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
