using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfJoin { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }
    }
}
