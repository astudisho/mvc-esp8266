using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ESP8266.Bussines.Bussines.Interface;
using ESP8266.Database.Database;
using ESP8266.Database.Repository.Interfaces;
using ESP8266.Model.Models;

namespace ESP8266.Bussines.Bussines
{
    public class Node : BaseBussines<NodeModel,t_node>, INode
    {
        private readonly INodeRepository _nodeRepo;

        public Node(INodeRepository nodeRepository) : base(nodeRepository)
        {
            _nodeRepo = nodeRepository;
        }
    }
}