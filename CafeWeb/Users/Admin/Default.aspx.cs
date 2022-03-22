using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CafeWeb.SessionHandle;

namespace CafeWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Auth"] != null)
            {
                MySession.Current.UserId = Request.Cookies["UserId"].Value;
                MySession.Current.UserName = Request.Cookies["UserName"].Value;
                MySession.Current.Auth = Request.Cookies["Auth"].Value;

                if (MySession.Current.Auth != "1")
                {
                    Session.Clear();
                    Response.Redirect("~/Login.aspx", true);
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Login.aspx", true);
            }
        }

        protected void SignOut_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Login.aspx", true);
        }
    }
}