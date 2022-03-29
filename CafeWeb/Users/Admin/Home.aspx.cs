using System;
using System.Web;
using WebClasses;
using Database;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CafeWebAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string userName;
        string orgFk, auth;

        protected void Page_Load(object sender, EventArgs e)
        {
            ControlData();

            userName = MySession.Current.UserName;
            userName = CryptPass.FirstLetterToUpper(userName);
        }

        protected void SignOut_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            Response.Cookies["OrgFk"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Login.aspx", true);
        }

        protected void SaveOrg_ServerClick(object sender, EventArgs e)
        {
            ApplicationDBContext.SetOrg(orgName.Value.ToString(), isActive.Checked); ;
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

        //protected void UpdateOrg_ServerClick(object sender, EventArgs e)
        //{
        //    orgUpdateId.Disabled = true;
        //}

        //protected void OrgView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    orgUpdateId.Value = OrgView.SelectedRow.Cells[1].Text;
        //    orgUpdateId.Disabled = true;
        //    orgUpdateName.Value = OrgView.SelectedRow.Cells[2].Text;
        //    orgUpdateActive.Value = OrgView.SelectedRow.Cells[3].Text;
        //}

        //protected void UpdateOrg_ServerClick(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((HtmlAnchor)sender).Parent.Parent as GridViewRow;
        //    orgUpdateId.Value = row.RowIndex.ToString();
        //}

        protected void ControlData()
        {
            if (MySession.Current.Auth != null)
            {
                if (MySession.Current.Auth != "1")
                {
                    if (MySession.Current.Auth == "2")
                    {
                        Response.Redirect("Yetkili");
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

                    if (MySession.Current.Auth != "1")
                    {
                        if (MySession.Current.Auth == "2")
                        {
                            Response.Redirect("Yetkili");
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