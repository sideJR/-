using System.Web;
using System.Web.Mvc;

namespace CM10_銘傳國際生演講查詢
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
