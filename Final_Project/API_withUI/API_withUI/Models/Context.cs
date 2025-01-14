using MyProject.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace API_withUI.Models
{


    public  class Context : DbContext
    {
        public Context()
            : base("name=connectstr")
        {
        }    

        public virtual DbSet<Timesheet> Timesheet { get; set; }
     
        public DbSet<EmployeeDetails> EmployeeDetails { get; internal set; }
    }
}