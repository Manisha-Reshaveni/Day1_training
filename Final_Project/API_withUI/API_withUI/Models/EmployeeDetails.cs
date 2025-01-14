using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace MyProject.Models

{

    public class EmployeeDetails

    {

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int EmpID { get; set; }

        public string Employeename { get; set; }

        public string Grade { get; set; }

        public string Designation { get; set; }

        public string Password { get; set; }

        // Optional: Add navigation properties if needed

        // public virtual ICollection<SomeOtherEntity> SomeOtherEntities { get; set; }

    }

}