using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEventManagement.DAL
{
    public class AccountRepository
    {
        static OnlineEventManagementDBContext context = new OnlineEventManagementDBContext();
        public static void AddUser(Account user)
        {
            context.UserDB.Add(user);
            context.SaveChanges();
        }
        public static Account VerifyMailId(string userMailId,string password)
        {
            Account user = context.UserDB.Where(u=>u.UserMailId==userMailId && u.UserPassword==password).FirstOrDefault();
            return user;
            //foreach(var value in users)
            //{
            //    if (value.UserMailId == userMailId && value.UserPassword == password)
            //    {
            //        isValue = true;
            //        break;
            //    }
            //}
            //return isValue;
        }
    }
}
