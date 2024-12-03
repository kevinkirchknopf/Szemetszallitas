using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szemetszallitas.Data;
using Szemetszallitas.Models;

namespace Szemetszallitas.Controllers
{
    public class NaptarsController : Controller
    {
        private readonly SzemetszallitasContext _context;

        public NaptarsController(SzemetszallitasContext context)
        {
            _context = context;
        }

        // GET: Naptars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Naptar.ToListAsync());
        }

        // GET: Naptars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naptar == null)
            {
                return NotFound();
            }

            return View(naptar);
        }

        // GET: Naptars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Naptars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,datum,SzolgId")] Naptar naptar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naptar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(naptar);
        }

        // GET: Naptars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar.FindAsync(id);
            if (naptar == null)
            {
                return NotFound();
            }
            return View(naptar);
        }

        // POST: Naptars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,datum,SzolgId")] Naptar naptar)
        {
            if (id != naptar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naptar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaptarExists(naptar.Id))
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
            return View(naptar);
        }

        // GET: Naptars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naptar = await _context.Naptar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naptar == null)
            {
                return NotFound();
            }

            return View(naptar);
        }

        // POST: Naptars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var naptar = await _context.Naptar.FindAsync(id);
            if (naptar != null)
            {
                _context.Naptar.Remove(naptar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaptarExists(int id)
        {
            return _context.Naptar.Any(e => e.Id == id);
        }
    }
}
