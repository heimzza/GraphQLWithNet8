using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithNet8.GraphQL;

public class Query
{
    [UseProjection]
    public IQueryable<Platform> GetPlatforms([Service] IDbContextFactory<AppDbContext> dbContextFactory)
    {
        var context = dbContextFactory.CreateDbContext();
        return context.Platforms.AsNoTracking(); // Improves performance
    }

    [UseProjection]
    public IQueryable<Command> GetCommands([Service] IDbContextFactory<AppDbContext> dbContext)
    {
        var context = dbContext.CreateDbContext();
        return context.Commands.AsNoTracking();
    }
}