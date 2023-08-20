using System.Reactive.Subjects;
using GraphApi.Models;

namespace GraphApi.Services;

public class OrderService
{
  private readonly Subject<OrderNotification> _broadcaster = new();

  public async Task<Order> Execute(Order order)
  {
    var orderNotification = GenerateOrderNotification(order);

    _broadcaster.OnNext(orderNotification);
    
    return await Task.FromResult(order);
  }

  public IObservable<OrderNotification> SubscribeEvents() => _broadcaster;

  public OrderNotification GenerateOrderNotification(Order order)
  {
    var notification = new OrderNotification(order, "Created");
    return notification;
  }
}