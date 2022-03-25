﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }

        public int DepartmentId { get; set; }
        public Department Department  { get; set; }

        public ICollection<Department> DeparmentList { get; set; }
    }
}
