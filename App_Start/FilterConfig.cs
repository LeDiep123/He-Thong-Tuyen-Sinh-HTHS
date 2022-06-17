using System.Web;
using System.Web.Mvc;

namespace He_Thong_Tuyen_Sinh_HTHS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
