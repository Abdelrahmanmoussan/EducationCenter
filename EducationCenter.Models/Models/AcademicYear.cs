using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class AcademicYear
    {
        [Key]
        public int AcademicYearID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<TeacherAcademicYear> TeacherAcademicYears { get; set; }
        public ICollection<SubjectAcademicYear> SubjectAcademicYears { get; set; }
    }

}
