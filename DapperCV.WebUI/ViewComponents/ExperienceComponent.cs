using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.ViewComponents
{
    public class ExperienceComponent : ViewComponent
    {
        private readonly IGenericService<Experience> _experienceService;
        private readonly IMapper _mapper;

        public ExperienceComponent(IGenericService<Experience> experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<ExperienceListDto>(_experienceService.GetAllService()));
        }
    }
}
