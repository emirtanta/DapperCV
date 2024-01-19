using DapperCV.Business.Interfaces;
using DapperCV.DataAccess.Interfaces;
using DapperCV.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericManager(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<TEntity> GetAllService()
        {
            return _genericRepository.GetAll();
        }

        public TEntity GetByIdService(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void InsertService(TEntity entity)
        {
            _genericRepository.Insert(entity);
        }

        public void UpdateService(TEntity entity)
        {
            _genericRepository.Update(entity);
        }

        public void DeleteService(TEntity entity)
        {
            _genericRepository.Delete(entity);
        }
    }
}
