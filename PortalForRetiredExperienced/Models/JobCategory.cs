using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class JobCategory
    {
        public JobCategory()
        {
            this.Jobs = new HashSet<JobPost>();
        }

        public int JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
        public virtual ICollection<JobPost> Jobs { get; set; }
    }
}
