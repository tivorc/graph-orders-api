using GraphApi.Inputs;
using GraphApi.Resolvers;
using GraphApi.Types;
using GraphQL.Types;

namespace GraphApi.Schema;

public class Mutations : ObjectGraphType<object>
{
  public Mutations()
  {
    Field<OrderType>("saveOrder")
      .Argument<OrderInputType>("order")
      .ResolveDelegate(OrderResolver.saveOrder);
  }
}
