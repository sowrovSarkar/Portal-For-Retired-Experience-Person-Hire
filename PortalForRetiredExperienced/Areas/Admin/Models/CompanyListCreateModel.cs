using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PortalForRetiredExperienced.Data.DbContexts;
using PortalForRetiredExperienced.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Areas.Admin.Models
{
    public class CompanyListCreateModel
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string WebAddress { get; set; }
        public string Discription { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        [Display (Name ="Upload Image")]
        public IFormFile ImageFile { get; set; }
 

    //    public async Task Create()
    //    {
    //        var hostingEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();

    //        string wwwRootpath = hostingEnvironment.WebRootPath;
    //        string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
    //        string extension = Path.GetExtension(ImageFile.FileName);
    //        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
    //        string path = Path.Combine(wwwRootpath + "/images/", fileName);

    //        var stream = new FileStream(path, FileMode.Create);
    //        await ImageFile.CopyToAsync(stream);

    //        var companyList = new CompanyList()
    //        {
    //            CompanyName = this.CompanyName,
    //            Discription = this.Discription,
    //            Logo = fileName,
    //            Location = this.Location,
    //            WebAddress = this.WebAddress,
    //            LinkedInLink = this.LinkedInLink,
    //            FacebookLink = this.FacebookLink
    //        };
    //        _context.Add(companyList);
    //        await _context.SaveChangesAsync();

    //    }

    }
}
