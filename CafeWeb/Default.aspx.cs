using System;
using System.Collections.Specialized;
using System.Web.UI;
using WebClasses;
using Database;
using System.Web;

namespace CafeWebDefault
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string UserId, UserName, Password, HashedData, IsChk, OrgFk, Auth, result;
        bool IsActive;
        int IntOrgFk;
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectPage();
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

        protected string ControlData()
        {
            IsActive = MySession.Current.UserId != null && ApplicationDBContext.IsUserActive(MySession.Current.UserId);
            if (MySession.Current.Auth != null && IsActive != false)
            {
                if (MySession.Current.Auth == "1")
                {
                    Response.RedirectToRoute("Admin");
                    return "200 OK";
                }
                else if (MySession.Current.Auth == "2")
                {
                    Response.RedirectToRoute("Yetkili");
                    return "200 OK";
                }
                else
                {
                    SignOutFunc();
                    return "205 OK";
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
                            return "200 OK";
                        }
                        else if (MySession.Current.Auth == "2")
                        {
                            Response.RedirectToRoute("Yetkili");
                            return "200 OK";
                        }
                        else
                        {
                            SignOutFunc();
                            return "205 OK";
                        }
                    }
                    else
                    {
                        SignOutFunc();
                        return "205 OK";
                    }
                }
            }

            return "404 ER";
        }

        protected void RedirectPage()
        {
            result = ControlData();

            if (result != "200 OK")
            {
                NameValueCollection nvc = Request.Form;
                UserOrg userOrg = new UserOrg();

                if (!string.IsNullOrEmpty(nvc["username"]) &&
                    !string.IsNullOrEmpty(nvc["Password"]))
                {
                    UserName = nvc["username"];
                    UserName = UserName.Trim();

                    Password = nvc["Password"];
                    HashedData = CryptPass.ComputeSha256Hash(Password);
                }

                if (nvc["Remember"] != null)
                {
                    IsChk = nvc["Remember"];
                    var ChkTuple = userOrg.SplitComma(IsChk);
                    if (ChkTuple == null)
                    {
                        IsChk = "false";
                    }
                    else
                    {
                        IsChk = ChkTuple.Item1;
                    }
                }
                else
                {
                    IsChk = "false";
                }

                var NamesTuple = userOrg.SplitPoint(UserName);

                if (NamesTuple == null)
                {
                    Response.Redirect("~/Login.aspx");
                }

                UserName = NamesTuple.Item2;
                var OrgChk = Int32.TryParse(NamesTuple.Item1, out IntOrgFk);
                if (OrgChk == false)
                {
                    Response.Redirect("~/Login.aspx");
                }

                UserInfo uInfo = ApplicationDBContext.GetData(UserName.ToLower(), HashedData, IntOrgFk);

                if (uInfo != null)
                {
                    MySession.SetSession(uInfo.id, UserName, uInfo.auth, IntOrgFk.ToString());

                    if (IsChk == "true")
                    {
                        Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["OrgFk"].Expires = DateTime.Now.AddDays(30);

                        Request.Cookies["UserId"].Value = uInfo.id;
                        Request.Cookies["UserName"].Value = UserName;
                        Request.Cookies["Auth"].Value = uInfo.auth;
                        Request.Cookies["OrgFk"].Value = IntOrgFk.ToString();
                    }

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
        }
    }
}