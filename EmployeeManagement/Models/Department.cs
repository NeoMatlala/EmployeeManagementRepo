using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        [Required]
        public string Manager { get; set; }

        [Required]
        public int Members { get; set; }
        
    }
}
