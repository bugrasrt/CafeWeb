using System;
using WebClasses;
using Database;
using System.Web;

namespace LoginClass
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string UserId, OrgFk, UserName, Auth;
        bool IsActive;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ControlData();
            }  
        }

        protected void SignOutFunc()
        {
            Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            try
            {
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["OrgFk"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(-1);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex}');</script>");
            }

            Response.Redirect("~/Login.aspx", true);
        }

        protected void ControlData()
        {
            IsActive = MySession.Current.UserId != null && ApplicationDBContext.IsUserActive(MySession.Current.UserId);
            if (MySession.Current.Auth != null && IsActive != false)
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
                    SignOutFunc();
                }
            }
            else
            {
                if (Request.Cookies["UserId"] != null && Request.Cookies["Auth"] != null)
                {
                    UserId = Request.Cookies["UserId"].Value;
                    OrgFk = Request.Cookies["OrgFk"].Value;
                    UserName = Request.Cookies["UserName"].Value;
                    Auth = Request.Cookies["Auth"].Value;
                    IsActive = ApplicationDBContext.IsUserActive(UserId);

                    if (IsActive != false)
                    {
                        MySession.SetSession(UserId, UserName, Auth, OrgFk);

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
                            SignOutFunc();
                        }
                    }
                    else
                    {
                        SignOutFunc();
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