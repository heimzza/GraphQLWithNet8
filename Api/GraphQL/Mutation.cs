using GraphQLWithNet8.Data;
using GraphQLWithNet8.GraphQL.Dtos;
using GraphQLWithNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithNet8.GraphQL;

public class Mutation
{
    public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
        [Service] IDbContextFactory<AppDbContext> contextFactory)
    {
        var context = contextFactory.CreateDbContext();

        var platform = new Platform{
            Name = input.Name,
            LicenseKey = input.LicenseKey
        };

        context.Platforms.Add(platform);

        await context.SaveChangesAsync();

        return new AddPlatformPayload(platform);
    }

    public async Task<AddCommandPayload> AddCommandPayloadAsync(AddCommandInput input,
        [Service] IDbContextFactory<AppDbContext> contextFactory)
    {
        var context = contextFactory.CreateDbContext();

        var command = new Command
        {
            HowTo = input.HowTo,
            CommandLine = input.CommandLine,
            PlatformId = input.PlatformId
        };

        context.Commands.Add(command);

        await context.SaveChangesAsync();

        return new AddCommandPayload(command);
    }
}