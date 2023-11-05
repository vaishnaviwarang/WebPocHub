using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPOCHub.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Employee Name is required field!")]
        public string EmployeeName { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(50)]
        [Required(ErrorMessage = "Employee City is required field!")]
        public string City { get; set; } = string.Empty;
        [MaxLength(10)]
        public string ZipCode { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Country { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Skillsets { get; set; } = string.Empty;
        [MaxLength(15)]
        [Required(ErrorMessage = "Phone Number is required!")]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(100)]
        [EmailAddress]
        [Required(ErrorMessage = "Employee Email is required!")]
        public string Email { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Avatar { get; set; } = string.Empty;

    }
}