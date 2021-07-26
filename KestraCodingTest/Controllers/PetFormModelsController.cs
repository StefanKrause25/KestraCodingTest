using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KestraCodingTest.Data;
using KestraCodingTest.Models;

namespace KestraCodingTest.Controllers
{
    public class PetFormModelsController : Controller
    {
        private readonly KestraCodingTestContext _context;

        public PetFormModelsController(KestraCodingTestContext context)
        {
            _context = context;
        }

        // GET: PetFormModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetFormModel.ToListAsync());
        }

        // GET: PetFormModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petFormModel = await _context.PetFormModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petFormModel == null)
            {
                return NotFound();
            }

            return View(petFormModel);
        }

        // GET: PetFormModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetFormModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PetName,PetAge,PetType")] PetFormModel petFormModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petFormModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petFormModel);
        }

        // GET: PetFormModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petFormModel = await _context.PetFormModel.FindAsync(id);
            if (petFormModel == null)
            {
                return NotFound();
            }
            return View(petFormModel);
        }

        // POST: PetFormModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PetName,PetAge,PetType")] PetFormModel petFormModel)
        {
            if (id != petFormModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petFormModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetFormModelExists(petFormModel.Id))
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
            return View(petFormModel);
        }

        // GET: PetFormModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petFormModel = await _context.PetFormModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petFormModel == null)
            {
                return NotFound();
            }

            return View(petFormModel);
        }

        // POST: PetFormModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petFormModel = await _context.PetFormModel.FindAsync(id);
            _context.PetFormModel.Remove(petFormModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetFormModelExists(int id)
        {
            return _context.PetFormModel.Any(e => e.Id == id);
        }
    }
}
