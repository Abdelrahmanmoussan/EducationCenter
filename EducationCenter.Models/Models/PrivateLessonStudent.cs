using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class PrivateLessonStudent
    {
        public int PrivateLessonID { get; set; }
        public PrivateLesson PrivateLesson { get; set; }

        [ForeignKey(nameof(Id))]
        public int Id { get; set; }
        public Student Student { get; set; }
    }

}
