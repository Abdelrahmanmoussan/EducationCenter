using EducationCenter.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [Required]
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        [Required]
        [MaxLength(20)]
        public AttendanceStatus AttendanceStatus { get; set; } // مثلا: Present, Absent, Late

        public string Notes { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }

}
