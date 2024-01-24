using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CertificationController : Controller
    {
        private readonly  IGenericService<Certification> _certificationService;
        private readonly  IMapper _mapper;


        public CertificationController(IGenericService<Certification> certificationService, IMapper mapper)
        {
            _certificationService = certificationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "sertifika"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            return View(_mapper.Map<List<CertificationListDto>>(_certificationService.GetAllService()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            TempData["active"] = "sertifika"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            

            return View(new CertificationAddDto());
        }

        [HttpPost]
        public IActionResult Add(CertificationAddDto model)
        {
            TempData["active"] = "sertifika"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                _certificationService.InsertService(_mapper.Map<Certification>(model));

                TempData["message"] = "Sertifika eklendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TempData["active"] = "sertifika"; //ilgili butona tıklayınca tıklanan yeri aktif eder


            return View(_mapper.Map<CertificationUpdateDto>(_certificationService.GetByIdService(id)));
        }

        [HttpPost]
        public IActionResult Update(CertificationUpdateDto model)
        {
            TempData["active"] = "sertifika"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                var updatedCertification = _certificationService.GetByIdService(model.Id);
                updatedCertification.Descripiton = model.Descripiton;

                _certificationService.UpdateService(updatedCertification);

                TempData["message"] = "Sertifika güncellendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "sertifika"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            var deletedEntity = _certificationService.GetByIdService(id);
            _certificationService.DeleteService(deletedEntity);

            TempData["message"] = "Sertifika silindi";

            return RedirectToAction("Index");
        }
    }
}
