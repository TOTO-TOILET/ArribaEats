using System.Data;

namespace Arriba_eat;
public enum RestaurantStyle
{
    Japanese = 1,
    Chinese,
    French,
    Italian,
    Austraian
}

public class AuthManager
{
    private UserController _controller;

    public AuthManager(UserController controller)
    {
        _controller = controller;
    }
    
    public User Login()
    {
        Console.WriteLine("Enter email address");
        string email = Console.ReadLine();
        
        Console.WriteLine("Enter password");
        string password = Console.ReadLine();
        
        foreach (var user in _controller.GetUsers())
        {
            if (user.email == email && user.password == password)
            {
                return user;
            }
        }

        Console.WriteLine("Email or password is incorrect");
        return null;
    }
    
    public void Register()
    {
        Console.WriteLine("Enter name");
        string name = Console.ReadLine();

        Console.WriteLine("Enter email address");
        string email = Console.ReadLine();

        Console.WriteLine("Enter password");
        string password = Console.ReadLine();

        User newUser = null; //initialise a new user

        while (true)
        {
            Console.WriteLine("Select user type:");
            Console.WriteLine("1.Customer");
            Console.WriteLine("2.Restaurant");
            Console.WriteLine("3.Deliverer");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Please enter a valid number");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter your location in the form of x,y");
                    string customerLocation = Console.ReadLine();

                    newUser = new Customer(name, email, password, customerLocation);
                    break;

                case 2:
                    Console.WriteLine("Enter your location in the form of x,y");
                    string restaurantLocation = Console.ReadLine();

                    int restaurantStyleChoice;
                    RestaurantStyle selectedStyle;
                    while (true)
                    {
                        Console.WriteLine("Select restaurant type:");
                        foreach (var style in Enum.GetValues(typeof(RestaurantStyle)))
                        {
                            Console.WriteLine($"{(int)style}. {style}");
                        }

                        string styleInput = Console.ReadLine();
                        if (int.TryParse(styleInput, out restaurantStyleChoice) && Enum.IsDefined(typeof(RestaurantStyle), restaurantStyleChoice))
                        {
                            selectedStyle = (RestaurantStyle)restaurantStyleChoice;
                            break;
                        }

                        Console.WriteLine("Please enter a valid number");
                    }

                    newUser = new Restaurant(name, email, password, restaurantLocation, selectedStyle.ToString()); 
                    break;

                case 3:
                    Console.WriteLine("Enter your licence plate number");
                    string licencePlate = Console.ReadLine();

                    newUser = new Deliverer(name, email, password, licencePlate);
                    break;
            }

            break;
        }

        if (newUser != null)
        {
            _controller.AddUser(newUser);
            Console.WriteLine($"Welcome to Arriba eats {newUser.name}!!");
        }
    }
    
     
}