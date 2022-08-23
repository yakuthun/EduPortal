    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course:FollowBaseEntity
    {
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }

        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }


        //public bool? IsDeleted { get; set; } 
        //public DateTime? DeletedDate { get; set; }

        public virtual Category Category { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
   
    }
}
