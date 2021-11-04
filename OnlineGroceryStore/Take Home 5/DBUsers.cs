using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_Home_5
{
    public class DBUsers
    {
        static public List<User> userList;
        static public List<Admin> adminList;

        static DBUsers()
        {
            userList = new List<User>();
            adminList = new List<Admin>();
            adminList.Add(new Admin("admin1", "12345"));
            adminList.Add(new Admin("admin2", "54321"));
            userList.Add(new User("Ali", "123"));
            userList.Add(new User("Ayşe", "321"));
        }
    }
}
