using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    //constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configurations
        //burası ne yapıyor araştır???
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //Ignores
        modelBuilder.Ignore<User>();
        modelBuilder.Ignore<Role>();
        modelBuilder.Ignore<UserRole>();
        modelBuilder.Ignore<RoleClaim>();
        modelBuilder.Ignore<UserToken>();
        modelBuilder.Ignore<UserClaim>();
        modelBuilder.Ignore<UserLogin>();






        
        base.OnModelCreating(modelBuilder);
    }
}