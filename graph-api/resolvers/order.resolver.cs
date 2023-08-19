using GraphApi.Dto;
using GraphApi.Models;
using GraphApi.Services;
using GraphQL;

namespace GraphApi.Resolvers;

public class OrderResolver
{
  public static Func<IResolveFieldContext, Task<Order>> getOrder = (context) =>
    {
      var orderId = context.GetArgument<Guid>("id");

      var order = new Order(orderId, "Order 1", "Description 1", 100);

      return Task.FromResult(order);
    };

  public static Func<IResolveFieldContext, Task<Order>> saveOrder = (context) =>
    {
      var order = context.GetArgument<OrderDto>("order");

      var result = new Order(Guid.NewGuid(), order.Name, order.Description, order.Total);
      var service = context.RequestServices!.GetRequiredService<OrderService>();

      return service.Execute(result);
    };
}
