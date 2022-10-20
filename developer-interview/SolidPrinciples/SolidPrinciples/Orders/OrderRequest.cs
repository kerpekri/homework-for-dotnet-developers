namespace SolidPrinciples.Orders;

public class OrderRequest
{
    public string OrderNumber { get; set; }
    public IEnumerable<OrderRequestLine> Lines { get; set; }
}

public class OrderRequestLine
{
    public string ItemNumber { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
}