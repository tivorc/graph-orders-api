using GraphApi.Schema;
using GraphApi.Services;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<OrderService>();
builder.Services.AddGraphQL(b => b // GraphQL.Server.Transports.AspNetCore
  .AddSchema<OrderSchema>()
  .AddSystemTextJson()
  .AddGraphTypes(typeof(OrderSchema).Assembly)
);

// builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(builder =>
  {
    builder
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

app.UseCors();
app.UseWebSockets();
app.UseGraphQL<OrderSchema>("/api/graphql");

app.Run();
