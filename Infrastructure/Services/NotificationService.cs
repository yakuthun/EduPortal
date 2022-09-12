using Application.Dto;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class NotificationService:INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationRepository _notificationRepository;

        public Task<Response<NotificationDto>> AddAsync(NotificationDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<NotificationDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<NotificationDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContentDto>> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContentDto>> SoftDelete(NotificationDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContentDto>> Update(NotificationDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<NotificationDto>>> Where(Expression<Func<Notification, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
