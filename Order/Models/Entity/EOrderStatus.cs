namespace Services.Order.Models.Entity
{
    public enum EOrderStatus
    {
        OrderPlaced = 0,
        ShipmentReady = 10,
        Shipped = 20,
        Received = 30,
        Cancelled = -10
    }
}
