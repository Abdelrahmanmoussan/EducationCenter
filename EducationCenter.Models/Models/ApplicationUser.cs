﻿
using EducationCenter.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Key]
        //public int UserID { get; set; }

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

        public Student Student { get; set; }

        public NotificationRecipient NotificationRecipient { get; set; }
    }

}
