using DapperCV.DTOS.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.ValidationRules
{
    public class AppUserUpdateDtoValidator:AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).InclusiveBetween(1,int.MaxValue).WithMessage("Id boş geçilemez");
        }
    }
}
