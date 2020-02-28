using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEventManagement.DAL
{
    public class UserRepository
    {
        static OnlineEventManagementDBContext context = new OnlineEventManagementDBContext();
        public static void AddUser(UserManager user)
        {
            context.UserDB.Add(user);
            context.SaveChanges();
        }
    }
}
