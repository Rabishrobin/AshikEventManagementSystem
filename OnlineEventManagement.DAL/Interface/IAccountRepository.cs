using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagement.DAL.Interface
{
    public interface IAccountRepository
    {
        void AddUser(Account user);
        bool VerifyUser(string mailId);
        Account ValidateLogin(string mailId, string password);
        IEnumerable<Account> GetCustomerList();
        int GenerateUserID();
    }
}
