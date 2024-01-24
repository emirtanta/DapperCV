using AutoMapper;
using DapperCV.DTOS.Dtos.AppUserDtos;
using DapperCV.DTOS.Dtos.CertificationDtos;
using DapperCV.DTOS.Dtos.EducationDtos;
using DapperCV.DTOS.Dtos.ExprerienceDtos;
using DapperCV.DTOS.Dtos.InterestDtos;
using DapperCV.DTOS.Dtos.SkillDtos;
using DapperCV.DTOS.Dtos.SocialMediaIconDtos;
using DapperCV.Entities.Concrete;

namespace DapperCV.WebUI.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            
            //sertifikasyon
            CreateMap<Certification, CertificationListDto>().ReverseMap();
            CreateMap<Certification, CertificationAddDto>().ReverseMap();
            CreateMap<Certification, CertificationUpdateDto>().ReverseMap();

            CreateMap<Education, EducationListDto>().ReverseMap();
            CreateMap<Education, EducationAddDto>().ReverseMap();
            CreateMap<Education, EducationUpdateDto>().ReverseMap();

            CreateMap<Experience, ExperienceListDto>().ReverseMap();
            CreateMap<Experience, ExperienceAddDto>().ReverseMap();
            CreateMap<Experience, ExperienceUpdateDto>().ReverseMap();

            CreateMap<Experience, InterestListDto>().ReverseMap();
            CreateMap<Experience, InterestAddDto>().ReverseMap();
            CreateMap<Experience, InterestUpdateDto>().ReverseMap();

            CreateMap<Experience, SkillListDto>().ReverseMap();
            CreateMap<Experience, SkillAddDto>().ReverseMap();
            CreateMap<Experience, SkillUpdateDto>().ReverseMap();

            CreateMap<Experience, SocialMediaIconListDto>().ReverseMap();
            CreateMap<Experience, SocialMediaIconAddDto>().ReverseMap();
            CreateMap<Experience, SocialMediaIconUpdateDto>().ReverseMap();

        }
    }
}
