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
    public class CertificationAddDtoValidator : AbstractValidator<CertificationAddDto>
    {
        public CertificationAddDtoValidator()
        {
            RuleFor(x=>x.Descripiton).NotEmpty().WithMessage("Açıklama boş geçilemez");
        }
    }
}
