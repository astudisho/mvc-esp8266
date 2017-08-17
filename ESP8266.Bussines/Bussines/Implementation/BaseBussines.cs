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
    public class BaseBussines<MType, RType> where MType : class 
                                            where RType : class
    {
        private readonly IGenericRepository<RType> _repository;

        public BaseBussines(IGenericRepository<RType> repository)
        {
            _repository = repository;

            Mapper.Initialize(cfg => {
                cfg.CreateMap(typeof(MType), typeof(RType));
                cfg.CreateMap(typeof(RType), typeof(MType));
            });
        }

        public async Task<MType> Add(MType model)
        {
            var result = (MType)Activator.CreateInstance(typeof(MType));

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
    }
}
