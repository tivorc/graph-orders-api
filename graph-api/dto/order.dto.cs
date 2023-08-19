namespace GraphApi.Dto;

public class OrderDto
{
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Total { get; set; }

  public OrderDto(string name, string description, decimal total)
  {
    Name = name;
    Description = description;
    Total = total;
  }
}
