using GraphApi.Models;
using GraphApi.Services;
using GraphApi.Types;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace GraphApi.Schema;

public class Subscriptions : ObjectGraphType
{
  private readonly OrderService _orderService;
  public Subscriptions(OrderService orderService)
  {
    _orderService = orderService;
    AddField(new FieldType
    {
      Name = "orderAdded",
      Type = typeof(OrderNotificationType),
      StreamResolver = new SourceStreamResolver<OrderNotification>(Subscribe),
    });
  }

  private IObservable<OrderNotification> Subscribe(IResolveFieldContext context)
  {
    return _orderService.SubscribeEvents();
  }
}
