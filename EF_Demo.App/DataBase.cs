using Microsoft.EntityFrameworkCore;

namespace EF_Demo.App;

public sealed class DataBase : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DataBase()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    } 
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=users.db");
    }
}