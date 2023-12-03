using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeManagement.ViewModels
{
    public class DepartmentEmployeeViewModel
    {
        //public Employee Employees {get; set;}
        
        public string Name { get; set; }

        public string Surname { get; set; }

        
        [DisplayName("ID Number")]
        public double IDNumber { get; set; }

        
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        // FK
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public List<Department> Departments { get; set; }
    }
}
