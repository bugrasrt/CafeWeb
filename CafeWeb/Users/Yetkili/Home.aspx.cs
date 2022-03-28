using System;
using System.Web;
using WebClasses;

namespace CafeWebYetkili
{
    public partial class HomePage : System.Web.UI.Page
    {
        public string userName;
        string orgFk, auth;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlData();

            userName = MySession.Current.UserName;
            userName = CryptPass.FirstLetterToUpper(userName);
        }

        protected void SignOut1_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            Response.Cookies["OrgFk"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Login.aspx", true);
        }
        protected void PersYon_ServerClick(object sender, EventArgs e)
        {
            PersYon.Visible = false;
        }

        protected void ControlData()
        {
            if (MySession.Current.Auth != null)
            {
                if (MySession.Current.Auth != "2")
                {
                    if (MySession.Current.Auth == "1")
                    {
                        Response.RedirectToRoute("Admin");
                    }
                    else
                    {
                        Session.Clear();
                        Response.Redirect("~/Login.aspx", true);
                    }
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

                    if (MySession.Current.Auth != "2")
                    {
                        if (MySession.Current.Auth == "1")
                        {
                            Response.RedirectToRoute("Admin");
                        }
                        else
                        {
                            Session.Clear();
                            Response.Redirect("~/Login.aspx", true);
                        }
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Login.aspx", true);
                }
            }
        }
    }
}