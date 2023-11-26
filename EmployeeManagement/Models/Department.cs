using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        // dept name, dept manager, ho w many members?
        [Key]
        public int ID { get; set; }

        [Required]
        public string Manager { get; set; }

        [Required]
        public int Members { get; set; }
        
    }
}
