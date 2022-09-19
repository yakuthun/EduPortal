using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CourseAssignRepository : ICourseAssignRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<CourseAssign> _dbSet;

        public CourseAssignRepository(ApplicationDbContext context, DbSet<CourseAssign> dbSet)
        {
            _context = context;
            _dbSet = context.Set<CourseAssign>();
        }

        
        public async Task AddCourseAssignAsync(CourseAssign entity)
        {
          await  _dbSet.AddAsync(entity);
        }
    }
}
