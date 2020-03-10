using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class AccountRepository
    {
        static OnlineEventManagementDBContext context = new OnlineEventManagementDBContext();
        public static void AddUser(Account user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public static Account VerifyMailId(string userMailId,string password)
        {
            Account user = context.Users.Where(u=>u.UserMailId==userMailId && u.UserPassword==password).FirstOrDefault();
            return user;
        }
    }
}
