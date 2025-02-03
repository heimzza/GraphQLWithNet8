using GraphQLWithNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithNet8.Data;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Platform> Platforms{ get; set; }
}