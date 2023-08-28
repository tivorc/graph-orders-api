using GraphApi.Models;

namespace GraphApi.Dto;

public class OrderDto
{
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Total { get; set; }
  public string WaiterId { get; set; }

  public OrderDto(string name, string description, decimal total, string waiterId)
  {
    Name = name;
    Description = description;
    Total = total;
    WaiterId = waiterId;
  }

  public Order ToEntity() {
    var waiter = new Person(new Guid(WaiterId), "");
    return new Order(new Guid("4b893e5a-0e33-41f0-985b-f244571aad55"), Name, Description, Total, OrderStatus.REGISTRADO) {
      Waiter = waiter
    };
  }
}
