namespace Arriba_eat;
public enum OrderStatus
{
    Pending,
    Preparing,
    Ready,
    OutForDelivery,
    Delivered
}
public class Order
{
    public int orderID { get; set; }
    public Dictionary<MenuItem, int> orderItems { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    public OrderStatus status {get;set;}
    public Deliverer? deliverer {get;set;}//nullable(when the order placed the deliverer will not be assigned yet
    
    public Customer customer {get;set;}

    public Order(int orderId, Dictionary<MenuItem, int> orderItems, Customer customer)
    {
        this.orderID = orderId;
        status = OrderStatus.Pending; // when the order class instantiated the order status should start with Pending
        this.orderItems = orderItems;
        this.customer = customer;
    }
}                                   