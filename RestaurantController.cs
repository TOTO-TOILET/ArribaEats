
namespace Arriba_eat;
public class RestaurantController : UserController
{
    private Restaurant _restaurant;

    public RestaurantController(Restaurant restaurant)
    {
        _restaurant = restaurant;
    }
    public void AddMenuItem(string menuItemName, double menuItemPrice)
    {
        _restaurant.menuItems.Add(menuItemName, menuItemPrice);
        Console.WriteLine($"New item added {menuItemName}: {menuItemPrice}");
    }

    public void PrepareOrder(Order order)
    {
        order.status = OrderStatus.Preparing;
    }

    public void FinishCooking(Order order)
    {
        order.status = OrderStatus.Ready;
    }

    public void HandoutOrder(Order order)
    {
        order.status = OrderStatus.OutForDelivery;
        Console.WriteLine($"Order: {order.orderID} is out for delivery");
    }
    
    /// <summary>
    /// This fetches order based on order id input
    /// <param name="id">order id</param>
    /// <returns>Order object</returns>
    public Order GetOrderById(int id)
    {
        return _restaurant.orders.FirstOrDefault(o => o.orderID == id);
    }
    
    public List<Order> GetAllOrdersPending()
    {
        return _restaurant.orders.Where(o => o.status == OrderStatus.Pending).ToList();
    }
    
    public List<Order> GetAllOrdersPreparing()
    {
        return _restaurant.orders.Where(o => o.status == OrderStatus.Preparing).ToList();
    }
    
    public List<Order> GetAllOrdersReady()
    {
        return _restaurant.orders.Where(o => o.status == OrderStatus.Ready).ToList();
    }
}