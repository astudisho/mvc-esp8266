using System.Web;
using System.Web.Mvc;

namespace ESP8266_Temperature
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
