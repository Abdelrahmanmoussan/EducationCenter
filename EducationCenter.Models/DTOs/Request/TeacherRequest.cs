using EducationCenter.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.DTOs.Request
{
    public class TeacherRequest
    {

        [Required]
        public int SubjectID { get; set; }

        [Required]
        public int AcademicYearID { get; set; }
        
    }
}
