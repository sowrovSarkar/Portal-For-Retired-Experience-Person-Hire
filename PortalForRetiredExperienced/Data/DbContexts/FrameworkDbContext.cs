using Microsoft.EntityFrameworkCore;
using PortalForRetiredExperienced.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Data.DbContexts
{
    public class FrameworkDbContext : DbContext
    {
        public FrameworkDbContext() : base()
        {

        }
        public FrameworkDbContext(DbContextOptions<FrameworkDbContext> dbContext) : base(dbContext)
        {

        }

       public DbSet<JobListModel> JobListModels { get; set; }

       public DbSet<CandidateListModel> CandidateList { get; set; }

       public DbSet<CompanyList> CompanyList { get; set; }

       public DbSet<Applicant> Applicant { get; set; }

       public DbSet<PortalForRetiredExperienced.Models.Contact> Contact { get; set; }

    }
}
