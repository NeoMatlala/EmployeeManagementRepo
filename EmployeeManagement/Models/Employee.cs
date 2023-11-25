using System.ComponentModel;
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
        [DisplayName("ID Number")]
        public double IDNumber { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
