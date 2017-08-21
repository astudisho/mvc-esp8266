using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using ESP8266.Bussines.Bussines.Interface;
using ESP8266.Database.Database;
using ESP8266.Model.Models;
using ESP8266.Database.Repository.Interfaces;
using log4net;
using AutoMapper;

namespace ESP8266.Bussines.Bussines.Implementation
{
    public class Node : BaseBussines<NodeModel,t_node> , INode
    {
	    private readonly INodeRepository _nodeRepository;
	    private readonly ILog _log;

        public Node(INodeRepository nodeRepository, ILog log) : base(nodeRepository, log)
        {
	        _log = log;
	        _nodeRepository = nodeRepository;
        }

	    public new async Task<NodeModel> Add(NodeModel model)
	    {
			var result = new NodeModel();
		    try
		    {
			    if (_nodeRepository.GetQueryable().Any(n => n.ChipInfo.Equals(model.ChipInfo) && n.FlashInfo.Equals(model.ChipInfo)))
			    {
				    var mapped = Mapper.Map<t_node, NodeModel>( _nodeRepository.GetQueryable().First(n => n.ChipInfo.Equals(model.ChipInfo) && n.FlashInfo.Equals(model.ChipInfo)));

				    return mapped;
			    }

				model.Guid = Guid.NewGuid().ToString();

				  result = await base.Add(model);
		    }
		    catch (Exception e)
		    {
			    _log.Error(e);
			    throw;
		    }

		    return result;
	    }

    }
}