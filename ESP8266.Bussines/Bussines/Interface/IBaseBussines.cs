using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;

namespace ESP8266.Bussines.Bussines.Interface
{
    public interface IBaseBussines<TType> where TType : class
    {
        Task<TType> Add(TType model);
        Task<bool> Update(TType model);
        Task<bool> Delete(TType model);
        Task<TType> GetById(int id);
        Task<IEnumerable<TType>> GetAll();
    }
}