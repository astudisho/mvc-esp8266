using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP8266.Database.Database;
using ESP8266.Model.Models;

namespace ESP8266.Bussines.Bussines.Interface
{
    public interface ITempHumedad : IBaseBussines<TempHumedadModel>
    {
	    Task<TempHumedadModel> Add(TempHumedadModel model, string chipInfo);
    }
}
