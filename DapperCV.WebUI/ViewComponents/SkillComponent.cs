using AutoMapper;
using DapperCV.Business.Interfaces;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using DapperCV.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.ViewComponents
{
    public class SkillComponent : ViewComponent
    {
        private readonly IGenericService<Skill> _skillService;
        private readonly IMapper _mapper;

        public SkillComponent(IGenericService<Skill> skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<SkillListDto>(_skillService.GetAllService()));
        }
    }
}
