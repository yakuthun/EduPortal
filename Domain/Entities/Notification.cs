using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
