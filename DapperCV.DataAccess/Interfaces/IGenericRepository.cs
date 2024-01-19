using DapperCV.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCV.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class,ITable,new()
    {
        /// <summary>
        /// dataları liste şeklinde getirir
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAll();

        /// <summary>
        /// id değerine göre bir adet veri getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// veriyi veritabanına ekler
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);  
        
        /// <summary>
        /// veriyi günceller
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        
        /// <summary>
        /// veriyi siler
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);    
    }
}
