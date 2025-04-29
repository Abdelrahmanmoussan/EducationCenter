using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<SubjectAcademicYear> SubjectAcademicYears { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }

}
