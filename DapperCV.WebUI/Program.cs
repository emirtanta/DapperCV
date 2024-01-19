using DapperCV.Business.Concrete;
using DapperCV.Business.Interfaces;
using DapperCV.Business.IOC.Microsoft;
using DapperCV.Business.ValidationRules;
using DapperCV.DataAccess.Concrete.Dapper;
using DapperCV.DataAccess.Interfaces;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.InterestDtos;
using DapperCV.DTOS.Dtos.SkillDtos;

using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();

MicrosoftDependencies.AddCustomDependencies(builder.Services, builder.Configuration);

//cookie ayarlar�
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => 
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.Name = "CVCookie"; //taray�c�da g�z�kecek cookie ad�
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; //hem http hem de https'de �al��mas�n� sa�lar
    opt.ExpireTimeSpan = TimeSpan.FromDays(1); //cookie'nin ya�am s�resi �rne�in 1 g�n
    opt.LoginPath = new PathString("/Auth/Login"); //yetkisiz sayfalarda y�nlendirilecek adres
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//area tan�mlamas� 
app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
