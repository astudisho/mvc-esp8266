using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ESP8266.Bussines.Bussines.Interface;
using ESP8266.Database.Database;
using ESP8266.Model.Models;
using ESP8266.Database.Repository.Interfaces;

namespace ESP8266.Bussines.Bussines.Implementation
{
    public class Node : BaseBussines<NodeModel,t_node> , INode
  
    {
        public Node(INodeRepository nodeRepository) : base(nodeRepository)
        {
            
        }
    }
}