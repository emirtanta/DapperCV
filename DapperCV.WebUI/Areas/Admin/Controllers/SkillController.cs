using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SkillController : Controller
    {
        private readonly IGenericService<Skill> _skillService;
        private readonly IMapper _mapper;

        public SkillController(IGenericService<Skill> skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "beceri"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            return View(_mapper.Map<List<SkillListDto>>(_skillService.GetAllService()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            TempData["active"] = "beceri"; //ilgili butona tıklayınca tıklanan yeri aktif eder



            return View(new SkillAddDto());
        }

        [HttpPost]
        public IActionResult Add(SkillAddDto model)
        {
            TempData["active"] = "beceri"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                _skillService.InsertService(_mapper.Map<Skill>(model));

                TempData["message"] = "Yetenek eklendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TempData["active"] = "beceri"; //ilgili butona tıklayınca tıklanan yeri aktif eder


            return View(_mapper.Map<SkillUpdateDto>(_skillService.GetByIdService(id)));
        }

        [HttpPost]
        public IActionResult Update(SkillUpdateDto model)
        {
            TempData["active"] = "beceri"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                var updatedSkill = _skillService.GetByIdService(model.Id);
                updatedSkill.Name = model.Name;

                _skillService.UpdateService(updatedSkill);

                TempData["message"] = "Yetenek güncellendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "beceri"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            var deletedEntity = _skillService.GetByIdService(id);
            _skillService.DeleteService(deletedEntity);

            TempData["message"] = "Yetenek silindi";

            return RedirectToAction("Index");
        }
    }
}
