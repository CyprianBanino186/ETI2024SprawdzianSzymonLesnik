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
    public class KursController : Controller
    {
        private readonly SprawdzianSzymonLesnikContext _context;

        public KursController(SprawdzianSzymonLesnikContext context)
        {
            _context = context;
        }

        // GET: Kurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurs.ToListAsync());
        }

        // GET: Kurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Kurs
                .FirstOrDefaultAsync(m => m.KursId == id);
            if (kurs == null)
            {
                return NotFound();
            }

            return View(kurs);
        }

        // GET: Kurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KursId,NazwaKursu,DataRozpoczecia,DataZakonczenia")] Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kurs);
        }

        // GET: Kurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Kurs.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
        }

        // POST: Kurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KursId,NazwaKursu,DataRozpoczecia,DataZakonczenia")] Kurs kurs)
        {
            if (id != kurs.KursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KursExists(kurs.KursId))
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
            return View(kurs);
        }

        // GET: Kurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Kurs
                .FirstOrDefaultAsync(m => m.KursId == id);
            if (kurs == null)
            {
                return NotFound();
            }

            return View(kurs);
        }

        // POST: Kurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurs = await _context.Kurs.FindAsync(id);
            if (kurs != null)
            {
                _context.Kurs.Remove(kurs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KursExists(int id)
        {
            return _context.Kurs.Any(e => e.KursId == id);
        }
    }
}
