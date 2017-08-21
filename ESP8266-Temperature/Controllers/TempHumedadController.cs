using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ESP8266.Bussines.Bussines.Interface;
using ESP8266.Model.Models;

namespace ESP8266_Temperature.Controllers
{
	[RoutePrefix("api/TempHumedad")]
	public class TempHumedadController : ApiController
	{
		private readonly ITempHumedad _tempHumedad;
		public TempHumedadController(ITempHumedad tempHumedad)
		{
			_tempHumedad = tempHumedad;
		}

		[HttpGet]
		[Route("GetAll")]
		public async Task<IHttpActionResult> GetAll()
		{
			return Json(await _tempHumedad.GetAll());
		}

		[HttpPost]
		[Route("Add")]
		public async Task<IHttpActionResult> Add(TempHumedadAddModel model)
		{
			return Json(await _tempHumedad.Add(model, model.ChipInfo));
		}
	}
}