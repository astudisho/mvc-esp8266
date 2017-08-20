using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP8266.Bussines;
using ESP8266.Database.Repository.Implementation;
using ESP8266.Database.Repository.Interfaces;
using ESP8266.Bussines.Bussines.Interface;
using AutoMapper;

namespace ESP8266.Bussines
{
    public class BaseBussines<MType, RType> : IBaseBussines<MType> 
        where MType : class 
        where RType : class

    {
    private readonly IGenericRepository<RType> _repository;

    public BaseBussines(IGenericRepository<RType> repository)
    {
        _repository = repository;

        Mapper.Initialize(cfg =>
        {
            cfg.CreateMap(typeof(MType), typeof(RType));
            cfg.CreateMap(typeof(RType), typeof(MType));
        });
    }

    public async Task<MType> Add(MType model)
    {
        var result = (MType) Activator.CreateInstance(typeof(MType));

        try
        {
            var toAdd = (Mapper.Map<MType, RType>(model));
            var resultRepo = await _repository.Add(toAdd);

            result = Mapper.Map<RType, MType>(resultRepo);
        }
        catch (Exception e)
        {
            throw;
        }

        return result;
    }

        public Task<bool> Delete(MType model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MType>> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();
                return Mapper.Map<IEnumerable<RType>, IEnumerable<MType>>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<MType> GetById(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> Update(MType model)
        {
            //var result = (MType)Activator.CreateInstance(typeof(MType));
            try
            {
                var toUpdate = Mapper.Map<MType,RType>(model);
                var result = await _repository.Update(toUpdate);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
