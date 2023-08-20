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
      Name = "order",
      Type = typeof(OrderNotificationType),
      StreamResolver = new SourceStreamResolver<OrderNotification>(SubscribeAsync),
    });
  }

  private async ValueTask<IObservable<OrderNotification?>> SubscribeAsync(IResolveFieldContext context)
  {
    return await _orderService.Notifications().ConfigureAwait(false);
  }
}
