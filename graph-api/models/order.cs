namespace GraphApi.Models;

public class Order
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Total { get; set; }

  public Order(Guid id, string name, string description, decimal total)
  {
    Id = id;
    Name = name;
    Description = description;
    Total = total;
  }
}
