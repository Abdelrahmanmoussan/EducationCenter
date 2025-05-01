using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class PrivateLesson
    {
        [Key]
        public int PrivateLessonID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public ICollection<PrivateLessonTeacher> PrivateLessonTeachers { get; set; }
        public ICollection<PrivateLessonStudent> PrivateLessonStudents { get; set; }
        public ICollection<PrivateLessonStudent> Students { get; set; }
    }

}
