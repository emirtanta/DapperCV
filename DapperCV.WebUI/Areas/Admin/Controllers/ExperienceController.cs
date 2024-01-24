using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        private readonly IGenericService<Experience> _experienceService;
        private readonly IMapper _mapper;

        public ExperienceController(IGenericService<Experience> experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "deneyim"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            return View(_mapper.Map<List<ExperienceListDto>>(_experienceService.GetAllService()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            TempData["active"] = "egitim"; //ilgili butona tıklayınca tıklanan yeri aktif eder



            return View(new ExperienceAddDto());
        }

        [HttpPost]
        public IActionResult Add(ExperienceAddDto model)
        {
            TempData["active"] = "deneyim"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                _experienceService.InsertService(_mapper.Map<Experience>(model));

                TempData["message"] = "Deneyim eklendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TempData["active"] = "deneyim"; //ilgili butona tıklayınca tıklanan yeri aktif eder


            return View(_mapper.Map<ExperienceUpdateDto>(_experienceService.GetByIdService(id)));
        }

        [HttpPost]
        public IActionResult Update(ExperienceUpdateDto model)
        {
            TempData["active"] = "egitim"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                var updatedExperience = _experienceService.GetByIdService(model.Id);
                updatedExperience.Title = model.Title;
                updatedExperience.SubTitle = model.SubTitle;
                updatedExperience.StartDate = model.StartDate;
                updatedExperience.EndDate = model.EndDate;
                updatedExperience.Description = model.Description;

                _experienceService.UpdateService(updatedExperience);

                TempData["message"] = "Deneyim güncellendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "deneyim"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            var deletedEntity = _experienceService.GetByIdService(id);
            _experienceService.DeleteService(deletedEntity);

            TempData["message"] = "Deneyim silindi";

            return RedirectToAction("Index");
        }
    }
}
