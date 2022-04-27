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

        //Kullancisi Verisini Getir
        public static UserInfo GetData(string uN, string hD, int oFk)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var usr = db.Users.Where(a => a.UserName == uN  &&
                                              a.Password == hD  &&
                                              a.OrgFk    == oFk &&
                                              a.isActive == true).FirstOrDefault();

                if (usr == null)
                {
                    return null;
                }

                UserInfo userObj = new UserInfo(usr.Id.ToString(), usr.UserName, usr.Auth.ToString());

                return userObj;
            }
        }

        //Organizasyon Kayit
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

                    return '0'; //Basarili
                }

                return '1'; //Hata
            }
        }

        //Organizasyon Guncelle
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

                    return '0';//Basarili
                }

                return '1'; //Boyle aktif bir organizasyon yok
            }
        }

        //Kullanici Aktiflik Kontrol
        public static bool IsUserActive(string Id)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var usr = db.Users.SingleOrDefault(a => a.Id.ToString() == Id && a.isActive == true);

                if (usr != null)
                {
                    return true;
                }

                return false;
            }

        }

        //Kullanici Kayit
        public static char SaveUser(string OrgId, string UserName, string Password, byte Auth, bool IsActive)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var org = db.Orgs.SingleOrDefault(a => a.Id.ToString() == OrgId && a.isActive == true);

                if (org != null)
                {
                    if (Int32.TryParse(OrgId, out int OrgFk)) {
                        var userCheck = db.Users.SingleOrDefault(a => a.UserName == UserName && a.OrgFk == OrgFk);

                        if (userCheck == null)
                        {
                            User user = new User();

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

        //Kullanici Guncelleme
        public static char UpdateUser(string OrgId, string UserId, string UserName, byte Auth, bool IsActive)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var org = db.Orgs.SingleOrDefault(a => a.Id.ToString() == OrgId);

                var usr = db.Users.Where(a => a.Id.ToString() == UserId).FirstOrDefault();

                if (org != null)
                {
                    if (Int32.TryParse(OrgId, out int OrgFk))
                    {
                        var userCheck = db.Users.Count(a => a.UserName == UserName && a.UserName != usr.UserName && a.OrgFk == OrgFk);

                        if (usr != null && userCheck < 1)
                        {
                            usr.OrgFk = OrgFk;
                            usr.UserName = UserName;
                            usr.Auth = Auth;
                            usr.isActive = IsActive;

                            db.SaveChanges();

                            return '0';
                        }
                        return '2';
                    }
                }
                return '1';
            }
        }

        //Organizasyon Silme
        public static char DelOrg(string id)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var org = db.Orgs.Where(a => a.Id.ToString() == id).First();
                var pers = from Users in db.Users where Users.OrgFk == org.Id select Users;

                if (org != null)
                {
                    if (pers != null)
                    {
                        foreach (var user in pers)
                        {
                            db.Users.Remove(user);
                        }
                    }

                    db.Orgs.Remove(org);
                    db.SaveChanges();

                    return '0';
                }
                return '1';
            }
        }

        //Kullanici Silme
        public static char DelUser(string id)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var usr = db.Users.Where(a => a.Id.ToString() == id).First();

                if (usr != null)
                {
                    db.Users.Remove(usr);
                    db.SaveChanges();

                    return '0';
                }
                return '1';
            }
        }

        //Organizasyon Listeleme
        public static List<Database.Org> ListOrgs()
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var orgs = db.Orgs.Where(a => a.Id > 1000);
                
                var orgList = orgs.ToList();

                if (orgList == null)
                {
                    return null;
                }

                return orgList;
            }
        }

        //Kullanici Listeleme
        public static List<Database.User> ListUsers()
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var users = db.Users.Where(a => a.Auth > 1);

                var userList = users.ToList();

                if (userList == null)
                {
                    return null;
                }

                return userList;
            }
        }

        //Bekleyenler Listeleme
        public static List<Database.WaitingUser> ListWaitingUsers()
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var users = db.WaitingUsers;

                var waitingUserList = users.ToList();

                if (waitingUserList == null)
                {
                    return null;
                }

                return waitingUserList;
            }
        }

        //Kayıt olanları onay sürecine dahil et
        public static char SaveWaitingUser(string UserName, string Password, string OrgFk)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var users = db.Users.Where(a => a.OrgFk.ToString() == OrgFk &&
                                                a.UserName == UserName);

                var waiting = db.WaitingUsers.Where(a => a.OrgFk.ToString() == OrgFk &&
                                                         a.UserName == UserName);

                if (users.Count() != 0 || waiting.Count() != 0)
                {
                    return '1';
                }

                var org = db.Orgs.SingleOrDefault(a => a.Id.ToString() == OrgFk && a.isActive == true);
                var isOrg = Int32.TryParse(OrgFk, out int orgId);

                if (org != null && isOrg)
                {
                    WaitingUser user = new WaitingUser();

                    var HashedPass = CryptPass.ComputeSha256Hash(Password);
                    user.UserName = UserName;
                    user.Password = HashedPass;
                    user.Auth = 3;
                    DateTime date = DateTime.Now;
                    user.CreatedAt = date;
                    user.ChangedAt = date;
                    user.isActive = false;
                    user.OrgFk = orgId;
                    db.WaitingUsers.Add(user);
                    db.SaveChanges();

                    return '0';
                }

                return '2';
            }
        }

        //Bekleyenlerden Users a transfer et
        public static char TransferToUsers(string UserId)
        {
            using (CafeDataBaseEntities db = new CafeDataBaseEntities())
            {
                var waitingUser = db.WaitingUsers.Where(a => a.Id.ToString() == UserId);

                User newUser = new User();

                if (waitingUser != null)
                {
                    foreach (var user in waitingUser)
                    {
                        newUser.OrgFk = user.OrgFk;
                        newUser.UserName = user.UserName;
                        newUser.Password = user.Password;
                        newUser.Auth = user.Auth;
                        newUser.CreatedAt = user.CreatedAt;
                        DateTime date = DateTime.Now;
                        newUser.ChangedAt = date;
                        newUser.isActive = true;

                        db.Users.Add(newUser);

                        db.WaitingUsers.Remove(user);
                    }

                    db.SaveChanges();

                    return '0';

                }

                return '1';
            }
        }
    }
}
