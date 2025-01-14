using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class ManagerLogin
    {
        
        public int ManagerID { get; set; }

        [Key]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public String Status { get; set; }
        public string Grade { get; set; }
        public string Designation { get; set; }

        [MaxLength(8,ErrorMessage ="password length can not be more than 8 characters")]
        public string Password { get; set; }
    }
}