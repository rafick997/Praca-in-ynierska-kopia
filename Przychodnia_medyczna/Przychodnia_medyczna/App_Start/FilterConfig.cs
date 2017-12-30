using System.Web;
using System.Web.Mvc;

namespace Przychodnia_medyczna
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
