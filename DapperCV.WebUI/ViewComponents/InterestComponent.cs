using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.InterestDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.ViewComponents
{
    public class InterestComponent : ViewComponent
    {
        private readonly IGenericService<Interest> _interestService;
        private readonly IMapper _mapper;

        public InterestComponent(IGenericService<Interest> interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<InterestListDto>(_interestService.GetAllService()));
        }
    }
}
