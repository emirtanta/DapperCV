using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.ViewComponents
{
    public class CertificationComponent : ViewComponent
    {

        private readonly IGenericService<Certification> _certificationService;
        private readonly IMapper _mapper;

        public CertificationComponent(IGenericService<Certification> certificationService, IMapper mapper)
        {
            _certificationService = certificationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<CertificationListDto>(_certificationService.GetAllService()));
        }
    }
}
