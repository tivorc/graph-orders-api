using GraphApi.Resolvers;
using GraphApi.Types;
using GraphQL.Types;

namespace GraphApi.Schema;
public class Queries : ObjectGraphType<object>
{
  public Queries()
  {
    Name = "Queries";
    Field<OrderType>("order")
      .Argument<NonNullGraphType<IdGraphType>>("id", "Unique identifier of the order")
      .ResolveDelegate(OrderResolver.getOrder);
    Field<NonNullGraphType<StringGraphType>>("hello")
      .Resolve(context => "Hello World from Chepén!");
  }
}
