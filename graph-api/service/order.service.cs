using System.Reactive.Subjects;
using GraphApi.Models;

namespace GraphApi.Services;

public class OrderService
{
  private readonly Subject<OrderNotification> _broadcaster = new();

  public async Task<Order> Execute(Order order)
  {
    if (order.Waiter is null)
      throw new ArgumentException("Waiter is required");

    var dbPeople = new List<Person> {
      new Person(new Guid("17f60984-756b-44b6-9302-04a8cc2524c1"), "Waiter 1"),
      new Person(new Guid("88b73e97-b6b8-4540-87b7-b7530feccda4"), "Waiter 2"),
      new Person(new Guid("eeee02d3-75e7-46cb-9fe1-0d1f15723c07"), "Waiter 3"),
    };

    var waiter = dbPeople.FirstOrDefault(x => x.Id == order.Waiter.Id);
    order.Waiter = waiter;

    var notification = new OrderNotification(order, "Created");

    _broadcaster.OnNext(notification);
    
    return await Task.FromResult(order);
  }

  public Task<List<Order>> GetOrders(DateTime datetime)
  {
    var dbOrders = new List<Order> {
      new Order(new Guid("4b893e5a-0e33-41f0-985b-f244571aad55"), "Order 1", "", 14, OrderStatus.REGISTRADO) { Waiter = new Person(new Guid("17f60984-756b-44b6-9302-04a8cc2524c1"), "Waiter 1") },
      new Order(new Guid("eda7948b-781d-4db3-a323-1c534e143362"), "Order 2", "", 432, OrderStatus.ATENDIDO) { Waiter = new Person(new Guid("88b73e97-b6b8-4540-87b7-b7530feccda4"), "Waiter 2") },
      new Order(new Guid("78ee8568-d0a9-4496-84ac-876f44226b70"), "Order 3", "", 432, OrderStatus.PAGADO) { Waiter = new Person(new Guid("eeee02d3-75e7-46cb-9fe1-0d1f15723c07"), "Waiter 3") },
    };

    return Task.FromResult(dbOrders);
  }

  public Task<Order?> GetOrder(Guid id)
  {
    var dbOrders = new List<Order> {
      new Order(new Guid("4b893e5a-0e33-41f0-985b-f244571aad55"), "Order 1", "", 14, OrderStatus.REGISTRADO) { Waiter = new Person(new Guid("17f60984-756b-44b6-9302-04a8cc2524c1"), "Waiter 1") },
      new Order(new Guid("eda7948b-781d-4db3-a323-1c534e143362"), "Order 2", "", 432, OrderStatus.ATENDIDO) { Waiter = new Person(new Guid("88b73e97-b6b8-4540-87b7-b7530feccda4"), "Waiter 2") },
      new Order(new Guid("78ee8568-d0a9-4496-84ac-876f44226b70"), "Order 3", "", 432, OrderStatus.PAGADO) { Waiter = new Person(new Guid("eeee02d3-75e7-46cb-9fe1-0d1f15723c07"), "Waiter 3") },
    };

    var order = dbOrders.FirstOrDefault(x => x.Id == id);

    return Task.FromResult(order);
  }

  public IObservable<OrderNotification> SubscribeEvents() => _broadcaster;

  public Task OrderNotification(Order order)
  {
    var notification = new OrderNotification(order, "Created");

    _broadcaster.OnNext(notification);

    return Task.CompletedTask;
  }
}
