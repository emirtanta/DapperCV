using DapperCV.Business.Concrete;
using DapperCV.Business.Interfaces;
using DapperCV.Business.ValidationRules;
using DapperCV.DataAccess.Concrete.Dapper;
using DapperCV.DataAccess.Interfaces;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.InterestDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using DapperCV.DTOS.Dtos.SocialMediaIconDtos;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.IOC.Microsoft
{
    //IDbConnection işleminde genişletme işlemi için tanımlandı
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(con => new SqlConnection(configuration.GetConnectionString("connectionMsSql")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(DpGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IAppUserRepository, DpAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            
            services.AddTransient<IValidator<CertificationAddDto>, CertificationAddDtoValidator>();
            services.AddTransient<IValidator<CertificationUpdateDto>, CertificationUpdateDtoValidator>();

            services.AddTransient<IValidator<ExprerienceAddDto>, ExprerienceAddDtoValidator>();
            services.AddTransient<IValidator<ExprerienceUpdateDto>, ExprerienceUpdateDtoValidator>();

            services.AddTransient<IValidator<EducationAddDto>, EducationAddDtoValidator>();
            services.AddTransient<IValidator<EducationUpdateDto>, EducationUpdateDtoValidator>();

            services.AddTransient<IValidator<SkillAddDto>, SkillAddDtoValidator>();
            services.AddTransient<IValidator<SkillUpdateDto>, SkillUpdateDtoValidator>();

            services.AddTransient<IValidator<InterestAddDto>, InterestAddDtoValidator>();
            services.AddTransient<IValidator<InterestUpdateDto>, InterestUpdateDtoValidator>();

            services.AddTransient<IValidator<SocialMediaIconAddDto>, SocialMediaIconAddDtoValidator>();
            services.AddTransient<IValidator<SocialMediaIconUpdateDto>, SocialMediaIconUpdateDtoValidator>();
        }
    }
}
