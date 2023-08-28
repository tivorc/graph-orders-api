using GraphApi.Models;
using GraphQL.Types;
using GraphQL.DataLoader;
using GraphApi.Services;

namespace GraphApi.Types;

public class OrderType : ObjectGraphType<Order>
{
  public OrderType(IDataLoaderContextAccessor accessor, PersonService personService)
  {
    Field<IdGraphType>("id").Resolve(ctx => ctx.Source.Id.ToString()).Description("The Id of the Order.");
    Field(x => x.Name).Description("The name of the Order");
    Field(x => x.Description).Description("The description of the Order");
    Field(x => x.Total).Description("The total of the Order");
    Field<OrderStatusEnum>("status").Resolve(context => context.Source.Status);
    Field<PersonType, Person>("waiter")
      .ResolveAsync(context =>
      {
        var loader = accessor.Context!.GetOrAddBatchLoader<Guid, Person>(
          "person.role", personService.GetOneByEnumerableOrderId
        );
        return loader.LoadAsync(context.Source.Id);
      }
    );
  }
}
