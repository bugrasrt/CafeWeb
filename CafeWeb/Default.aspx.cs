using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClasses;
using Database;

namespace CafeWebDefault
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string userName, password, hashedData, isChk;
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectPage();
        }

        protected void ControlData()
        {
            if (MySession.Current.Auth == "1")
            {
                Response.Redirect("~/Users/Admin/Home.aspx");
            }
            else if (MySession.Current.Auth == "2")
            {
                Response.Redirect("~/Users/Yetkili/Home.aspx");
            }
            if (Request.Cookies["Auth"] != null)
            {
                MySession.Current.OrgFk = Request.Cookies["OrgFk"].Value;
                MySession.Current.UserName = Request.Cookies["UserName"].Value;
                MySession.Current.Auth = Request.Cookies["Auth"].Value;

                if (MySession.Current.Auth == "1")
                {
                    Response.Redirect("~/Users/Admin/Home.aspx");
                }
                else if (MySession.Current.Auth == "2")
                {
                    Response.Redirect("~/Users/Yetkili/Home.aspx");
                }
            }
        }

        protected void RedirectPage()
        {
            ControlData();

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

            var uname = NamesTuple.Item2;
            uname.ToLower();
            var orgFk = Int32.Parse(NamesTuple.Item1);

            UserInfo uInfo = ApplicationDBContext.GetData(uname, hashedData, orgFk);

            if (uInfo != null)
            {
                MySession.Current.OrgFk = orgFk.ToString();
                MySession.Current.UserName = uname;
                MySession.Current.Auth = uInfo.auth;

                if (isChk == "true")
                {
                    Response.Cookies["OrgFk"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(30);

                    Request.Cookies["OrgFk"].Value = orgFk.ToString();
                    Request.Cookies["UserName"].Value = uname;
                    Request.Cookies["Auth"].Value = uInfo.auth;
                }

                if (MySession.Current.Auth == "1")
                {
                    Response.Redirect("~/Users/Admin/Home.aspx");
                }
                else if (MySession.Current.Auth == "2")
                {
                    Response.Redirect("~/Users/Yetkili/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}