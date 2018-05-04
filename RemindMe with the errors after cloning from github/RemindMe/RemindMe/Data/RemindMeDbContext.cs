using RemindMe.Models;
using Microsoft.EntityFrameworkCore;

namespace RemindMe.Data
{
    public class RemindMeDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<RecurringReminders> RecurringReminders { get; set; }
        public DbSet<NonRecurringReminders> NonRecurringReminders { get; set; }
        public DbSet<EventTypesRecurring> EventTypesRecurring { get; set; }
        public DbSet<EventTypesNonRecurring> EventTypesNonRecurring { get; set; }

        
        public RemindMeDbContext(DbContextOptions<RemindMeDbContext> options)
              : base(options)
        { }

        /*
        This method will set the primary key of the UserEventTypesNonRecurring class and table to be a composite key, consisting of both NonRecurringEventId  and UserId.
        (Many-to-Many relationship between User and EventTypesNonRecurring  and 
        will set the primary key of the UserEventTypesRecurring class and table to be a composite key, consisting of both RecurringEventId  and UserId.
        Many-to-Many relationship between User and EventTypesRecurring  and)
                              
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEventTypesNonRecurring>()
                .HasKey(c => new {c.UserId, c.NonRecurringEventId });

            modelBuilder.Entity<UserEventTypesRecurring>()
                .HasKey(c => new { c.UserId, c.RecurringEventId });


        }
        
    }
}
