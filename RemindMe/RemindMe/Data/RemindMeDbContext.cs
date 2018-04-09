using RemindMe.Models;
using Microsoft.EntityFrameworkCore;

namespace RemindMe.Data
{
    public class RemindMeDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        

        public RemindMeDbContext(DbContextOptions<RemindMeDbContext> options)
              : base(options)
        { }

        
    }
}
