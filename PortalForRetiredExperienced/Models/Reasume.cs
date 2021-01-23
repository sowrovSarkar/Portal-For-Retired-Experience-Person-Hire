using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public class Reasume
    {
        public int ResumeId { get; set; }
        public string ResumePath { get; set; }
        public System.DateTime ResumeUploadDate { get; set; }
        public Nullable<System.DateTime> ResumeLastModifiedDate { get; set; }
        public int JobSeekerId { get; set; }
        public byte[] CvFile { get; set; }
        public string CvFileText { get; set; }
        public string CvFileName { get; set; }

      //  public virtual JobSeeker JobSeeker { get; set; }
    }
}

