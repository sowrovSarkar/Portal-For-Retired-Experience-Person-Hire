using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalForRetiredExperienced.Data.DbContexts;
using PortalForRetiredExperienced.Models;

namespace PortalForRetiredExperienced.Controllers
{
    public class JobListModelsController : Controller
    {
        private readonly FrameworkDbContext _context;

        public JobListModelsController(FrameworkDbContext context)
        {
            _context = context;
        }

        // GET: JobListModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobListModels.ToListAsync());
        }

        // GET: JobListModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobListModel = await _context.JobListModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobListModel == null)
            {
                return NotFound();
            }

            return View(jobListModel);
        }

        // GET: JobListModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobListModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobTitle,Description,JobNature,Salary,Location,DateTime")] JobListModel jobListModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobListModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobListModel);
        }

        // GET: JobListModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobListModel = await _context.JobListModels.FindAsync(id);
            if (jobListModel == null)
            {
                return NotFound();
            }
            return View(jobListModel);
        }

        // POST: JobListModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobTitle,Description,JobNature,Salary,Location,DateTime")] JobListModel jobListModel)
        {
            if (id != jobListModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobListModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobListModelExists(jobListModel.Id))
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
            return View(jobListModel);
        }

        // GET: JobListModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobListModel = await _context.JobListModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobListModel == null)
            {
                return NotFound();
            }

            return View(jobListModel);
        }

        // POST: JobListModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobListModel = await _context.JobListModels.FindAsync(id);
            _context.JobListModels.Remove(jobListModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobListModelExists(int id)
        {
            return _context.JobListModels.Any(e => e.Id == id);
        }
    }
}
