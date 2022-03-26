﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClasses;

namespace Database
{
    public class ApplicationDBContext
    {
        public static UserInfo GetData(string uN, string hD, int oFk)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var obj = db.Users.Where(a => a.UserName.Equals(uN) &&
                                              a.Password.Equals(hD) &&
                                              a.OrgFk.Equals(oFk)).FirstOrDefault();

                if (obj == null)
                {
                    return null;
                }

                UserInfo userObj = new UserInfo(obj.Id.ToString(), obj.UserName, obj.Auth.ToString());

                return userObj;
            }
        }

        public static void SetOrg(string orgName, bool isActive)
        {
            DateTime strDate;
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var orgs = db.Set<Org>();

                Org org = new Org();
                strDate = DateTime.Now;

                if (org != null)
                {
                    org.OrgName = orgName;
                    org.isActive = isActive;
                    org.CreatedAt = strDate;
                    org.ChangedAt = strDate;

                    orgs.Add(org);

                    db.SaveChanges();
                }
            }
        }
    }
}