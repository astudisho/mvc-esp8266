using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESP8266.Database.Repository.Interfaces
{
    public interface IGenericRepository<TType>
    {
        Task<TType> Add(TType entity);
        Task Add(IEnumerable<TType> entities);
        Task<bool> Update(TType entity);
        Task<bool> Delete(TType entity);
        Task<bool> Delete(Expression<Func<TType, bool>> filter);
        Task<TType> Get(Expression<Func<TType, bool>> filter);
        Task<IList<TType>> GetAny(Expression<Func<TType, bool>> filter);
        IList<TType> GetAnyNotAsync(Expression<Func<TType, bool>> filter);
        Task<IEnumerable<TType>> GetAll();
        IQueryable<TType> GetQueryable();
    }
}
