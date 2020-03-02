using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEventManagementSystem.BL
{
    public class AccountBL
    {
        public static void AddUser(Account user)
        {
            AccountRepository.AddUser(user);
        }
        public static Account ValidateLogIn(string username,string password)
        {
           return AccountRepository.VerifyMailId(username, password);
        }
    }
}
