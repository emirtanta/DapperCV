using DapperCV.Business.Interfaces;
using DapperCV.DataAccess.Concrete.Dapper;
using DapperCV.DataAccess.Interfaces;
using DapperCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.Concrete
{
    public class SocialMediaIconManager : GenericManager<SocialMediaIcon>, ISocialMediaIconService
    {
        private readonly IGenericRepository<SocialMediaIcon> _genericRepository;
        private readonly ISocialMediaIconRepository _socialMediaIconRepository;

        public SocialMediaIconManager(IGenericRepository<SocialMediaIcon> genericRepository, ISocialMediaIconRepository socialMediaIconRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _socialMediaIconRepository = socialMediaIconRepository;
        }

        public List<SocialMediaIcon> GetByUserIdService(int userId)
        {
            return _socialMediaIconRepository.GetByUserId(userId);
        }
    }
}
