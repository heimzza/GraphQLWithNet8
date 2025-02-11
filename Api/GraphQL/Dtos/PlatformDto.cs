using GraphQLWithNet8.Data;
using GraphQLWithNet8.Models;

namespace GraphQLWithNet8.GraphQL.Dtos;

public class PlatformDto : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents a software or service that has CLI.");

        descriptor
            .Field(q => q.LicenseKey)
            .Ignore();   

        descriptor
            .Field(q => q.Commands)
            .ResolveWith<Resolvers>(q => q.GetCommands(default!, default!))
            .Description("This is the list of available commands for this platform.");

        base.Configure(descriptor);
    }

    private class Resolvers
    {
        public IQueryable<Command> GetCommands(Platform platform, [Service] AppDbContext context)
        {
            return context.Commands.Where(p => p.PlatformId == platform.Id);
        }
    }
}