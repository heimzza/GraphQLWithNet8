using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;

namespace GraphQLWithNet8.GraphQL;

public class Query 
{
    public IQueryable<Platform> GetPlatforms([Service] AppDbContext context)
    {
        return context.Platforms;
    }

}