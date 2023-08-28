using GraphApi.Dto;
using GraphApi.Models;
using GraphApi.Services;
using GraphQL;

namespace GraphApi.Resolvers;

public class OrderResolver
{
  public static Func<IResolveFieldContext, Task<Order?>> getOrder = (context) =>
    {
      var orderId = context.GetArgument<Guid>("id");
      var service = context.RequestServices!.GetRequiredService<OrderService>();

      return service.GetOrder(orderId);
    };

  public static Func<IResolveFieldContext, Task<List<Order>>> getOrders = (context) =>
    {
      var date = context.GetArgument<DateTime>("date");

      var service = context.RequestServices!.GetRequiredService<OrderService>();

      return service.GetOrders(date);
    };

  public static Func<IResolveFieldContext, Task<Order>> saveOrder = (context) =>
    {
      var order = context.GetArgument<OrderDto>("order");

      var service = context.RequestServices!.GetRequiredService<OrderService>();

      return service.Execute(order.ToEntity());
    };
}
