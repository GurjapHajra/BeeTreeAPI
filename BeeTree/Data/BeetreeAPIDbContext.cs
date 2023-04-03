using BeeTree.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeTree.Data
{
    public class BeetreeAPIDbContext : DbContext
    {
        public BeetreeAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UserData { get; set; }

    }
}
