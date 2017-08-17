using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP8266.Bussines;
using ESP8266.Database.Repository.Implementation;
using AutoMapper;

namespace ESP8266.Bussines
{
    class BaseBussines<MType, RType> where MType : class where RType : class
    {
        private readonly GenericRepository<RType> repository;

        public BaseBussines()
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(MType), typeof(RType)));
        }

        public async Task<MType> Add(MType model)
        {
            var result = (MType)Activator.CreateInstance(typeof(MType));

            try
            {
                var resultRepo = await repository.Add(Mapper.Map<MType, RType>(model));

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
