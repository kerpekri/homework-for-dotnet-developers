namespace SolidPrinciples.Orders;

public class OrderProcessor
{
    public void ProcessOrder(OrderRequest request)
    {
        var entity = new OrderEntity
        {
            OrderNumber = request.OrderNumber,
        };

        var draftLines = new List<OrderEntityLine>();
        var otherLines = new List<OrderEntityLine>();

        foreach (var requestLine in request.Lines)
        {
            if (requestLine.Status == "DRAFT")
            {
                var entityLine = new OrderEntityLine
                {
                    Quantity = requestLine.Quantity,
                    ItemNumber = requestLine.ItemNumber,
                };
                draftLines.Add(entityLine);
            }
            else
            {
                var otherLine = new OrderEntityLine
                {
                    Quantity = requestLine.Quantity,
                    ItemNumber = requestLine.ItemNumber,
                };
                otherLines.Add(otherLine);
            }
        }

        entity.DraftLines = draftLines;
        entity.OtherLines = otherLines;
        SaveOrderInDB(entity);
    }

    private void SaveOrderInDB(OrderEntity entity)
    {
        //Do the saving logic here
    }
}