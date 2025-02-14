using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithNet8.GraphQL.Dtos;

public class CommandDto : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command.");

        descriptor
            .Field(c => c.Platform)
            .ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!))
            .Type<ObjectType<Platform>>();
    }

    private class Resolvers
    {
        public Platform? GetPlatform(
            [Parent] Command command, 
            [Service] IDbContextFactory<AppDbContext> contextFactory)
        {
            var context = contextFactory.CreateDbContext();
            return context.Platforms
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == command.PlatformId);
        }
    }
}
