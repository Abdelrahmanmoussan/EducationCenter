using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        //[Required]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        //[Required]
        public int ClassGroupID { get; set; }
        public ClassGroup ClassGroup { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string EnrollmentStatus { get; set; } // مثلا: Active, Cancelled

        public string Notes { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }

}
