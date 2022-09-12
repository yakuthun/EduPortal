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
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<Notification> _dbSet;

        public NotificationRepository(ApplicationDbContext context, DbSet<Notification> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public Task AddAsync(Notification entity)
        {
            throw new NotImplementedException();
        }

        public async Task AddNotificationAsync(Notification entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task<IEnumerable<Notification>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Notification SoftDelete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Notification Update(Notification entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Notification> Where(Expression<Func<Notification, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
