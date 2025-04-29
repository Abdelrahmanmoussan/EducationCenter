using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class SubjectAcademicYear
    {
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }

}
