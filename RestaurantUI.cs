namespace Arriba_eat;

public class RestaurantUI:UserUI
{
    private RestaurantController _restaurantController;
    private Restaurant _restaurant;
    public RestaurantUI(RestaurantController controller, Restaurant restaurant)
    {
        _restaurantController = controller;
        _restaurant = restaurant;
    }

    private void AskItemDetail(out string name, out double price)
    {
        Console.WriteLine("Please enter a name: ");
        name = Console.ReadLine();
        Console.WriteLine("Please enter a price: ");
        while (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.Write("Invalid input. Please enter a valid price: ");
        }
    }

    private void DisplayMenuItems()
    {
        int index = 1;
        foreach (var menu in _restaurant.menuItems)
        {
            Console.WriteLine($"{index}. {menu.Key}: ${menu.Value}");
            index++;
        }
    }

    private Order DisplayOrdersRecieved() // still have to implement error handling in case there is no orders yet
    {
        var orders = _restaurantController.GetAllOrdersPending();
        if (!orders.Any())
        {
            Console.WriteLine("There are no orders recieved.");
            return null;
        }
        
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.orderID}. {order.customer.name}");
        }

        Console.WriteLine("Select order by order ID: ");
        if (int.TryParse(Console.ReadLine(), out int orderID))
        {
            var selectedOrder = _restaurantController.GetOrderById(orderID);
            if (selectedOrder != null)
            {
                return selectedOrder;
            }
            else
            {
                Console.WriteLine("Order not found");
                return null;
            }
        }

        return null;
    }
    
    private Order DisplayOrdersPreparing() // still have to implement error handling in case there is no orders yet
    {
        var orders = _restaurantController.GetAllOrdersPreparing();
        if (!orders.Any())
        {
            Console.WriteLine("There are no orders found.");
            return null;
        }
        
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.orderID}. {order.customer.name}");
        }

        Console.WriteLine("Select order by order ID: ");
        if (int.TryParse(Console.ReadLine(), out int orderID))
        {
            var selectedOrder = _restaurantController.GetOrderById(orderID);
            if (selectedOrder != null)
            {
                return selectedOrder;
            }
            else
            {
                Console.WriteLine("Order not found");
                return null;
            }
        }

        return null;
    }

    private Order DisplayDelivererArrived()
    {
        var deliverers
    }
    
    
    public override void DisplayMainMenu()
    {
        base.DisplayMainMenu();
        Console.WriteLine("2. Add new item to menu");
        Console.WriteLine("3. See current restaurant menu");
        Console.WriteLine("4. Start cooking order");
        Console.WriteLine("5. Finish cooking order");
        Console.WriteLine("6. Handle deliverer arrived");
        Console.WriteLine("7. Log out");
        
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                DisplayUserInfo(_restaurant);
                break;
            case 2:
                AskItemDetail(out string name, out double price);
                _restaurantController.AddMenuItem(name, price);
                break;
            case 3:
                DisplayMenuItems();
                break;
            case 4:
                Order OrderToCook = DisplayOrdersRecieved();
                _restaurantController.PrepareOrder(OrderToCook);
                break;
            case 5:
                Order PreparedOrder= DisplayOrdersPreparing();
                _restaurantController.FinishCooking(PreparedOrder);
                break;
            case 6:
                //DisplayDelivererArrived() -> Deliverer deliverer, Order order
                _restaurantController.HandoutOrder(deliverer, order);
                break;
            case 7:
                return;
        }
    }
}