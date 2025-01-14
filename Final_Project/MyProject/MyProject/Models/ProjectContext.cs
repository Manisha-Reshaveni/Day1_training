using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MyProject.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=connectstr")
        { }
        public DbSet<EmployeeLogin> EmpLogin { get; set; }

        public DbSet<ManagerLogin> MngLogin { get; set; }
                
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public DbSet<ProjectDetails> projectDetails { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<ManagerTimesheet> ManagerTimesheet { get; set; }
        public DbSet<EmployeeLeaveRequest> Leaves { get; set; }
        //public DbSet<ProjectDetails> ProjectDetails { get; set; }
        public DbSet<ManagerLeave> ManagerLeaves { get; set; }
        public IEnumerable<Holidays> Holidays { get; set; }
     
    }
}