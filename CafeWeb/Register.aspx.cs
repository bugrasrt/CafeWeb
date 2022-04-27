using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using WebClasses;

namespace CafeWeb
{
    public partial class Register : System.Web.UI.Page
    {
        string UserName, Password, RePassword, OrgFk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Handle_Data();
            }
        }

        protected void Handle_Data()
        {
            var check = true;

            NameValueCollection nvc = Request.Form;

            if (!string.IsNullOrEmpty(nvc["UserName"]) &&
                !string.IsNullOrEmpty(nvc["Password"]) &&
                !string.IsNullOrEmpty(nvc["RePassword"]))
            {
                UserName = nvc["UserName"];
                UserName = UserName.Trim();

                Password = nvc["Password"];
                Password = Password.Trim();

                RePassword = nvc["RePassword"];
                RePassword = RePassword.Trim();

                OrgFk = nvc["OrgId"];
                OrgFk = OrgFk.Trim();

                if (Password != RePassword)
                {
                    resultEl.InnerText = "3:Şifreler uyumsuz!";
                    check = false;
                }

                if (!terms.Checked)
                {
                    resultEl.InnerText = "4:Şartları onaylamanız gerek!";
                    check = false;
                }
                
            }

            if (check)
            {
                var result = ApplicationDBContext.SaveWaitingUser(UserName, Password, OrgFk);

                if (result == '0')
                {
                    resultEl.InnerText = "0:save";
                }
                else if (result == '2')
                {
                    resultEl.InnerText = "2:Aktif böyle bir işletme yok!";
                }
                else if (result == '1')
                {
                    resultEl.InnerText = "1:Bu işletmede aynı kullanıcı adında biri zaten kayıtlı!";
                }

                terms.Checked = false;
            }
        }
    }
}