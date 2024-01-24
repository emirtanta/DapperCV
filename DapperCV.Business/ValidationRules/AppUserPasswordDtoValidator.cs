using DapperCV.DTOS.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.ValidationRules
{
    public class AppUserPasswordDtoValidator:AbstractValidator<AppUserPasswordDto>
    {
        public AppUserPasswordDtoValidator()
        {
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Parola tekrar boş geçilemez");
            RuleFor(x=>x.ConfirmPassword).Equal(x=>x.Password).WithMessage("Parolalar uyuşmuyor");
        }
    }
}
