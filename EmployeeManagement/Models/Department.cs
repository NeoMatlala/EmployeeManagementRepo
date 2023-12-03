using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        public string Manager { get; set; }

        public int Members { get; set; }

        //Nav Prop
        public List<Employee> Employees { get; set; }

    }
}
