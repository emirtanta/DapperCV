using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.InterestDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class InterestController : Controller
    {
        private readonly  IGenericService<Interest> _interestService;
        private readonly  IMapper _mapper;


        public InterestController(IGenericService<Interest> interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "hobi"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            return View(_mapper.Map<List<InterestListDto>>(_interestService.GetAllService()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            TempData["active"] = "hobi"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            

            return View(new InterestAddDto());
        }

        [HttpPost]
        public IActionResult Add(InterestAddDto model)
        {
            TempData["active"] = "hobi"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                _interestService.InsertService(_mapper.Map<Interest>(model));

                TempData["message"] = "Hobi alanı eklendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TempData["active"] = "hobi"; //ilgili butona tıklayınca tıklanan yeri aktif eder


            return View(_mapper.Map<InterestUpdateDto>(_interestService.GetByIdService(id)));
        }

        [HttpPost]
        public IActionResult Update(InterestUpdateDto model)
        {
            TempData["active"] = "hobi"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            if (ModelState.IsValid)
            {
                var updatedCertification = _interestService.GetByIdService(model.Id);
                updatedCertification.Descripiton = model.Name;

                _interestService.UpdateService(updatedCertification);

                TempData["message"] = "Hobi alanı güncellendi";

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "hobi"; //ilgili butona tıklayınca tıklanan yeri aktif eder

            var deletedEntity = _interestService.GetByIdService(id);
            _interestService.DeleteService(deletedEntity);

            TempData["message"] = "Hobi alanı silindi";

            return RedirectToAction("Index");
        }
    }
}
