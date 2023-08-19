using GraphQL.Types;

namespace GraphApi.Inputs;
public class OrderInputType : InputObjectGraphType
{
  public OrderInputType()
  {
    Name = "OrderInput";
    Field<NonNullGraphType<StringGraphType>>("name");
    Field<NonNullGraphType<StringGraphType>>("description");
    Field<NonNullGraphType<DecimalGraphType>>("total");
  }
}
