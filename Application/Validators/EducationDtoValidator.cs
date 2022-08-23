using Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class EducationDtoValidator:AbstractValidator<EducationDTO>
    {
        public EducationDtoValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithErrorCode("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
