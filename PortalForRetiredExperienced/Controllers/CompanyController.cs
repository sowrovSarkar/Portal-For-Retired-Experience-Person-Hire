using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PortalForRetiredExperienced.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult CompanyList()
        {
            return View();
        }
    }
}
