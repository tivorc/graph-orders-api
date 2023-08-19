using GraphApi.Models;
using GraphQL.Types;

namespace GraphApi.Types;

public class OrderNotificationType : ObjectGraphType<OrderNotification>
{
  public OrderNotificationType()
  {
    Field<OrderType>("order").Resolve(context => context.Source.Order);
    Field(x => x.Action).Description("The description of the Order");
    Field(x => x.At).Description("The total of the Order");
  }
}
