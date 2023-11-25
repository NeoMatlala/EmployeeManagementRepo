using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public double IDNumber { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
