using Application.Interfaces.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<UserApp,UserAppRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public DbSet<Education> Educations { get; set; }
        //public DbSet<UserApp> UserApps { get; set; }
        //public DbSet<UserAppRole> UserAppRoles { get; set; }
        //public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserLesson> UserLessons{ get; set; }
        public DbSet<UserFavoriteLesson> UserFavoriteLessons{ get; set; }
        public DbSet<CourseAssign> CourseAssigns{ get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration dosyalarını tarar ve bulur.
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //önceki
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
