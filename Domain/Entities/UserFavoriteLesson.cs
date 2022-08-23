using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserFavoriteLesson
    {
        [Key]
        public int UserFavoriteLessonID { get; set; }
        public bool? IsFavorited { get; set; }
        //
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int LessonID { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
