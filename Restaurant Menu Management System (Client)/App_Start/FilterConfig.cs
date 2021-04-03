using System.Web;
using System.Web.Mvc;

namespace Restaurant_Menu_Management_System__Client_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
