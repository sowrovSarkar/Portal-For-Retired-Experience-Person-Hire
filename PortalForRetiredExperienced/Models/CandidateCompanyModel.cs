using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class CandidateCompanyModel
    {
        [Key]
        public int TId { get; set; }
        public int ProfileId { get; set; }
        public int JobId { get; set; }
      //  IList<Profile> Profiles { get; set; }
        //IList<JobListModel> Jobs { get; set; }
    }
}
