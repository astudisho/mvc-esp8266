using ESP8266.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ESP8266.Bussines.Bussines.Interface;

namespace ESP8266_Temperature.Controllers
{
    [RoutePrefix("api/Node")]
    public class NodeController : ApiController
    {
        private readonly INode _node;

        public NodeController(INode tempHumedad)
        {
            _node = tempHumedad;
        }
		[HttpPost]
		[Route("Add")]
        public async Task<IHttpActionResult> Add(NodeModel model)
        {
            return Json(await _node.Add(model));
        }

		[HttpGet]
		[Route("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Json(await _node.GetAll());
        }
    }
}