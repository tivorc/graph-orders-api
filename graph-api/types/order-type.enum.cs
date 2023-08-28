using GraphQL.Types;
using GraphApi.Models;

namespace GraphApi.Types
{
  public class OrderStatusEnum : EnumerationGraphType<OrderStatus>
  {
    public OrderStatusEnum()
    {
      Name = "OrderStatusEnum";
      Description = "Order status";
    }
  }
}
