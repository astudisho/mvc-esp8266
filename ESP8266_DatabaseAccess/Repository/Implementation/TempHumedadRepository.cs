using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP8266_DatabaseAccess.Database;
using ESP8266_DatabaseAccess.Repository.Interfaces;

namespace ESP8266_DatabaseAccess.Repository.Implementation
{
    class TempHumedadRepository : GenericRepository<t_temp_humedad> ,ITempHumedadRepository
    {
        public TempHumedadRepository(esp8266Entities dbContext) : base (dbContext)
        {
        }        
    }
}
