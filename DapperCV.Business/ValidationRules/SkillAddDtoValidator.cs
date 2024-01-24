using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.ValidationRules
{
    public class SkillAddDtoValidator : AbstractValidator<SkillAddDto>
    {
        public SkillAddDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Yetenek adı boş geçilemez");
        }
    }
}
