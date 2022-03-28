using System;
using WebClasses;

namespace LoginClass
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string orgFk, userName, auth;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ControlData();
            }
        }

        protected void ControlData()
        {
            if (MySession.Current.Auth != null)
            {
                if (MySession.Current.Auth == "1")
                {
                    Response.RedirectToRoute("Admin");
                }
                else if (MySession.Current.Auth == "2")
                {
                    Response.RedirectToRoute("Yetkili");
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Login.aspx", true);
                }
            }
            else
            {
                if (Request.Cookies["Auth"] != null)
                {
                    orgFk = Request.Cookies["OrgFk"].Value;
                    userName = Request.Cookies["UserName"].Value;
                    auth = Request.Cookies["Auth"].Value;

                    MySession.SetSession(orgFk, userName, auth);

                    if (MySession.Current.Auth == "1")
                    {
                        Response.RedirectToRoute("Admin");
                    }
                    else if (MySession.Current.Auth == "2")
                    {
                        Response.RedirectToRoute("Yetkili");
                    }
                    else
                    {
                        Session.Clear();
                        Response.Redirect("~/Login.aspx", true);
                    }
                }
                else
                {
                    Session.Clear();
                }
            }
        }
    }
}