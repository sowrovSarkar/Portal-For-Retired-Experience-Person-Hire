using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalForRetiredExperienced.Data.DbContexts;

namespace PortalForRetiredExperienced.Controllers
{
    public class CompanyController : Controller
    {
        private readonly FrameworkDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(FrameworkDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyList.ToListAsync());
        }
        public async Task<IActionResult> CompanyList()
        {
            return View(await _context.CompanyList.ToListAsync());
        }
    }
}
