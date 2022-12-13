using System.Web;
using System.Web.Mvc;

namespace CM9_旁聽名單
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
