using GraphApi.Models;

namespace GraphApi.Services;

public class PersonService
{
  public async Task<IDictionary<Guid, Person>> GetOneByEnumerableOrderId(IEnumerable<Guid> ids)
  {
    var dbOrders = new List<Order> {
      new Order(new Guid("4b893e5a-0e33-41f0-985b-f244571aad55"), "Order 1", "", 14, OrderStatus.REGISTRADO) { Waiter = new Person(new Guid("17f60984-756b-44b6-9302-04a8cc2524c1"), "Waiter 1") },
      new Order(new Guid("eda7948b-781d-4db3-a323-1c534e143362"), "Order 2", "", 432, OrderStatus.ATENDIDO) { Waiter = new Person(new Guid("88b73e97-b6b8-4540-87b7-b7530feccda4"), "Waiter 2") },
      new Order(new Guid("78ee8568-d0a9-4496-84ac-876f44226b70"), "Order 3", "", 432, OrderStatus.PAGADO) { Waiter = new Person(new Guid("eeee02d3-75e7-46cb-9fe1-0d1f15723c07"), "Waiter 3") },
    };

    var orders = dbOrders.Where(x => ids.Contains(x.Id));
    var dictionary = new Dictionary<Guid, Person>();
    foreach (var order in orders)
    {
      if(order.Waiter != null)
        dictionary.Add(order.Id, order.Waiter);
    }
    return await Task.FromResult<IDictionary<Guid, Person>>(dictionary);
  }
}
