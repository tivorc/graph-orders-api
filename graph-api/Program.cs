using GraphApi.Schema;
using GraphApi.Services;
using GraphQL;
using GraphQL.DataLoader;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<PersonService>();

builder.Services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
builder.Services.AddSingleton<DataLoaderDocumentListener>();

builder.Services.AddGraphQL(b => b // GraphQL.Server.Transports.AspNetCore
  .AddSchema<OrderSchema>()
  .AddDataLoader()
  .AddSystemTextJson()
  .AddGraphTypes(typeof(OrderSchema).Assembly)
);

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(builder =>
  {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();
app.UseWebSockets();
app.UseGraphQL<OrderSchema>("/api/graphql");
app.UseGraphQLPlayground(
  "/",                               // url to host Playground at
  new GraphQL.Server.Ui.Playground.PlaygroundOptions
  {
      GraphQLEndPoint = "/api/graphql",         // url of GraphQL endpoint
      SubscriptionsEndPoint = "/api/graphql",   // url of GraphQL endpoint
  });

await app.RunAsync();
