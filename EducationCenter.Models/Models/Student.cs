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
    public class Student
    {
        [Key]
        public int Id { get; set; }  // مفتاح أساسي مستقل

        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int? AcademicYearID { get; set; }
        public AcademicYear? AcademicYear { get; set; }

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

        public ICollection<PrivateLessonStudent> PrivateLessonStudents { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<AssessmentResult> AssessmentResults { get; set; }
    }


}
