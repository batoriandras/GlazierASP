using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Service> Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> ctx) : base(ctx) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
