using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalForRetiredExperienced.Areas.Admin.Models;
using PortalForRetiredExperienced.Data.DbContexts;
using PortalForRetiredExperienced.Models;

namespace PortalForRetiredExperienced.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly FrameworkDbContext _context;
        private readonly ApplicationDbContext _memberShipContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfilesController(FrameworkDbContext context , ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _memberShipContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        // GET: Profiles
        public async Task<IActionResult>Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            return View(await _context.Profile.Where(x => x.UserId == currentUserId.ToString()).ToListAsync());
        }
        public async Task<IActionResult>Profile()
        {
            return View(await _context.Profile.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .FirstOrDefaultAsync(m => m.P_Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfileCreateModel profile)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name);


            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(profile);
                var profileEntity = new Profile
                {
                    ProfilePic = uniqueFileName,
                    JobTitle = profile.JobTitle,
                    Address = profile.Address,
                    PhoneNumber = profile.PhoneNumber,
                    DateofBirth = profile.DateofBirth,
                    UploadCv = profile.UploadCV,
                    UserId = currentUserId.ToString()
                };
                _context.Add(profileEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("P_Id,ProfilePic,UploadCv,DateofBirth,PhoneNumber,Address,JobTitle")] Profile profile)
        {
            if (id != profile.P_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.P_Id))
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
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .FirstOrDefaultAsync(m => m.P_Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private string UploadedFile(ProfileCreateModel model)
        {
            string uniqueFileName = null;

            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                } 
            }
            return uniqueFileName;
        }

        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.P_Id == id);
        }
    }
}
