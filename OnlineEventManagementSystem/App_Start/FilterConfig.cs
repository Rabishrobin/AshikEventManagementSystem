using OnlineEventManagementSystem.Models;
using System.Web.Mvc;

namespace OnlineEventManagementSystem.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionFilter());
        }
    }
}