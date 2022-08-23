using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson:FollowBaseEntity
    {
        [Key]
        public int LessonID { get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public string VideoUrl{ get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public ICollection<UserFavoriteLesson> UserFavoriteLessons { get; set; }
    }
}
