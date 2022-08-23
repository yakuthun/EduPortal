using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TeamLead
    {
        [Key]
        public int TeamLeadID { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
