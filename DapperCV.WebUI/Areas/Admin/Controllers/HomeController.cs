using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IFormFile _formFile;

        public HomeController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        //kullanıcı güncelleme
        public IActionResult Index()
        {
            TempData["active"] = "bilgilerim";

            //griş yapan kullanıcının adını getirir
            var user= _appUserService.FindByNameService(User.Identity.Name);

            var appUserUpdateModel = new AppUserUpdateModel
            {
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                Id = user.Id,
                ImageUrl = user.ImageUrl,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ShortDescripiton = user.ShortDescripiton
            };

            return View(appUserUpdateModel);
        }

        [HttpPost]
        public IActionResult Index(AppUserUpdateModel model)
        {
            TempData["active"] = "bilgilerim";

            if (ModelState.IsValid) 
            {
                var updatedAppUser = _appUserService.GetByIdService(model.Id);

                //resim yükleme işlemi
                if (model.Picture!=null) 
                {
                    var imgName = Guid.NewGuid() + Path.GetExtension(model.Picture.FileName);
                    var path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imgName;
                    var stream = new FileStream(path, FileMode.Create);

                    model.Picture.CopyTo(stream);

                    updatedAppUser.ImageUrl = imgName;
                }

                updatedAppUser.FirstName = model.FirstName;
                updatedAppUser.LastName = model.LastName;
                updatedAppUser.PhoneNumber = model.PhoneNumber;
                updatedAppUser.ShortDescripiton= model.ShortDescripiton;
                updatedAppUser.Address = model.Address;
                updatedAppUser.Email = model.Email;

                _appUserService.UpdateService(updatedAppUser);

                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
            }

            return RedirectToAction("Index");
        }

        public IActionResult ChangePassword()
        {
            var user = _appUserService.FindByNameService(User.Identity.Name);


            TempData["active"] = "sifre";

            return View(new AppUserPasswordDto { Id=user.Id});
        }

        [HttpPost]
        public IActionResult ChangePassword(AppUserPasswordDto model)
        {

            if (ModelState.IsValid)
            {
                var updatedUser = _appUserService.FindByNameService(User.Identity.Name);
                updatedUser.Password = model.Password;

                _appUserService.UpdateService(updatedUser);

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }



            TempData["active"] = "sifre";
            return View();
        }
    }
}
