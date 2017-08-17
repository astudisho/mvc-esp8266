using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ESP8266.Model.Models;
using ESP8266.Database.Database;
using ESP8266.Database.Repository.Interfaces;
using ESP8266.Database.Repository.Implementation;
using ESP8266.Bussines.Bussines.Interface;

namespace ESP8266.Bussines.Bussines.Implementation
{
    public class TempHumedad : BaseBussines<TempHumedadModel, t_temp_humedad>
    {
        public TempHumedad(IGenericRepository<t_temp_humedad> repository) : base(repository)
        {
            
        }
    }
}