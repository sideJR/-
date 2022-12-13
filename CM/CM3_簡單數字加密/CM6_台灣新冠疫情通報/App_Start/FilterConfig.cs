using System.Web;
using System.Web.Mvc;

namespace CM6_台灣新冠疫情通報
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
