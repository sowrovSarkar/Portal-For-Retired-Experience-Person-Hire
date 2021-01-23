using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalForRetiredExperienced.Data.DbContexts;
using PortalForRetiredExperienced.Models;

namespace PortalForRetiredExperienced.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobListController : Controller
    {
        private readonly FrameworkDbContext _context;

        public JobListController(FrameworkDbContext context)
        {
            _context = context;
        }

        // GET: Admin/JobList
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobListModels.ToListAsync());
        }

        // GET: Admin/JobList/Details/5
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

        // GET: Admin/JobList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/JobList/Create
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

        // GET: Admin/JobList/Edit/5
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

        // POST: Admin/JobList/Edit/5
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

        // GET: Admin/JobList/Delete/5
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

        // POST: Admin/JobList/Delete/5
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
