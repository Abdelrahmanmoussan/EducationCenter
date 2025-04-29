using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [Required]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [MaxLength(20)]
        public string PaymentMethod { get; set; } // مثلا: Cash, Visa

        public string Notes { get; set; }

        public decimal PlatformPercentage { get; set; }
        public decimal NetAmountForTeacher { get; set; }

        [MaxLength(20)]
        public string PaymentStatus { get; set; } // مثلا: Paid, Pending
    }

}
