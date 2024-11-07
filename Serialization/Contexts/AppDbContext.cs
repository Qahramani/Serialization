using Microsoft.EntityFrameworkCore;

namespace Serialization.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Person> People { get; set; } = null!;
}
