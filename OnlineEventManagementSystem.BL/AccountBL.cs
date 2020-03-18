﻿using OnlineEventManagement.Repository.DAL;
using OnlineEventManagementSystem.Entity;

namespace OnlineEventManagementSystem.BL
{
    public class AccountBL
    {
        public static void AddUser(Account user)
        {
            AccountRepository.AddUser(user);        //Adding user details
        }
        public static Account ValidateLogIn(string username,string password)
        {
           return AccountRepository.VerifyMailId(username, password);           //Verifying the user mail id and password
        }
    }
}
