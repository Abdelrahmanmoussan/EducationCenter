using EducationCenter.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.DTOs.Request
{
    internal class RegisterRequest
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
        [MaxLength(20)]
        public RoleStatus RoleStatus { get; set; } // "Student" or "Teacher"
    }
}
