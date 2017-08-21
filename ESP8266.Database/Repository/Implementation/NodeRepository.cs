using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP8266.Database.Database;
using ESP8266.Database.Repository.Interfaces;
using ESP8266.Database.Repository.Implementation;
using log4net;

namespace ESP8266.Database.Repository.Implementation
{
    public class NodeRepository : GenericRepository<t_node> ,INodeRepository
    {
	    private readonly ILog _log;
        public NodeRepository(esp8266Entities dbContext, ILog log) : base(dbContext, log)
        {
	        _log = log;
        }
    }
}
