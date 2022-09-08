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
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService<Category,CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepositories<Category> _genericRepository;

        public CategoryService(IUnitOfWork unitOfWork, IGenericRepositories<Category> genericRepository) : base(unitOfWork, genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<CategoryDto>> AddCategoryAsync(CategoryDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<Category>(entity);//mapleme işlemi yaptık
            entity.Description = DateTime.Now.ToString();
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<CategoryDto>(newEntity);
            return Response<CategoryDto>.Success(newDto, 200);
        }
    }
}
