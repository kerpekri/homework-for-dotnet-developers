namespace SolidPrinciples.Orders;

public class OrderEntity
{
    public string OrderNumber { get; set; }
    public IEnumerable<OrderEntityLine> DraftLines { get; set; }
    public IEnumerable<OrderEntityLine> OtherLines { get; set; }
}

public class OrderEntityLine
{
    public string ItemNumber { get; set; }
    public int Quantity { get; set; }
}