using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PortalForRetiredExperienced.Controllers
{
    public class CandidatesController : Controller
    {
          public IActionResult CandidateDetails ()
        {
            return View();
        }
        public IActionResult CandidateList ()
        {
            return View();
        }
    }
}
