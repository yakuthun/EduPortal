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
        }
    }
}