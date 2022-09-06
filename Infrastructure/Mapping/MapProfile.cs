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
        }
    }
}
