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
    public class CompanyListsController : Controller
    {
        private readonly FrameworkDbContext _context;

        public CompanyListsController(FrameworkDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CompanyLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyList.ToListAsync());
        }

        // GET: Admin/CompanyLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyList = await _context.CompanyList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyList == null)
            {
                return NotFound();
            }

            return View(companyList);
        }

        // GET: Admin/CompanyLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CompanyLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,Logo,Location,WebAddress,Discription,FacebookLink,LinkedInLink")] CompanyList companyList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyList);
        }

        // GET: Admin/CompanyLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyList = await _context.CompanyList.FindAsync(id);
            if (companyList == null)
            {
                return NotFound();
            }
            return View(companyList);
        }

        // POST: Admin/CompanyLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Logo,Location,WebAddress,Discription,FacebookLink,LinkedInLink")] CompanyList companyList)
        {
            if (id != companyList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyListExists(companyList.Id))
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
            return View(companyList);
        }

        // GET: Admin/CompanyLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyList = await _context.CompanyList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyList == null)
            {
                return NotFound();
            }

            return View(companyList);
        }

        // POST: Admin/CompanyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyList = await _context.CompanyList.FindAsync(id);
            _context.CompanyList.Remove(companyList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyListExists(int id)
        {
            return _context.CompanyList.Any(e => e.Id == id);
        }
    }
}
