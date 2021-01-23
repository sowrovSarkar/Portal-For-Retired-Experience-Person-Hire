using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class Applicant
    {
        public Applicant()
        {
            //this.EmployerSelectsSeekers = new HashSet<EmployerSelectsSeeker>();
            //this.Jobs = new HashSet<Job>();
            //this.JobAppoinments = new HashSet<JobAppoinment>();
            //this.JobSeekers = new HashSet<JobSeeker>();
        }

        public int EmployerId { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        public string EmployerUsername { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "Contact number is Required")]
        public string EmployerContactNo { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string EmployerEmail { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string EmployerPassword { get; set; }

        public string ProfilePictureName { get; set; }
        public string CompanyName { get; set; }
    }
}

