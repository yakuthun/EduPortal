using Application.Dto;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Education> _service;

        public EducationController(IService<Education> service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var educations = await _service.GetAllAsync();
            var educationsDTOs = _mapper.Map<List<EducationDTO>>(educations.ToList());
            //return Ok(CustomResponseDto<List<EducationDTO>>.Success(200, educationsDTOs));
            return CreateActionResult(CustomResponseDto<List<EducationDTO>>.Success(200, educationsDTOs));
        }
        [ServiceFilter(typeof(NotFoundFilter<Education>))]//notfound filter eklendi
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var education = await _service.GetByIdAsync(id);
            var educationsDTOs= _mapper.Map<EducationDTO>(education);
            //return Ok(CustomResponseDto<List<EducationDTO>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDto<EducationDTO>.Success(200, educationsDTOs));
        }
        //Ekleme
        [HttpPost]
        public async Task<IActionResult> Save(EducationDTO productDto)
        {//_service.Addasync() bizden product istiyor biz de _mapper.Map diyerek <Education'u dönüştür.yukarıdaki productDto'yu >
            var product = await _service.AddAsync(_mapper.Map<Education>(productDto));
            var productsDto = _mapper.Map<EducationDTO>(product);
            //return Ok(CustomResponseDto<List<EducationDTO>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDto<EducationDTO>.Success(201, productsDto));//201 created anlamına gelir
        }
        //Güncelleme
        [HttpPut]
        public async Task<IActionResult> Update(EducationUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Education>(productDto));
            //geriye bir şey dönmeyeceğimiz için NoContentDto kullandık
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        //Silme api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<EducationDTO>.Success(204));
        }
    }
}
