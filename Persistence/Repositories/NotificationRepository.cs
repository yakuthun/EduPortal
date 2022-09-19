using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Notification> _dbSet;
        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Notification>();
        }


        public async Task AddNotificationAsync(Notification entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}
