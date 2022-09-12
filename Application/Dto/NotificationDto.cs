using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class NotificationDto
    {
        public int NotificationID { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; }
        //[Required]
        public string? UserKey { get; set; }

    }
}
