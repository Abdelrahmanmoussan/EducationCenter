using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Models.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsRead { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int NotificationRecipientID { get; set; }
        public NotificationRecipient NotificationRecipient { get; set; }
    }

}
