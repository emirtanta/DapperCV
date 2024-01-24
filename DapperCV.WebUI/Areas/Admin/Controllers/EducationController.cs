using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class EducationController : Controller
    {
        private readonly IGenericService<Education> _educationService;
        private readonly IMapper _mapper;

        public EducationController(IGenericService<Education> educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "sertifika"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            return View(_mapper.Map<List<EducationListDto>>(_educationService.GetAllService()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            TempData["active"] = "egitim"; //ilgili butona tıklayınca tıklanan yeri aktif eder



            return View(new EducationAddDto());
        }

        [HttpPost]
        public IActionResult Add(EducationAddDto model)
        {
            TempData["active"] = "egitim"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                _educationService.InsertService(_mapper.Map<Education>(model));

                TempData["message"] = "Eğitim eklendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TempData["active"] = "egitim"; //ilgili butona tıklayınca tıklanan yeri aktif eder


            return View(_mapper.Map<EducationUpdateDto>(_educationService.GetByIdService(id)));
        }

        [HttpPost]
        public IActionResult Update(EducationUpdateDto model)
        {
            TempData["active"] = "egitim"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                var updatedEducation = _educationService.GetByIdService(model.Id);
                updatedEducation.Title = model.Title;
                updatedEducation.SubTitle = model.SubTitle;
                updatedEducation.StartDate = model.StartDate;
                updatedEducation.EndDate = model.EndDate;
                updatedEducation.Description = model.Description;

                _educationService.UpdateService(updatedEducation);

                TempData["message"] = "Eğitim güncellendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "egitim"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            var deletedEntity = _educationService.GetByIdService(id);
            _educationService.DeleteService(deletedEntity);

            TempData["message"] = "Eğitim silindi";

            return RedirectToAction("Index");
        }
    }
}
