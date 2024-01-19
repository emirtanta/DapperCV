using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.CertificationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.ValidationRules
{
    public class CertificationUpdateDtoValidator : AbstractValidator<CertificationUpdateDto>
    {
        public CertificationUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id boş geçilemez");
            RuleFor(x=>x.Descripiton).NotEmpty().WithMessage("Açıklama boş geçilemez");
        }
    }
}
