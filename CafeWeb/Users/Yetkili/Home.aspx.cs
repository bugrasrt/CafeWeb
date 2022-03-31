using Database;
using System;
using System.Web;
using WebClasses;

namespace CafeWebYetkili
{
    public partial class HomePage : System.Web.UI.Page
    {
        public string UserName;
        string UserId, OrgFk, Auth;
        bool IsActive;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlData();

            UserName = MySession.Current.UserName;
            UserName = CryptPass.FirstLetterToUpper(UserName);
        }

        protected void SignOut1_ServerClick(object sender, EventArgs e)
        {
            SignOutFunc();
        }
        protected void PersYon_ServerClick(object sender, EventArgs e)
        {
            PersYon.Visible = false;
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
                        SignOutFunc();
                    }
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
                        MySession.SetSession(UserId, OrgFk, UserName, Auth);

                        if (MySession.Current.Auth != "2")
                        {
                            if (MySession.Current.Auth == "1")
                            {
                                Response.RedirectToRoute("Admin");
                            }
                            else
                            {
                                SignOutFunc();
                            }
                        }
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
        }
    }
}