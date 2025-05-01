using EducationCenter.Models.Enums;
using EducationCenter.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.DTOs.Request
{
    public class RegisterRequestDTO
    {
       

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        public string? Image { get; set; }

        [Required]
        public RoleStatus RoleStatus { get; set; } // "Student" or "Teacher"
        [Required]
        [MaxLength(100)]

        //public int AcademicYearID { get; set; }
        //public AcademicYear AcademicYear { get; set; }
        public string ParentName { get; set; }

        [Required]
        [Phone]
        public string ParentPhone { get; set; }

        [Required]
        [EmailAddress]
        public string ParentMail { get; set; }

        [Required]
        public ParentStatus ParentStatus { get; set; }
    }
}
