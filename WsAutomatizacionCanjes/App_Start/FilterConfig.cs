using System.Web;
using System.Web.Mvc;

namespace WsAutomatizacionCanjes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
