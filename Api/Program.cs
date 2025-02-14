using GraphQL.Server.Ui.Voyager;
using GraphQLWithNet8.Data;
using GraphQLWithNet8.GraphQL;
using GraphQLWithNet8.GraphQL.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<PlatformDto>()
    .AddType<CommandDto>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.UseGraphQLVoyager(
    path: "/graphql-voyager", 
    options: new VoyagerOptions()
    {
        GraphQLEndPoint = "/graphql",
    }
);

app.Run();