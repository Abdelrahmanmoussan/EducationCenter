using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class NotificationRecipient
    {
        [Key]
        public int NotificationRecipientID { get; set; }

        [Required]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public bool DeliveryByGmail { get; set; }
        public bool IsDelivered { get; set; }
    }

}
