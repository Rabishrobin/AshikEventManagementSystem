using OnlineEventManagement.DAL;
using OnlineEventManagementSystem.Entity;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class AccountRepository
    {
        public static void AddUser(Account user)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Users.Add(user);        //Adding the user details to the conext
                context.SaveChanges();          //Saving the changes to the database
            }
        }
        public static Account VerifyMailId(string userMailId,string password)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Account user = context.Users.Where(u => u.UserMailId == userMailId && u.UserPassword == password).FirstOrDefault();     //Verfying the user mailid and password
                return user;
            }
        }
    }
}
