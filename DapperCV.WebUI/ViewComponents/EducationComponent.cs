using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.ViewComponents
{
    public class EducationComponent : ViewComponent
    {

        private readonly IGenericService<Education> _educationService;
        private readonly IMapper _mapper;

        public EducationComponent(IGenericService<Education> educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<EducationListDto>(_educationService.GetAllService()));
        }
    }
}
