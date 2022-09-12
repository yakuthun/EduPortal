using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CourseAssignDto
    {
        public int CourseAssignID { get; set; }
        public string AssignKey { get; set; }
        public string TeamLeadKey { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFinish { get; set; }
        public int? CourseID { get; set; }
    }
}
