using DapperCV.Business.Interfaces;
using DapperCV.DataAccess.Interfaces;
using DapperCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericRepository<AppUser> _genericRepository;
        private readonly IAppUserRepository _appUseerRepository;

        public AppUserManager(IGenericRepository<AppUser> genericRepository, IAppUserRepository appUseerRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _appUseerRepository = appUseerRepository;
        }
        public bool CheckUserService(string userName, string password)
        {
            return _appUseerRepository.CheckUser(userName,password);
        }

        public AppUser FindByNameService(string userName)
        {
            return _appUseerRepository.FindByName(userName);
        }
    }
}
