using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CafeWeb.RouteMapping
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Users",
                "Users/{id}",
                "~/Default.aspx");
            routes.MapPageRoute(
                "Login",
                "Login/{id}",
                "~/Login.aspx");
            routes.MapPageRoute(
                "PageNotFound",
                "PageNotFound/{id}",
                "~/PageNotFound.aspx");
        }
    }
}