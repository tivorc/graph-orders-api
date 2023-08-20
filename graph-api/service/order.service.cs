using System.Reactive.Linq;
using System.Reactive.Subjects;
using GraphApi.Models;

namespace GraphApi.Services;

public class OrderService
{
  private readonly ISubject<OrderNotification> _orderStream = new ReplaySubject<OrderNotification>(1);

  public async Task<Order> Execute(Order order)
  {
    var orderNotification = GenerateOrderNotification(order);

    _orderStream.OnNext(orderNotification);
    
    return await Task.FromResult(order);
  }

  public async ValueTask<IObservable<OrderNotification>> Notifications()
  {
    await Task.Delay(100).ConfigureAwait(false);
    return _orderStream.AsObservable();
  }

  public OrderNotification GenerateOrderNotification(Order order)
  {
    var notification = new OrderNotification(order, "Created");
    return notification;
  }
}