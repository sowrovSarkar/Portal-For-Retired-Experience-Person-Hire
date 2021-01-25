using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class CandidateListModel
    {

        [Key]
        public int Ca_id { get; set; }
        public String CandidateName { set; get; }
        public String Profession { set; get; }
        public String ProfileLink { set; get; }

    }
}
