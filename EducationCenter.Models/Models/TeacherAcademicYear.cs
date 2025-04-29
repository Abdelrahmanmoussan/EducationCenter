using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class TeacherAcademicYear
    {
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }

}
