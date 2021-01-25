using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class JobListModel : IEntity<int>
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } 
        public string Description { get; set; } 
        public string JobNature { get; set; } 
        public string Salary { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public string JobType { get; set; }
        public CompanyList CompanyDetails { get; set; }

        public JobListModel()
        {
            CompanyDetails = new CompanyList();
        }

    }
}
