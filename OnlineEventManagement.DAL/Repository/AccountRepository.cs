using OnlineEventManagement.DAL;
using OnlineEventManagement.DAL.Interface;
using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEventManagement.Repository.DAL
{
    public class AccountRepository : IAccountRepository
    {
        public void AddUser(Account user)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                context.Users.Add(user);        //Adding the user details to the conext
                context.SaveChanges();          //Saving the changes to the database
            }
        }
        public bool VerifyUser(string mailId)
        {
            bool CanAddUser = false;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                //Verifying the existance of the user
                if(context.Users.Where(u => u.UserMailId == mailId).FirstOrDefault() == null)
                {
                    CanAddUser = true;
                }
            }
            return CanAddUser;
        }
        public Account ValidateLogin(string mailId,string password)
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                Account user = context.Users.Where(u => u.UserMailId == mailId && u.UserPassword == password).FirstOrDefault();     //Verfying the user mailid and password
                return user;
            }
        }
        public IEnumerable<Account> GetCustomerList()
        {
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                return context.Users.ToList();                         //Getting all the user details from the database as a list
            }
        }
        public int GenerateUserID()
        {
            int id = 0;
            int userID;
            using (OnlineEventManagementDBContext context = new OnlineEventManagementDBContext())
            {
                //Getting the latest user id
                id = int.Parse(context.Users.ToList().Last().UserID.ToString().Substring(4))+1;
                //Generating user id
                userID= int.Parse((int)'C' + DateTime.Now.Year.ToString().Substring(2, 2) + id.ToString().PadLeft(3, '0'));
            }
            return userID;
        }
    }
}
