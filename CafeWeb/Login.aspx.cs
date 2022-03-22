using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using CafeWeb.SessionHandle;

namespace CafeWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string userName, password, hashedData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (MySession.Current.Auth == "1")
                {
                    Response.Redirect("~/Users/Admin/Default.aspx");
                }
                else
                {
                    if (Request.Cookies["UserId"] != null &&
                        Request.Cookies["UserName"] != null && 
                        Request.Cookies["Auth"] != null)
                    {
                        MySession.Current.UserId = Request.Cookies["UserId"].Value;
                        MySession.Current.UserName = Request.Cookies["UserName"].Value;
                        MySession.Current.Auth = Request.Cookies["Auth"].Value;
                    }
                }
                
            }
            else
            {
                if (rememberMe.Checked)
                {
                    Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(30);
                }

                RedirectPage();
            }
        }

        public void RedirectPage()
        {

            NameValueCollection nvc = Request.Form;

            if (!string.IsNullOrEmpty(nvc["username"]))
            {
                userName = nvc["username"];
                userName.ToLower();
            }

            if (!string.IsNullOrEmpty(nvc["password"]))
            {
                password = nvc["password"];
                hashedData = ComputeSha256Hash(password);
            }

            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var obj = db.Users.Where(a => a.UserName.Equals(userName) && a.Password.Equals(hashedData)).FirstOrDefault();
                if (obj != null)
                {
                    MySession.Current.UserId = obj.UserId.ToString();
                    MySession.Current.UserName = obj.UserName.ToString();
                    MySession.Current.Auth = obj.Auth.ToString();

                    Response.Cookies["UserId"].Value = obj.UserId.ToString();
                    Response.Cookies["UserName"].Value = obj.UserName.ToString();
                    Response.Cookies["Auth"].Value = obj.Auth.ToString();

                    if (MySession.Current.Auth == "1")
                    {
                        Response.Redirect("~/Users/Admin/Default.aspx", true);
                    }
                    
                }
            }
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}