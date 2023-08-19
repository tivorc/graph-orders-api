namespace GraphApi.Models;

public class OrderNotification
{
  public Order Order { get; set; }
  public string Action { get; set; }
  public DateTime At { get; set; }

  public OrderNotification(Order order, string action)
  {
    Order = order;
    Action = action;
    At = DateTime.Now;
  }
}