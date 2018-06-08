using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //Apply Authoize @ Global Level.
            filters.Add(new AuthorizeAttribute());

            //Task 4 - Disable regular HTTP Access.
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
