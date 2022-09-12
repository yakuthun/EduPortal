﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string EMailConfirmed { get; set; }
        public string Password { get; set; }
        public int LessonsCount { get; set; }
        public string Skills { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<UserLesson> UserLessons { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        //
        public ICollection<UserFavoriteLesson> UserFavoriteLessons { get; set; }
        //public ICollection<Notification> Notifications { get; set; }

    }
}
