using DapperCV.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.Business.Interfaces
{
    public interface IGenericService<TEntity>where TEntity : class,ITable,new()
    {
        /// <summary>
        /// dataları liste şeklinde getirir
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAllService();

        /// <summary>
        /// id değerine göre bir adet veri getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetByIdService(int id);

        /// <summary>
        /// veriyi veritabanına ekler
        /// </summary>
        /// <param name="entity"></param>
        void InsertService(TEntity entity);

        /// <summary>
        /// veriyi günceller
        /// </summary>
        /// <param name="entity"></param>
        void UpdateService(TEntity entity);

        /// <summary>
        /// veriyi siler
        /// </summary>
        /// <param name="entity"></param>
        void DeleteService(TEntity entity);
    }
}
