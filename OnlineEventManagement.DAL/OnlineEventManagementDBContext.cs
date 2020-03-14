using OnlineEventManagementSystem.Entity;
using System.Data.Entity;

namespace OnlineEventManagement.DAL
{
    public class OnlineEventManagementDBContext:DbContext
    {
        public OnlineEventManagementDBContext() : base("EventManagement")
        {

        }
        public DbSet<Account> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Service> Services { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().MapToStoredProcedures();
        }
    }
}
