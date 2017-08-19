using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using ESP8266.Model.Models;
using ESP8266.Bussines.Bussines.Implementation;
using ESP8266.Database.Repository.Implementation;
using ESP8266.Database.Database;

namespace ESP8266_Temperature.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        
        // GET api/values
        public async Task<IHttpActionResult> Get()
        {
            
            return Json(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(new { value = id });
        }

        // POST api/values
        //public async Task<IHttpActionResult> Post(TempHumedadModel model)
        //{
        //    var tempHumedadBussines = new TempHumedad(new GenericRepository<t_temp_humedad>(new esp8266Entities()));
        //    return Json(await tempHumedadBussines.Add(model));
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route ("Add")]
        public async Task<IHttpActionResult> Add(TempHumedadModel model)
        {
            var tempHumedadBussines = new TempHumedad(new GenericRepository<t_temp_humedad>(new esp8266Entities()));
            return Json(await tempHumedadBussines.Add(model));
        }
    }
}
