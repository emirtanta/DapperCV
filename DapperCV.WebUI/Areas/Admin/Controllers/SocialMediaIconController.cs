using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.SocialMediaIconDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SocialMediaIconController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ISocialMediaIconService _socialMediaIconService;
        private readonly IMapper _mapper;

        public SocialMediaIconController(IAppUserService appUserService, ISocialMediaIconService socialMediaIconService,IMapper mapper)
        {
            _appUserService = appUserService;
            _socialMediaIconService = socialMediaIconService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "ikon"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            var user= _appUserService.FindByNameService(User.Identity.Name);

            return View(_mapper.Map<List<SocialMediaIconListDto>>(_socialMediaIconService.GetByIdService(user.Id)));
        }

        [HttpGet]
        public IActionResult Add()
        {
            TempData["active"] = "ikon"; //ilgili butona tıklayınca tıklanan yeri aktif eder



            return View(new SocialMediaIconAddDto());
        }

        [HttpPost]
        public IActionResult Add(SocialMediaIconAddDto model)
        {
            TempData["active"] = "ikon"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                var user = _appUserService.FindByNameService(User.Identity.Name);
                model.AppUserId = user.Id;

                _socialMediaIconService.InsertService(_mapper.Map<SocialMediaIcon>(model));

                TempData["message"] = "Sosyal Medya eklendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TempData["active"] = "ikon"; //ilgili butona tıklayınca tıklanan yeri aktif eder


            return View(_mapper.Map<SocialMediaIconUpdateDto>(_socialMediaIconService.GetByIdService(id)));
        }

        [HttpPost]
        public IActionResult Update(SocialMediaIconUpdateDto model)
        {
            TempData["active"] = "ikon"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                var user = _appUserService.FindByNameService(User.Identity.Name);

                var updatedSocialMediaIcon = _socialMediaIconService.GetByIdService(model.Id);
                updatedSocialMediaIcon.AppUserId = user.Id;
                updatedSocialMediaIcon.Link = model.Link;
                updatedSocialMediaIcon.Icon = model.Icon;

                _socialMediaIconService.UpdateService(updatedSocialMediaIcon);

                TempData["message"] = "Sosyal medya güncellendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "ikon"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            var deletedEntity = _socialMediaIconService.GetByIdService(id);
            _socialMediaIconService.DeleteService(deletedEntity);

            TempData["message"] = "Sosyal medya silindi";

            return RedirectToAction("Index");
        }
    }
}
