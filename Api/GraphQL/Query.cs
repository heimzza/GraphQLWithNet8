using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithNet8.GraphQL;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatforms([Service] AppDbContext context)
    {
        return context.Platforms.AsNoTracking();
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommands([Service] AppDbContext context)
    {
        return context.Commands.AsNoTracking() 
            ?? throw new GraphQLException("No commands found");
    }
}