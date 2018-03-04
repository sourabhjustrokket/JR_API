using Microsoft.EntityFrameworkCore;
using JR_API.Entities;

namespace JR_API.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}