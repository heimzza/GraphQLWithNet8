using GraphQLWithNet8.Models;

namespace GraphQLWithNet8.GraphQL;

public class Subscription
{
    [Topic, Subscribe]
    public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;

    [Topic, Subscribe]
    public Command OnCommandAdded([EventMessage] Command command) => command;
}