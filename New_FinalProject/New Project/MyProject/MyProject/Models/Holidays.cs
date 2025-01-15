using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    
        public class Holidays
        {
            [Key]
        public int HolidayId { get; set; }
        public DateTime HolidayDate { get; set; }
    }
    

}