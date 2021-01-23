using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class JobPost
    {
       
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobRequirements { get; set; }
        public string JobDescription { get; set; }
        public string JobPosition { get; set; }
        public string JobLocation { get; set; }
        public Nullable<decimal> JobSalary { get; set; }
        public double JobWorkingHour { get; set; }
        public int EmployerId { get; set; }
        public int JobCategoryId { get; set; }

        public virtual Applicant Employer { get; set; }
        public virtual JobCategory JobCategory { get; set; }
    //    public virtual ICollection<JobAppoinment> JobAppoinments { get; set; }
    //    public virtual ICollection<JobSeeked> JobSeekeds { get; set; }
    }
}
 
