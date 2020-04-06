using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YogamedAppRole.Data;
using YogamedAppRole.Models;

namespace YogamedAppRole.Controllers
{
    public class YogaTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YogaTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YogaTables
        [Authorize(Policy = "adminpolicy")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.YogaTable.Include(y => y.Ydfk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: YogaTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yogaTable = await _context.YogaTable
                .Include(y => y.Ydfk)
                .FirstOrDefaultAsync(m => m.YogaId == id);
            if (yogaTable == null)
            {
                return NotFound();
            }

            return View(yogaTable);
        }

        // GET: YogaTables/Create
        public IActionResult Create()
        {
            ViewData["YdfkId"] = new SelectList(_context.DiseaseTable, "DiseaseId", "DiseaseId");
            return View();
        }

        // POST: YogaTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YogaId,YogaName,YogaStep,YdfkId")] YogaTable yogaTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yogaTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["YdfkId"] = new SelectList(_context.DiseaseTable, "DiseaseId", "DiseaseId", yogaTable.YdfkId);
            return View(yogaTable);
        }

        // GET: YogaTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yogaTable = await _context.YogaTable.FindAsync(id);
            if (yogaTable == null)
            {
                return NotFound();
            }
            ViewData["YdfkId"] = new SelectList(_context.DiseaseTable, "DiseaseId", "DiseaseId", yogaTable.YdfkId);
            return View(yogaTable);
        }

        // POST: YogaTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YogaId,YogaName,YogaStep,YdfkId")] YogaTable yogaTable)
        {
            if (id != yogaTable.YogaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yogaTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YogaTableExists(yogaTable.YogaId))
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
            ViewData["YdfkId"] = new SelectList(_context.DiseaseTable, "DiseaseId", "DiseaseId", yogaTable.YdfkId);
            return View(yogaTable);
        }

        // GET: YogaTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yogaTable = await _context.YogaTable
                .Include(y => y.Ydfk)
                .FirstOrDefaultAsync(m => m.YogaId == id);
            if (yogaTable == null)
            {
                return NotFound();
            }

            return View(yogaTable);
        }

        // POST: YogaTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yogaTable = await _context.YogaTable.FindAsync(id);
            _context.YogaTable.Remove(yogaTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YogaTableExists(int id)
        {
            return _context.YogaTable.Any(e => e.YogaId == id);
        }
    }
}
