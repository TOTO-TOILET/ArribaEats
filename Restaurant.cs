namespace Arriba_eat;

public class Restaurant : User
{
    private string restaurantType;
    public Dictionary<string, double> menuItems;
    public List<Order> orders;  

    public Restaurant(string name, string email, string password, string location, string restaurantType)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.restaurantType = restaurantType;
        this.location = location;
        orders = new List<Order>();
        menuItems = new Dictionary<string, double>();
    }
}