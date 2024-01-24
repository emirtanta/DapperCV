using Dapper;
using DapperCV.DataAccess.Interfaces;
using DapperCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DataAccess.Concrete.Dapper
{
    public class DpAppUserRepository:DpGenericRepository<AppUser>,IAppUserRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpAppUserRepository(IDbConnection dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool CheckUser(string userName, string password)
        {
            var user = _dbConnection.QueryFirstOrDefault<AppUser>("select * from AppUsers where UserName=@userName and Password=@password", new { userName=userName,password=password});

            return user != null;
        }

        public AppUser FindByName(string userName)
        {
            return _dbConnection.QueryFirstOrDefault<AppUser>("Select * from AppUsers where=@userName", new
            {
                userName = userName
            });
        }
    }
}
