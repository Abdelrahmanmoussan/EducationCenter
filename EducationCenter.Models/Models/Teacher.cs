using EducationCenter.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Teacher 
    {
        [Key, ForeignKey("User")]
        public int TeacherId { get; set; }

        [Required]
        public TeacherStatus TeacherStatus { get; set; } 

        [Required]
        public decimal NetAmount { get; set; }

        public string Content { get; set; }

        [Required]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public ICollection<PrivateLessonTeacher> PrivateLessonTeachers { get; set; }
        public ICollection<TeacherAcademicYear> TeacherAcademicYears { get; set; }
        public ICollection<ClassGroup> ClassGroups { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }

}
