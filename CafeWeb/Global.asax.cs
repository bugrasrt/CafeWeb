using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CafeWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Clear();
            RegisterCustomRoutes(RouteTable.Routes);
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                routeName: "Admin",
                routeUrl: "Admin/Home",
                physicalFile: "~/Users/Admin/Home.aspx"
            );
            routes.MapPageRoute(
                routeName: "Yetkili",
                routeUrl: "Yetkili/Home",
                physicalFile: "~/Users/Yetkili/Home.aspx"
            );
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            if (exc != null)
            {
                Server.Transfer("/Error/PageNotFound.aspx", true);
            }

            Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}