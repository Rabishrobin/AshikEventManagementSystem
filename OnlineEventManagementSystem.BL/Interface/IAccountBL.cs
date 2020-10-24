using OnlineEventManagementSystem.Entity;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.BL.Interface
{
    public interface IAccountBL
    {
        void AddUser(Account user);
        bool VerifyUser(string mailId);
        Account ValidateLogin(string mailId, string password);
        IEnumerable<Account> GetCustomerList();
        int GenerateUserID();
    }
}
