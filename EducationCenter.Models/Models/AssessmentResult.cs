using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class AssessmentResult
    {
        [Key]
        public int AssessmentResultID { get; set; }

        [Required]
        public int AssessmentID { get; set; }
        public Assessment Assessment { get; set; }

        [Required]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [Required]
        public int Score { get; set; }

        public string Feedback { get; set; }
    }

}
