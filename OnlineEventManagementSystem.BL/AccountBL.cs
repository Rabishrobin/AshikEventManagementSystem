using OnlineEventManagement.Repository.DAL;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL
{
    public class AccountBL
    {
        public static void AddUser(Account user)
        {
            AccountRepository.AddUser(user);        //Adding user details
        }
        public static int? VerifyMailId(string mailId)
        {
            return AccountRepository.VerifyMailId(mailId);                  //Verifying user existance
        }
        public static Account ValidateLogin(string username,string password)
        {
           return AccountRepository.ValidateLogin(username, password);           //Verifying the user mail id and password
        }
        public static IEnumerable<Account> DisplayCustomers()
        {
            return AccountRepository.DisplayCustomers();         //Getting the user details as object in list from the database 
        }
    }
}
