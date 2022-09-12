using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mapping
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<EducationDTO, Education>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<LessonDto, Lesson>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<UpdateUserDto, UserApp>().ReverseMap();
            CreateMap<UserDeleteDto, UserApp>().ReverseMap();
            CreateMap<CategoryFollowDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<NotificationDto, Notification>().ReverseMap();
            CreateMap<CourseAssignDto, CourseAssign>().ReverseMap();
        }
    }
}