using GraphApi.Models;
using GraphQL.Types;

namespace GraphApi.Types;

public class PersonType : ObjectGraphType<Person>
{
  public PersonType()
  {
    Field<IdGraphType>("id").Resolve(ctx => ctx.Source.Id.ToString()).Description("The Id of the Person.");
    Field(x => x.Name).Description("The name of the Person");
  }
}
