using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseAssign:FollowBaseEntity
    {
        [Key]
        public int CourseAssignID { get; set; }
        public string AssignKey { get; set; }
        public string TeamLeadKey { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFinish { get; set; }
        public int? CourseID { get; set; }
        public Course Course { get; set; }
    }
}
