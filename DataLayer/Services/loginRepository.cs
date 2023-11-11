using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class loginRepository : IAdminLoginRepository
    {
        Mycmscontext db;
        public loginRepository(Mycmscontext context)
        {
            db = context;

        }
        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogin.Any(u=> u.UserName== username && u.Password == password);
        }
    }
}
