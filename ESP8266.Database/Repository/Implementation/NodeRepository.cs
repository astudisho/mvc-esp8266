using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP8266.Database.Database;
using ESP8266.Database.Repository.Interfaces;
using ESP8266.Database.Repository.Implementation;

namespace ESP8266.Database.Repository.Implementation
{
    public class NodeRepository : GenericRepository<t_node> ,INodeRepository
    {
        public NodeRepository(esp8266Entities dbContext) : base(dbContext)
        {

        }
    }
}
