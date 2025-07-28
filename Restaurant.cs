namespace Arriba_eat;

public class Restaurant : User
{
    private string restaurantType;

    public Restaurant(string name, string email, string password, string location, string restaurantType)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.restaurantType = restaurantType;
    }
}