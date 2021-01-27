using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class Profile
    {
        [Key]
        public int P_Id { get; set; }
        public string ProfilePic { get; set; }
        
        public string UploadCv { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public string UserId { get; set; }
        public IList<IdentityUser> User { get; set; }


    }
}
