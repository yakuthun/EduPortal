using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    //aktif
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Education, EducationDTO>().ReverseMap();
            CreateMap<Education, EducationUpdateDto>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
            CreateMap<UserAppRoleDto, UserAppRole>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<LessonDto, Lesson>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<UpdateUserDto, UserApp>().ReverseMap();
            CreateMap<UserDeleteDto, UserApp>().ReverseMap();
            CreateMap<CategoryFollowDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<NotificationDto, Notification>().ReverseMap();
            CreateMap<CourseAssignDto, CourseAssign>().ReverseMap();
            //CreateMap<GenericUpdateDto, FollowBaseEntity>().ReverseMap();
        }
    }
}
