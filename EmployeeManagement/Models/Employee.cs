﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        
        public string Name { get; set; }

        public string Surname { get; set; }

        
        [DisplayName("ID Number")]
        public double IDNumber { get; set; }

        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        // FK
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        // navigation property
        public Department Department { get; set; }

        
    }
}
