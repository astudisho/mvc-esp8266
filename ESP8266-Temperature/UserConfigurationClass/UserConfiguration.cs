using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ESP8266.Bussines.Bussines;
using ESP8266.Bussines.Bussines.Implementation;
using ESP8266.Bussines.Bussines.Interface;
using Ninject.Modules;

namespace ESP8266_Temperature.UserConfigurationClass
{
    public static class  UserConfiguration
    {
        public class NinjectBindings : NinjectModule
        {
            public override void Load()
            {
                //Bind<ITempHumedad>().To<TempHumedad>();
                //Bind<INode>().To<Node>();
            }
        }
    }
}