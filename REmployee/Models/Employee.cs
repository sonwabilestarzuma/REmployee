using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REmployee.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "User Role")]
        public string UserRole { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public bool Active { get; set; }


        [Required]
        [Display(Name = "Job Title")]
        public Title Title { get; set; }
        public int TitleId { get; set; }

        [Required]
        [Display(Name = "Employee Status")]
        public int EmployeeStatusId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}
