using GraphApi.Models;
using GraphQL.Types;

namespace GraphApi.Types;

public class OrderType : ObjectGraphType<Order>
{
  public OrderType()
  {
    Field<IdGraphType>("id").Resolve(ctx => ctx.Source.Id.ToString()).Description("The Id of the Order.");
    Field(x => x.Name).Description("The name of the Order");
    Field(x => x.Description).Description("The description of the Order");
    Field(x => x.Total).Description("The total of the Order");
  }
}
