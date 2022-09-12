using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface INotificationService:IGenericService<Notification, NotificationDto>
    {
        Task<Response<NotificationDto>> AddAsync(NotificationDto entity);
    }
}
