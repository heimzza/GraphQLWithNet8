using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;

namespace GraphQLWithNet8.GraphQL.Dtos;

public class CommandDto : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command.");

        descriptor
            .Field(c => c.Id)
            .Type<NonNullType<IntType>>();

        descriptor
            .Field(c => c.HowTo)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(c => c.CommandLine)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(c => c.PlatformId)
            .Type<NonNullType<IntType>>();

        descriptor
            .Field(c => c.Platform)
            .ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!))
            .Type<NonNullType<ObjectType<Platform>>>();
    }

    private class Resolvers
    {
        public Platform GetPlatform([Parent] Command command, [Service] AppDbContext context)
        {
            return context.Platforms
                .FirstOrDefault(p => p.Id == command.PlatformId) 
                ?? throw new GraphQLException($"Platform with ID {command.PlatformId} not found");
        }
    }
}
