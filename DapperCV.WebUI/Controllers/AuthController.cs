using DapperCV.Business.Interfaces;
using DapperCV.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DapperCV.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AuthController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Login()
        {
            return View(new AppUserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (_appUserService.CheckUserService(model.UserName,model.Password))
                {
                    //giriş başarılı

                    var claims = new List<Claim> 
                    {
                        new Claim(ClaimTypes.Name,model.UserName),
                        new Claim(ClaimTypes.Role,"Admin"),
                    };

                    var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home", new { @area = "Admin" });
                }

                //giriş başarısız
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }

            return View(model);
        }
    }
}
