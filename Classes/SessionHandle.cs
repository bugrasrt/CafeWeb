using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClasses
{
    public class MySession
    {
        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // **** add your session properties here, e.g like this:
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Auth { get; set; }
        public string OrgFk { get; set; }

        public static void SetSession(string UserId, string UserName, string Auth, string OrgFk)
        {
            Current.UserId = UserId;
            Current.UserName = UserName;
            Current.Auth = Auth;
            Current.OrgFk = OrgFk;
        }
    }
}