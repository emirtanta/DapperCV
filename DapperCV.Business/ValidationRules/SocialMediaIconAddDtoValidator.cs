using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.InterestDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using DapperCV.DTOS.Dtos.SocialMediaIconDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.ValidationRules
{
    public class SocialMediaIconAddDtoValidator : AbstractValidator<SocialMediaIconAddDto>
    {
        public SocialMediaIconAddDtoValidator()
        {
            RuleFor(x=>x.Link).NotEmpty().WithMessage("Link boş geçilemez");
            RuleFor(x=>x.Icon).NotEmpty().WithMessage("İkon boş geçilemez");
        }
    }
}
