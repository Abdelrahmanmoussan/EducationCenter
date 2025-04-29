using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class ClassGroup
    {
        [Key]
        public int ClassGroupID { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

}
