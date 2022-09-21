using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Migrations;
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

        public async Task<Notification> GetNotification(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            var sx = _dbSet.Where(x => x.UserKey == id).ToListAsync();
            if (sx != null)
            {
                _context.Entry(entity).State = EntityState.Detached;//takip edilmesin track edilmesin
            }
            return entity;
        }

        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            return await _dbSet.ToListAsync();
        }
    }
}