using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP8266_Database.Database;
using ESP8266_Database.Repository.Interfaces;
using ESP8266_Database.Repository.Implementation;

namespace ESP8266_Database.Repository.Implementation
{
    class NodeRepository : GenericRepository<t_node> ,INodeRepository
    {
        public NodeRepository(esp8266Entities dbContext) : base(dbContext)
        {

        }
    }
}
