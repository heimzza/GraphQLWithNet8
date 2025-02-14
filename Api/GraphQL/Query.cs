using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithNet8.GraphQL;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatforms([Service] IDbContextFactory<AppDbContext> contextFactory)
    {
        // Don't dispose the context as the IQueryable needs it
        var context = contextFactory.CreateDbContext();
        return context.Platforms.AsNoTracking();
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommands([Service] IDbContextFactory<AppDbContext> contextFactory)
    {
        var context = contextFactory.CreateDbContext();
        return context.Commands.AsNoTracking();
    }
}
