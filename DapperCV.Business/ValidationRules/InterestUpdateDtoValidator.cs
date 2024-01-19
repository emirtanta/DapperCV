using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.InterestDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.ValidationRules
{
    public class InterestUpdateDtoValidator : AbstractValidator<InterestUpdateDto>
    {
        public InterestUpdateDtoValidator()
        {
            RuleFor(x=>x.Descripiton).NotEmpty().WithMessage("Açıklama boş geçilemez");
        }
    }
}
