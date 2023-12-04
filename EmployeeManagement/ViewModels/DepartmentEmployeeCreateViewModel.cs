using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeManagement.ViewModels
{
    public class DepartmentEmployeeCreateViewModel
    {
        //public List<Employee> Employee {get; set;}
        public Employee Employee { get; set; }

        public List<Department> Departments { get; set; }

        //public int EmployeeId => Employee.ID;
    }
}
