using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.DTOs.Response
{
    public class StudentRegisterResponseDTO
    {
        public string Message { get; set; }
        public string StudentFullName { get; set; }
        public int StudentId { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public int AcademicYearID { get; set; }
    }
}
