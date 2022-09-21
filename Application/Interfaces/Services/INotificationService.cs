using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface INotificationService
    {//verilerin girişi
        Task<Response<NotificationDto>> AddNotificationAsync(string message,string userkey);
        Task<Response<NotificationDto>> GetNotification(string id);
        Task<Response<IEnumerable<NotificationDto>>> GetNotifications();
    }
}
