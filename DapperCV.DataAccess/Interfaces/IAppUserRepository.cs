using DapperCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DataAccess.Interfaces
{
    public interface IAppUserRepository:IGenericRepository<AppUser>
    {
        /// <summary>
        /// eğer kullanıcı varsa true yoksa false döner
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CheckUser(string userName, string password);
    }
}
