using System;
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
                var obj = db.Users.Where(a => a.UserName == uN  &&
                                              a.Password == hD  &&
                                              a.OrgFk    == oFk &&
                                              a.isActive == true).FirstOrDefault();

                if (obj == null)
                {
                    return null;
                }

                UserInfo userObj = new UserInfo(obj.Id.ToString(), obj.UserName, obj.Auth.ToString());

                return userObj;
            }
        }

        public static char SetOrg(string orgName, bool isActive)
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

                    return '0';
                }

                return '1';
            }
        }

        public static char UpdateOrg(string orgId, string orgName, bool isActive)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {

                var org = db.Orgs.SingleOrDefault(a => a.Id.ToString() == orgId);

                var pers = from Users in db.Users where Users.OrgFk.ToString() == orgId select Users;

                if (org != null)
                {
                    DateTime date = DateTime.Now;

                    org.OrgName = orgName;
                    org.isActive = isActive;
                    org.ChangedAt = date;
                    db.SaveChanges();

                    foreach (var user in pers)
                    {
                        user.isActive = isActive;
                        user.ChangedAt = date;
                    }

                    db.SaveChanges();

                    return '0';
                }

                return '1';
            }
        }

        public static bool IsUserActive(string Id)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var obj = db.Users.SingleOrDefault(a => a.Id.ToString() == Id && a.isActive == true);

                if (obj != null)
                {
                    return true;
                }

                return false;
            }

        }

        public static char SaveUser(string OrgId, string UserName, string Password, byte Auth, bool IsActive)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var obj = db.Orgs.SingleOrDefault(a => a.Id.ToString() == OrgId && a.isActive == true);

                if (obj != null)
                {
                    if (Int32.TryParse(OrgId, out int OrgFk)) {
                        var userCheck = db.Users.SingleOrDefault(a => a.UserName == UserName && a.OrgFk == OrgFk);
                        User user = new User();

                        if (userCheck == null)
                        {
                            var HashedPass = CryptPass.ComputeSha256Hash(Password);
                            user.UserName = UserName;
                            user.Password = HashedPass;
                            user.Auth = Auth;
                            DateTime date = DateTime.Now;
                            user.CreatedAt = date;
                            user.ChangedAt = date;
                            user.isActive = IsActive;
                            user.OrgFk = OrgFk;
                            db.Users.Add(user);
                            db.SaveChanges();

                            return '0';
                        }
                            
                        else
                        {
                            return '2';
                        }
                    } 
                }

                return '1';
            }
        }

        public static List<Database.Org> ListOrgs()
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var obj = db.Orgs.Where(a => a.Id > 1000);
                
                var orgList = obj.ToList();

                if (orgList == null)
                {
                    return null;
                }

                return orgList;
            }
        }

        public static List<Database.User> ListUsers()
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var obj = db.Users.Where(a => a.Auth > 1);

                var orgList = obj.ToList();

                if (orgList == null)
                {
                    return null;
                }

                return orgList;
            }
        }
    }
}
