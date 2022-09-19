﻿using Application.Dto;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using AutoMapper.Internal.Mappers;
using Domain.Entities;
using Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork, INotificationRepository notificationRepository)
        {
            _unitOfWork = unitOfWork;
            _notificationRepository = notificationRepository;
        }

        public async Task<Response<NotificationDto>> AddNotificationAsync(string message,string userkey)
        {
            NotificationDto entity = new NotificationDto();
            var newEntity = ObjectMapper.Mapper.Map<Notification>(entity);
            newEntity.Message = message;
            newEntity.UserKey = userkey;
            newEntity.CreatedDate = DateTime.Now;
            await _notificationRepository.AddNotificationAsync(newEntity);
            await _unitOfWork.CommitAsync();
            return Response<NotificationDto>.Success(200);
        }
    }
}
