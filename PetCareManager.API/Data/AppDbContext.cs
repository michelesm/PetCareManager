public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }
}