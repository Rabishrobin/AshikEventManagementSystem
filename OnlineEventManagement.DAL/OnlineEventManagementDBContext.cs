using OnlineEventManagementSystem.Entity;
using System.Data.Entity;

namespace OnlineEventManagement.DAL
{
    public class OnlineEventManagementDBContext:DbContext
    {
        public OnlineEventManagementDBContext() : base("EventManagement")
        {

        }
        public DbSet<Account> UserDB { get; set; }
        public DbSet<Event> EventDB { get; set; }
    }
}
