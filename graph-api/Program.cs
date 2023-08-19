using GraphApi.Schema;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQL(b => b // GraphQL.Server.Transports.AspNetCore
  .AddSchema<OrderSchema>()
  .AddSystemTextJson()
  .AddGraphTypes(typeof(OrderSchema).Assembly)
);

builder.Services.AddHttpContextAccessor();

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
app.UseGraphQL<OrderSchema>("/api/graphql");

app.Run();
