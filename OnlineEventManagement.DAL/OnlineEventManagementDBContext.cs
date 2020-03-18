using OnlineEventManagementSystem.Entity;
using System.Data.Entity;

namespace OnlineEventManagement.DAL
{
    public class OnlineEventManagementDBContext:DbContext
    {
        public OnlineEventManagementDBContext() : base("EventManagement")
        {

        }
        public DbSet<Account> Users { get; set; }           //Dbset of the user details table
        public DbSet<Event> Events { get; set; }            //Dbset of the event details table
        public DbSet<Service> Services { get; set; }        //Dbset of the service details table
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Service>().MapToStoredProcedures();
        //}
    }
}
