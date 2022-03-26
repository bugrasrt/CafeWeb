using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using WebClasses;

namespace LoginClass
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlData();
        }

        private void ControlData()
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
    }
}