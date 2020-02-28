using OnlineEventManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace OnlineEventManagement.DAL
{
    public class OnlineEventManagementDBContext:DbContext
    {
        public OnlineEventManagementDBContext() : base("EventManagement")
        {

        }
        public DbSet<UserManager> UserDB { get; set; }
    }
}
