using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEventManagementSystem.BL
{
    public class Account
    {
        public static void AddUser(UserManager user)
        {
            UserRepository.AddUser(user);
        }
    }
}
