using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class ManagerLeave
    {
        [Key]
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int DaysOfLeave { get; set; }
        public string ContactAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Reason { get; set; }
        public string Session { get; set; }
        public List<DateTime> Holidays { get; set; }


    }
}