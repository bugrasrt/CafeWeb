using System;
using System.Web;
using WebClasses;
using Database;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace CafeWebAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string UserName;
        string OrgFk, Auth, UserId;
        bool IsActive;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlData();

            UserName = MySession.Current.UserName;
            UserName = CryptPass.FirstLetterToUpper(UserName);
        }

        protected void SignOut_ServerClick(object sender, EventArgs e)
        {
            SignOutFunc();
        }

        protected void SaveOrg_ServerClick(object sender, EventArgs e)
        {
            var result = ApplicationDBContext.SetOrg(OrgName.Value.Trim().ToString(), OrgisActive.Checked);
            if (result == '0')
            {
                resultEl.InnerText = "0";
            }
            else
            {
                resultEl.InnerText = "1:Kayıt Başarısız";
            }
            OrgName.Value = "";
            OrgisActive.Checked = false;
            OrgView.DataBind();
            UserView.DataBind();
        }

        protected void OrgUpdateBtn_ServerClick(object sender, EventArgs e)
        {
            var result = ApplicationDBContext.UpdateOrg(OrgUpdateId.Value.Trim().ToString(), OrgUpdateName.Value.Trim().ToString(), 
                                                        OrgUpdateActive.Checked);
            if (result == '0')
            {
                resultEl.InnerText = "0";
            }
            else
            {
                resultEl.InnerText = "1:Güncelleme Başarısız!";
            }
            OrgView.DataBind();
            UserView.DataBind();
        }

        protected void SaveUser_ServerClick(object sender, EventArgs e)
        {
            var result = ApplicationDBContext.SaveUser(UserOrgId.Value.Trim().ToString(), UserSetName.Value.Trim().ToString(),
                                                       UserSetPassword.Value.Trim().ToString(), Byte.Parse(UserYetki.Value),
                                                       UserisActive.Checked);

            if (result == '0')
            {
                resultEl.InnerText = "0";
            }
            else if (result == '1')
            {
                resultEl.InnerText = "1:Aktif böyle bir işletme yok!";
            }
            else
            {
                resultEl.InnerText = "2:Bu işletmede aynı kullanıcı adında biri zaten kayıtlı!";
            }
            UserOrgId.Value = "";
            UserSetName.Value = "";
            UserYetki.SelectedIndex = 2;
            UserisActive.Checked = false;
            UserSetPassword.Value = "";
            UserSetPassConfirm.Value = "";
            OrgView.DataBind();
            UserView.DataBind();
        }

        protected void PersUpdateBtn_ServerClick(object sender, EventArgs e)
        {
            var result = ApplicationDBContext.UpdateUser(PersUpdateOrgId.Value.Trim().ToString(), PersUpdateId.Value.Trim().ToString(),
                                                       PersUpdateName.Value.Trim().ToString(), Byte.Parse(PersUpdateYetki.Value),
                                                       PersUpdateActive.Checked);

            if (result == '0')
            {
                resultEl.InnerText = "0";
            }
            else if (result == '1')
            {
                resultEl.InnerText = "1:Aktif böyle bir işletme yok!";
            }
            else
            {
                resultEl.InnerText = "2:Bu işletmede aynı kullanıcı adında biri zaten kayıtlı!";
            }
            OrgView.DataBind();
            UserView.DataBind();
        }

        protected void DelBtn_ServerClick(object sender, EventArgs e)
        {
            var delStr = aspHidden.Value;
            var getId = delStr.Split(':');

            if (getId[0] == "Org")
            {
                var result = ApplicationDBContext.DelOrg(getId[1]);

                if (result == '0')
                {
                    resultEl.InnerText = "0";
                }
                else if (result == '1')
                {
                    resultEl.InnerText = "1:Kullanıcı kaydı silinemedi!";
                }
            }
            else if (getId[0] == "User")
            {
                var result = ApplicationDBContext.DelUser(getId[1]);

                if (result == '0')
                {
                    resultEl.InnerText = "0";
                }
                else if (result == '1')
                {
                    resultEl.InnerText = "1:İşletme kaydı silinemedi!";
                }
            }
            OrgView.DataBind();
            UserView.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Database.Org> OrgView_GetData()
        {
            return ApplicationDBContext.ListOrgs().AsQueryable();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Database.User> UserView_GetData()
        {
            return ApplicationDBContext.ListUsers().AsQueryable();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Database.WaitingUser> WaitingUserView_GetData()
        {
            return ApplicationDBContext.ListWaitingUsers().AsQueryable(); ;
        }

        protected void OrgView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.BorderStyle = BorderStyle.None;
                tc.BorderWidth = 0;
                tc.BorderColor = System.Drawing.Color.Transparent;
            }
        }

        protected void UserView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.BorderStyle = BorderStyle.None;
                tc.BorderWidth = 0;
                tc.BorderColor = System.Drawing.Color.Transparent;
            }
        }

        protected void WaitingUserView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.BorderStyle = BorderStyle.None;
                tc.BorderWidth = 0;
                tc.BorderColor = System.Drawing.Color.Transparent;
            }
        }

        protected void OnayWaitingBtn_ServerClick(object sender, EventArgs e)
        {
            var WaitingId = aspHidden.Value.Split(':');
            var result = ApplicationDBContext.TransferToUsers(WaitingId[1]);

            if (result == '0')
            {
                resultEl.InnerText = "0";
            }
            else if (result == '1')
            {
                resultEl.InnerText = "1:Kayıt bekleyen böyle bir kullanıcı yok!";
            }

            UserView.DataBind();
            WaitingUserView.DataBind();
        }

        protected void DelWaitingBtn_ServerClick(object sender, EventArgs e)
        {
            var WaitingId = aspHidden.Value.Split(':');
            var result = ApplicationDBContext.DelWaitingUser(WaitingId[1]);

            if (result == '0')
            {
                resultEl.InnerText = "0";
            }
            else if (result == '1')
            {
                resultEl.InnerText = "1:Bir hata oluştu!";
            }

            WaitingUserView.DataBind();
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
                if (MySession.Current.Auth != "1")
                {
                    if (MySession.Current.Auth == "2")
                    {
                        Response.Redirect("Yetkili");
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
                        MySession.SetSession(UserId, UserName, Auth, OrgFk);

                        if (MySession.Current.Auth != "1")
                        {
                            if (MySession.Current.Auth == "2")
                            {
                                Response.Redirect("Yetkili");
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