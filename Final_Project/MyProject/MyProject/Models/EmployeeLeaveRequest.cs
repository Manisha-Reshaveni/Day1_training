﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class EmployeeLeaveRequest
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int DaysOfLeave { get; set; }
        public string ApproverName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactNumber { get; set; }
        public string CCTo { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }
        public string Session { get; set; }
        public string ManagerApprovalStatus { get; set; }
        public string ManagerComments { get; set; }
        public List<DateTime> Holidays { get; set; }

     

        // Constructor to set default values
        public EmployeeLeaveRequest()
        {
            IsApproved = false;
        }
    }
}