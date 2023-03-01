using Microsoft.EntityFrameworkCore;

namespace FirstApp;

internal class ApplicationContext : DbContext
{
    public ApplicationContext() => Database.EnsureCreated();

    private string _connectionString;// = "server=localhost;user=tester;password=tester;database=cdpo;TrustServerCertificate=True";

    public DbSet<Client> Clients => Set<Client>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}