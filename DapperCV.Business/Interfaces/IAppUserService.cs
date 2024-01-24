using DapperCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.Interfaces
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        /// <summary>
        /// eğer kullanıcı varsa true yoksa false döner
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CheckUserService(string userName, string password);

        /// <summary>
        /// kullanıcıyı isme göre arar
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        AppUser FindByNameService(string userName);
    }
}
