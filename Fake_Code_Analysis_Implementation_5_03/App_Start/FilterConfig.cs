using System.Web;
using System.Web.Mvc;

namespace Fake_Code_Analysis_Implementation_5_03
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
