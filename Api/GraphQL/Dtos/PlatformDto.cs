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
    }
}