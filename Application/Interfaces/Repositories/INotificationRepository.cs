using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task AddNotificationAsync(Notification entity);
        Task<Notification> GetNotification(string id);
        Task<IEnumerable<Notification>> GetNotifications();
    }
}
