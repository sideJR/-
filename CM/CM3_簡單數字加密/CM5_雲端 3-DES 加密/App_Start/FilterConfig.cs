using System.Web;
using System.Web.Mvc;

namespace CM5_雲端_3_DES_加密
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
