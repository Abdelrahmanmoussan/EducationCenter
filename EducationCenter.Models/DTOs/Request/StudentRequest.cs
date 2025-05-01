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
    public class StudentRequest
    {
        [Required]
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }

        [Required]
        [MaxLength(100)]
        public string ParentName { get; set; }

        [Required]
        [Phone]
        public string ParentPhone { get; set; }

        [Required]
        [EmailAddress]
        public string ParentMail { get; set; }

        [Required]
        [MaxLength(50)]
        public ParentStatus ParentStatus { get; set; }
    }
}
