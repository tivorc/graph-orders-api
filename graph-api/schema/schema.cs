namespace GraphApi.Schema;

public class OrderSchema : GraphQL.Types.Schema
{
  public OrderSchema(IServiceProvider serviceProvider) : base(serviceProvider)
  {
    Query = serviceProvider.GetRequiredService<Queries>();
    Mutation = serviceProvider.GetRequiredService<Mutations>();
    Subscription = serviceProvider.GetRequiredService<Subscriptions>();
  }
}
