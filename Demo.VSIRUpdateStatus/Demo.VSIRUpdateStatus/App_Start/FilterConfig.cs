using System.Web;
using System.Web.Mvc;

namespace Demo.UpdateOrderStatus.XinhCaNgay
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
