using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } // Unique code

        [Required]
        [MaxLength(20)]
        public string SubscriptionStatus { get; set; } // مثلا: Active, Expired

        [Required]
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }

}
