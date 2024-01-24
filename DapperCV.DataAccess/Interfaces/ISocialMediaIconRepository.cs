using DapperCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DataAccess.Interfaces
{
    public interface ISocialMediaIconRepository : IGenericRepository<SocialMediaIcon>
    {
        /// <summary>
        /// kullanıcıya ait sosyal medya ikonunu bulur
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        List<SocialMediaIcon> GetByUserId(int userId);
    }
}
