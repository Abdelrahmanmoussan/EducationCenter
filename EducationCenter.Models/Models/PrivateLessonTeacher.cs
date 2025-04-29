using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class PrivateLessonTeacher
    {
        public int PrivateLessonID { get; set; }
        public PrivateLesson PrivateLesson { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }

}
