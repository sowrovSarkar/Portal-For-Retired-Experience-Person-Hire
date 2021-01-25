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
    public class CandidateListController : Controller
    {
        private readonly FrameworkDbContext _context;

        public CandidateListController(FrameworkDbContext context)
        {
            _context = context;
        }

        // GET: CandidateList
        public async Task<IActionResult> Index()
        {
            return View(await _context.CandidateList.ToListAsync());
        }
        public async Task<IActionResult> CandidateList()
        {
            return View(await _context.CandidateList.ToListAsync());
        }

        // GET: CandidateList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateListModel = await _context.CandidateList
                .FirstOrDefaultAsync(m => m.Ca_id == id);
            if (candidateListModel == null)
            {
                return NotFound();
            }

            return View(candidateListModel);
        }

        // GET: CandidateList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CandidateList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ca_id,CandidateName,Profession,ProfileLink")] CandidateListModel candidateListModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidateListModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidateListModel);
        }

        // GET: CandidateList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateListModel = await _context.CandidateList.FindAsync(id);
            if (candidateListModel == null)
            {
                return NotFound();
            }
            return View(candidateListModel);
        }

        // POST: CandidateList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ca_id,CandidateName,Profession,ProfileLink")] CandidateListModel candidateListModel)
        {
            if (id != candidateListModel.Ca_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidateListModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateListModelExists(candidateListModel.Ca_id))
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
            return View(candidateListModel);
        }

        // GET: CandidateList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateListModel = await _context.CandidateList
                .FirstOrDefaultAsync(m => m.Ca_id == id);
            if (candidateListModel == null)
            {
                return NotFound();
            }

            return View(candidateListModel);
        }

        // POST: CandidateList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidateListModel = await _context.CandidateList.FindAsync(id);
            _context.CandidateList.Remove(candidateListModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateListModelExists(int id)
        {
            return _context.CandidateList.Any(e => e.Ca_id == id);
        }
    }
}
