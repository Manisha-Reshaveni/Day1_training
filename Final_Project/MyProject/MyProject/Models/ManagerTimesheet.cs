using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class ManagerTimesheet
    {
        [Key]
        public int ProjectID { get; set; }
        public string Projectname { get; set; }
        public string Task { get; set; }
        public DateTime Datenow { get; set; }
        public string Category { get; set; }
        public int Hours { get; set; }
        public string Remarks { get; set; }
    }
}