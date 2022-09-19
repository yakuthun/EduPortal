using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICourseAssignService
    {
        Task<Response<CourseAssignDto>> AddCourseAssignAsync(CourseAssignDto courseAssignDto);
    }
}
