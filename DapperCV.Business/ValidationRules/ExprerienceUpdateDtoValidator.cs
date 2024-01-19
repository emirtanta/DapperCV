using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.ValidationRules
{
    public class ExprerienceUpdateDtoValidator : AbstractValidator<ExprerienceUpdateDto>
    {
        public ExprerienceUpdateDtoValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x=>x.SubTitle).NotEmpty().WithMessage("Alt Başlık boş geçilemez");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x=>x.StartDate).NotEmpty().WithMessage("Başlangıç Tarihi boş geçilemez");
        }
    }
}
