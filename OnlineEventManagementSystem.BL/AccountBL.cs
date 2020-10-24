using OnlineEventManagement.Repository.DAL;
using OnlineEventManagementSystem.BL.Interface;
using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL
{
    public class AccountBL : IAccountBL
    {
        AccountRepository userRepository;
        public AccountBL()
        {
            userRepository = new AccountRepository();
        }
        public void AddUser(Account user)
        {
            userRepository.AddUser(user);        //Adding user details
        }
        public bool VerifyUser(string mailId)
        {
            return userRepository.VerifyUser(mailId);                  //Verifying user existance
        }
        public Account ValidateLogin(string mailId,string password)
        {
           return userRepository.ValidateLogin(mailId, password);           //Verifying the user mail id and password
        }
        public IEnumerable<Account> GetCustomerList()
        {
            return userRepository.GetCustomerList();         //Getting the user details as object in list from the database 
        }
        public int GenerateUserID()
        {
            return userRepository.GenerateUserID();
        }
    }
}
