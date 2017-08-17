using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ESP8266.Bussines.Bussines.Implementation;
using ESP8266.Bussines.Bussines.Interface;
using Ninject.Modules;

namespace ESP8266_Temperature.UserConfigurationClass
{
    public class  UserConfiguration
    {
        public class NinjectBindings : NinjectModule
        {
            public override void Load()
            {
                
            }
        }
    }
}