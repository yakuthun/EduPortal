using Application.Dto;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using AutoMapper.Internal.Mappers;
using Domain.Entities;
using Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CourseAssignService : ICourseAssignService
    {
        private readonly ICourseAssignRepository _courseAssignRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CourseAssignService(ICourseAssignRepository courseAssignRepository, IUnitOfWork unitOfWork)
        {
            _courseAssignRepository = courseAssignRepository;
            _unitOfWork = unitOfWork;
        }

      
        public async Task<Response<CourseAssignDto>> AddCourseAssignAsync(CourseAssignDto courseAssignDto)
        {

            var newEntity = ObjectMapper.Mapper.Map<CourseAssign>(courseAssignDto);//mapleme işlemi yaptık
            //ent.CreatedDate = DateTime.Now;
            await _courseAssignRepository.AddCourseAssignAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<CourseAssignDto>(newEntity);
            return Response<CourseAssignDto>.Success(newDto, 200);
        }
    }
}
