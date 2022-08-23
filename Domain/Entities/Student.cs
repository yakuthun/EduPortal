using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Skill { get; set; }
        public int TeamLeadID { get; set; }
        public virtual TeamLead TeamLead { get; set; }
    }
}
