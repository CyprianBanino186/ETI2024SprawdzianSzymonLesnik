﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SprawdzianSzymonLesnik.Data;
using SprawdzianSzymonLesnik.Models;

namespace SprawdzianSzymonLesnik.Controllers
{
    public class UczenController : Controller
    {
        private readonly SprawdzianSzymonLesnikContext _context;

        public UczenController(SprawdzianSzymonLesnikContext context)
        {
            _context = context;
        }

        // GET: Uczen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uczen.ToListAsync());
        }

        // GET: Uczen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uczen = await _context.Uczen
                .FirstOrDefaultAsync(m => m.UczenId == id);
            if (uczen == null)
            {
                return NotFound();
            }

            return View(uczen);
        }

        // GET: Uczen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uczen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UczenId,Imie,Nazwisko,Adres")] Uczen uczen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uczen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uczen);
        }

        // GET: Uczen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uczen = await _context.Uczen.FindAsync(id);
            if (uczen == null)
            {
                return NotFound();
            }
            return View(uczen);
        }

        // POST: Uczen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UczenId,Imie,Nazwisko,Adres")] Uczen uczen)
        {
            if (id != uczen.UczenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uczen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UczenExists(uczen.UczenId))
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
            return View(uczen);
        }

        // GET: Uczen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uczen = await _context.Uczen
                .FirstOrDefaultAsync(m => m.UczenId == id);
            if (uczen == null)
            {
                return NotFound();
            }

            return View(uczen);
        }

        // POST: Uczen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uczen = await _context.Uczen.FindAsync(id);
            if (uczen != null)
            {
                _context.Uczen.Remove(uczen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UczenExists(int id)
        {
            return _context.Uczen.Any(e => e.UczenId == id);
        }
    }
}
