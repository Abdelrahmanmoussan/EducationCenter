using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Lecture
    {
        [Key]
        public int LectureID { get; set; }

        [Required]
        public int ClassGroupID { get; set; }
        public ClassGroup ClassGroup { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime LectureDate { get; set; }

        public string VideoURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? AttendanceID { get; set; }
        public Attendance Attendance { get; set; }

        public int? AssessmentID { get; set; }


        public Assessment Assessment { get; set; }
    }

}
