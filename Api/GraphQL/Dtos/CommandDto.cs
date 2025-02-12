using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;

namespace GraphQLWithNet8.GraphQL.Dtos;

public class CommandDto : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command.");

        descriptor
            .Field(q => q.Platform)
            .ResolveWith<Resolvers>(q => q.GetPlatform(default!, default!));
    }

    private class Resolvers
    {
        public Platform GetPlatform(Command command, [Service] AppDbContext context)
        {
            return context.Platforms.FirstOrDefault(q => q.Id == command.PlatformId);
        }
    }
}