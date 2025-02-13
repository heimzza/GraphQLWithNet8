using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithNet8.GraphQL;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatforms([Service] IDbContextFactory<AppDbContext> dbContextFactory)
    {
        var context = dbContextFactory.CreateDbContext();
        return context.Platforms.AsNoTracking();
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommands([Service] IDbContextFactory<AppDbContext> dbContext)
    {
        var context = dbContext.CreateDbContext();
        return context.Commands.AsNoTracking();
    }
}