using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalForRetiredExperienced.Data.DbContexts;
using PortalForRetiredExperienced.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Controllers
{
    public class JobLIstController : Controller
    {
        private readonly FrameworkDbContext _context;

        public JobLIstController(FrameworkDbContext context)
        {
            _context = context;
        }

        // GET: JobListModels
        public async Task<IActionResult> JobList()
        {
            return View(await _context.JobListModels.ToListAsync());
        }
        //public IActionResult JobList()
        //{
        //    var model = new JobListModel();
        //    return View(model);
        //}
        public async Task<IActionResult> Apply(int? id, CandidateCompanyModel model)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            if (id == null)
            {
                return NotFound();
            }
            var jobListModel = await _context.JobListModels.FindAsync(id);
            if (jobListModel == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var profile = _context.Profile.FirstOrDefaultAsync(p => p.UserId == currentUserId.ToString());
                model.ProfileId = profile.Id;
                model.JobId = jobListModel.Id;
                
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
