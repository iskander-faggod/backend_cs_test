using CSBackendTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CSBackendTest.Data.Context;

public sealed class BackendTestContext : DbContext
{
    public DbSet<Customer> Customers { get; private set; } = null!;
    
    public BackendTestContext(DbContextOptions<BackendTestContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            Name = "default",
            Surname = "default",
            Id = Guid.NewGuid(),
        });
        base.OnModelCreating(modelBuilder);
    }
}