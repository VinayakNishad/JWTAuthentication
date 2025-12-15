using Microsoft.EntityFrameworkCore;
using AuthApi.Models;


namespace AuthApi.Data;


public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();
    }
}