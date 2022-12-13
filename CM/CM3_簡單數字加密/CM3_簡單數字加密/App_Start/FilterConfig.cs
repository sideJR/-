using System.Web;
using System.Web.Mvc;

namespace CM3_簡單數字加密
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
