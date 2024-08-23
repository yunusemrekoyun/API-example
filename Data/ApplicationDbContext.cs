// Data klasörü içinde ApplicationDbContext.cs dosyası
using Microsoft.EntityFrameworkCore;
using TransferApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}


