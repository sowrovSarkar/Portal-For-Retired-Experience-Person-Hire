using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalForRetiredExperienced.Data.DbContexts;
using PortalForRetiredExperienced.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Test()
        {
            return View();
        }
    }
}
