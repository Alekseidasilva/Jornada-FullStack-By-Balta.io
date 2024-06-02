using System.Reflection;
using Fina.Api.Data.Mappings;
using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) {}

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Transation> Transations { get; set; }= null!;
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     //   modelBuilder.ApplyConfiguration(new CategoryMapping());
       // modelBuilder.ApplyConfiguration(new TransationMapping());

       modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}