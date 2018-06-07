using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Task 3 - Apply Authoize @ Global Level.
            filters.Add(new AuthorizeAttribute());
        }
    }
}
