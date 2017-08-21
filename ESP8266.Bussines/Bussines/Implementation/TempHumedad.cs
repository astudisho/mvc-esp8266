using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ESP8266.Model.Models;
using ESP8266.Database.Database;
using ESP8266.Database.Repository.Interfaces;
using ESP8266.Database.Repository.Implementation;
using ESP8266.Bussines.Bussines.Interface;
using System.Threading.Tasks;
using log4net;

namespace ESP8266.Bussines.Bussines.Implementation
{

	public class TempHumedad : BaseBussines<TempHumedadModel, t_temp_humedad>, ITempHumedad
    {
	    private readonly ITempHumedadRepository _tempHumedadRepository;
	    private readonly INodeRepository _nodeRepository;

	    private readonly ILog _log;
		public TempHumedad(ITempHumedadRepository tempHumedadRepository, ILog log, INodeRepository nodeRepository): base(tempHumedadRepository,log)
        {
	        _tempHumedadRepository = tempHumedadRepository;
	        _log = log;
	        _nodeRepository = nodeRepository;
        }

		public async Task<TempHumedadModel> Add(TempHumedadModel model, string chipInfo)
		{
			var result = new TempHumedadModel();
			try
			{
				var node = await _nodeRepository.Get(n => n.ChipInfo.Equals(chipInfo));

				if (node == default(t_node))
					return result;

				model.IdNode = node.IdNode;
				model.HoraFecha = DateTime.Now;

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