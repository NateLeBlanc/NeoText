using Microsoft.EntityFrameworkCore;
using NeoText.Domain.Models;

namespace NeoText.Database;
public class UserDbContext : DbContext
{
    public DbSet<User> User { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasKey(client => client.UserId);
    }
}
