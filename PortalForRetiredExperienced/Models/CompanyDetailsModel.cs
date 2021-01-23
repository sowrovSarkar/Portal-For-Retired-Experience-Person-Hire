using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class CompanyDetailsModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Logo  { get; set; }
        public string Location { get; set; }
        public string WebAddress { get; set; }
        public string Discription { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
    }
}
