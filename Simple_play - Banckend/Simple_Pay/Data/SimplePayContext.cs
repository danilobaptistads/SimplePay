using Microsoft.EntityFrameworkCore;

namespace Simple_Pay.Data;

internal class SimpleplayContext : DbContext
{
    private string connectionString = "Server=127.0.0.1,1433;Database=SimplePayDB;user ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}