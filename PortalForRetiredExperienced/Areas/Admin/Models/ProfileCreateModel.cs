using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Areas.Admin.Models
{
    public class ProfileCreateModel
    {
        public string UploadCV { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
