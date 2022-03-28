using System;
using System.Collections.Specialized;
using System.Web.UI;
using WebClasses;
using Database;

namespace CafeWebDefault
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string userName, password, hashedData, isChk, orgFk, auth, result;
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectPage();
        }

        protected string ControlData()
        {
            if (MySession.Current.Auth != null)
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
                    Session.Clear();
                    Response.Redirect("~/Login.aspx", true);
                    return "205 OK";
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
                        return "200 OK";
                    }
                    else if (MySession.Current.Auth == "2")
                    {
                        Response.RedirectToRoute("Yetkili");
                        return "200 OK";
                    }
                    else
                    {
                        Session.Clear();
                        Response.Redirect("~/Login.aspx", true);
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
                    !string.IsNullOrEmpty(nvc["password"]))
                {
                    userName = nvc["username"];
                    userName = userName.Trim();

                    password = nvc["password"];
                    hashedData = CryptPass.ComputeSha256Hash(password);
                }

                if (nvc["Remember"] != null)
                {
                    isChk = nvc["Remember"];
                    var ChkTuple = userOrg.SplitComma(isChk);
                    if (ChkTuple == null)
                    {
                        isChk = "false";
                    }
                    else
                    {
                        isChk = ChkTuple.Item1;
                    }
                }
                else
                {
                    isChk = "false";
                }

                var NamesTuple = userOrg.SplitPoint(userName);

                if (NamesTuple == null)
                {
                    Response.Redirect("~/Login.aspx");
                }

                userName = NamesTuple.Item2;
                var orgFk = Int32.Parse(NamesTuple.Item1);

                UserInfo uInfo = ApplicationDBContext.GetData(userName.ToLower(), hashedData, orgFk);

                if (uInfo != null)
                {
                    MySession.SetSession(orgFk.ToString(), userName, uInfo.auth);

                    if (isChk == "true")
                    {
                        Response.Cookies["OrgFk"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(30);

                        Request.Cookies["OrgFk"].Value = orgFk.ToString();
                        Request.Cookies["UserName"].Value = userName;
                        Request.Cookies["Auth"].Value = uInfo.auth;
                    }

                    if (MySession.Current.Auth == "1")
                    {
                        Response.RedirectToRoute("Admin");
                    }
                    else if (MySession.Current.Auth == "2")
                    {
                        Response.RedirectToRoute("Yetkili");
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