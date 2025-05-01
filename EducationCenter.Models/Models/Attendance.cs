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
        public AttendanceStatus AttendanceStatus { get; set; } // مثلا: Present, Absent, Late

        public string Notes { get; set; }
        public int Id { get; set; }
        public Student Student { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }

}
