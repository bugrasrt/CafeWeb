using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClasses
{
    public class UserInfo
    {
        public string id;
        public string name;
        public string auth;

        public UserInfo(string id, string name, string auth)
        {
            this.id = id;
            this.name = name;
            this.auth = auth;
        }
    }
}
